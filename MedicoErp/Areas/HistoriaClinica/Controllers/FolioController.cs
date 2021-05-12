using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using MedicoErp.Model.Entities.HistoriaClinica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.HistoriaClinica.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_HistoriaClinica)]
    public class FolioController : ControllerBase
    {
        private readonly IFolioBusiness folioBusiness;

        public FolioController(IFolioBusiness _folioBusiness)
        {
            this.folioBusiness = _folioBusiness;
        }


        [HttpGet("{idEvento}")]
        public IActionResult GetAllByIdEvento(long idEvento)
        {
            try
            {
                var lista = folioBusiness.GetAllByIdEvento(idEvento);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("ByIdPac/{idPaciente}/{idCentro}")]
        public IActionResult GetAllByIdPaciente(long idPaciente, int idCentro)
        {
            try
            {
                var lista = folioBusiness.GetAllByIdPaciente(idPaciente, idCentro);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Folio entity)
        {
            try
            {
                long idFolio = folioBusiness.Create(entity);
                return Ok(idFolio);
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
                int val = folioBusiness.Anular(data);
                return Ok(val);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("ByIdFolio/{idFolio}")]
        public IActionResult GetAllByIdFolio(long idFolio)
        {
            try
            {
                var lista = folioBusiness.GetAllByIdFolio(idFolio);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
