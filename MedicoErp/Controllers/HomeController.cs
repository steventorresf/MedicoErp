using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicoErp.Models;
using System.Text;
using ClosedXML.Excel;
using System.IO;
using MedicoErp.Model.Common;

namespace MedicoErp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            bool Valido = Util.ValidarServidor();
            if (!Valido)
            {
                Response.Redirect("~/Login");
            }
            return View();
        }

        public IActionResult CambiarClave()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        
    }
}
