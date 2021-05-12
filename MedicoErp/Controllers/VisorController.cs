using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using Microsoft.AspNetCore.Mvc;

namespace MedicoErp.Controllers
{
    public class VisorController : Controller
    {
        private readonly IUsuarioBusiness usuarioBusiness;
        private readonly IMultimediaBusiness multimediaBusiness;

        public VisorController(IUsuarioBusiness _usuarioBusiness, IMultimediaBusiness _multimediaBusiness)
        {
            this.usuarioBusiness = _usuarioBusiness;
            this.multimediaBusiness = _multimediaBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PdfPrevio(string idu)
        {
            if (!string.IsNullOrEmpty(idu))
            {
                ViewBag.file = "data:application/pdf;base64," + usuarioBusiness.GetFilePdf(Convert.ToInt32(idu));
            }
            return View();
        }

        public IActionResult Archivo(string idm, string idc, string doc)
        {
            ViewBag.nombreArchivo = "";
            ViewBag.extension = "";
            ViewBag.dataApp = "";

            if (!string.IsNullOrEmpty(idm))
            {
                var entity = multimediaBusiness.GetBase64ArchivoByIdMultimedia(Convert.ToInt32(idm));

                ViewBag.nombreArchivo = entity.NombreArchivo;
                ViewBag.extension = entity.Extension;
                ViewBag.dataApp = entity.DataApp;
            }

            if(!string.IsNullOrEmpty(idc) && !string.IsNullOrEmpty(doc))
            {
                string NombreDocumento = Util.GetNombreDocumentoByCod(doc);
                string Ruta = Parametros.RutaDocumentos + idc + "//" + NombreDocumento;
                if (System.IO.File.Exists(Ruta))
                {
                    ViewBag.nombreArchivo = NombreDocumento;
                    ViewBag.extension = "pdf";
                    ViewBag.dataApp = Util.GetDataArchivo("pdf") + Util.GetBase64Pdf(Ruta);
                }
            }
            return View();
        }

    }
}