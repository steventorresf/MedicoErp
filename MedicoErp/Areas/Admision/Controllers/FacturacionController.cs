using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.Admision.Business;
using MedicoErp.Areas.Admision.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MedicoErp.Areas.Admision.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Admision)]
    public class FacturacionController : ControllerBase
    {
        private FacturacionBusiness BusinessFact = new FacturacionBusiness();

        [HttpPost]
        public IActionResult CreateFacturacion([FromBody] JObject data)
        {
            try
            {
                int idFacturacion = BusinessFact.CreateByFacturacion(data);
                return Ok(idFacturacion);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPostFacturacion", ex.Message, null);
                return Ok(new { resp = false });
            }
        }
    }
}