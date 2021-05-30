using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using MedicoErp.Model.Entities.HistoriaClinica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MedicoErp.Areas.HistoriaClinica.Controllers
{
    [Route("HistoriaClinica/api/[controller]")]
    [ApiController]
    public class FormulacionController : ControllerBase
    {
        private readonly IFormulacionBusiness formulacionBusiness;

        public FormulacionController(IFormulacionBusiness _formulacionBusiness)
        {
            this.formulacionBusiness = _formulacionBusiness;
        }

        [HttpGet("{IdEvento}")]
        public IActionResult GetAllByIdEvento(long IdEvento)
        {
            try
            {
                var lista = formulacionBusiness.GetAllByIdEvento(IdEvento);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("ByPac/{IdPaciente}")]
        public IActionResult GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                var lista = formulacionBusiness.GetAllByIdPaciente(IdPaciente);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetForImp/{IdFormulacion}")]
        public IActionResult GetFormulacionImpresion(long IdFormulacion)
        {
            try
            {
                var lista = formulacionBusiness.GetFormulacionImp(IdFormulacion);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Formulacion entityFor)
        {
            try
            {
                formulacionBusiness.Create(entityFor);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("An")]
        public IActionResult Anular([FromBody] JObject data)
        {
            try
            {
                int val = formulacionBusiness.Anular(data);
                return Ok(val);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}