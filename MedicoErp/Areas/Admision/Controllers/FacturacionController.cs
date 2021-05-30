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
    public class FacturacionController : ControllerBase
    {
        private readonly IFacturacionBusiness facturacionBusiness;

        public FacturacionController(IFacturacionBusiness _facturacionBusiness)
        {
            this.facturacionBusiness = _facturacionBusiness;
        }

        [HttpPost]
        public IActionResult CreateFacturacion([FromBody] JObject data)
        {
            try
            {
                int idFacturacion = facturacionBusiness.CreateByFacturacion(data);
                return Ok(idFacturacion);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("SinCita")]
        public IActionResult CreateFacturacionSinCita([FromBody] JObject data)
        {
            try
            {
                int idFacturacion = facturacionBusiness.CreateByFacturacionSinCita(data);
                return Ok(idFacturacion);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("GetId")]
        public IActionResult GetIdDocumento([FromBody] JObject data)
        {
            try
            {
                int idFacturacion = facturacionBusiness.GetIdDocumento(data);
                return Ok(idFacturacion);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{idPaciente}")]
        public IActionResult GetAllByIdPaciente(long idPaciente)
        {
            try
            {
                var entity = facturacionBusiness.GetAllByIdPaciente(idPaciente);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("Imp/{idFacturacion}")]
        public IActionResult GetImpresionFacturacion(int idFacturacion)
        {
            try
            {
                var entity = facturacionBusiness.GetFacturacionImpresion(idFacturacion);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}