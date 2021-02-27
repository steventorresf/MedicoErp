using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Areas.HistoriaClinica.Entities;
using MedicoErp.Models;
using MedicoErp.Utiles;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.HistoriaClinica.Business
{
    public class OrdenesBusiness
    {
        public List<Ordenes> GetAllByIdEvento(long IdEvento)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Ordenes> Lista = (from ord in context.Ordenes.Where(x => x.IdEvento == IdEvento && x.CodEstado.Equals(Constantes.EstadoActivo))
                                       select new Ordenes()
                                       {
                                           IdOrden = ord.IdOrden,
                                           IdEvento = ord.IdEvento,
                                           CodEstado = ord.CodEstado,
                                           FechaOrden = ord.FechaOrden,
                                           CreadoPor = ord.CreadoPor,
                                           FechaCreado = ord.FechaCreado,
                                           FechaModificado = ord.FechaModificado,
                                           ModificadoPor = ord.ModificadoPor,
                                           NoOrden = ord.NoOrden,
                                           sFechaOrden = ord.FechaOrden.ToString("dd/MM/yyyy")
                                       }).OrderByDescending(x => x.FechaOrden).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetAllOrdenesByIdEvento", ex.Message, null);
                throw;
            }
        }

        public List<Ordenes> GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Ordenes> Lista = (from ev in context.Eventos.Where(x => x.IdPaciente == IdPaciente)
                                       join or in context.Ordenes on ev.IdEvento equals or.IdEvento
                                       join me in context.Usuarios on or.IdMedico equals me.IdUsuario
                                       join co in context.Convenios on ev.IdContrato equals co.IdConvenio
                                       where !or.CodEstado.Equals(Constantes.EstadoInactivo) && !ev.CodEstado.Equals(Constantes.EstadoInactivo)
                                       select new Ordenes()
                                       {
                                           IdOrden = or.IdOrden,
                                           IdEvento = or.IdEvento,
                                           CodEstado = or.CodEstado,
                                           FechaOrden = or.FechaOrden,
                                           CreadoPor = or.CreadoPor,
                                           FechaCreado = or.FechaCreado,
                                           FechaModificado = or.FechaModificado,
                                           ModificadoPor = or.ModificadoPor,
                                           NoOrden = or.NoOrden,
                                           NombreMedico = me.NombreCompleto,
                                           NombreConvenio = co.NombreConvenio,
                                           sFechaOrden = or.FechaOrden.ToString("dd/MM/yyyy hh:mm tt", new CultureInfo("en-US"))
                                       }).OrderByDescending(x => x.FechaOrden).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetAllByIdPaciente", ex.Message, null);
                throw;
            }
        }

        public void Create(Ordenes entity, int IdCentro)
        {
            try
            {
                BaseContext context = new BaseContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    CentroAtencion entityCen = context.CentrosAtencions.Find(IdCentro);
                    entityCen.NoOrden++;
                    context.SaveChanges();

                    entity.NoOrden = entityCen.NoOrden;
                    entity.FechaOrden = DateTime.Now;
                    entity.FechaCreado = DateTimeOffset.Now;

                    context.Ordenes.Add(entity);
                    context.SaveChanges();

                    Ordenes obOrd = context.Ordenes.FirstOrDefault(x => x.NoOrden == entity.NoOrden && x.IdEvento == entity.IdEvento);
                    List<OrdenesDetalleTemp> listDetalleTemp = context.OrdenesDetalleTemp.Where(x => x.IdUsuario == entity.IdMedico).ToList();

                    List<OrdenesDetalle> listDetalle = new List<OrdenesDetalle>();
                    foreach (OrdenesDetalleTemp tmp in listDetalleTemp)
                    {
                        OrdenesDetalle entityDet = new OrdenesDetalle();
                        entityDet.IdOrden = obOrd.IdOrden;
                        entityDet.IdServicio = tmp.IdServicio;
                        entityDet.Cantidad = tmp.Cantidad;
                        entityDet.CreadoPor = entity.CreadoPor;
                        entityDet.FechaCreado = DateTimeOffset.Now;
                        listDetalle.Add(entityDet);
                    }

                    context.OrdenesDetalle.AddRange(listDetalle);
                    context.SaveChanges();

                    context.OrdenesDetalleTemp.RemoveRange(listDetalleTemp);
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("OrdenCreate", ex.Message, null);
                throw;
            }
        }

        public Ordenes GetOrdenImp(long IdOrden)
        {
            try
            {
                BaseContext context = new BaseContext();
                Ordenes entity = (from or in context.Ordenes.Where(x => x.IdOrden == IdOrden)
                                  join ev in context.Eventos on or.IdEvento equals ev.IdEvento
                                  join pa in context.Pacientes on ev.IdPaciente equals pa.IdPaciente
                                  join ce in context.CentrosAtencions on ev.IdCentro equals ce.IdCentro
                                  join co in context.Convenios on ev.IdContrato equals co.IdConvenio
                                  join me in context.Usuarios on or.IdMedico equals me.IdUsuario
                                  join tu in context.TablasDetalles.Where(x => x.CodTabla.Equals(Constantes.TabTipoUsuario)) on co.CodTipoUsuario equals tu.CodValor
                                  select new Ordenes()
                                  {
                                      IdOrden = or.IdOrden,
                                      NoOrden = or.NoOrden,
                                      Centro = ce,
                                      Paciente = pa,
                                      Convenio = co,
                                      TipoUsuario = tu.Descripcion,
                                      sFechaNacimiento = pa.FechaNacimiento.ToString("dd/MM/yyyy"),
                                      sFechaOrden = or.FechaOrden.ToString("dd/MM/yyyy"),
                                      CreadoPor = or.CreadoPor,
                                      IdMedico = or.IdMedico,
                                      Medico = me,
                                      Observaciones = or.Observaciones,
                                      Firma = Util.GetFirmaMedico(me.NomUsuario),
                                  }).FirstOrDefault();

                entity.ListOrdenDetalle = (from od in context.OrdenesDetalle.Where(x => x.IdOrden == IdOrden)
                                           join se in context.Servicios on od.IdServicio equals se.IdServicio
                                           select new OrdenesDetalle()
                                           {
                                               IdDetalle = od.IdDetalle,
                                               IdOrden = od.IdOrden,
                                               IdServicio = od.IdServicio,
                                               Cantidad = od.Cantidad,
                                               Servicio = se,
                                               FechaCreado = od.FechaCreado,
                                               CreadoPor = od.CreadoPor,
                                           }).ToList();
                return entity;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetOrdenImp", ex.Message, null);
                throw;
            }
        }

    }
}
