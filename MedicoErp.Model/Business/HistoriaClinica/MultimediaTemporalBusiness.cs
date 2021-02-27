using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.HistoriaClinica;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Business.HistoriaClinica
{
    public class MultimediaTemporalBusiness : IMultimediaTemporalBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public MultimediaTemporalBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public List<MultimediaTemporal> GetAllTemporalesByIdUsuario(int IdUsuario)
        {
            try
            {
                List<MultimediaTemporal> Lista = context.MultimediaTemporal.Where(x => x.IdUsuario == IdUsuario).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllTemporalesByIdUsuario", ex, null);
                throw;
            }
        }

        public void SubirImagenTemporal(JObject data)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    int IdCentro = data["idCentro"].ToObject<int>();
                    int IdUsu = data["idUsu"].ToObject<int>();
                    int Orden = data["orden"].ToObject<int>();
                    string NombreImg = data["nombreImg"].ToObject<string>();
                    string Img = data["img"].ToObject<string>();

                    MultimediaTemporal entity = new MultimediaTemporal();
                    entity.IdUsuario = IdUsu;
                    entity.NombreImg = NombreImg;
                    entity.Orden = Orden;
                    context.MultimediaTemporal.Add(entity);
                    context.SaveChanges();

                    string Directorio = Parametros.RutaImagenesTemporales + IdCentro;
                    if (!Directory.Exists(Directorio))
                    {
                        Directory.CreateDirectory(Directorio);
                    }

                    string FilePath = string.Format(Directorio + "/{0}", IdUsu + "_" + NombreImg);
                    byte[] bytes = Convert.FromBase64String(Img);
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
                errorBusiness.Create("SubirImagen", ex, null);
                throw;
            }
        }

        public void DeleteAll(int IdUsuario, int IdCentro)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    List<MultimediaTemporal> Listado = context.MultimediaTemporal.Where(x => x.IdUsuario == IdUsuario).ToList();
                    context.MultimediaTemporal.RemoveRange(Listado);
                    context.SaveChanges();

                    foreach (MultimediaTemporal mul in Listado)
                    {
                        string FilePath = Parametros.RutaImagenesTemporales + IdCentro + "/" + IdUsuario + "_" + mul.NombreImg;
                        if (File.Exists(FilePath))
                        {
                            File.Delete(FilePath);
                        }
                    }

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("DeleteAllMultimediaTemporal", ex, null);
                throw;
            }
        }

        public void Delete(int IdDetalle, int IdCentro)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    MultimediaTemporal entity = context.MultimediaTemporal.Find(IdDetalle);
                    context.MultimediaTemporal.Remove(entity);
                    context.SaveChanges();

                    string FilePath = Parametros.RutaImagenesTemporales + IdCentro + "/" + entity.IdUsuario + "_" + entity.NombreImg;
                    if (File.Exists(FilePath))
                    {
                        File.Delete(FilePath);
                    }

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("DeleteMultimediaTemporal", ex, null);
                throw;
            }
        }
    }
}
