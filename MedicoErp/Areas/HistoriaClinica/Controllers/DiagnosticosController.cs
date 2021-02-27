using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.HistoriaClinica.Business;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MedicoErp.Areas.HistoriaClinica.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_HistoriaClinica)]
    public class DiagnosticosController : ControllerBase
    {
        private readonly DiagnosticosBusiness BusinessDiag = new DiagnosticosBusiness(); 

        [HttpPost("Prefix")]
        public IActionResult GetDiagnosticos([FromBody] JObject data)
        {
            string Prefix = data["prefix"].ToObject<string>();
            var lista = BusinessDiag.GetDiagnosticosPrefix(Prefix);
            return Ok(lista);
        }
    }
}