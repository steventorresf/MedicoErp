using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.Admision.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Areas.HistoriaClinica.Entities;
using MedicoErp.Models;
using MedicoErp.Utiles;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.HistoriaClinica.Business
{
    public class EventosBusiness
    {
        public long AtenderCita(long IdCita, string CreadoPor)
        {
            try
            {
                BaseContext context = new BaseContext();
                using(var tran = context.Database.BeginTransaction())
                {
                    Citas entityCit = context.Citas.Find(IdCita);
                    if(entityCit.IdEvento == null)
                    {
                        CentroAtencion obCentro = context.CentrosAtencions.Find(entityCit.IdCentro);
                        obCentro.NoEvento++;
                        context.SaveChanges();

                        Paciente entityPac = context.Pacientes.Find(entityCit.IdPaciente);

                        Eventos entityEve = new Eventos();
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
                        context.Eventos.Add(entityEve);
                        context.SaveChanges();

                        entityEve = context.Eventos.FirstOrDefault(x => x.NoEvento == entityEve.NoEvento && x.IdCentro == entityEve.IdCentro);

                        entityCit.IdEvento = entityEve.IdEvento;
                        context.SaveChanges();
                    }
                                        
                    tran.Commit();

                    return Convert.ToInt64(entityCit.IdEvento);
                }                
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("AtenderCita", ex.Message, null);
                throw;
            }
        }

        public Eventos GetByIdEvento(long IdEvento)
        {
            try
            {
                BaseContext context = new BaseContext();
                Eventos entity = (from ev in context.Eventos.Where(x => x.IdEvento == IdEvento)
                                  join pa in context.Pacientes on ev.IdPaciente equals pa.IdPaciente
                                  join co in context.Convenios on ev.IdContrato equals co.IdConvenio
                                  join me in context.Usuarios on ev.IdMedico equals me.IdUsuario
                                  join ce in context.CentrosAtencions on ev.IdCentro equals ce.IdCentro
                                  join tu in context.TablasDetalles.Where(x => x.CodTabla.Equals(Constantes.TabTipoUsuario)) on co.CodTipoUsuario equals tu.CodValor
                                  join ec in context.TablasDetalles.Where(x => x.CodTabla.Equals(Constantes.TabEstadosCivil)) on pa.CodEstadoCivil equals ec.CodValor
                                  select new Eventos()
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
                    entity.DiagnosticoPal = context.Diagnosticos.Find(entity.CodDiagPal);
                }

                if (!string.IsNullOrEmpty(entity.CodDiagRel1))
                {
                    entity.DiagnosticoRel1 = context.Diagnosticos.Find(entity.CodDiagRel1);
                }
                return entity;
            }
            catch(Exception ex)
            {
                ErroresBusiness.Create("GetByIdEvento", ex.Message, null);
                throw;
            }
        }

        public List<Eventos> GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Eventos> Lista = (from ev in context.Eventos.Where(x => x.IdPaciente == IdPaciente && !x.CodEstado.Equals(Constantes.EstadoInactivo))
                                      join me in context.Usuarios on ev.IdMedico equals me.IdUsuario
                                      join co in context.Convenios on ev.IdContrato equals co.IdConvenio
                                      select new Eventos()
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
                ErroresBusiness.Create("GetAllByIdPaciente", ex.Message, null);
                throw;
            }
        }

        public void Update(long IdEvento, string Campo, string Dato, string NombreUsuario)
        {
            try
            {
                BaseContext context = new BaseContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    Eventos entity = context.Eventos.Find(IdEvento);
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
                ErroresBusiness.Create("UpdateEvento", ex.Message, null);
                throw;
            }
        }

        public void FinalizarEvento(long IdEvento, string NombreUsuario)
        {
            try
            {
                BaseContext context = new BaseContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    Eventos entity = context.Eventos.Find(IdEvento);
                    entity.CodEstado = Constantes.EstadoFinalizado;
                    entity.FinalizadoPor = NombreUsuario;
                    entity.FechaFinalizado = DateTimeOffset.Now;
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("FinalizarEvento", ex.Message, null);
                throw;
            }
        }
    }
}
