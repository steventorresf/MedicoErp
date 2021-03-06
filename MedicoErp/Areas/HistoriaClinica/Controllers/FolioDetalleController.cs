﻿using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using MedicoErp.Model.Entities.HistoriaClinica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.HistoriaClinica.Controllers
{
    [Route("HistoriaClinica/api/[controller]")]
    [ApiController]
    public class FolioDetalleController : ControllerBase
    {
        private readonly IFolioDetalleBusiness folioDetalleBusiness;

        public FolioDetalleController(IFolioDetalleBusiness _folioDetalleBusiness)
        {
            this.folioDetalleBusiness = _folioDetalleBusiness;
        }


        [HttpPost("{IdDetalle}")]
        public IActionResult Update(long IdDetalle, [FromBody] FolioDetalle entity)
        {
            try
            {
                folioDetalleBusiness.Update(IdDetalle, entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
