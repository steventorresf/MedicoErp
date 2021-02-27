using iTextSharp.text;
using iTextSharp.text.pdf;
using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Areas.HistoriaClinica.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Utiles
{
    public class Pdf
    {
        private static Paragraph obtCadena(string cadena, int tamaño, int estilo, BaseColor color)
        {
            BaseFont bf = BaseFont.CreateFont("C:\\Windows\\Fonts\\calibri.ttf", BaseFont.CP1252, false);
            Font fuente = new Font(bf, tamaño, estilo, color);
            Paragraph p = new Paragraph(cadena, fuente);
            return p;
        }

        private static PdfPCell obtCelda(string cadena, int tamaño, int estilo, BaseColor color, int alineacion, int border)
        {
            Paragraph p = obtCadena(cadena, tamaño, estilo, color);
            PdfPCell celda = new PdfPCell(p);
            celda.HorizontalAlignment = alineacion;
            celda.VerticalAlignment = Element.ALIGN_MIDDLE;
            celda.Border = border;
            celda.BorderColor = BaseColor.LIGHT_GRAY;
            celda.PaddingBottom = 4;
            return celda;
        }

        private static PdfPCell obtCeldaPadding(string cadena, int tamaño, int estilo, BaseColor color, int alineacion, int border)
        {
            Paragraph p = obtCadena(cadena, tamaño, estilo, color);
            PdfPCell celda = new PdfPCell(p);
            celda.HorizontalAlignment = alineacion;
            celda.VerticalAlignment = Element.ALIGN_TOP;
            celda.Border = border;
            celda.BorderColor = BaseColor.LIGHT_GRAY;
            celda.Padding = 1f;
            return celda;
        }

        private static PdfPCell obtImagen(float i, float j, string RutaImg)
        {
            PdfPCell celda;
            try
            {
                Image img = Image.GetInstance(RutaImg);
                img.ScaleToFit(i, j);
                img.Alignment = Element.ALIGN_CENTER;

                celda = new PdfPCell(img);
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.Border = 0;
            }
            catch (Exception) { celda = new PdfPCell(); celda.Border = 0; }
            return celda;
        }


        public static bool MultimediaPDF(string RutaArchivo, Paciente entityPac, List<MultimediaTemporal> ListaImgs, int IdCentro, int IdUsu, string Obs)
        {
            //Document pdf = new Document(PageSize.HALFLETTER, 15f, 15f, 13f, 13f);
            Document pdf = new Document(PageSize.A4);
            try
            {
                int Tam = 9;
                PdfWriter escritor = PdfWriter.GetInstance(pdf, new FileStream(RutaArchivo, FileMode.Create));
                pdf.Open();

                PdfPTable TabEncabezado = new PdfPTable(4);
                TabEncabezado.WidthPercentage = 100;
                TabEncabezado.SetWidths(new float[] { 0.15f, 0.35f, 0.15f, 0.35f });

                PdfPCell cel = obtCelda("DATOS DEL PACIENTE", Tam, 1, BaseColor.BLACK, Element.ALIGN_CENTER, 15);
                cel.Colspan = 4;
                cel.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);
                TabEncabezado.AddCell(cel);

                cel = obtCelda("Paciente", Tam, 1, BaseColor.BLACK, Element.ALIGN_LEFT, 15);
                TabEncabezado.AddCell(cel);
                cel = obtCelda(entityPac.NombrePaciente, Tam, 0, BaseColor.BLACK, Element.ALIGN_LEFT, 15);
                TabEncabezado.AddCell(cel);
                cel = obtCelda("Doc. Identidad:", Tam, 1, BaseColor.BLACK, Element.ALIGN_LEFT, 15);
                TabEncabezado.AddCell(cel);
                cel = obtCelda(entityPac.TipoIden + " " + entityPac.NumIden, Tam, 0, BaseColor.BLACK, Element.ALIGN_LEFT, 15);
                TabEncabezado.AddCell(cel);

                cel = obtCelda("Fecha Nac.:", Tam, 1, BaseColor.BLACK, Element.ALIGN_LEFT, 15);
                TabEncabezado.AddCell(cel);
                cel = obtCelda(entityPac.FechaNacimiento.ToString("dd/MMM/yyyy", new CultureInfo("es-CO")), Tam, 0, BaseColor.BLACK, Element.ALIGN_LEFT, 15);
                TabEncabezado.AddCell(cel);
                cel = obtCelda("Género:", Tam, 1, BaseColor.BLACK, Element.ALIGN_LEFT, 15);
                TabEncabezado.AddCell(cel);
                cel = obtCelda(entityPac.CodSexo.Equals("F") ? "FEMENINO" : "MASCULINO", Tam, 0, BaseColor.BLACK, Element.ALIGN_LEFT, 15);
                TabEncabezado.AddCell(cel);

                pdf.Add(TabEncabezado);

                PdfPTable TabDetalle = new PdfPTable(2);
                TabDetalle.SpacingBefore = 15f;
                TabDetalle.WidthPercentage = 100;
                TabDetalle.SetWidths(new float[] { 0.50f, 0.50f });

                string ruta = "ImgTemp/" + IdCentro + "/" + IdUsu + "/" + IdUsu + "_";
                foreach (MultimediaTemporal img in ListaImgs)
                {
                    string RutaImg = Parametros.RutaImagenesTemporales + IdCentro + "/" + img.IdUsuario + "_" + img.NombreImg;
                    cel = obtImagen(100f, 100f, RutaImg);
                    cel.Padding = 8f;
                    TabDetalle.AddCell(cel);
                }

                PdfPTable TabObs = new PdfPTable(1);
                TabObs.WidthPercentage = 100;

                cel = obtCelda("OBSERVACIONES:", Tam, 1, BaseColor.BLACK, Element.ALIGN_LEFT, 0);
                TabObs.AddCell(cel);
                cel = obtCelda(Obs, Tam, 0, BaseColor.BLACK, Element.ALIGN_LEFT, 0);
                cel.VerticalAlignment = Element.ALIGN_TOP;
                TabObs.AddCell(cel);

                cel = new PdfPCell(TabObs);
                cel.Border = 0;

                if (ListaImgs.Count % 2 == 0)
                {
                    cel.Colspan = 2;
                }

                TabDetalle.AddCell(cel);

                pdf.Add(TabDetalle);

                pdf.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (pdf.IsOpen())
                {
                    pdf.Close();
                }
                ErroresBusiness.Create("MultimediaPdf", ex.Message, null);
                return false;
            }
        }
    }
}
