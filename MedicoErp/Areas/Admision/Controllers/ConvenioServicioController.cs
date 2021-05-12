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
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Admision)]
    public class ConvenioServicioController : ControllerBase
    {
        private readonly IConvenioServicioBusiness convenioServicioBusiness;

        public ConvenioServicioController(IConvenioServicioBusiness _convenioServicioBusiness)
        {
            this.convenioServicioBusiness = _convenioServicioBusiness;
        }


        [HttpPost]
        public IActionResult Post([FromBody] List<ConvenioServicio> Lista)
        {
            try
            {
                convenioServicioBusiness.Creates(Lista);
                return Ok(true);
            }
            catch (Exception ex)
            {
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

                convenioServicioBusiness.UpdateTarifa(IdDetalle, VTarifa);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("ByIdSer/{IdCon}/{IdSer}")]
        public IActionResult GetByIdServicio(int IdCon, int IdSer)
        {
            try
            {
                var entity = convenioServicioBusiness.GetByIdServicio(IdCon, IdSer);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{IdCon}")]
        public IActionResult GetServiciosContratados(int IdCon)
        {
            try
            {
                var lista = convenioServicioBusiness.GetServiciosContratado(IdCon);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetNo/{IdCen}/{IdCon}")]
        public IActionResult GetServiciosNoContratados(int IdCen, int IdCon)
        {
            try
            {
                var lista = convenioServicioBusiness.GetServiciosNoContratado(IdCen, IdCon);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{IdDetalle}")]
        public IActionResult Delete(int IdDetalle)
        {
            try
            {
                convenioServicioBusiness.Delete(IdDetalle);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
