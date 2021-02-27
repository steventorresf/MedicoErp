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
    public class FormulacionesBusiness
    {
        public List<Formulaciones> GetAllByIdEvento(long IdEvento)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Formulaciones> Lista = (from fr in context.Formulaciones.Where(x => x.IdEvento == IdEvento && x.CodEstado.Equals(Constantes.EstadoActivo))
                                             select new Formulaciones()
                                             {
                                                 IdFormulacion = fr.IdFormulacion,
                                                 IdEvento = fr.IdEvento,
                                                 NoFormulacion = fr.NoFormulacion,
                                                 CodEstado = fr.CodEstado,
                                                 FechaFormulacion = fr.FechaFormulacion,
                                                 CreadoPor = fr.CreadoPor,
                                                 FechaCreado = fr.FechaCreado,
                                                 FechaModificado = fr.FechaModificado,
                                                 ModificadoPor = fr.ModificadoPor,
                                                 sFechaFormulacion = fr.FechaFormulacion.ToString("dd/MM/yyyy", new CultureInfo("en-US"))
                                             }).OrderByDescending(x => x.FechaFormulacion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetFormulasAllByIdEvento", ex.Message, null);
                throw;
            }
        }

        public List<Formulaciones> GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Formulaciones> Lista = (from ev in context.Eventos.Where(x => x.IdPaciente == IdPaciente)
                                             join fr in context.Formulaciones on ev.IdEvento equals fr.IdEvento
                                             join me in context.Usuarios on fr.IdMedico equals me.IdUsuario
                                             join co in context.Convenios on ev.IdContrato equals co.IdConvenio
                                             where !fr.CodEstado.Equals(Constantes.EstadoInactivo) && !ev.CodEstado.Equals(Constantes.EstadoInactivo)
                                             select new Formulaciones()
                                             {
                                                 IdFormulacion = fr.IdFormulacion,
                                                 IdEvento = fr.IdEvento,
                                                 CodEstado = fr.CodEstado,
                                                 FechaFormulacion = fr.FechaFormulacion,
                                                 CreadoPor = fr.CreadoPor,
                                                 FechaCreado = fr.FechaCreado,
                                                 FechaModificado = fr.FechaModificado,
                                                 ModificadoPor = fr.ModificadoPor,
                                                 NoFormulacion = fr.NoFormulacion,
                                                 NombreMedico = me.NombreCompleto,
                                                 NombreConvenio = co.NombreConvenio,
                                                 sFechaFormulacion = fr.FechaFormulacion.ToString("dd/MM/yyyy hh:mm tt", new CultureInfo("en-US"))
                                             }).OrderByDescending(x => x.FechaFormulacion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetAllByIdPaciente", ex.Message, null);
                throw;
            }
        }

        public void Create(Formulaciones entity, int IdCentro)
        {
            try
            {
                BaseContext context = new BaseContext();
                using(var tran = context.Database.BeginTransaction())
                {
                    CentroAtencion entityCen = context.CentrosAtencions.Find(IdCentro);
                    entityCen.NoFormulacion++;
                    context.SaveChanges();

                    entity.NoFormulacion = entityCen.NoFormulacion;
                    entity.FechaCreado = DateTimeOffset.Now;
                    entity.FechaFormulacion = DateTimeOffset.Now;

                    context.Formulaciones.Add(entity);
                    context.SaveChanges();

                    Formulaciones obFor = context.Formulaciones.FirstOrDefault(x => x.NoFormulacion == entity.NoFormulacion && x.IdEvento == entity.IdEvento);
                    List<FormulacionesDetalleTemp> listDetalleTemp = context.FormulacionesDetalleTemp.Where(x => x.IdUsuario == entity.IdMedico).ToList();

                    List<FormulacionesDetalle> listDetalle = new List<FormulacionesDetalle>();
                    foreach (FormulacionesDetalleTemp tmp in listDetalleTemp)
                    {
                        FormulacionesDetalle entityDet = new FormulacionesDetalle();
                        entityDet.IdFormulacion = obFor.IdFormulacion;
                        entityDet.Medicamento = tmp.Medicamento;
                        entityDet.CodViaAdmon = tmp.CodViaAdmon;
                        entityDet.Posologia = tmp.Posologia;
                        entityDet.Valor = tmp.Valor;
                        entityDet.Cantidad = tmp.Cantidad;
                        entityDet.CreadoPor = entity.CreadoPor;
                        entity.FechaCreado = DateTimeOffset.Now;
                        listDetalle.Add(entityDet);
                    }

                    context.FormulacionesDetalle.AddRange(listDetalle);
                    context.SaveChanges();

                    context.FormulacionesDetalleTemp.RemoveRange(listDetalleTemp);
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("FormulacionCreate", ex.Message, null);
                throw;
            }
        }

        public Formulaciones GetFormulacionImp(long IdFormulacion)
        {
            try
            {
                BaseContext context = new BaseContext();
                Formulaciones entity = (from fr in context.Formulaciones.Where(x => x.IdFormulacion == IdFormulacion)
                                        join ev in context.Eventos on fr.IdEvento equals ev.IdEvento
                                        join pa in context.Pacientes on ev.IdPaciente equals pa.IdPaciente
                                        join ce in context.CentrosAtencions on ev.IdCentro equals ce.IdCentro
                                        join co in context.Convenios on ev.IdContrato equals co.IdConvenio
                                        join me in context.Usuarios on fr.IdMedico equals me.IdUsuario
                                        join tu in context.TablasDetalles.Where(x => x.CodTabla.Equals(Constantes.TabTipoUsuario)) on co.CodTipoUsuario equals tu.CodValor
                                        select new Formulaciones()
                                        {
                                            NoFormulacion = fr.NoFormulacion,
                                            Centro = ce,
                                            Paciente = pa,
                                            Convenio = co,
                                            Medico = me,
                                            NombreConvenio = co.NombreConvenio,
                                            sFechaNacimiento = pa.FechaNacimiento.ToString("dd/MM/yyyy"),
                                            sFechaFormulacion = fr.FechaFormulacion.ToString("dd/MM/yyyy"),
                                            TipoUsuario = tu.Descripcion,
                                            CreadoPor = fr.CreadoPor,
                                            TiempoEvo = fr.TiempoEvo == null ? "" : fr.TiempoEvo,
                                            ProxControl = fr.ProxControl == null ? "" : fr.ProxControl,
                                            Firma = Util.GetFirmaMedico(me.NomUsuario),
                                        }).FirstOrDefault();

                entity.ListFormulacionDetalle = (from fd in context.FormulacionesDetalle.Where(x => x.IdFormulacion == IdFormulacion)
                                                 join va in context.TablasDetalles.Where(x => x.CodTabla.Equals(Constantes.TabViasAdmon)) on fd.CodViaAdmon equals va.CodValor
                                                 select new FormulacionesDetalle()
                                                 {
                                                     IdDetalle = fd.IdDetalle,
                                                     IdFormulacion = fd.IdFormulacion,
                                                     IdMedicamento = fd.IdMedicamento,
                                                     Medicamento = fd.Medicamento,
                                                     CodViaAdmon = fd.CodViaAdmon,
                                                     Cantidad = fd.Cantidad,
                                                     Posologia = fd.Posologia,
                                                     Valor = fd.Valor,
                                                     FechaCreado = fd.FechaCreado,
                                                     CreadoPor = fd.CreadoPor,
                                                     ViaAdmon = va.Descripcion,
                                                 }).ToList();
                return entity;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetFormulacionImp", ex.Message, null);
                throw;
            }
        }
    }
}
