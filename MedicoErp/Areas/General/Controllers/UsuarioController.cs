using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Common;
using MedicoErp.Model.Entities.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.General.Controllers
{
    [Route("General/api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBusiness usuarioBusiness;

        public UsuarioController(IUsuarioBusiness _usuarioBusiness)
        {
            this.usuarioBusiness = _usuarioBusiness;
        }

        [HttpPost("Login")]
        public IActionResult PostLogin([FromBody] Login data)
        {
            try
            {
                var entity = usuarioBusiness.PostLogin(data);
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
                throw;
            }
        }


        [HttpGet("{IdCentro}")]
        public IActionResult Get(int IdCentro)
        {
            try
            {
                var lista = usuarioBusiness.GetUsuarios(IdCentro);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("Med/{IdCentro}")]
        public IActionResult GetMedicos(int IdCentro)
        {
            try
            {
                var lista = usuarioBusiness.GetMedicos(IdCentro);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario entity)
        {
            try
            {
                usuarioBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdUsuario}")]
        public IActionResult Put(int IdUsuario, [FromBody] Usuario entity)
        {
            try
            {
                usuarioBusiness.Update(IdUsuario, entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("Inact/{IdUsuario}")]
        public IActionResult PutInactivar(int IdUsuario)
        {
            try
            {
                usuarioBusiness.Inactivar(IdUsuario);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("Act/{IdUsuario}")]
        public IActionResult PutActivar(int IdUsuario)
        {
            try
            {
                usuarioBusiness.Activar(IdUsuario);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("RClave/{IdUsuario}")]
        public IActionResult PutResetClave(int IdUsuario)
        {
            try
            {
                usuarioBusiness.ResetearClave(IdUsuario);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("UpClave")]
        public IActionResult UpdateContraseña([FromBody] JObject data)
        {
            try
            {
                int Resp = usuarioBusiness.UpdateContraseña(data);
                return Ok(Resp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
