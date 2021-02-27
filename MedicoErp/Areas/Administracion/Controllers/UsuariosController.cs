using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.Administracion.Business;
using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MedicoErp.Areas.Administracion.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Administracion)]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioBusiness BusinessUsu = new UsuarioBusiness();

        [HttpPost("Login")]
        public IActionResult PostLogin([FromBody] Login data)
        {
            try
            {
                var entity = BusinessUsu.PostLogin(data);
                if (entity.Respuesta.Equals("TodoOkey"))
                {
                    HttpContext.Session.SetString("IdUsu", entity.IdUsuario.ToString());
                    HttpContext.Session.SetString("NomUsu", entity.NombreUsuario);
                    HttpContext.Session.SetString("NombreUsu", entity.NombreCompleto);
                    HttpContext.Session.SetString("CodSexo", entity.CodSexo);
                    HttpContext.Session.SetString("IdCentro", entity.IdCentro.ToString());
                    HttpContext.Session.SetString("NombreCentro", entity.NombreCentro);
                    HttpContext.Session.SetString("Avatar", entity.Avatar);
                }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("PostLoginController", ex.Message, null);
                throw;
            }
        }


        [HttpGet("{IdCentro}")]
        public IActionResult Get(int IdCentro)
        {
            try
            {
                var lista = BusinessUsu.GetUsuarios(IdCentro);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetUsuarios", ex.Message, null);
                throw;
            }
        }

        [HttpGet("Med/{IdCentro}")]
        public IActionResult GetMedicos(int IdCentro)
        {
            try
            {
                var lista = BusinessUsu.GetMedicos(IdCentro);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetMedicos", ex.Message, null);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario entity)
        {
            try
            {
                BusinessUsu.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPostUsuario", ex.Message, null);
                throw;
            }
        }

        [HttpPut("{IdUsuario}")]
        public IActionResult Put(int IdUsuario, [FromBody] Usuario entity)
        {
            try
            {
                BusinessUsu.Update(IdUsuario, entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPutUsuario", ex.Message, null);
                throw;
            }
        }

        [HttpPut("Inact/{IdUsuario}")]
        public IActionResult PutInactivar(int IdUsuario)
        {
            try
            {
                BusinessUsu.Inactivar(IdUsuario);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPutInactivarUsuario", ex.Message, null);
                throw;
            }
        }

        [HttpPut("Act/{IdUsuario}")]
        public IActionResult PutActivar(int IdUsuario)
        {
            try
            {
                BusinessUsu.Activar(IdUsuario);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPutActivarUsuario", ex.Message, null);
                throw;
            }
        }

        [HttpPut("RClave/{IdUsuario}")]
        public IActionResult PutResetClave(int IdUsuario)
        {
            try
            {
                BusinessUsu.ResetearClave(IdUsuario);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPutResetClaveUsuario", ex.Message, null);
                throw;
            }
        }


    }
}