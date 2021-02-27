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
    public class ServiciosController : ControllerBase
    {
        private readonly ServicioBusiness BusinessSer = new ServicioBusiness();

        [HttpGet("{IdCentro}")]
        public IActionResult GetServicios(int IdCentro)
        {
            try
            {
                var lista = BusinessSer.GetServicios(IdCentro);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetServicios", ex.Message, null);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Servicio entity)
        {
            try
            {
                BusinessSer.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPostServicio", ex.Message, null);
                throw;
            }
        }

        [HttpPut("{IdSer}")]
        public IActionResult Put(int IdSer, [FromBody] Servicio entity)
        {
            try
            {
                BusinessSer.Update(IdSer, entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPutServicio", ex.Message, null);
                throw;
            }
        }

        [HttpPost("UpEst")]
        public IActionResult PutEstado([FromBody] JObject data)
        {
            try
            {
                int IdServicio = data["IdServicio"].ToObject<int>();
                bool Activo = data["Activo"].ToObject<bool>();

                BusinessSer.UpdateEstado(IdServicio, Activo);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPutEstadoServicio", ex.Message, null);
                throw;
            }
        }

    }
}