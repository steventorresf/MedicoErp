using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Common;
using MedicoErp.Model.Entities.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class CentroAtencionController : ControllerBase
    {
        private readonly ICentroAtencionBusiness centroAtencionBusiness;

        public CentroAtencionController(ICentroAtencionBusiness _centroAtencionBusiness)
        {
            this.centroAtencionBusiness = _centroAtencionBusiness;
        }


        [HttpGet("ById/{idCentro}")]
        public IActionResult GetById(int idCentro)
        {
            try
            {
                var entity = centroAtencionBusiness.GetById(idCentro);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{idCentro}")]
        public IActionResult GetAll(int idCentro)
        {
            try
            {
                var lista = centroAtencionBusiness.GetAll(idCentro);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("Ext/{idCentro}")]
        public IActionResult GetExternos(int idCentro)
        {
            try
            {
                var lista = centroAtencionBusiness.GetAllExternos(idCentro);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CentroAtencion entity)
        {
            try
            {
                centroAtencionBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{idCentro}")]
        public IActionResult Update(int idCentro, [FromBody] CentroAtencion entity)
        {
            try
            {
                centroAtencionBusiness.Update(idCentro, entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("Ext/{idCentro}")]
        public IActionResult UpdateExterno(int idCentro, [FromBody] CentroAtencion entity)
        {
            try
            {
                centroAtencionBusiness.UpdateExterno(idCentro, entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
