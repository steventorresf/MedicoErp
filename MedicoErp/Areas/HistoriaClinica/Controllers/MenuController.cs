using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Utiles;
using Microsoft.AspNetCore.Mvc;

namespace MedicoErp.Areas.HistoriaClinica.Controllers
{
    [Area(Constantes.Area_HistoriaClinica)]
    public class MenuController : Controller
    {
        public IActionResult Atender()
        {
            return View();
        }
        public IActionResult Evento(long ide)
        {
            ViewBag.IdEvento = ide;
            return View();
        }
        public IActionResult EventoFormulacion(long ide)
        {
            ViewBag.IdEvento = ide;
            return View();
        }
        public IActionResult EventoOrdenMedica(long ide)
        {
            ViewBag.IdEvento = ide;
            return View();
        }
        public IActionResult ConsHistorias()
        {
            return View();
        }
        public IActionResult Multimedia()
        {
            return View();
        }
    }
}