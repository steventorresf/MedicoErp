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
    public class OrdenesDetalleTempController : ControllerBase
    {
        private OrdenesDetalleBusinessTemp BusinessOrdDetTemp = new OrdenesDetalleBusinessTemp();

        [HttpGet("{IdUsuario}")]
        public IActionResult GetAllByIdUsuario(int IdUsuario)
        {
            try
            {
                var lista = BusinessOrdDetTemp.GetAllByIdUsuario(IdUsuario);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerOrdenesDetalleTempGetAllByIdUsuario", ex.Message, null);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrdenesDetalleTemp entity)
        {
            try
            {
                BusinessOrdDetTemp.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerOrdenesDetalleTempCreate", ex.Message, null);
                throw;
            }
        }

        [HttpDelete("{IdDetalle}")]
        public IActionResult Delete(int IdDetalle)
        {
            try
            {
                BusinessOrdDetTemp.Delete(IdDetalle);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerOrdenesDetalleTempDelete", ex.Message, null);
                throw;
            }
        }
    }
}