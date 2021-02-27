using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.Administracion.Business;
using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MedicoErp.Areas.Administracion.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Administracion)]
    public class PacientesController : ControllerBase
    {
        private PacienteBusiness BusinessPac = new PacienteBusiness();

        [HttpPost("Get")]
        public IActionResult GetByIden([FromBody] JObject data)
        {
            try
            {
                int IdCentro = data["IdCentro"].ToObject<int>();
                string TipoIden = data["TipoIden"].ToObject<string>();
                string NumIden = data["NumIden"].ToObject<string>();

                var entity = BusinessPac.GetPacienteByIdent(TipoIden, NumIden);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetByIdenPacientes", ex.Message, null);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Paciente entity)
        {
            try
            {
                BusinessPac.Create(entity);
                var obPac = BusinessPac.GetPacienteByIdent(entity.TipoIden, entity.NumIden);
                return Ok(obPac);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPostPaciente", ex.Message, null);
                throw;
            }
        }

        [HttpPut("{IdPac}")]
        public IActionResult Put(long IdPac, [FromBody] Paciente entity)
        {
            try
            {
                BusinessPac.Update(IdPac, entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerPutPaciente", ex.Message, null);
                throw;
            }
        }
    }
}