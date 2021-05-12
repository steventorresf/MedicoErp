using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Model.Common;
using Microsoft.AspNetCore.Mvc;

namespace MedicoErp.Areas.Admision.Controllers
{
    [Area(Constantes.Area_Admision)]
    public class MenuController : Controller
    {
        public IActionResult Citas()
        {
            return View();
        }
        public IActionResult FacturarSinCita()
        {
            return View();
        }
        public IActionResult Convenios()
        {
            return View();
        }
        public IActionResult ConsAgenda()
        {
            return View();
        }
        public IActionResult Horarios()
        {
            return View();
        }
        public IActionResult ConsDocumentos()
        {
            return View();
        }
    }
}