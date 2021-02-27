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
    public class TablasDetalleController : ControllerBase
    {
        private readonly TablasDetalleBusiness BusinessTabDet = new TablasDetalleBusiness();

        [HttpGet("{CodTabla}")]
        public IActionResult GetDetalleByTab(string CodTabla)
        {
            try
            {
                var lista = BusinessTabDet.GetTabDetalleByCodTabla(CodTabla);
                return Ok(lista);
            }
            catch(Exception ex)
            {
                ErroresBusiness.Create("GetDetalleByTabController", ex.Message, null);
                throw;
            }
        }
    }
}