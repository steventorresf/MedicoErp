using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.Admision.Business;
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
    public class HorariosController : ControllerBase
    {
        private HorariosBusiness BusinessHor = new HorariosBusiness();

        [HttpGet("HorMed/{IdMedico}")]
        public IActionResult GetHorariosMedico(int IdMedico)
        {
            try
            {
                var lista = BusinessHor.GetHorariosMedico(IdMedico);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetHorariosMedico", ex.Message, null);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] JObject data)
        {
            try
            {
                string cad = BusinessHor.GetSCreatesHorarios(data);
                return Ok(cad);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPostHorarios", ex.Message, null);
                throw;
            }
        }

        [HttpGet("FecMed/{IdMedico}")]
        public IActionResult GetFechasMedico(int IdMedico)
        {
            try
            {
                string[] arLista = BusinessHor.GetFechasMed(IdMedico);
                return Ok(arLista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetFechasMedico", ex.Message, null);
                throw;
            }
        }

        [HttpPost("FecMed")]
        public IActionResult GetFechaHorasMedico([FromBody] JObject data)
        {
            try
            {
                int IdMedico = data["IdMedico"].ToObject<int>();
                DateTime Fecha = data["Fecha"].ToObject<DateTime>();

                var lista = BusinessHor.GetFechaHorasMed(IdMedico, Fecha);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetFechasMedico", ex.Message, null);
                throw;
            }
        }
    }
}