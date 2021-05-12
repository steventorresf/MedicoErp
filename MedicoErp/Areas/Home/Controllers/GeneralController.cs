using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Model.Common;
using MedicoErp.Model.Entities.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MedicoErp.Areas.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        //private readonly UsuarioBusiness BusinessUsu = new UsuarioBusiness();

        [HttpPost("LogIn")]
        public IActionResult InicioSesion([FromBody] JObject data)
        {
            try
            {
                string Usu = data["Usu"].ToObject<string>();
                string Con = data["Con"].ToObject<string>();

                if(!string.IsNullOrEmpty(Usu) && !string.IsNullOrEmpty(Con))
                {
                    string Clave = Util.EncriptarMD5(Con);
                    Usuario obUsu = null;// BusinessUsu.GetByUsuario(Usu, Clave);
                    if (obUsu != null)
                    {
                        if (obUsu.CodEstado.Equals(Constantes.EstadoActivo))
                        {
                            HttpContext.Session.SetString("IdUsu", obUsu.IdUsuario.ToString());
                            HttpContext.Session.SetString("NomUsu", obUsu.NomUsuario);
                            HttpContext.Session.SetString("NombreUsu", obUsu.NombreCompleto);
                            HttpContext.Session.SetString("CodSexo", obUsu.CodSexo);
                            HttpContext.Session.SetString("IdCentro", obUsu.IdCentro.ToString());
                            HttpContext.Session.SetString("Imagen", "favicon.ico");

                            return Ok(new { resp = "TodoOkey" });
                        }
                        else { return Ok(new { resp = "Usuario Inactivo." }); }
                    }
                    else { return Ok(new { resp = "Usuario y/o Contraseña Incorrecta." }); }
                }
                else { return Ok(new { resp = "Hacker" }); }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetCookies")]
        public IActionResult GetCookies()
        {
            try
            {
                JObject data = new JObject();
                data.Add("IdUsu", Convert.ToInt32(HttpContext.Session.GetString("IdUsu")));
                data.Add("NombreUsu", HttpContext.Session.GetString("NomUsu"));
                data.Add("NombreUsuario", HttpContext.Session.GetString("NombreUsu"));
                data.Add("CodSexo", HttpContext.Session.GetString("CodSexo"));
                data.Add("Imagen", HttpContext.Session.GetString("Imagen"));
                data.Add("IdCentro", HttpContext.Session.GetString("IdCentro"));

                return Ok(new { resp = true, esValido = true, obCookies = data });
            }
            catch (Exception ex)
            {
                return Ok(new { resp = false });
            }
        }

        [HttpPost("LogOut")]
        public IActionResult CierreSesion([FromBody] JObject data)
        {
            try
            {
                HttpContext.Session.Clear();
                return Ok(new { resp = true });
            }
            catch (Exception ex)
            {
                return Ok(new { resp = false });
            }
        }


    }
}