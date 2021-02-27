using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MedicoErp.Controllers
{
    public class AdmisionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AsignarCita()
        {
            return View();
        }
        public IActionResult TrasladarCancelarCita()
        {
            return View();
        }
        public IActionResult Facturar()
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