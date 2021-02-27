using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.Admision.Business;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MedicoErp.Controllers
{
    public class ExcelController : Controller
    {
        private CitasBusiness CitBusiness = new CitasBusiness();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAgendaMedica(string Fi, string Ff, int Im, string Nm)
        {
            byte[] bytes = CitBusiness.ExcelAgendaMedica(Fi, Ff, Im, Nm);
            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, Constantes.NomExcelAgendaMedica);
        }

    }
}