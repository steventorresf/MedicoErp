using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.Admision;
using MedicoErp.Model.Entities.General;
using MedicoErp.Model.Entities.HistoriaClinica;
using Newtonsoft.Json.Linq;
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
                        Secuencia entitySec = context.Secuencia.FirstOrDefault(x => x.IdCentro == entityCit.IdCentro && x.TipoDoc.Equals("EV"));
                        entitySec.NumDoc++;
                        context.SaveChanges();

                        Paciente entityPac = context.Paciente.Find(entityCit.IdPaciente);

                        Evento entityEve = new Evento();
                        entityEve.NoEvento = entitySec.NumDoc;
                        entityEve.TipoEvento = "C";
                        entityEve.FechaEvento = DateTimeOffset.Now;
                        entityEve.IdCentro = entityCit.IdCentro;
                        entityEve.IdPaciente = entityCit.IdPaciente;
                        entityEve.IdMedico = entityCit.IdMedico;
                        entityEve.TipoIden = entityPac.TipoIden;
                        entityEve.NumIden = entityPac.NumIden;
                        entityEve.NombreAcomp = entityCit.NombreAcomp;
                        entityEve.TelefonoAcomp = entityCit.TelefonoAcomp;
                        entityEve.IdConvenio = entityCit.IdConvenio;
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

        public void CreateExt(Evento entity)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    Secuencia entitySec = context.Secuencia.FirstOrDefault(x => x.IdCentro == entity.IdCentro && x.TipoDoc.Equals("EV"));
                    entitySec.NumDoc++;
                    context.SaveChanges();

                    entity.NoEvento = entitySec.NumDoc;
                    entity.FechaEvento = DateTimeOffset.Now;
                    entity.FechaCreado = DateTimeOffset.Now;
                    context.Evento.Add(entity);
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateExt", ex, null);
                throw;
            }
        }

        public int Anular(JObject data)
        {
            try
            {
                long IdEvento = data["idEvento"].ToObject<long>();
                string ModificadoPor = data["modificadoPor"].ToObject<string>();

                Evento entity = context.Evento.FirstOrDefault(x => x.IdEvento == IdEvento);
                entity.CodEstado = Constantes.EstadoAnulado;
                entity.ModificadoPor = ModificadoPor;
                entity.FechaModificado = DateTimeOffset.Now;
                context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("EventoAnular", ex, null);
                throw;
            }
        }

        public Evento GetByIdEvento(long IdEvento)
        {
            try
            {
                Evento entity = (from ev in context.Evento.Where(x => x.IdEvento == IdEvento)
                                  join pa in context.Paciente on ev.IdPaciente equals pa.IdPaciente
                                  join co in context.Convenio on ev.IdConvenio equals co.IdConvenio
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
                                      IdConvenio = ev.IdConvenio,
                                      IdPaciente = ev.IdPaciente,
                                      TipoUsuario = tu.Descripcion,
                                      EstadoCivil = ec.Descripcion,
                                      NombreAcomp = ev.NombreAcomp,
                                      TelefonoAcomp = ev.TelefonoAcomp,
                                      ModificadoPor = ev.ModificadoPor,
                                      NoEvento = ev.NoEvento,
                                      NumIden = ev.NumIden,
                                      TipoDiag = ev.TipoDiag,
                                      sFechaNacimiento = pa.FechaNacimiento.ToString("dd/MM/yyyy"),
                                      Convenio = co,
                                      Paciente = pa,
                                      Medico = me,
                                      Centro = ce,
                                      DiagnosticoPal = null,
                                      DiagnosticoRel1 = null,
                                      DiagnosticoRel2 = null,
                                      DiagnosticoRel3 = null,
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

                if (!string.IsNullOrEmpty(entity.CodDiagRel2))
                {
                    entity.DiagnosticoRel2 = context.Diagnostico.Find(entity.CodDiagRel2);
                }

                if (!string.IsNullOrEmpty(entity.CodDiagRel3))
                {
                    entity.DiagnosticoRel3 = context.Diagnostico.Find(entity.CodDiagRel3);
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
                List<Evento> Lista = (from ev in context.Evento.Where(x => x.IdPaciente == IdPaciente && !x.CodEstado.Equals(Constantes.EstadoAnulado))
                                      join me in context.Usuario on ev.IdMedico equals me.IdUsuario
                                      join co in context.Convenio on ev.IdConvenio equals co.IdConvenio
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
                                          TipoEvento = ev.TipoEvento,
                                          Medico = me,
                                          Convenio = co,
                                          sFechaEvento = ev.FechaEvento.ToString("dd/MM/yyyy hh:mm tt", new CultureInfo("en-US")),
                                          DescripcionEvento = ev.NoEvento + " - " + ev.FechaEvento.ToString("dd/MM/yyyy") + " - " + co.NombreConvenio,
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
                        case Constantes.CamDiagPal: entity.CodDiagPal = Dato; break;
                        case Constantes.CamDiagRel1: entity.CodDiagRel1 = Dato; break;
                        case Constantes.CamDiagRel2: entity.CodDiagRel2 = Dato; break;
                        case Constantes.CamDiagRel3: entity.CodDiagRel3 = Dato; break;
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

        public Evento GetEventoImpresion(long IdEvento, long IdFolio)
        {
            try
            {
                Evento entity = GetByIdEvento(IdEvento);
                if (IdFolio > 0)
                {
                    entity.ListaFolios = (from fo in context.Folio.Where(x => x.IdFolio == IdFolio && x.IdEvento == IdEvento)
                                          join fm in context.Formato on fo.IdFormato equals fm.IdFormato
                                          select new Folio()
                                          {
                                              IdFolio = fo.IdFolio,
                                              NoFolio = fo.NoFolio,
                                              FechaFolio = fo.FechaFolio,
                                              sFechaFolio = fo.FechaFolio.ToString("dd/MM/yyyy"),
                                              CreadoPor = fo.CreadoPor,
                                              Formato = fm,
                                          }).OrderBy(x => x.Formato.Orden).ToList();
                }
                else
                {
                    entity.ListaFolios = (from fo in context.Folio.Where(x => x.IdEvento == IdEvento)
                                          join fm in context.Formato on fo.IdFormato equals fm.IdFormato
                                          select new Folio()
                                          {
                                              IdFolio = fo.IdFolio,
                                              NoFolio = fo.NoFolio,
                                              FechaFolio = fo.FechaFolio,
                                              sFechaFolio = fo.FechaFolio.ToString("dd/MM/yyyy"),
                                              CreadoPor = fo.CreadoPor,
                                              Formato = fm,
                                          }).OrderBy(x => x.Formato.Orden).ToList();
                }
                
                foreach(Folio fo in entity.ListaFolios)
                {
                    var Lista = (from fd in context.FolioDetalle.Where(x => x.IdFolio == fo.IdFolio && !string.IsNullOrEmpty(x.Respuesta))
                                 join pr in context.Pregunta on fd.IdPregunta equals pr.IdPregunta
                                 join ar in context.Area on pr.IdArea equals ar.IdArea
                                 select new
                                 {
                                     ar.IdArea,
                                     ar.NombreArea,
                                     OrdenArea = ar.Orden,
                                     ar.Visible,
                                     pr.IdPregunta,
                                     pr.NombrePregunta,
                                     OrdenPregunta = pr.Orden,
                                     fd.Respuesta,
                                 })
                                 .GroupBy(x => new { x.IdArea, x.NombreArea, x.OrdenArea, x.Visible })
                                 .Select(a => new
                                 {
                                     a.Key.IdArea,
                                     a.Key.NombreArea,
                                     a.Key.OrdenArea,
                                     a.Key.Visible,
                                     ListaDetalle = a.OrderBy(p => p.OrdenPregunta),
                                 }).ToList();

                    fo.ListaAreas = new List<Area>();
                    foreach(var a in Lista)
                    {
                        Area entityAr = new Area();
                        entityAr.IdArea = a.IdArea;
                        entityAr.NombreArea = a.NombreArea;
                        entityAr.Orden = a.OrdenArea;
                        entityAr.Visible = a.Visible;
                        entityAr.ListaPreguntas = new List<Pregunta>();

                        foreach(var p in a.ListaDetalle)
                        {
                            Pregunta entityPr = new Pregunta();
                            entityPr.IdPregunta = p.IdPregunta;
                            entityPr.NombrePregunta = p.NombrePregunta;
                            entityPr.Respuesta = p.Respuesta;
                            entityAr.ListaPreguntas.Add(entityPr);
                        }

                        fo.ListaAreas.Add(entityAr);
                    }                    
                }

                return entity;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetEventoImpresion", ex, null);
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
