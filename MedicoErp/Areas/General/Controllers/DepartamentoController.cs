using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicoErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoBusiness departamentoBusiness;

        public DepartamentoController(IDepartamentoBusiness _departamentoBusiness)
        {
            departamentoBusiness = _departamentoBusiness;
        }

        [HttpGet]
        public IActionResult GetDepartamentos()
        {
            try
            {
                var lista = departamentoBusiness.GetDepartamentos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}