using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Common;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.General;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Business.General
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly IMenuUsuarioBusiness menuUsuarioBusiness;
        private readonly MedicoErpContext context;

        public UsuarioBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness, IMenuUsuarioBusiness _menuUsuarioBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
            this.menuUsuarioBusiness = _menuUsuarioBusiness;
        }


        public Cookie PostLogin(Login data)
        {
            try
            {
                Cookie dataCookies = new Cookie();
                if (data != null && !string.IsNullOrEmpty(data.NomUsu) && !string.IsNullOrEmpty(data.Clave))
                {
                    string Clave = Util.EncriptarMD5(data.Clave);

                    Usuario entity = context.Usuario.FirstOrDefault(x => x.NomUsuario.Equals(data.NomUsu) && x.Clave.Equals(Clave));
                    if (entity != null)
                    {
                        if (entity.CodEstado.Equals(Constantes.EstadoActivo))
                        {
                            dataCookies.Respuesta = "TodoOkey";
                            dataCookies.IdUsuario = entity.IdUsuario;
                            dataCookies.NombreUsuario = entity.NomUsuario;
                            dataCookies.NombreCompleto = entity.NombreCompleto;
                            dataCookies.CodSexo = entity.CodSexo;
                            dataCookies.IdCentro = entity.IdCentro;
                            dataCookies.Avatar = entity.Avatar;
                            dataCookies.Menu = menuUsuarioBusiness.GetMenuByIdUsuario(entity.IdUsuario);
                        }
                        else { dataCookies.Respuesta = "Usuario Inactivo."; }
                    }
                    else { dataCookies.Respuesta = "Usuario y/o Contraseña Incorrecta."; }
                }
                else { dataCookies.Respuesta = "Hacker"; }

                return dataCookies;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetByUsuario", ex, null);
                throw;
            }
        }

        public List<Usuario> GetUsuarios(int IdCentro)
        {
            try
            {
                List<Usuario> Lista = (from us in context.Usuario.Where(x=>x.IdCentro == IdCentro)
                                       join es in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabEstados)) on us.CodEstado equals es.CodValor
                                       select new Usuario()
                                       {
                                           IdUsuario = us.IdUsuario,
                                           TipoIden = us.TipoIden,
                                           NumIden = us.NumIden,
                                           DocIdentidad = us.TipoIden + " " + us.NumIden,
                                           NombreCompleto = us.NombreCompleto,
                                           CodSexo = us.CodSexo,
                                           Direccion = us.Direccion,
                                           Telefono = us.Telefono,
                                           FechaNacimiento = us.FechaNacimiento,
                                           NomUsuario = us.NomUsuario,
                                           EsMedico = us.EsMedico,
                                           Especialidad = us.Especialidad,
                                           Registro = us.Registro,
                                           CodEstado = us.CodEstado,
                                           IdCentro = us.IdCentro,
                                           Avatar = us.Avatar,
                                           NombreEstado = es.Descripcion,
                                           EsMedicoDesc = us.EsMedico ? "Si" : "No",
                                           CreadoPor = us.CreadoPor,
                                           FechaCreado = us.FechaCreado,
                                           ModificadoPor = us.ModificadoPor,
                                           FechaModificado = us.FechaModificado,
                                           Clave = "-",
                                           sFechaNacimiento = us.FechaNacimiento.ToString("MM/dd/yyyy"),
                                       }).OrderBy(x => x.NombreCompleto).OrderBy(x => x.CodEstado).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetUsuarios", ex, null);
                throw;
            }
        }

        public string GetFilePdf(int IdUsuario)
        {
            try
            {
                Usuario entity = context.Usuario.Find(IdUsuario);
                return entity.FilePdf;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetFilePdf", ex, null);
                throw;
            }
        }

        public void SetFilePdf(int IdUsuario, string Pdf)
        {
            try
            {
                Usuario entity = context.Usuario.Find(IdUsuario);
                entity.FilePdf = Pdf;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetFilePdf", ex, null);
                throw;
            }
        }

        public List<Usuario> GetMedicos(int IdCentro)
        {
            try
            {
                List<Usuario> Lista = context.Usuario.Where(x => x.IdCentro == IdCentro && x.EsMedico && x.CodEstado.Equals(Constantes.EstadoActivo)).OrderBy(x => x.NombreCompleto).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetMedicos", ex, null);
                throw;
            }
        }

        public void Create(Usuario entity)
        {
            try
            {
                using(var tran = context.Database.BeginTransaction())
                {
                    entity.FechaCreado = DateTimeOffset.Now;
                    context.Usuario.Add(entity);
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateUsuario", ex, null);
                throw;
            }
        }

        public void Update(int IdUsuario, Usuario entity)
        {
            try
            {
                Usuario obUsu = context.Usuario.Find(IdUsuario);
                obUsu.TipoIden = entity.TipoIden;
                obUsu.NumIden = entity.NumIden;
                obUsu.NombreCompleto = entity.NombreCompleto;
                obUsu.CodSexo = entity.CodSexo;
                obUsu.Direccion = entity.Direccion;
                obUsu.Telefono = entity.Telefono;
                obUsu.EsMedico = entity.EsMedico;
                obUsu.FechaNacimiento = entity.FechaNacimiento;
                obUsu.Especialidad = entity.Especialidad;
                obUsu.Registro = entity.Registro;
                obUsu.Avatar = entity.Avatar;
                obUsu.CodEstado = entity.CodEstado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateUsuario", ex, null);
                throw;
            }
        }

        public void Activar(int IdUsuario)
        {
            try
            {
                Usuario obUsu = context.Usuario.Find(IdUsuario);
                obUsu.CodEstado = Constantes.EstadoActivo;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("ActivarUsuario", ex, null);
                throw;
            }
        }

        public void Inactivar(int IdUsuario)
        {
            try
            {
                Usuario obUsu = context.Usuario.Find(IdUsuario);
                obUsu.CodEstado = Constantes.EstadoInactivo;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("InactivarUsuario", ex, null);
                throw;
            }
        }

        public void ResetearClave(int IdUsuario)
        {
            try
            {
                Usuario obUsu = context.Usuario.Find(IdUsuario);
                obUsu.Clave = Util.EncriptarMD5(Constantes.ClavePredeterminada);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("ResetearClaveUsuario", ex, null);
                throw;
            }
        }

        public int UpdateContraseña(JObject data)
        {
            try
            {
                int Resp = 1;
                int IdUsuario = data["idUsuario"].ToObject<int>();
                string ClaveActual = data["claveActual"].ToObject<string>();
                string ClaveNueva = data["claveNueva"].ToObject<string>();
                string ClaveConfirmar = data["claveConfirmar"].ToObject<string>();
                string ModificadoPor = data["modificadoPor"].ToObject<string>();

                Usuario entity = context.Usuario.Find(IdUsuario);
                if (entity.Clave.Equals(Util.EncriptarMD5(ClaveActual)))
                {
                    if (Util.EncriptarMD5(ClaveNueva).Equals(Util.EncriptarMD5(ClaveConfirmar)))
                    {
                        entity.Clave = Util.EncriptarMD5(ClaveNueva);
                        entity.ModificadoPor = ModificadoPor;
                        entity.FechaModificado = DateTimeOffset.Now;
                        context.SaveChanges();
                    }
                    else { Resp = -2; }
                }
                else { Resp = -1; }

                return Resp;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateContraseña", ex, null);
                throw;
            }
        }
    }
}
