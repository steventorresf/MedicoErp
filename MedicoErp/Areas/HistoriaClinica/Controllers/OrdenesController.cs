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
    public class OrdenesController : ControllerBase
    {
        private OrdenesBusiness BusinessOrd = new OrdenesBusiness();

        [HttpGet("{IdEvento}")]
        public IActionResult GetAllByIdEvento(long IdEvento)
        {
            try
            {
                var lista = BusinessOrd.GetAllByIdEvento(IdEvento);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerOrdenesGetAllByIdEvento", ex.Message, null);
                throw;
            }
        }

        [HttpGet("ByPac/{IdPaciente}")]
        public IActionResult GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                var lista = BusinessOrd.GetAllByIdPaciente(IdPaciente);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetAllByIdPaciente", ex.Message, null);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                Ordenes entityOrd = data["entityOrd"].ToObject<Ordenes>();
                int idCentro = data["idCentro"].ToObject<int>();

                BusinessOrd.Create(entityOrd, idCentro);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerCreateOrden", ex.Message, null);
                throw;
            }
        }

        [HttpGet("GetOrdImp/{IdOrden}")]
        public IActionResult GetOrdenImpresion(long IdOrden)
        {
            try
            {
                var lista = BusinessOrd.GetOrdenImp(IdOrden);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetOrdenImpresion", ex.Message, null);
                throw;
            }
        }
    }
}