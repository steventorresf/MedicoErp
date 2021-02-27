using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.General.Business;
using MedicoErp.Areas.General.Entities;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicoErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class MenuUsuarioController : ControllerBase
    {
        private readonly MenuUsuarioBusiness BusinessUsuMen = new MenuUsuarioBusiness();

        [HttpGet("GetMenu/{IdUsu}")]
        public IActionResult GetMenuByIdUsuario(int IdUsu)
        {
            try
            {
                string menu = BusinessUsuMen.GetMenuByIdUsuario(IdUsu);
                return Ok(menu);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetMenuByIdUsuario", ex.Message, null);
                throw;
            }
        }

        [HttpGet("{IdUsu}")]
        public IActionResult GetAllByIdUsuario(int IdUsu)
        {
            try
            {
                var lista = BusinessUsuMen.GetAllByIdUsuario(IdUsu);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetAllByIdUsuario", ex.Message, null);
                throw;
            }
        }

        [HttpGet("Not/{IdUsu}")]
        public IActionResult GetNotAllByIdUsuario(int IdUsu)
        {
            try
            {
                var lista = BusinessUsuMen.GetNotAllByIdUsuario(IdUsu);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetNotAllByIdUsuario", ex.Message, null);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] MenuUsuario entity)
        {
            try
            {
                BusinessUsuMen.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerMenuUsuarioCreate", ex.Message, null);
                throw;
            }
        }

        [HttpDelete("{IdMenuUsu}")]
        public IActionResult Delete(int IdMenuUsu)
        {
            try
            {
                BusinessUsuMen.Delete(IdMenuUsu);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerMenuUsuarioDelete", ex.Message, null);
                throw;
            }
        }
    }
}