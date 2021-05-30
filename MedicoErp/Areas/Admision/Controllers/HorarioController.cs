using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Model.Abstract.Admision;
using MedicoErp.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MedicoErp.Areas.Admision.Controllers
{
    [Route("Admision/api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private readonly IHorarioBusiness horarioBusiness;

        public HorarioController(IHorarioBusiness _horarioBusiness)
        {
            this.horarioBusiness = _horarioBusiness;
        }

        [HttpGet("HorMed/{IdMedico}")]
        public IActionResult GetHorariosMedico(int IdMedico)
        {
            try
            {
                var lista = horarioBusiness.GetHorariosMedico(IdMedico);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] JObject data)
        {
            try
            {
                string cad = horarioBusiness.GetSCreatesHorarios(data);
                return Ok(cad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("FecMed/{IdMedico}")]
        public IActionResult GetFechasMedico(int IdMedico)
        {
            try
            {
                string[] arLista = horarioBusiness.GetFechasMed(IdMedico);
                return Ok(arLista);
            }
            catch (Exception ex)
            {
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

                var lista = horarioBusiness.GetFechaHorasMed(IdMedico, Fecha);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}