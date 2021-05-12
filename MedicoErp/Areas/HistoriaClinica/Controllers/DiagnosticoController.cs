using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MedicoErp.Areas.HistoriaClinica.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_HistoriaClinica)]
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoBusiness diagnosticoBusiness;

        public DiagnosticoController(IDiagnosticoBusiness _diagnosticoBusiness)
        {
            this.diagnosticoBusiness = _diagnosticoBusiness;
        }

        [HttpPost("Prefix")]
        public IActionResult GetDiagnosticos([FromBody] JObject data)
        {
            string Prefix = data["prefix"].ToObject<string>();
            var lista = diagnosticoBusiness.GetDiagnosticosPrefix(Prefix);
            return Ok(lista);
        }
    }
}