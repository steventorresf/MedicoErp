using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.General.Business;
using MedicoErp.Areas.HistoriaClinica.Business;
using MedicoErp.Areas.HistoriaClinica.Entities;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MedicoErp.Areas.HistoriaClinica.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_HistoriaClinica)]
    public class FormulacionesController : ControllerBase
    {
        private readonly FormulacionesBusiness BusinessFr = new FormulacionesBusiness();

        [HttpGet("{IdEvento}")]
        public IActionResult GetAllByIdEvento(long IdEvento)
        {
            try
            {
                var lista = BusinessFr.GetAllByIdEvento(IdEvento);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerFormulaGetAllByIdEvento", ex.Message, null);
                throw;
            }
        }

        [HttpGet("ByPac/{IdPaciente}")]
        public IActionResult GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                var lista = BusinessFr.GetAllByIdPaciente(IdPaciente);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetAllByIdPaciente", ex.Message, null);
                throw;
            }
        }

        [HttpGet("GetForImp/{IdFormulacion}")]
        public IActionResult GetFormulacionImpresion(long IdFormulacion)
        {
            try
            {
                var lista = BusinessFr.GetFormulacionImp(IdFormulacion);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetFormulacionImpresion", ex.Message, null);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                Formulaciones entityFor = data["entityFor"].ToObject<Formulaciones>();
                int idCentro = data["idCentro"].ToObject<int>();

                BusinessFr.Create(entityFor, idCentro);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerCreateFormula", ex.Message, null);
                throw;
            }
        }
    }
}