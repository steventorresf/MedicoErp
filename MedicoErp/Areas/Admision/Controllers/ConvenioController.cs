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
    public class ConvenioController : ControllerBase
    {
        private readonly IConvenioBusiness convenioBusiness;

        public ConvenioController(IConvenioBusiness _convenioBusiness)
        {
            this.convenioBusiness = _convenioBusiness;
        }


        [HttpGet("{IdCentro}")]
        public IActionResult Get(int IdCentro)
        {
            try
            {
                var lista = convenioBusiness.GetConvenios(IdCentro);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("Act/{IdCentro}")]
        public IActionResult GetActivos(int IdCentro)
        {
            try
            {
                var lista = convenioBusiness.GetConveniosActivos(IdCentro);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Convenio entity)
        {
            try
            {
                convenioBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("{IdCon}")]
        public IActionResult Put(int IdCon, [FromBody] Convenio entity)
        {
            try
            {
                convenioBusiness.Update(IdCon, entity);
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
                int IdCon = data["IdCon"].ToObject<int>();
                string CodEst = data["CodEst"].ToObject<string>();

                if (CodEst.Equals(Constantes.EstadoActivo))
                {
                    convenioBusiness.Activar(IdCon);
                }

                if (CodEst.Equals(Constantes.EstadoInactivo))
                {
                    convenioBusiness.Inactivar(IdCon);
                }

                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
