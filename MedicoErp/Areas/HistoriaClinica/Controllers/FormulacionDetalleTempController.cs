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
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_HistoriaClinica)]
    public class FormulacionDetalleTempController : ControllerBase
    {
        private readonly IFormulacionDetalleBusinessTemp formulacionDetalleBusinessTemp;

        public FormulacionDetalleTempController(IFormulacionDetalleBusinessTemp _formulacionDetalleBusinessTemp)
        {
            this.formulacionDetalleBusinessTemp = _formulacionDetalleBusinessTemp;
        }

        [HttpGet("{IdUsuario}")]
        public IActionResult GetAllByIdUsuario(int IdUsuario)
        {
            try
            {
                var lista = formulacionDetalleBusinessTemp.GetAllByIdUsuario(IdUsuario);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] FormulacionDetalleTemp entity)
        {
            try
            {
                formulacionDetalleBusinessTemp.Create(entity);
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
                formulacionDetalleBusinessTemp.Delete(IdDetalle);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}