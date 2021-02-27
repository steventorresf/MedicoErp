using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.General.Business;
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
    public class EventosController : ControllerBase
    {
        private EventosBusiness BusinessEv = new EventosBusiness();

        [HttpPost("AtCita")]
        public IActionResult AtenderCita([FromBody] JObject data)
        {
            try
            {
                long IdCita = data["idCita"].ToObject<long>();
                string NomUsu = data["nomUsu"].ToObject<string>();

                long IdEvento = BusinessEv.AtenderCita(IdCita, NomUsu);
                return Ok(IdEvento);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerAtenderCita", ex.Message, null);
                throw;
            }
        }

        [HttpGet("GetByIdEvento/{IdEvento}")]
        public IActionResult GetByIdEvento(long IdEvento)
        {
            try
            {
                var entity = BusinessEv.GetByIdEvento(IdEvento);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetByIdEvento", ex.Message, null);
                throw;
            }
        }

        [HttpGet("GetAllByIdPaciente/{IdPaciente}")]
        public IActionResult GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                var lista = BusinessEv.GetAllByIdPaciente(IdPaciente);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetAllByIdPaciente", ex.Message, null);
                throw;
            }
        }

        [HttpPut("{IdEvento}")]
        public IActionResult Update(long IdEvento, [FromBody] JObject data)
        {
            try
            {
                string Campo = data["campo"].ToObject<string>();
                string Dato = data["dato"].ToObject<string>();
                string NombreUsuario = data["nombreUsuario"].ToObject<string>();

                BusinessEv.Update(IdEvento, Campo, Dato, NombreUsuario);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetByIdEvento", ex.Message, null);
                throw;
            }
        }

        [HttpPut("Finalizar/{IdEvento}")]
        public IActionResult FinalizarEvento(long IdEvento, [FromBody] JObject data)
        {
            try
            {
                string NombreUsuario = data["nombreUsuario"].ToObject<string>();

                BusinessEv.FinalizarEvento(IdEvento, NombreUsuario);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerFinalizarEvento", ex.Message, null);
                throw;
            }
        }
    }
}