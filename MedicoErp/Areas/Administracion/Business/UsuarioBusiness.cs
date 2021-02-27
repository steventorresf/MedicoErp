using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Models;
using MedicoErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.Administracion.Business
{
    public class UsuarioBusiness
    {
        private MenuUsuarioBusiness BusinessMenuUsu = new MenuUsuarioBusiness();

        public Cookies PostLogin(Login data)
        {
            try
            {
                Cookies dataCookies = new Cookies();
                if (data != null && !string.IsNullOrEmpty(data.NomUsu) && !string.IsNullOrEmpty(data.Clave))
                {
                    string Clave = Util.EncriptarMD5(data.Clave);

                    BaseContext context = new BaseContext();
                    Usuario entity = context.Usuarios.FirstOrDefault(x => x.NomUsuario.Equals(data.NomUsu) && x.Clave.Equals(Clave));
                    if (entity != null)
                    {
                        if (entity.CodEstado.Equals(Constantes.EstadoActivo))
                        {
                            CentroAtencion entityCen = context.CentrosAtencions.Find(entity.IdCentro);

                            dataCookies.Respuesta = "TodoOkey";
                            dataCookies.IdUsuario = entity.IdUsuario;
                            dataCookies.NombreUsuario = entity.NomUsuario;
                            dataCookies.NombreCompleto = entity.NombreCompleto;
                            dataCookies.CodSexo = entity.CodSexo;
                            dataCookies.IdCentro = entity.IdCentro;
                            dataCookies.NombreCentro = entityCen.NombreCentro;
                            dataCookies.Avatar = entity.Avatar;
                            dataCookies.Menu = BusinessMenuUsu.GetMenuByIdUsuario(entity.IdUsuario);
                        }
                        else { dataCookies.Respuesta = "Usuario Inactivo."; }
                    }
                    else { dataCookies.Respuesta = "Usuario y/o Contraseña Incorrecta."; }
                }
                else { dataCookies.Respuesta = "Hacker"; }
                
                return dataCookies;
            }
            catch(Exception ex)
            {
                ErroresBusiness.Create("GetByUsuario", ex.Message, null);
                throw;
            }
        }

        public List<Usuario> GetUsuarios(int IdCentro)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Usuario> Lista = (from us in context.Usuarios.Where(x => x.IdCentro == IdCentro)
                                        join es in context.TablasDetalles.Where(x => x.CodTabla.Equals(Constantes.TabEstados)) on us.CodEstado equals es.CodValor
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
                                            FechaIngreso = us.FechaIngreso,
                                            IdCentro = us.IdCentro,
                                            Avatar = us.Avatar,
                                            NombreEstado = es.Descripcion,
                                            EsMedicoDesc = us.EsMedico ? "Si" : "No",
                                            CreadoPor = us.CreadoPor,
                                            FechaCreado = us.FechaCreado,
                                            ModificadoPor = us.ModificadoPor,
                                            FechaModificado = us.FechaModificado,
                                            Clave = "-",
                                        }).OrderBy(x => x.NombreCompleto).OrderBy(x => x.CodEstado).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetUsuarios", ex.Message, null);
                throw;
            }
        }

        public string GetFilePdf(int IdUsuario)
        {
            try
            {
                BaseContext context = new BaseContext();
                Usuario entity = context.Usuarios.Find(IdUsuario);
                return entity.FilePdf;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetFilePdf", ex.Message, null);
                throw;
            }
        }

        public void SetFilePdf(int IdUsuario, string Pdf)
        {
            try
            {
                BaseContext context = new BaseContext();
                Usuario entity = context.Usuarios.Find(IdUsuario);
                entity.FilePdf = Pdf;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetFilePdf", ex.Message, null);
                throw;
            }
        }

        public List<Usuario> GetMedicos(int IdCentro)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Usuario> Lista = context.Usuarios.Where(x => x.IdCentro == IdCentro && x.EsMedico && x.CodEstado.Equals(Constantes.EstadoActivo)).OrderBy(x => x.NombreCompleto).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetMedicos", ex.Message, null);
                throw;
            }
        }

        public void Create(Usuario entity)
        {
            try
            {
                entity.FechaIngreso = DateTimeOffset.Now;
                entity.Especialidad = entity.Especialidad.Equals(".") ? "" : entity.Especialidad;
                entity.Registro = entity.Registro.Equals(".") ? "" : entity.Registro;

                BaseContext context = new BaseContext();
                context.Usuarios.Add(entity);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                ErroresBusiness.Create("CreateUsuario", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdUsuario, Usuario entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                Usuario obUsu = context.Usuarios.Find(IdUsuario);
                obUsu.TipoIden = entity.TipoIden;
                obUsu.NumIden = entity.NumIden;
                obUsu.NombreCompleto = entity.NombreCompleto;
                obUsu.CodSexo = entity.CodSexo;
                obUsu.Direccion = entity.Direccion;
                obUsu.Telefono = entity.Telefono;
                obUsu.EsMedico = entity.EsMedico;
                obUsu.FechaNacimiento = entity.FechaNacimiento;
                obUsu.Especialidad = string.IsNullOrEmpty(entity.Especialidad) ? "" : entity.Especialidad;
                obUsu.Registro = string.IsNullOrEmpty(entity.Registro) ? "" : entity.Registro;
                obUsu.Avatar = entity.Avatar;
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                ErroresBusiness.Create("UpdateUsuario", ex.Message, null);
                throw;
            }
        }

        public void Activar(int IdUsuario)
        {
            try
            {
                BaseContext context = new BaseContext();
                Usuario obUsu = context.Usuarios.Find(IdUsuario);
                obUsu.CodEstado = Constantes.EstadoActivo;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ActivarUsuario", ex.Message, null);
                throw;
            }
        }

        public void Inactivar(int IdUsuario)
        {
            try
            {
                BaseContext context = new BaseContext();
                Usuario obUsu = context.Usuarios.Find(IdUsuario);
                obUsu.CodEstado = Constantes.EstadoInactivo;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("InactivarUsuario", ex.Message, null);
                throw;
            }
        }

        public void ResetearClave(int IdUsuario)
        {
            try
            {
                BaseContext context = new BaseContext();
                Usuario obUsu = context.Usuarios.Find(IdUsuario);
                obUsu.Clave = Util.EncriptarMD5(Constantes.ClavePredeterminada);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ResetearClaveUsuario", ex.Message, null);
                throw;
            }
        }

    }
}
