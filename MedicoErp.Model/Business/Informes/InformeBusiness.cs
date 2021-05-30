using ClosedXML.Excel;
using MedicoErp.Model.Abstract.Admision;
using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Abstract.Informes;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.Admision;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace MedicoErp.Model.Business.Informes
{
    public class InformeBusiness : IInformeBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly ICitaBusiness citaBusiness;
        private readonly MedicoErpContext context;

        public InformeBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness, ICitaBusiness _citaBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
            this.citaBusiness = _citaBusiness;
        }


        public byte[] ExcelAgendaMedica(string Fi, string Ff, int Im)
        {
            try
            {
                DateTime FechaIni = Convert.ToDateTime(Fi);
                DateTime FechaFin = Convert.ToDateTime(Ff);

                var Lista = citaBusiness.GetAgendaMedica(FechaIni, FechaFin, Im);
                IXLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Hoja1");

                int irow = 1;
                worksheet.Cell(irow, 1).SetValue("Fecha").Style.Font.SetBold(true);
                worksheet.Cell(irow, 2).SetValue("Hora").Style.Font.SetBold(true);
                worksheet.Cell(irow, 3).SetValue("Paciente").Style.Font.SetBold(true);
                worksheet.Cell(irow, 4).SetValue("Identificación").Style.Font.SetBold(true);
                worksheet.Cell(irow, 5).SetValue("Teléfono").Style.Font.SetBold(true);
                worksheet.Cell(irow, 6).SetValue("Convenio").Style.Font.SetBold(true);
                worksheet.Cell(irow, 7).SetValue("Servicio").Style.Font.SetBold(true);

                foreach (var c in Lista)
                {
                    irow++;
                    worksheet.Cell(irow, 1).Value = c.Fecha.Date;
                    worksheet.Cell(irow, 1).DataType = XLDataType.DateTime;

                    worksheet.Cell(irow, 2).Value = c.HoraDate.TimeOfDay;
                    worksheet.Cell(irow, 2).DataType = XLDataType.TimeSpan;

                    worksheet.Cell(irow, 3).Value = c.NombrePaciente;
                    worksheet.Cell(irow, 3).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 4).Value = c.Identificacion;
                    worksheet.Cell(irow, 4).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 5).Value = c.Telefono;
                    worksheet.Cell(irow, 5).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 6).Value = c.NombreConvenio;
                    worksheet.Cell(irow, 6).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 7).Value = c.NombreServicio;
                    worksheet.Cell(irow, 7).DataType = XLDataType.Text;
                }

                worksheet.Columns().AdjustToContents();

                MemoryStream ms = new MemoryStream();
                workbook.SaveAs(ms);

                return ms.ToArray();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAgendaMedica", ex, null);
                throw;
            }
        }

        public byte[] GetActividades(string FechaInicial, string FechaFinal, int IdCentro)
        {
            try
            {
                List<Cita> Lista = citaBusiness.GetActividades(FechaInicial, FechaFinal, IdCentro);
                IXLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Hoja1");

                int irow = 1;
                worksheet.Cell(irow, 1).SetValue("Fecha").Style.Font.SetBold(true);
                worksheet.Cell(irow, 2).SetValue("TipoDoc").Style.Font.SetBold(true);
                worksheet.Cell(irow, 3).SetValue("NoDoc").Style.Font.SetBold(true);
                worksheet.Cell(irow, 4).SetValue("CentroRemision").Style.Font.SetBold(true);
                worksheet.Cell(irow, 5).SetValue("TipoIdentificación").Style.Font.SetBold(true);
                worksheet.Cell(irow, 6).SetValue("NúmeroIdentificación").Style.Font.SetBold(true);
                worksheet.Cell(irow, 7).SetValue("NombrePaciente").Style.Font.SetBold(true);
                worksheet.Cell(irow, 8).SetValue("Teléfono").Style.Font.SetBold(true);
                worksheet.Cell(irow, 9).SetValue("Convenio").Style.Font.SetBold(true);
                worksheet.Cell(irow, 10).SetValue("Médico").Style.Font.SetBold(true);
                worksheet.Cell(irow, 11).SetValue("CódigoCups").Style.Font.SetBold(true);
                worksheet.Cell(irow, 12).SetValue("ClaseServicio").Style.Font.SetBold(true);
                worksheet.Cell(irow, 13).SetValue("NombreServicio").Style.Font.SetBold(true);
                worksheet.Cell(irow, 14).SetValue("Cantidad").Style.Font.SetBold(true);
                worksheet.Cell(irow, 15).SetValue("Tarifa").Style.Font.SetBold(true);
                worksheet.Cell(irow, 16).SetValue("Vr. Total").Style.Font.SetBold(true);

                foreach (Cita c in Lista)
                {
                    irow++;
                    worksheet.Cell(irow, 1).Value = c.Fecha.Date;
                    worksheet.Cell(irow, 1).DataType = XLDataType.DateTime;

                    worksheet.Cell(irow, 2).Value = c.TipoDocumento;
                    worksheet.Cell(irow, 2).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 3).Value = c.NumDocumento;
                    worksheet.Cell(irow, 3).DataType = XLDataType.Number;

                    worksheet.Cell(irow, 4).Value = c.NombreCentro;
                    worksheet.Cell(irow, 4).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 5).Value = c.TipoIdentificacion;
                    worksheet.Cell(irow, 5).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 6).Value = c.Identificacion;
                    worksheet.Cell(irow, 6).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 7).Value = c.NombrePaciente;
                    worksheet.Cell(irow, 7).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 8).Value = c.Telefono;
                    worksheet.Cell(irow, 8).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 9).Value = c.NombreConvenio;
                    worksheet.Cell(irow, 9).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 10).Value = c.NombreMedico;
                    worksheet.Cell(irow, 10).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 11).Value = c.CodigoRef;
                    worksheet.Cell(irow, 11).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 12).Value = c.NombreClaseServicio;
                    worksheet.Cell(irow, 12).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 13).Value = c.NombreServicio;
                    worksheet.Cell(irow, 13).DataType = XLDataType.Text;

                    worksheet.Cell(irow, 14).Value = c.Cantidad;
                    worksheet.Cell(irow, 14).DataType = XLDataType.Number;

                    worksheet.Cell(irow, 15).Value = c.Tarifa;
                    worksheet.Cell(irow, 15).DataType = XLDataType.Number;

                    worksheet.Cell(irow, 16).Value = c.VrTotal;
                    worksheet.Cell(irow, 16).DataType = XLDataType.Number;
                }

                worksheet.Columns().AdjustToContents();

                MemoryStream ms = new MemoryStream();
                workbook.SaveAs(ms);

                return ms.ToArray();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetActividadesInf", ex, null);
                throw;
            }
        }
    }
}
