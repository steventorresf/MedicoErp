using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.General.Business;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicoErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class MunicipiosController : ControllerBase
    {
        private readonly MunicipiosBusiness BusinessMun = new MunicipiosBusiness();

        [HttpGet("{CodDpto}")]
        public IActionResult GetDepartamentos(string CodDpto)
        {
            try
            {
                var lista = BusinessMun.GetMunicipiosByDpto(CodDpto);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetMunicipios", ex.Message, null);
                throw;
            }
        }
    }
}