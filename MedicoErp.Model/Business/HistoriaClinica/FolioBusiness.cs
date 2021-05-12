using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.General;
using MedicoErp.Model.Entities.HistoriaClinica;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MedicoErp.Model.Business.HistoriaClinica
{
    public class FolioBusiness : IFolioBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public FolioBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public List<Folio> GetAllByIdEvento(long IdEvento)
        {
            try
            {
                List<Folio> Lista = (from fo in context.Folio.Where(x => x.IdEvento == IdEvento && !x.CodEstado.Equals(Constantes.EstadoAnulado))
                                     join form in context.Formato on fo.IdFormato equals form.IdFormato
                                     select new Folio()
                                     {
                                         IdFolio = fo.IdFolio,
                                         IdCentro = fo.IdCentro,
                                         IdEvento = fo.IdEvento,
                                         IdFormato = fo.IdFormato,
                                         NoFolio = fo.NoFolio,
                                         CodEstado = fo.CodEstado,
                                         FechaFolio = fo.FechaFolio,
                                         CreadoPor = fo.CreadoPor,
                                         FechaCreado = fo.FechaCreado,
                                         FechaModificado = fo.FechaModificado,
                                         ModificadoPor = fo.ModificadoPor,
                                         sFechaFolio = fo.FechaFolio.ToString("dd/MM/yyyy", new CultureInfo("en-US")),
                                         Formato = form,
                                     }).OrderByDescending(x => x.FechaFolio).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetFoliosAllByIdEvento", ex, null);
                throw;
            }
        }

        public List<Folio> GetAllByIdPaciente(long IdPaciente, int IdCentro)
        {
            try
            {
                List<Folio> Lista = (from ev in context.Evento.Where(x => x.IdPaciente == IdPaciente && x.IdCentro == IdCentro && !x.CodEstado.Equals(Constantes.EstadoAnulado))
                                     join fo in context.Folio on ev.IdEvento equals fo.IdEvento
                                     join fm in context.Formato on fo.IdFormato equals fm.IdFormato
                                     join me in context.Usuario on ev.IdMedico equals me.IdUsuario
                                     join co in context.Convenio on ev.IdConvenio equals co.IdConvenio
                                     where !fo.CodEstado.Equals(Constantes.EstadoAnulado)
                                     select new Folio()
                                     {
                                         IdFolio = fo.IdFolio,
                                         IdCentro = fo.IdCentro,
                                         IdEvento = fo.IdEvento,
                                         IdFormato = fo.IdFormato,
                                         NoFolio = fo.NoFolio,
                                         CodEstado = fo.CodEstado,
                                         FechaFolio = fo.FechaFolio,
                                         CreadoPor = fo.CreadoPor,
                                         FechaCreado = fo.FechaCreado,
                                         FechaModificado = fo.FechaModificado,
                                         ModificadoPor = fo.ModificadoPor,
                                         sFechaFolio = fo.FechaFolio.ToString("dd/MM/yyyy", new CultureInfo("en-US")),
                                         Formato = fm,
                                         Evento = ev,
                                         NombreMedico = me.NombreCompleto,
                                         NombreConvenio = co.NombreConvenio,
                                     }).OrderByDescending(x => x.FechaFolio).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetFoliosAllByIdEvento", ex, null);
                throw;
            }
        }

        public long Create(Folio entity)
        {
            try
            {
                using(var tran = context.Database.BeginTransaction())
                {
                    Secuencia entitySec = context.Secuencia.FirstOrDefault(x => x.IdCentro == entity.IdCentro && x.TipoDoc.Equals("FO"));
                    entitySec.NumDoc++;
                    context.SaveChanges();

                    entity.NoFolio = entitySec.NumDoc;
                    entity.FechaFolio = DateTimeOffset.Now;
                    entity.FechaCreado = DateTimeOffset.Now;
                    context.Folio.Add(entity);
                    context.SaveChanges();

                    Folio entityFol = context.Folio.FirstOrDefault(x => x.NoFolio == entity.NoFolio && x.IdCentro == entity.IdCentro);

                    List<FolioDetalle> ListaDetalle = (from ar in context.Area.Where(x => x.IdFormato == entityFol.IdFormato && x.CodEstado.Equals(Constantes.EstadoActivo))
                                                       join pr in context.Pregunta on ar.IdArea equals pr.IdArea
                                                       where pr.CodEstado.Equals(Constantes.EstadoActivo)
                                                       select new FolioDetalle()
                                                       {
                                                           IdDetalle = 0,
                                                           IdFolio = entityFol.IdFolio,
                                                           IdPregunta = pr.IdPregunta,
                                                           TipoDato = pr.TipoDato,
                                                           IdTipoRespuesta = pr.IdTipoRespuesta,
                                                           Valor = pr.RespPredeterminada,
                                                           Respuesta = pr.RespPredeterminada,
                                                           CreadoPor = entityFol.CreadoPor,
                                                           FechaCreado = DateTimeOffset.Now,
                                                       }).ToList();
                    
                    context.FolioDetalle.AddRange(ListaDetalle);
                    context.SaveChanges();

                    tran.Commit();

                    return entityFol.IdFolio;
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateFolio", ex, null);
                throw;
            }
        }

        public int Anular(JObject data)
        {
            try
            {
                long IdFolio = data["idFolio"].ToObject<long>();
                string ModificadoPor = data["modificadoPor"].ToObject<string>();

                Folio entity = context.Folio.FirstOrDefault(x => x.IdFolio == IdFolio);
                entity.CodEstado = Constantes.EstadoAnulado;
                entity.ModificadoPor = ModificadoPor;
                entity.FechaModificado = DateTimeOffset.Now;
                context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("FolioAnular", ex, null);
                throw;
            }
        }

        public Folio GetAllByIdFolio(long IdFolio)
        {
            try
            {
                Folio entityFol = context.Folio.FirstOrDefault(x => x.IdFolio == IdFolio);
                entityFol.Formato = context.Formato.Find(entityFol.IdFormato);

                var Lista = (from fd in context.FolioDetalle.Where(x => x.IdFolio == entityFol.IdFolio)
                             join pr in context.Pregunta on fd.IdPregunta equals pr.IdPregunta
                             join ar in context.Area on pr.IdArea equals ar.IdArea
                             select new
                             {
                                 ar.IdArea,
                                 ar.NombreArea,
                                 OrdenArea = ar.Orden,
                                 ar.Visible,
                                 fd.IdDetalle,
                                 pr.IdPregunta,
                                 pr.NombrePregunta,
                                 OrdePregunta = pr.Orden,
                                 fd.TipoDato,
                                 fd.IdTipoRespuesta,
                                 fd.Valor,
                                 fd.Respuesta,
                                 pr.EsRequerido,
                                 pr.CodEstado,
                                 fd.CreadoPor,
                                 fd.FechaCreado,
                             })
                             .GroupBy(x => new { x.IdArea, x.NombreArea, x.OrdenArea, x.Visible })
                             .Select(a => new
                             {
                                 a.Key.IdArea,
                                 a.Key.NombreArea,
                                 a.Key.OrdenArea,
                                 a.Key.Visible,
                                 ListaDet = a.OrderBy(p => p.OrdePregunta)
                             }).ToList();

                List<Area> ListaAreas = new List<Area>();
                foreach (var a in Lista)
                {
                    Area entityAr = new Area();
                    entityAr.IdArea = a.IdArea;
                    entityAr.NombreArea = a.NombreArea;
                    entityAr.Orden = a.OrdenArea;
                    entityAr.Visible = a.Visible;
                    entityAr.ListaPreguntas = new List<Pregunta>();

                    foreach (var p in a.ListaDet)
                    {
                        Pregunta entityPr = new Pregunta();
                        entityPr.IdDetalle = p.IdDetalle;
                        entityPr.IdPregunta = p.IdPregunta;
                        entityPr.NombrePregunta = p.NombrePregunta;
                        entityPr.Orden = p.OrdePregunta;
                        entityPr.TipoDato = p.TipoDato;
                        entityPr.IdTipoRespuesta = p.IdTipoRespuesta;
                        entityPr.Valor = p.Valor;
                        entityPr.Respuesta = p.Respuesta;
                        entityPr.CodEstado = p.CodEstado;
                        entityPr.CreadoPor = p.CreadoPor;
                        entityPr.EsRequerido = p.EsRequerido;
                        entityPr.FechaCreado = p.FechaCreado;

                        if (p.IdTipoRespuesta != null && p.IdTipoRespuesta > 0 && p.TipoDato.Equals("CO"))
                        {
                            entityPr.ListaTipoRespuesta = context.TipoRespuestaDetalle.Where(x => x.IdTipoRespuesta == entityPr.IdTipoRespuesta).ToList();
                        }

                        entityAr.ListaPreguntas.Add(entityPr);
                    }

                    ListaAreas.Add(entityAr);
                }

                entityFol.ListaAreas = ListaAreas;

                return entityFol;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllByIdFolio", ex, null);
                throw;
            }
        }
    }
}
