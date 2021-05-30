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
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenBusiness ordenBusiness;

        public OrdenController(IOrdenBusiness _ordenBusiness)
        {
            this.ordenBusiness = _ordenBusiness;
        }

        [HttpGet("{IdEvento}")]
        public IActionResult GetAllByIdEvento(long IdEvento)
        {
            try
            {
                var lista = ordenBusiness.GetAllByIdEvento(IdEvento);
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
                var lista = ordenBusiness.GetAllByIdPaciente(IdPaciente);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Orden entityOrd)
        {
            try
            {
                ordenBusiness.Create(entityOrd);
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
                int val = ordenBusiness.Anular(data);
                return Ok(val);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetOrdImp/{IdOrden}")]
        public IActionResult GetOrdenImpresion(long IdOrden)
        {
            try
            {
                var lista = ordenBusiness.GetOrdenImp(IdOrden);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}