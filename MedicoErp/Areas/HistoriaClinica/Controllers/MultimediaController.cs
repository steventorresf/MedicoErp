using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using MedicoErp.Model.Entities.HistoriaClinica;
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
        private readonly IMultimediaBusiness multimediaBusiness;
        private readonly IMultimediaTemporalBusiness multimediaTemporalBusiness;

        public MultimediaController(IMultimediaBusiness _multimediaBusiness, IMultimediaTemporalBusiness _multimediaTemporalBusiness)
        {
            this.multimediaBusiness = _multimediaBusiness;
            this.multimediaTemporalBusiness = _multimediaTemporalBusiness;
        }

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
                throw;
            }
        }

        [HttpGet("ByPac/{IdPaciente}")]
        public IActionResult GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                var lista = multimediaBusiness.GetAllByIdPaciente(IdPaciente);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("ByTemp/{IdUsuario}")]
        public IActionResult GetAllTemporalesByIdUsuario(int IdUsuario)
        {
            try
            {
                var lista = multimediaTemporalBusiness.GetAllTemporalesByIdUsuario(IdUsuario);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("Arch")]
        public IActionResult SubirArchivo([FromBody] Multimedia entity)
        {
            try
            {
                multimediaBusiness.MultimediaSubirArch(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("Img")]
        public IActionResult SubirImgTemporal([FromBody] JObject data)
        {
            try
            {
                multimediaTemporalBusiness.SubirImagenTemporal(data);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("DelAll/{IdUsuario}/{IdCentro}")]
        public IActionResult DeleteAllTemporal(int IdUsuario, int IdCentro)
        {
            try
            {
                multimediaTemporalBusiness.DeleteAll(IdUsuario, IdCentro);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("DelImgTemp/{IdDetalle}/{IdCentro}")]
        public IActionResult DeleteImagenTemporal(int IdDetalle, int IdCentro)
        {
            try
            {
                multimediaTemporalBusiness.Delete(IdDetalle, IdCentro);
                return Ok(true);
            }
            catch (Exception ex)
            {
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
                    bool resp = multimediaBusiness.MultimediaPdfVistaPrevia(data);
                    return Ok(resp);
                }
                else
                {
                    multimediaBusiness.MultimediaPdfReal(data);
                    return Ok(true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}