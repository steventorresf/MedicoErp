using MedicoErp.Model.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.Informes.Controllers
{
    [Area(Constantes.Area_Informes)]
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Actividades()
        {
            return View();
        }
    }
}
