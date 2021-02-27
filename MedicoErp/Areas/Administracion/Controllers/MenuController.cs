using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Mvc;

namespace MedicoErp.Areas.Administracion.Controllers
{
    [Area(Constantes.Area_Administracion)]
    public class MenuController : Controller
    {
        public IActionResult MiCentro()
        {
            return View();
        }
        public IActionResult Convenios()
        {
            return View();
        }
        public IActionResult Servicios()
        {
            return View();
        }
        public IActionResult Usuarios()
        {
            return View();
        }
    }
}