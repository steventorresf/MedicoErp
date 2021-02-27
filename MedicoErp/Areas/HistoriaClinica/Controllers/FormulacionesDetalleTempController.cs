using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.General.Business;
using MedicoErp.Areas.HistoriaClinica.Business;
using MedicoErp.Areas.HistoriaClinica.Entities;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicoErp.Areas.HistoriaClinica.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_HistoriaClinica)]
    public class FormulacionesDetalleTempController : ControllerBase
    {
        private FormulacionesDetalleBusinessTemp BusinessForDetTemp = new FormulacionesDetalleBusinessTemp();

        [HttpGet("{IdUsuario}")]
        public IActionResult GetAllByIdUsuario(int IdUsuario)
        {
            try
            {
                var lista = BusinessForDetTemp.GetAllByIdUsuario(IdUsuario);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerFormulacionesDetalleTempGetAllByIdUsuario", ex.Message, null);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] FormulacionesDetalleTemp entity)
        {
            try
            {
                BusinessForDetTemp.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerFormulacionesDetalleTempCreate", ex.Message, null);
                throw;
            }
        }

        [HttpDelete("{IdDetalle}")]
        public IActionResult Delete(int IdDetalle)
        {
            try
            {
                BusinessForDetTemp.Delete(IdDetalle);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerFormulacionesDetalleTempDelete", ex.Message, null);
                throw;
            }
        }
    }
}