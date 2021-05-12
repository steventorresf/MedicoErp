using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Model.Common;
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
        public IActionResult EventoFolio(long ide, long idf)
        {
            ViewBag.IdEvento = ide;
            ViewBag.IdFolio = idf;
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
        public IActionResult ActualizarHistoria()
        {
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