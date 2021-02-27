using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.Administracion.Business;
using MedicoErp.Areas.General.Business;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicoErp.Areas.Administracion.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Administracion)]
    public class EspecialidadesController : ControllerBase
    {
        private readonly EspecialidadBusiness BusinessEsp = new EspecialidadBusiness();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lista = BusinessEsp.GetEspecialidades();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetEsp", ex.Message, null);
                throw;
            }
        }
    }
}