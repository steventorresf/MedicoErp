using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.Admision;
using MedicoErp.Model.Entities.HistoriaClinica;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Business.HistoriaClinica
{
    public class MultimediaBusiness : IMultimediaBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly IUsuarioBusiness usuarioBusiness;
        private readonly MedicoErpContext context;

        public MultimediaBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness, IUsuarioBusiness _usuarioBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
            this.usuarioBusiness = _usuarioBusiness;
        }


        public List<Multimedia> GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                List<Multimedia> Lista = (from mu in context.Multimedia.Where(x => x.IdPaciente == IdPaciente)
                                          join ev in context.Evento on mu.IdEvento equals ev.IdEvento into LeftJoinEvento
                                          from LFEv in LeftJoinEvento.DefaultIfEmpty()
                                          select new Multimedia()
                                          {
                                              IdMultimedia = mu.IdMultimedia,
                                              IdCentro = mu.IdCentro,
                                              IdPaciente = mu.IdPaciente,
                                              NombreArchivo = mu.NombreArchivo,
                                              NombreRuta = mu.NombreRuta,
                                              Extension = mu.Extension,
                                              FechaCreado = mu.FechaCreado,
                                              CreadoPor = mu.CreadoPor,
                                              sFechaCreacion = mu.FechaCreado.ToString("dd/MM/yyyy hh:mm tt", new CultureInfo("en-US")),
                                              NoEvento = LFEv != null ? LFEv.NoEvento.ToString() : "",
                                          }).OrderByDescending(x => x.FechaCreado).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllByIdPaciente", ex, null);
                throw;
            }
        }

        public Multimedia GetBase64ArchivoByIdMultimedia(int IdMultimedia)
        {
            try
            {
                Multimedia entity = context.Multimedia.Find(IdMultimedia);

                FileStream file = File.OpenRead(Parametros.RutaMultimedia + entity.IdCentro + "//" + entity.NombreRuta);
                byte[] vs = new byte[file.Length];
                file.Read(vs, 0, vs.Length);
                file.Close();

                entity.DataApp = Util.GetDataArchivo(entity.Extension) + Convert.ToBase64String(vs);

                return entity;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetBase64Pdf", ex, null);
                throw;
            }
        }

        public string GetBase64PdfByIdMultimedia(int IdMultimedia)
        {
            try
            {
                Multimedia entity = context.Multimedia.Find(IdMultimedia);

                FileStream file = File.OpenRead(Parametros.RutaMultimedia + entity.IdCentro + "//" + entity.NombreRuta);
                byte[] vs = new byte[file.Length];
                file.Read(vs, 0, vs.Length);
                file.Close();

                return Convert.ToBase64String(vs);
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetBase64Pdf", ex, null);
                throw;
            }
        }

        public bool MultimediaPdfVistaPrevia(JObject data)
        {
            try
            {
                string RutaArchivo = Parametros.RutaGeneral + data["nombreArch"].ToObject<string>();
                Paciente entityPac = data["entityPac"].ToObject<Paciente>();
                List<MultimediaTemporal> ListaImgs = data["listaImgs"].ToObject<List<MultimediaTemporal>>();
                int IdCentro = data["idCentro"].ToObject<int>();
                int IdUsuario = data["idUsuario"].ToObject<int>();
                string Obs = data["obs"].ToObject<string>();
                string NombreUsuario = data["nombreUsuario"].ToObject<string>();

                bool resp = Pdf.MultimediaPDF(RutaArchivo, entityPac, ListaImgs, IdCentro, IdUsuario, Obs);
                if (resp)
                {
                    FileStream file = File.OpenRead(RutaArchivo);
                    byte[] vs = new byte[file.Length];
                    file.Read(vs, 0, vs.Length);
                    file.Close();

                    string pdf = Convert.ToBase64String(vs);
                    usuarioBusiness.SetFilePdf(IdUsuario, pdf);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("MultimediaPdfVistaPrevia", ex, null);
                throw;
            }
        }

        public void MultimediaPdfReal(JObject data)
        {
            try
            {
                string NombreArch = data["nombreArch"].ToObject<string>();
                string NombreRuta = DateTimeOffset.Now.ToString("yyyyMMdd_HHmmss") + "_" + NombreArch;
                Paciente entityPac = data["entityPac"].ToObject<Paciente>();
                List<MultimediaTemporal> ListaImgs = data["listaImgs"].ToObject<List<MultimediaTemporal>>();
                int IdCentro = data["idCentro"].ToObject<int>();
                int IdUsuario = data["idUsuario"].ToObject<int>();
                string Obs = data["obs"].ToObject<string>();
                string NombreUsuario = data["nombreUsuario"].ToObject<string>();
                long? IdEvento = data["idEvento"].ToObject<long>();

                using (var tran = context.Database.BeginTransaction())
                {
                    Multimedia entityMul = new Multimedia();
                    entityMul.IdCentro = IdCentro;
                    entityMul.IdPaciente = entityPac.IdPaciente;
                    entityMul.IdEvento = IdEvento > 0 ? IdEvento : null;
                    entityMul.NombreArchivo = NombreArch;
                    entityMul.NombreRuta = NombreRuta;
                    entityMul.Extension = "pdf";
                    entityMul.Observaciones = Obs;
                    entityMul.FechaCreado = DateTimeOffset.Now;
                    entityMul.CreadoPor = NombreUsuario;
                    context.Multimedia.Add(entityMul);
                    context.SaveChanges();

                    string Directorio = Parametros.RutaMultimedia + IdCentro;
                    if (!Directory.Exists(Directorio))
                    {
                        Directory.CreateDirectory(Directorio);
                    }

                    string RutaArchivo = Directorio + "//" + NombreRuta;
                    bool resp = Pdf.MultimediaPDF(RutaArchivo, entityPac, ListaImgs, IdCentro, IdUsuario, Obs);
                    if (resp)
                    {
                        tran.Commit();
                    }
                    else { tran.Rollback(); }
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("MultimediaPdfReal", ex, null);
                throw;
            }
        }

        public void MultimediaSubirArch(Multimedia entity)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    if (entity.IdEvento <= 0)
                    {
                        entity.IdEvento = null;
                    }
                    entity.Extension = entity.NombreOriginal.Substring(entity.NombreOriginal.LastIndexOf(".") + 1);
                    entity.NombreArchivo += "." + entity.Extension;
                    entity.NombreRuta = DateTimeOffset.Now.ToString("yyyyMMdd_HHmmss") + "_" + entity.NombreArchivo;
                    entity.FechaCreado = DateTimeOffset.Now;
                    context.Multimedia.Add(entity);
                    context.SaveChanges();

                    string Directorio = Parametros.RutaMultimedia + entity.IdCentro;
                    if (!Directory.Exists(Directorio))
                    {
                        Directory.CreateDirectory(Directorio);
                    }

                    string FilePath = Directorio + "/" + entity.NombreRuta;
                    byte[] bytes = Convert.FromBase64String(entity.Archivo);
                    using (var imageFile = new FileStream(FilePath, FileMode.Create))
                    {
                        imageFile.Write(bytes, 0, bytes.Length);
                        imageFile.Flush();
                    }

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("MultimediaSubirArch", ex, null);
                throw;
            }
        }
    }
}
