using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using MedicoErp.Areas.Administracion.Business;
using MedicoErp.Areas.Admision.Business;
using MedicoErp.Areas.Admision.Entities;
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
    public class CitasController : ControllerBase
    {
        private CitasBusiness BusinessCita = new CitasBusiness();

        [HttpPost]
        public IActionResult Post([FromBody] Citas entity)
        {
            try
            {
                bool Val = BusinessCita.Create(entity);
                return Ok(Val);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPostCitas", ex.Message, null);
                throw;
            }
        }

        [HttpPost("UpTar")]
        public IActionResult PostUpdateTarifa([FromBody] JObject data)
        {
            try
            {
                long IdCita = data["idCita"].ToObject<long>();
                decimal Tarifa = data["tarifa"].ToObject<decimal>();

                BusinessCita.UpdateTarifa(IdCita, Tarifa);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPostUpdateTarifa", ex.Message, null);
                throw;
            }
        }

        [HttpGet("{IdPac}")]
        public IActionResult GetAsignadas(long IdPac)
        {
            try
            {
                var lista = BusinessCita.GetAsignadas(IdPac);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetAsignadas", ex.Message, null);
                throw;
            }
        }

        [HttpGet("{IdPac}/{IdCon}")]
        public IActionResult GetAsignadasConvenio(long IdPac, int IdCon)
        {
            try
            {
                var lista = BusinessCita.GetAsignadasConvenio(IdPac, IdCon);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetAsignadasConvenio", ex.Message, null);
                throw;
            }
        }

        [HttpPut("{IdCita}")]
        public IActionResult Update(long IdCita, [FromBody] Citas entity)
        {
            try
            {
                bool Val = BusinessCita.Update(IdCita, entity);
                return Ok(Val);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerUpdateCita", ex.Message, null);
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

                BusinessCita.Delete(IdCita, NomUsu);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerDeleteCita", ex.Message, null);
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

                var lista = BusinessCita.GetAgendaMedica(FechaIni, FechaFin, IdMed);
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

                var lista = BusinessCita.GetMiAgendaFecha(IdMed, Fecha);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetMiAgendaMedica", ex.Message, null);
                throw;
            }
        }

    }
}