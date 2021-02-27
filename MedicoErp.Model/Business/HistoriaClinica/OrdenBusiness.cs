﻿using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.General;
using MedicoErp.Model.Entities.HistoriaClinica;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Business.HistoriaClinica
{
    public class OrdenBusiness : IOrdenBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public OrdenBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public List<Orden> GetAllByIdEvento(long IdEvento)
        {
            try
            {
                List<Orden> Lista = (from ord in context.Orden.Where(x => x.IdEvento == IdEvento && x.CodEstado.Equals(Constantes.EstadoActivo))
                                       select new Orden()
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
                errorBusiness.Create("GetAllOrdenesByIdEvento", ex, null);
                throw;
            }
        }

        public List<Orden> GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                List<Orden> Lista = (from ev in context.Evento.Where(x => x.IdPaciente == IdPaciente)
                                       join or in context.Orden on ev.IdEvento equals or.IdEvento
                                       join me in context.Usuario on or.IdMedico equals me.IdUsuario
                                       join co in context.Convenio on ev.IdContrato equals co.IdConvenio
                                       where !or.CodEstado.Equals(Constantes.EstadoInactivo) && !ev.CodEstado.Equals(Constantes.EstadoInactivo)
                                       select new Orden()
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
                errorBusiness.Create("GetAllByIdPaciente", ex, null);
                throw;
            }
        }

        public void Create(Orden entity, int IdCentro)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    CentroAtencion entityCen = context.CentroAtencion.Find(IdCentro);
                    entityCen.NoOrden++;
                    context.SaveChanges();

                    entity.NoOrden = entityCen.NoOrden;
                    entity.FechaOrden = DateTime.Now;
                    entity.FechaCreado = DateTimeOffset.Now;

                    context.Orden.Add(entity);
                    context.SaveChanges();

                    Orden obOrd = context.Orden.FirstOrDefault(x => x.NoOrden == entity.NoOrden && x.IdEvento == entity.IdEvento);
                    List<OrdenDetalleTemp> listDetalleTemp = context.OrdenDetalleTemp.Where(x => x.IdUsuario == entity.IdMedico).ToList();

                    List<OrdenDetalle> listDetalle = new List<OrdenDetalle>();
                    foreach (OrdenDetalleTemp tmp in listDetalleTemp)
                    {
                        OrdenDetalle entityDet = new OrdenDetalle();
                        entityDet.IdOrden = obOrd.IdOrden;
                        entityDet.IdServicio = tmp.IdServicio;
                        entityDet.Cantidad = tmp.Cantidad;
                        entityDet.CreadoPor = entity.CreadoPor;
                        entityDet.FechaCreado = DateTimeOffset.Now;
                        listDetalle.Add(entityDet);
                    }

                    context.OrdenDetalle.AddRange(listDetalle);
                    context.SaveChanges();

                    context.OrdenDetalleTemp.RemoveRange(listDetalleTemp);
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("OrdenCreate", ex, null);
                throw;
            }
        }

        public Orden GetOrdenImp(long IdOrden)
        {
            try
            {
                Orden entity = (from or in context.Orden.Where(x => x.IdOrden == IdOrden)
                                  join ev in context.Evento on or.IdEvento equals ev.IdEvento
                                  join pa in context.Paciente on ev.IdPaciente equals pa.IdPaciente
                                  join ce in context.CentroAtencion on ev.IdCentro equals ce.IdCentro
                                  join co in context.Convenio on ev.IdContrato equals co.IdConvenio
                                  join me in context.Usuario on or.IdMedico equals me.IdUsuario
                                  join tu in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabTipoUsuario)) on co.CodTipoUsuario equals tu.CodValor
                                  select new Orden()
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

                entity.ListOrdenDetalle = (from od in context.OrdenDetalle.Where(x => x.IdOrden == IdOrden)
                                           join se in context.Servicio on od.IdServicio equals se.IdServicio
                                           select new OrdenDetalle()
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
                errorBusiness.Create("GetOrdenImp", ex, null);
                throw;
            }
        }
    }
}