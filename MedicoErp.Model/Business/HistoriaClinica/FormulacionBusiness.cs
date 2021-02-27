using MedicoErp.Model.Abstract.General;
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
    public class FormulacionBusiness : IFormulacionBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public FormulacionBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public List<Formulacion> GetAllByIdEvento(long IdEvento)
        {
            try
            {
                List<Formulacion> Lista = (from fr in context.Formulacion.Where(x => x.IdEvento == IdEvento && x.CodEstado.Equals(Constantes.EstadoActivo))
                                             select new Formulacion()
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
                errorBusiness.Create("GetFormulasAllByIdEvento", ex, null);
                throw;
            }
        }

        public List<Formulacion> GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                List<Formulacion> Lista = (from ev in context.Evento.Where(x => x.IdPaciente == IdPaciente)
                                             join fr in context.Formulacion on ev.IdEvento equals fr.IdEvento
                                             join me in context.Usuario on fr.IdMedico equals me.IdUsuario
                                             join co in context.Convenio on ev.IdContrato equals co.IdConvenio
                                             where !fr.CodEstado.Equals(Constantes.EstadoInactivo) && !ev.CodEstado.Equals(Constantes.EstadoInactivo)
                                             select new Formulacion()
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
                errorBusiness.Create("GetAllByIdPaciente", ex, null);
                throw;
            }
        }

        public void Create(Formulacion entity, int IdCentro)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    CentroAtencion entityCen = context.CentroAtencion.Find(IdCentro);
                    entityCen.NoFormulacion++;
                    context.SaveChanges();

                    entity.NoFormulacion = entityCen.NoFormulacion;
                    entity.FechaCreado = DateTimeOffset.Now;
                    entity.FechaFormulacion = DateTimeOffset.Now;

                    context.Formulacion.Add(entity);
                    context.SaveChanges();

                    Formulacion obFor = context.Formulacion.FirstOrDefault(x => x.NoFormulacion == entity.NoFormulacion && x.IdEvento == entity.IdEvento);
                    List<FormulacionDetalleTemp> listDetalleTemp = context.FormulacionDetalleTemp.Where(x => x.IdUsuario == entity.IdMedico).ToList();

                    List<FormulacionDetalle> listDetalle = new List<FormulacionDetalle>();
                    foreach (FormulacionDetalleTemp tmp in listDetalleTemp)
                    {
                        FormulacionDetalle entityDet = new FormulacionDetalle();
                        entityDet.IdFormulacion = obFor.IdFormulacion;
                        entityDet.Medicamento = tmp.Medicamento;
                        entityDet.CodViaAdmon = tmp.CodViaAdmon;
                        entityDet.Posologia = tmp.Posologia;
                        entityDet.Valor = tmp.Valor;
                        entityDet.Cantidad = tmp.Cantidad;
                        entityDet.CreadoPor = entity.CreadoPor;
                        entityDet.FechaCreado = DateTimeOffset.Now;
                        listDetalle.Add(entityDet);
                    }

                    context.FormulacionDetalle.AddRange(listDetalle);
                    context.SaveChanges();

                    context.FormulacionDetalleTemp.RemoveRange(listDetalleTemp);
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("FormulacionCreate", ex, null);
                throw;
            }
        }

        public Formulacion GetFormulacionImp(long IdFormulacion)
        {
            try
            {
                Formulacion entity = (from fr in context.Formulacion.Where(x => x.IdFormulacion == IdFormulacion)
                                        join ev in context.Evento on fr.IdEvento equals ev.IdEvento
                                        join pa in context.Paciente on ev.IdPaciente equals pa.IdPaciente
                                        join ce in context.CentroAtencion on ev.IdCentro equals ce.IdCentro
                                        join co in context.Convenio on ev.IdContrato equals co.IdConvenio
                                        join me in context.Usuario on fr.IdMedico equals me.IdUsuario
                                        join tu in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabTipoUsuario)) on co.CodTipoUsuario equals tu.CodValor
                                        select new Formulacion()
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

                entity.ListFormulacionDetalle = (from fd in context.FormulacionDetalle.Where(x => x.IdFormulacion == IdFormulacion)
                                                 join va in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabViasAdmon)) on fd.CodViaAdmon equals va.CodValor
                                                 select new FormulacionDetalle()
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
                errorBusiness.Create("GetFormulacionImp", ex, null);
                throw;
            }
        }
    }
}
