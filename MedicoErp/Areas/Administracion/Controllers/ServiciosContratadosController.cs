using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.Administracion.Business;
using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MedicoErp.Areas.Administracion.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Administracion)]
    public class ServiciosContratadosController : ControllerBase
    {
        private readonly ServicioContratadoBusiness BusinessSerCon = new ServicioContratadoBusiness();

        [HttpPost]
        public IActionResult Post([FromBody] List<ServicioContratado> Lista)
        {
            try
            {
                BusinessSerCon.Creates(Lista);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreatesServiciosContratados", ex.Message, null);
                throw;
            }
        }

        [HttpPost("UpTar")]
        public IActionResult PostModTarifa([FromBody] JObject data)
        {
            try
            {
                decimal VTarifa = data["tarifa"].ToObject<decimal>();
                int IdDetalle = data["idDetalle"].ToObject<int>();

                BusinessSerCon.UpdateTarifa(IdDetalle, VTarifa);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("PostModTarifa", ex.Message, null);
                throw;
            }
        }

        [HttpGet("{IdCon}")]
        public IActionResult GetServiciosContratados(int IdCon)
        {
            try
            {
                var lista = BusinessSerCon.GetServiciosContratado(IdCon);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetServiciosContratados", ex.Message, null);
                throw;
            }
        }

        [HttpGet("GetNo/{IdCen}/{IdCon}")]
        public IActionResult GetServiciosNoContratados(int IdCen, int IdCon)
        {
            try
            {
                var lista = BusinessSerCon.GetServiciosNoContratado(IdCen, IdCon);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetServiciosNoContratados", ex.Message, null);
                throw;
            }
        }

        [HttpDelete("{IdDetalle}")]
        public IActionResult Delete(int IdDetalle)
        {
            try
            {
                BusinessSerCon.Delete(IdDetalle);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("DeleteServiciosContratados", ex.Message, null);
                throw;
            }
        }

    }
}