using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Utiles;
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
        public IActionResult ConsAgenda()
        {
            return View();
        }
        public IActionResult Horarios()
        {
            return View();
        }
    }
}