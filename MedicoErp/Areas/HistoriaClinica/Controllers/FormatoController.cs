using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.HistoriaClinica.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_HistoriaClinica)]
    public class FormatoController : ControllerBase
    {
        private readonly IFormatoBusiness formatoBusiness;

        public FormatoController(IFormatoBusiness _formatoBusiness)
        {
            this.formatoBusiness = _formatoBusiness;
        }

        [HttpGet("{idCentro}")]
        public IActionResult GetAll(int idCentro)
        {
            try
            {
                var lista = formatoBusiness.GetAll(idCentro);
                return Ok(lista);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet("NotEvento/{idCentro}/{idEvento}")]
        public IActionResult GetAllNotEvento(int idCentro, long idEvento)
        {
            try
            {
                var lista = formatoBusiness.GetAllNotEvento(idCentro, idEvento);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
