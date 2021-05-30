using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using MedicoErp.Model.Abstract.Admision;
using MedicoErp.Model.Common;
using MedicoErp.Model.Entities.Admision;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MedicoErp.Areas.Admision.Controllers
{
    [Route("Admision/api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly ICitaBusiness citaBusiness;

        public CitaController(ICitaBusiness _citaBusiness)
        {
            this.citaBusiness = _citaBusiness;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cita entity)
        {
            try
            {
                long idCita = citaBusiness.Create(entity);
                return Ok(idCita);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("UpTarDesc")]
        public IActionResult PostUpdateTarifa([FromBody] JObject data)
        {
            try
            {
                citaBusiness.UpdateTarifaDescuento(data);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{IdPac}")]
        public IActionResult GetAsignadas(long IdPac)
        {
            try
            {
                var lista = citaBusiness.GetAsignadas(IdPac);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{IdPac}/{IdCon}")]
        public IActionResult GetAsignadasConvenio(long IdPac, int IdCon)
        {
            try
            {
                var lista = citaBusiness.GetAsignadasConvenio(IdPac, IdCon);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdCita}")]
        public IActionResult Update(long IdCita, [FromBody] Cita entity)
        {
            try
            {
                bool Val = citaBusiness.Update(IdCita, entity);
                return Ok(Val);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("Cancel")]
        public IActionResult Delete([FromBody] JObject data)
        {
            try
            {
                long IdCita = data["IdCita"].ToObject<long>();
                string NomUsu = data["NomUsu"].ToObject<string>();

                citaBusiness.Delete(IdCita, NomUsu);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("CAg")]
        public IActionResult ConsultarAgenda([FromBody] JObject data)
        {
            try
            {
                DateTime FechaIni = data["fechaInicio"].ToObject<DateTime>();
                DateTime FechaFin = data["fechaFin"].ToObject<DateTime>();
                int IdMed = data["idMedico"].ToObject<int>();

                var lista = citaBusiness.GetAgendaMedica(FechaIni, FechaFin, IdMed);
                return Ok(lista);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpPost("CAgMed")]
        public IActionResult GetMiAgendaMedica([FromBody] JObject data)
        {
            try
            {
                DateTime Fecha = data["Fecha"].ToObject<DateTime>();
                int IdMed = data["IdMed"].ToObject<int>();

                var lista = citaBusiness.GetMiAgendaFecha(IdMed, Fecha);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("Imp/{idCita}")]
        public IActionResult GetImpresion(int idCita)
        {
            try
            {
                var entity = citaBusiness.GetImpresion(idCita);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}