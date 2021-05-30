using MedicoErp.Model.Abstract.Admision;
using MedicoErp.Model.Common;
using MedicoErp.Model.Entities.Admision;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.Admision.Controllers
{
    [Route("Admision/api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteBusiness pacienteBusiness;

        public PacienteController(IPacienteBusiness _pacienteBusiness)
        {
            this.pacienteBusiness = _pacienteBusiness;
        }


        [HttpPost("Get")]
        public IActionResult GetByIden([FromBody] JObject data)
        {
            try
            {
                int IdCentro = data["IdCentro"].ToObject<int>();
                string TipoIden = data["TipoIden"].ToObject<string>();
                string NumIden = data["NumIden"].ToObject<string>();

                var entity = pacienteBusiness.GetPacienteByIdent(TipoIden, NumIden, IdCentro);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Paciente entity)
        {
            try
            {
                pacienteBusiness.Create(entity);
                var obPac = pacienteBusiness.GetPacienteByIdent(entity.TipoIden, entity.NumIden, entity.IdCentro);
                return Ok(obPac);
            }
            catch (Exception ex)
            {                
                throw;
            }
        }

        [HttpPut("{IdPac}")]
        public IActionResult Put(long IdPac, [FromBody] Paciente entity)
        {
            try
            {
                pacienteBusiness.Update(IdPac, entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
