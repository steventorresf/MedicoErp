using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Areas.Administracion.Business;
using MedicoErp.Areas.HistoriaClinica.Business;
using Microsoft.AspNetCore.Mvc;

namespace MedicoErp.Controllers
{
    public class VisorController : Controller
    {
        private UsuarioBusiness BusinessUsu = new UsuarioBusiness();
        private MultimediaBusiness BusinessMul = new MultimediaBusiness();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pdf(string idu, string idm)
        {
            if(!string.IsNullOrEmpty(idu) && string.IsNullOrEmpty(idm))
            {
                ViewBag.file = "data:application/pdf;base64," + BusinessUsu.GetFilePdf(Convert.ToInt32(idu));
            }

            if (string.IsNullOrEmpty(idu) && !string.IsNullOrEmpty(idm))
            {
                ViewBag.file = "data:application/pdf;base64," + BusinessMul.GetBase64PdfByIdMultimedia(Convert.ToInt32(idm));
            }
            return View();
        }
    }
}