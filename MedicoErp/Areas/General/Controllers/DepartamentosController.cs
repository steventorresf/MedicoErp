using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.General.Business;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicoErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class DepartamentosController : ControllerBase
    {
        private readonly DepartamentosBusiness BusinessDpto = new DepartamentosBusiness();

        [HttpGet]
        public IActionResult GetDepartamentos()
        {
            try
            {
                var lista = BusinessDpto.GetDepartamentos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetDepartamentos", ex.Message, null);
                throw;
            }
        }
    }
}