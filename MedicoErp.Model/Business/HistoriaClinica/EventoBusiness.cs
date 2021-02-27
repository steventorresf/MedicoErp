using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.Admision;
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
    public class EventoBusiness : IEventoBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public EventoBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public long AtenderCita(long IdCita, string CreadoPor)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    Cita entityCit = context.Cita.Find(IdCita);
                    if (entityCit.IdEvento == null)
                    {
                        CentroAtencion obCentro = context.CentroAtencion.Find(entityCit.IdCentro);
                        obCentro.NoEvento++;
                        context.SaveChanges();

                        Paciente entityPac = context.Paciente.Find(entityCit.IdPaciente);

                        Evento entityEve = new Evento();
                        entityEve.NoEvento = obCentro.NoEvento;
                        entityEve.TipoEvento = "C";
                        entityEve.FechaEvento = DateTimeOffset.Now;
                        entityEve.IdCentro = entityCit.IdCentro;
                        entityEve.IdPaciente = entityCit.IdPaciente;
                        entityEve.IdMedico = entityCit.IdMedico;
                        entityEve.TipoIden = entityPac.TipoIden;
                        entityEve.NumIden = entityPac.NumIden;
                        entityEve.NombreAcomp = entityCit.NombreAcomp;
                        entityEve.TelefonoAcomp = entityCit.TelefonoAcomp;
                        entityEve.IdContrato = entityCit.IdConvenio;
                        entityEve.CodEstado = Constantes.EstadoPendiente;
                        entityEve.FechaCreado = DateTimeOffset.Now;
                        entityEve.CreadoPor = CreadoPor;
                        context.Evento.Add(entityEve);
                        context.SaveChanges();

                        entityEve = context.Evento.FirstOrDefault(x => x.NoEvento == entityEve.NoEvento && x.IdCentro == entityEve.IdCentro);

                        entityCit.IdEvento = entityEve.IdEvento;
                        context.SaveChanges();
                    }

                    tran.Commit();

                    return Convert.ToInt64(entityCit.IdEvento);
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("AtenderCita", ex, null);
                throw;
            }
        }

        public Evento GetByIdEvento(long IdEvento)
        {
            try
            {
                Evento entity = (from ev in context.Evento.Where(x => x.IdEvento == IdEvento)
                                  join pa in context.Paciente on ev.IdPaciente equals pa.IdPaciente
                                  join co in context.Convenio on ev.IdContrato equals co.IdConvenio
                                  join me in context.Usuario on ev.IdMedico equals me.IdUsuario
                                  join ce in context.CentroAtencion on ev.IdCentro equals ce.IdCentro
                                  join tu in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabTipoUsuario)) on co.CodTipoUsuario equals tu.CodValor
                                  join ec in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabEstadosCivil)) on pa.CodEstadoCivil equals ec.CodValor
                                  select new Evento()
                                  {
                                      IdEvento = ev.IdEvento,
                                      TipoEvento = ev.TipoEvento,
                                      TipoIden = ev.TipoIden,
                                      CodCausaExt = ev.CodCausaExt,
                                      CodDiagPal = ev.CodDiagPal,
                                      CodDiagRel1 = ev.CodDiagRel1,
                                      CodDiagRel2 = ev.CodDiagRel2,
                                      CodDiagRel3 = ev.CodDiagRel3,
                                      CodEstado = ev.CodEstado,
                                      CodFinalCons = ev.CodFinalCons,
                                      CreadoPor = ev.CreadoPor,
                                      FechaCreado = ev.FechaCreado,
                                      FechaEvento = ev.FechaEvento,
                                      sFechaEvento = ev.FechaEvento.ToString("dd/MM/yyyy"),
                                      FechaFinalizado = ev.FechaFinalizado,
                                      FechaModificado = ev.FechaModificado,
                                      FinalizadoPor = ev.FinalizadoPor,
                                      IdCentro = ev.IdCentro,
                                      IdContrato = ev.IdContrato,
                                      IdPaciente = ev.IdPaciente,
                                      TipoUsuario = tu.Descripcion,
                                      EstadoCivil = ec.Descripcion,
                                      NombreAcomp = ev.NombreAcomp,
                                      TelefonoAcomp = ev.TelefonoAcomp,
                                      ModificadoPor = ev.ModificadoPor,
                                      NoEvento = ev.NoEvento,
                                      NumIden = ev.NumIden,
                                      TipoDiag = ev.TipoDiag,
                                      Evolucion = ev.Evolucion,
                                      BiopsiaAnterior = ev.BiopsiaAnterior,
                                      AyudasDiagnosticas = ev.AyudasDiagnosticas,
                                      Anexos = ev.Anexos,
                                      sFechaNacimiento = pa.FechaNacimiento.ToString("dd/MM/yyyy"),
                                      Convenio = co,
                                      Paciente = pa,
                                      Medico = me,
                                      Centro = ce,
                                      DiagnosticoPal = null,
                                      DiagnosticoRel1 = null,
                                      Firma = Util.GetFirmaMedico(me.NomUsuario),
                                  }).FirstOrDefault();

                if (!string.IsNullOrEmpty(entity.CodDiagPal))
                {
                    entity.DiagnosticoPal = context.Diagnostico.Find(entity.CodDiagPal);
                }

                if (!string.IsNullOrEmpty(entity.CodDiagRel1))
                {
                    entity.DiagnosticoRel1 = context.Diagnostico.Find(entity.CodDiagRel1);
                }
                return entity;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetByIdEvento", ex, null);
                throw;
            }
        }

        public List<Evento> GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                List<Evento> Lista = (from ev in context.Evento.Where(x => x.IdPaciente == IdPaciente && !x.CodEstado.Equals(Constantes.EstadoInactivo))
                                       join me in context.Usuario on ev.IdMedico equals me.IdUsuario
                                       join co in context.Convenio on ev.IdContrato equals co.IdConvenio
                                       select new Evento()
                                       {
                                           IdEvento = ev.IdEvento,
                                           CodEstado = ev.CodEstado,
                                           FechaEvento = ev.FechaEvento,
                                           CreadoPor = ev.CreadoPor,
                                           FechaCreado = ev.FechaCreado,
                                           FechaModificado = ev.FechaModificado,
                                           ModificadoPor = ev.ModificadoPor,
                                           NoEvento = ev.NoEvento,
                                           Medico = me,
                                           Convenio = co,
                                           sFechaEvento = ev.FechaEvento.ToString("dd/MM/yyyy hh:mm tt", new CultureInfo("en-US"))
                                       }).OrderByDescending(x => x.FechaEvento).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllByIdPaciente", ex, null);
                throw;
            }
        }

        public void Update(long IdEvento, string Campo, string Dato, string NombreUsuario)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    Evento entity = context.Evento.Find(IdEvento);
                    switch (Campo)
                    {
                        case Constantes.CamEvolucion: entity.Evolucion = Dato; break;
                        case Constantes.CamBiopsia: entity.BiopsiaAnterior = Dato; break;
                        case Constantes.CamAyudaDx: entity.AyudasDiagnosticas = Dato; break;
                        case Constantes.CamAnexos: entity.Anexos = Dato; break;
                        case Constantes.CamDiagPal: entity.CodDiagPal = Dato; break;
                        case Constantes.CamDiagRel: entity.CodDiagRel1 = Dato; break;
                    }
                    entity.ModificadoPor = NombreUsuario;
                    entity.FechaModificado = DateTimeOffset.Now;
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateEvento", ex, null);
                throw;
            }
        }

        public void FinalizarEvento(long IdEvento, string NombreUsuario)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    Evento entity = context.Evento.Find(IdEvento);
                    entity.CodEstado = Constantes.EstadoFinalizado;
                    entity.FinalizadoPor = NombreUsuario;
                    entity.FechaFinalizado = DateTimeOffset.Now;
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("FinalizarEvento", ex, null);
                throw;
            }
        }
    }
}
