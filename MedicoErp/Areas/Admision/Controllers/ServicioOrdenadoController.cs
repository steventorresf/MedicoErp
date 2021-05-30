using MedicoErp.Model.Abstract.Admision;
using MedicoErp.Model.Common;
using MedicoErp.Model.Entities.Admision;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.Admision.Controllers
{
    [Route("Admision/api/[controller]")]
    [ApiController]
    public class ServicioOrdenadoController : ControllerBase
    {
        private readonly IServicioOrdenadoBusiness servicioOrdenadoBusiness;

        public ServicioOrdenadoController(IServicioOrdenadoBusiness _servicioOrdenadoBusiness)
        {
            this.servicioOrdenadoBusiness = _servicioOrdenadoBusiness;
        }


        [HttpGet("{IdCentro}/{IdPaciente}/{IdConvenio}")]
        public IActionResult getAllByIdPacAndIdCon(int IdCentro, long IdPaciente, int IdConvenio)
        {
            try
            {
                var lista = servicioOrdenadoBusiness.getAllByIdPacAndIdCon(IdCentro, IdPaciente, IdConvenio);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ServicioOrdenado entity)
        {
            try
            {
                servicioOrdenadoBusiness.Create(entity);
                return Ok(true);
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
                servicioOrdenadoBusiness.UpdateTarifaDescuento(data);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{IdServicioOrdenado}")]
        public IActionResult Delete(long IdServicioOrdenado)
        {
            try
            {
                servicioOrdenadoBusiness.Delete(IdServicioOrdenado);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
