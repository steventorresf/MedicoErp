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
    public class ConveniosController : ControllerBase
    {
        private readonly ConvenioBusiness BusinessCon = new ConvenioBusiness();

        [HttpGet("{IdCentro}")]
        public IActionResult Get(int IdCentro)
        {
            try
            {
                var lista = BusinessCon.GetConvenios(IdCentro);
                return Ok(lista);
            }
            catch(Exception ex)
            {
                ErroresBusiness.Create("ControllerGetConvenio", ex.Message, null);
                throw;
            }
        }

        [HttpGet("Act/{IdCentro}")]
        public IActionResult GetActivos(int IdCentro)
        {
            try
            {
                var lista = BusinessCon.GetConveniosActivos(IdCentro);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetConveniosActivos", ex.Message, null);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Convenio entity)
        {
            try
            {
                BusinessCon.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPostConvenio", ex.Message, null);
                throw;
            }
        }

        [HttpPut("{IdCon}")]
        public IActionResult Put(int IdCon, [FromBody] Convenio entity)
        {
            try
            {
                BusinessCon.Update(IdCon, entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPutConvenio", ex.Message, null);
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
                    BusinessCon.Activar(IdCon);
                }

                if (CodEst.Equals(Constantes.EstadoInactivo))
                {
                    BusinessCon.Inactivar(IdCon);
                }

                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPutEstadoConvenio", ex.Message, null);
                throw;
            }
        }

    }
}