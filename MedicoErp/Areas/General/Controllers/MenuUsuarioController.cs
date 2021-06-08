using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Model.Entities.General;
using MedicoErp.Model.Abstract.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicoErp.Model.Common;

namespace MedicoErp.Areas.General.Controllers
{
    [Route("General/api/[controller]")]
    [ApiController]
    public class MenuUsuarioController : ControllerBase
    {
        private readonly IMenuUsuarioBusiness menuUsuarioBusiness;

        public MenuUsuarioController(IMenuUsuarioBusiness _menuUsuarioBusiness)
        {
            menuUsuarioBusiness = _menuUsuarioBusiness;
        }


        [HttpGet("GetMenu/{IdUsu}")]
        public IActionResult GetMenuByIdUsuario(int IdUsu)
        {
            try
            {
                string menu = menuUsuarioBusiness.GetMenuByIdUsuario(IdUsu);
                return Ok(menu);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{IdUsu}")]
        public IActionResult GetAllByIdUsuario(int IdUsu)
        {
            try
            {
                var lista = menuUsuarioBusiness.GetAllByIdUsuario(IdUsu);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("Not/{IdUsu}")]
        public IActionResult GetNotAllByIdUsuario(int IdUsu)
        {
            try
            {
                var lista = menuUsuarioBusiness.GetNotAllByIdUsuario(IdUsu);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] MenuUsuario entity)
        {
            try
            {
                menuUsuarioBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("Creates")]
        public IActionResult Creates([FromBody] List<MenuUsuario> lista)
        {
            try
            {
                menuUsuarioBusiness.Creates(lista);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{IdMenuUsu}")]
        public IActionResult Delete(int IdMenuUsu)
        {
            try
            {
                menuUsuarioBusiness.Delete(IdMenuUsu);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}