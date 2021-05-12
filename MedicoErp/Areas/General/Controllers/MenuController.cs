using MedicoErp.Model.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.General.Controllers
{
    [Area(Constantes.Area_General)]
    public class MenuController : Controller
    {
        public IActionResult MiCentro()
        {
            return View();
        }
        public IActionResult CentrosExternos()
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
