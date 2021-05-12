using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Model.Abstract.Admision;
using MedicoErp.Model.Abstract.Informes;
using MedicoErp.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MedicoErp.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IInformeBusiness informeBusiness;

        public ExcelController(IInformeBusiness _informeBusiness)
        {
            this.informeBusiness = _informeBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AgendaMedica(string Fi, string Ff, int Im, string Nm)
        {
            string NombreArchivo = Nm.Replace(" ", "") + ".xlsx";
            byte[] bytes = informeBusiness.ExcelAgendaMedica(Fi, Ff, Im);
            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, NombreArchivo);
        }

        [HttpGet]
        public IActionResult Actividades(string Fi, string Ff, int Ic)
        {
            byte[] bytes = informeBusiness.GetActividades(Fi, Ff, Ic);
            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, Constantes.NomExcelActividades);
        }

    }
}