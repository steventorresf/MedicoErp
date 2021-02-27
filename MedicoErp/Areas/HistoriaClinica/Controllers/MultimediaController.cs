using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.General.Business;
using MedicoErp.Areas.HistoriaClinica.Business;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MedicoErp.Areas.HistoriaClinica.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_HistoriaClinica)]
    public class MultimediaController : ControllerBase
    {
        private MultimediaBusiness BusinessMul = new MultimediaBusiness();
        private MultimediaTemporalBusiness BusinessMulTemp = new MultimediaTemporalBusiness();

        [HttpPost]
        public IActionResult CreateMultimedia([FromBody] JObject data)
        {
            try
            {
                //long Resp = BusinessFo.Create(data);
                return Ok();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerCreateFolio", ex.Message, null);
                throw;
            }
        }

        [HttpGet("ByPac/{IdPaciente}")]
        public IActionResult GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                var lista = BusinessMul.GetAllByIdPaciente(IdPaciente);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetAllByIdPaciente", ex.Message, null);
                throw;
            }
        }

        [HttpGet("ByTemp/{IdUsuario}")]
        public IActionResult GetAllTemporalesByIdUsuario(int IdUsuario)
        {
            try
            {
                var lista = BusinessMulTemp.GetAllTemporalesByIdUsuario(IdUsuario);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetAllByIdPaciente", ex.Message, null);
                throw;
            }
        }

        [HttpPost("Img")]
        public IActionResult SubirImgTemporal([FromBody] JObject data)
        {
            try
            {
                BusinessMulTemp.SubirImagenTemporal(data);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPostSubirImg", ex.Message, null);
                throw;
            }
        }

        [HttpDelete("DelAll/{IdUsuario}/{IdCentro}")]
        public IActionResult DeleteAllTemporal(int IdUsuario, int IdCentro)
        {
            try
            {
                BusinessMulTemp.DeleteAll(IdUsuario, IdCentro);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerDeleteAllTemporal", ex.Message, null);
                throw;
            }
        }

        [HttpDelete("DelImgTemp/{IdDetalle}/{IdCentro}")]
        public IActionResult DeleteImagenTemporal(int IdDetalle, int IdCentro)
        {
            try
            {
                BusinessMulTemp.Delete(IdDetalle, IdCentro);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerDeleteImagenTemporal", ex.Message, null);
                throw;
            }
        }

        [HttpPost("MulPdf/{Tip}")]
        public IActionResult MultimediaPDF(string Tip, [FromBody] JObject data)
        {
            try
            {
                if (Tip.Equals("1"))
                {
                    bool resp = BusinessMul.MultimediaPdfVistaPrevia(data);
                    return Ok(resp);
                }
                else
                {
                    BusinessMul.MultimediaPdfReal(data);
                    return Ok(true);
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ContyrollerMultimediaPDF", ex.Message, null);
                throw;
            }
        }
    }
}