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
    [Route("General/api/[controller]")]
    [ApiController]
    public class TipoServicioController : ControllerBase
    {
        private readonly ITipoServicioBusiness tipoServicioBusiness;

        public TipoServicioController(ITipoServicioBusiness _tipoServicioBusiness)
        {
            this.tipoServicioBusiness = _tipoServicioBusiness;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lista = tipoServicioBusiness.GetTiposServicios();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
