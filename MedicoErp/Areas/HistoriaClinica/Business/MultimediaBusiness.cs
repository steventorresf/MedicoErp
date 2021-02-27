using MedicoErp.Areas.Administracion.Business;
using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Areas.HistoriaClinica.Entities;
using MedicoErp.Models;
using MedicoErp.Utiles;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Areas.HistoriaClinica.Business
{
    public class MultimediaBusiness
    {
        private UsuarioBusiness BusinessUsu = new UsuarioBusiness();

        public List<Multimedia> GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Multimedia> Lista = (from mu in context.Multimedia.Where(x => x.IdPaciente == IdPaciente)
                                          select new Multimedia()
                                          {
                                              IdMultimedia = mu.IdMultimedia,
                                              IdCentro = mu.IdCentro,
                                              IdPaciente = mu.IdPaciente,
                                              NombreArchivo = mu.NombreArchivo,
                                              NombreRuta = mu.NombreRuta,
                                              FechaCreado = mu.FechaCreado,
                                              CreadoPor = mu.CreadoPor,
                                              sFechaCreacion = mu.FechaCreado.ToString("dd/MM/yyyy hh:mm tt", new CultureInfo("en-US"))
                                          }).OrderByDescending(x => x.FechaCreado).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetAllByIdPaciente", ex.Message, null);
                throw;
            }
        }

        public string GetBase64PdfByIdMultimedia(int IdMultimedia)
        {
            try
            {
                BaseContext context = new BaseContext();
                Multimedia entity = context.Multimedia.Find(IdMultimedia);

                FileStream file = File.OpenRead(Parametros.RutaMultimedia + entity.IdCentro + "//" + entity.NombreRuta);
                byte[] vs = new byte[file.Length];
                file.Read(vs, 0, vs.Length);
                file.Close();

                return Convert.ToBase64String(vs);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetBase64Pdf", ex.Message, null);
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
                    BusinessUsu.SetFilePdf(IdUsuario, pdf);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("MultimediaPdfVistaPrevia", ex.Message, null);
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

                BaseContext context = new BaseContext();
                using(var tran = context.Database.BeginTransaction())
                {
                    Multimedia entityMul = new Multimedia();
                    entityMul.IdCentro = IdCentro;
                    entityMul.IdPaciente = entityPac.IdPaciente;
                    entityMul.NombreArchivo = NombreArch;
                    entityMul.NombreRuta = NombreRuta;
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
                ErroresBusiness.Create("MultimediaPdfReal", ex.Message, null);
                throw;
            }
        }
    }
}
