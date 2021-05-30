using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using MedicoErp.Model.Entities.HistoriaClinica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicoErp.Areas.HistoriaClinica.Controllers
{
    [Route("HistoriaClinica/api/[controller]")]
    [ApiController]
    public class OrdenDetalleTempController : ControllerBase
    {
        private readonly IOrdenDetalleBusinessTemp ordenDetalleBusinessTemp;

        public OrdenDetalleTempController(IOrdenDetalleBusinessTemp _ordenDetalleBusinessTemp)
        {
            this.ordenDetalleBusinessTemp = _ordenDetalleBusinessTemp;
        }

        [HttpGet("{IdUsuario}")]
        public IActionResult GetAllByIdUsuario(int IdUsuario)
        {
            try
            {
                var lista = ordenDetalleBusinessTemp.GetAllByIdUsuario(IdUsuario);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrdenDetalleTemp entity)
        {
            try
            {
                ordenDetalleBusinessTemp.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("{IdDetalle}")]
        public IActionResult Update(int IdDetalle, [FromBody] OrdenDetalleTemp entity)
        {
            try
            {
                ordenDetalleBusinessTemp.Update(IdDetalle, entity);
                return Ok(true);
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
                ordenDetalleBusinessTemp.Delete(IdDetalle);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}