using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class ClaseServicioController : ControllerBase
    {
        private readonly IClaseServicioBusiness claseServicioBusiness;

        public ClaseServicioController(IClaseServicioBusiness _claseServicioBusiness)
        {
            this.claseServicioBusiness = _claseServicioBusiness;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lista = claseServicioBusiness.GetClasesServicios();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
