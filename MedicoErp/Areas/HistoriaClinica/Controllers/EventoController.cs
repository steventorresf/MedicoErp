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
    public class EventoController : ControllerBase
    {
        private readonly IEventoBusiness eventoBusiness;

        public EventoController(IEventoBusiness _eventoBusiness)
        {
            this.eventoBusiness = _eventoBusiness;
        }

        [HttpPost("AtCita")]
        public IActionResult AtenderCita([FromBody] JObject data)
        {
            try
            {
                long IdCita = data["idCita"].ToObject<long>();
                string NomUsu = data["nomUsu"].ToObject<string>();

                long IdEvento = eventoBusiness.AtenderCita(IdCita, NomUsu);
                return Ok(IdEvento);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("Ext")]
        public IActionResult CreateExt([FromBody] Evento entity)
        {
            try
            {
                eventoBusiness.CreateExt(entity);
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
                int val = eventoBusiness.Anular(data);
                return Ok(val);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetByIdEvento/{IdEvento}")]
        public IActionResult GetByIdEvento(long IdEvento)
        {
            try
            {
                var entity = eventoBusiness.GetByIdEvento(IdEvento);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetAllByIdPaciente/{IdPaciente}")]
        public IActionResult GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                var lista = eventoBusiness.GetAllByIdPaciente(IdPaciente);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("Imp/{IdEvento}/{IdFolio}")]
        public IActionResult GetEventoImpresion(long IdEvento, long IdFolio)
        {
            try
            {
                var lista = eventoBusiness.GetEventoImpresion(IdEvento, IdFolio);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("{IdEvento}")]
        public IActionResult Update(long IdEvento, [FromBody] JObject data)
        {
            try
            {
                string Campo = data["campo"].ToObject<string>();
                string Dato = data["dato"].ToObject<string>();
                string NombreUsuario = data["nombreUsuario"].ToObject<string>();

                eventoBusiness.Update(IdEvento, Campo, Dato, NombreUsuario);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("Finalizar/{IdEvento}")]
        public IActionResult FinalizarEvento(long IdEvento, [FromBody] JObject data)
        {
            try
            {
                string NombreUsuario = data["nombreUsuario"].ToObject<string>();

                eventoBusiness.FinalizarEvento(IdEvento, NombreUsuario);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}