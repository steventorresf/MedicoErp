using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Common;
using MedicoErp.Model.Entities.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.General.Controllers
{
    [Route("General/api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioBusiness servicioBusiness;

        public ServicioController(IServicioBusiness _servicioBusiness)
        {
            this.servicioBusiness = _servicioBusiness;
        }


        [HttpGet("{IdCentro}")]
        public IActionResult GetServicios(int IdCentro)
        {
            try
            {
                var lista = servicioBusiness.GetServicios(IdCentro);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Servicio entity)
        {
            try
            {
                servicioBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdSer}")]
        public IActionResult Put(int IdSer, [FromBody] Servicio entity)
        {
            try
            {
                servicioBusiness.Update(IdSer, entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
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

                servicioBusiness.UpdateEstado(IdServicio, Activo);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
