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
    [Route("General/api/[controller]")]
    [ApiController]
    public class TablaDetalleController : ControllerBase
    {
        private readonly ITablaDetalleBusiness tablaDetalleBusiness;

        public TablaDetalleController(ITablaDetalleBusiness _tablaDetalleBusiness)
        {
            tablaDetalleBusiness = _tablaDetalleBusiness;
        }

        [HttpGet("{CodTabla}")]
        public IActionResult GetDetalleByTab(string CodTabla)
        {
            try
            {
                var lista = tablaDetalleBusiness.GetTabDetalleByCodTabla(CodTabla);
                return Ok(lista);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}