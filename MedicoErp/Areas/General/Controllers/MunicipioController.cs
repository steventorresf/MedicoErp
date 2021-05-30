using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicoErp.Areas.General.Controllers
{
    [Route("General/api/[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioBusiness municipioBusiness;

        public MunicipioController(IMunicipioBusiness _municipioBusiness)
        {
            municipioBusiness = _municipioBusiness;
        }

        [HttpGet("{CodDpto}")]
        public IActionResult GetMunicipios(string CodDpto)
        {
            try
            {
                var lista = municipioBusiness.GetMunicipiosByDpto(CodDpto);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}