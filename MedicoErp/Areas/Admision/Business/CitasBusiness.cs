using ClosedXML.Excel;
using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.Admision.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Models;
using MedicoErp.Utiles;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.Admision.Business
{
    public class CitasBusiness
    {
        public bool Create(Citas entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                using(var tran = context.Database.BeginTransaction())
                {
                    bool Valido = true;

                    Horarios horario = context.Horarios.Find(entity.IdReserva);
                    if (horario.CodEstado.Equals(Constantes.EstadoAgendado))
                    {
                        Valido = false;
                    }
                    else
                    {
                        horario.CodEstado = Constantes.EstadoAgendado;

                        entity.Hora = horario.HoraInicial.ToString("hh:mm tt", new CultureInfo("en-US"));
                        entity.FechaCreado = DateTimeOffset.Now;
                        context.Citas.Add(entity);
                        context.SaveChanges();
                    }

                    tran.Commit();

                    return Valido;
                }
            }
            catch(Exception ex)
            {
                ErroresBusiness.Create("CreateCita", ex.Message, null);
                throw;
            }
        }

        public bool Update(long IdCita, Citas entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                using(var tran = context.Database.BeginTransaction())
                {
                    bool Valido = true;

                    Horarios horarioNew = context.Horarios.Find(entity.IdReserva);
                    if (horarioNew.CodEstado.Equals(Constantes.EstadoAgendado))
                    {
                        Valido = false;
                    }
                    else
                    {
                        horarioNew.CodEstado = Constantes.EstadoAgendado;
                        context.SaveChanges();

                        Citas obCita = context.Citas.Find(IdCita);
                        long IdHorarioOld = obCita.IdReserva;

                        obCita.IdReserva = horarioNew.IdHorario;
                        obCita.Fecha = horarioNew.Fecha;
                        obCita.Hora = horarioNew.HoraInicial.ToString("hh:mm tt", new CultureInfo("en-US"));
                        obCita.ModificadoPor = entity.ModificadoPor;
                        obCita.FechaModificado = DateTimeOffset.Now;
                        context.SaveChanges();

                        Horarios horarioOld = context.Horarios.Find(IdHorarioOld);
                        horarioOld.CodEstado = Constantes.EstadoLibre;
                        context.SaveChanges();

                        context.SaveChanges();
                    }

                    tran.Commit();

                    return Valido;
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("TrasladarCita", ex.Message, null);
                throw;
            }
        }

        public void UpdateTarifa(long IdCita, decimal Tarifa)
        {
            try
            {
                BaseContext context = new BaseContext();
                Citas entity = context.Citas.Find(IdCita);
                entity.Tarifa = Tarifa;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateTarifa", ex.Message, null);
                throw;
            }
        }

        public void Delete(long IdCita, string NomUsu)
        {
            try
            {
                BaseContext context = new BaseContext();
                using(var tran = context.Database.BeginTransaction())
                {
                    Citas entity = context.Citas.Find(IdCita);
                    entity.CodEstado = Constantes.EstadoCancelado;
                    entity.ModificadoPor = NomUsu;
                    entity.FechaModificado = DateTimeOffset.Now;
                    context.SaveChanges();

                    Horarios entityHor = context.Horarios.Find(entity.IdReserva);
                    entityHor.CodEstado = Constantes.EstadoLibre;
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("DeleteCita", ex.Message, null);
                throw;
            }
        }

        public List<Citas> GetAsignadas(long IdPac)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Citas> Lista = (from ci in context.Citas.Where(x => x.IdPaciente == IdPac && x.CodEstado.Equals(Constantes.EstadoAgendado))
                                     join se in context.Servicios on ci.IdServicio equals se.IdServicio
                                     join co in context.Convenios on ci.IdConvenio equals co.IdConvenio
                                     join me in context.Usuarios on ci.IdMedico equals me.IdUsuario
                                     select new Citas()
                                     {
                                         IdCita = ci.IdCita,
                                         Fecha = ci.Fecha,
                                         SFecha = ci.Fecha.ToString("dd/MM/yyyy"),
                                         Cantidad = ci.Cantidad,
                                         IdReserva = ci.IdReserva,
                                         CodEstado = ci.CodEstado,
                                         FechaCreado = ci.FechaCreado,
                                         CreadoPor = ci.CreadoPor,
                                         FechaModificado = ci.FechaModificado,
                                         ModificadoPor = ci.ModificadoPor,
                                         NombreServicio = se.NombreServicio,
                                         NombreConvenio = co.NombreConvenio,
                                         NombreMedico = me.NombreCompleto,
                                         Hora = ci.Hora,
                                     }).OrderByDescending(x => x.Fecha).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetAsignadasCita", ex.Message, null);
                throw;
            }
        }

        public List<Citas> GetAsignadasConvenio(long IdPac, int IdCon)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Citas> Lista = (from ci in context.Citas.Where(x => x.IdPaciente == IdPac && x.IdConvenio == IdCon && x.CodEstado.Equals(Constantes.EstadoAgendado))
                                     join se in context.Servicios on ci.IdServicio equals se.IdServicio
                                     join me in context.Usuarios on ci.IdMedico equals me.IdUsuario
                                     select new Citas()
                                     {
                                         IdCita = ci.IdCita,
                                         Fecha = ci.Fecha,
                                         Hora = ci.Hora,
                                         SFecha = ci.Fecha.ToString("dd/MM/yyyy"),
                                         Cantidad = ci.Cantidad,
                                         IdReserva = ci.IdReserva,
                                         CodEstado = ci.CodEstado,
                                         FechaCreado = ci.FechaCreado,
                                         CreadoPor = ci.CreadoPor,
                                         FechaModificado = ci.FechaModificado,
                                         ModificadoPor = ci.ModificadoPor,
                                         NombreServicio = se.NombreServicio,
                                         NombreMedico = me.NombreCompleto,
                                         Tarifa = ci.Tarifa,
                                     }).OrderByDescending(x => x.Fecha).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetAsignadasCita", ex.Message, null);
                throw;
            }
        }

        public List<Citas> GetAgendaMedica(DateTime FechaIni, DateTime FechaFin, int IdMedico)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Citas> Lista = (from ci in context.Citas.Where(x => x.IdMedico == IdMedico && x.Fecha >= FechaIni && x.Fecha <= FechaFin && !x.CodEstado.Equals(Constantes.EstadoCancelado))
                                     join se in context.Servicios on ci.IdServicio equals se.IdServicio
                                     join co in context.Convenios on ci.IdConvenio equals co.IdConvenio
                                     join pa in context.Pacientes on ci.IdPaciente equals pa.IdPaciente
                                     join ho in context.Horarios on ci.IdReserva equals ho.IdHorario
                                     join es in context.TablasDetalles.Where(x => x.CodTabla.Equals(Constantes.TabEstados)) on ci.CodEstado equals es.CodValor
                                     select new Citas()
                                     {
                                         IdCita = ci.IdCita,
                                         Fecha = ci.Fecha + ho.HoraInicial.TimeOfDay,
                                         SFecha = ci.Fecha.ToString("dd/MM/yyyy"),
                                         Cantidad = ci.Cantidad,
                                         IdReserva = ci.IdReserva,
                                         CodEstado = ci.CodEstado,
                                         FechaCreado = ci.FechaCreado,
                                         CreadoPor = ci.CreadoPor,
                                         FechaModificado = ci.FechaModificado,
                                         ModificadoPor = ci.ModificadoPor,
                                         NombreServicio = se.NombreServicio,
                                         NombreConvenio = co.NombreConvenio,
                                         NombrePaciente = pa.NombrePaciente,
                                         NombreEstado = es.Descripcion,
                                         Identificacion = pa.TipoIden + " " + pa.NumIden,
                                         Telefono = pa.Telefono,
                                         Hora = ho.HoraInicial.ToString("hh:mm tt", new CultureInfo("es-CO")),
                                     }).OrderBy(x => x.Fecha).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetAgendaMedica", ex.Message, null);
                throw;
            }
        }

        public List<Citas> GetMiAgendaFecha(int IdMedico, DateTime Fecha)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Citas> Lista = (from ci in context.Citas.Where(x => x.IdMedico == IdMedico && x.Fecha == Fecha && (x.CodEstado.Equals(Constantes.EstadoAgendado) || x.CodEstado.Equals(Constantes.EstadoConfirmado)))
                                     join se in context.Servicios on ci.IdServicio equals se.IdServicio
                                     join co in context.Convenios on ci.IdConvenio equals co.IdConvenio
                                     join pa in context.Pacientes on ci.IdPaciente equals pa.IdPaciente
                                     join ho in context.Horarios on ci.IdReserva equals ho.IdHorario
                                     join es in context.TablasDetalles.Where(x => x.CodTabla.Equals(Constantes.TabEstados)) on ci.CodEstado equals es.CodValor
                                     select new Citas()
                                     {
                                         IdCita = ci.IdCita,
                                         Fecha = ci.Fecha,
                                         SFecha = ci.Fecha.ToString("dd/MM/yyyy"),
                                         Cantidad = ci.Cantidad,
                                         IdReserva = ci.IdReserva,
                                         CodEstado = ci.CodEstado,
                                         FechaCreado = ci.FechaCreado,
                                         CreadoPor = ci.CreadoPor,
                                         FechaModificado = ci.FechaModificado,
                                         ModificadoPor = ci.ModificadoPor,
                                         NombreServicio = se.NombreServicio,
                                         NombreConvenio = co.NombreConvenio,
                                         NombreEstado = es.Descripcion,
                                         Identificacion = pa.TipoIden + " " + pa.NumIden,
                                         NombrePaciente = pa.NombrePaciente,
                                         Hora = ho.HoraInicial.ToString("hh:mm tt", new CultureInfo("es-CO")),
                                         Tarifa = ci.Tarifa
                                     }).OrderByDescending(x => x.Hora).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetMiAgendaFecha", ex.Message, null);
                throw;
            }
        }

        public void Facturar(Citas obCita, string NomUsu)
        {
            try
            {
                BaseContext context = new BaseContext();
                using (var tran = context.Database.BeginTransaction())
                {

                    CentroAtencion entityCen = context.CentrosAtencions.Find(obCita.IdCentro);
                    entityCen.NoVolante++;
                    context.SaveChanges();

                    Facturacion entityFac = new Facturacion();
                    entityFac.Tipo = "VO";
                    entityFac.TipoDocumento = entityCen.PrefijoVol;
                    entityFac.NumDocumento = entityCen.NoVolante;
                    entityFac.IdConvenio = obCita.IdConvenio;
                    entityFac.IdPaciente = obCita.IdPaciente;
                    entityFac.IdCentro = obCita.IdCentro;
                    entityFac.IdResolucion = 0;
                    entityFac.CodEstado = Constantes.EstadoActivo;
                    entityFac.FechaPago = DateTimeOffset.Now;
                    entityFac.CreadoPor = NomUsu;
                    entityFac.FechaCreado = DateTimeOffset.Now;
                    context.Facturacions.Add(entityFac);
                    context.SaveChanges();

                    entityFac = context.Facturacions.FirstOrDefault(x => x.NumDocumento == entityFac.NumDocumento && x.TipoDocumento.Equals(entityFac.TipoDocumento) && x.IdCentro == entityFac.IdCentro);

                    Citas entityCit = context.Citas.Find(obCita.IdCita);
                    entityCit.CodEstado = Constantes.EstadoConfirmado;
                    entityCit.IdFacturacion = entityFac.IdFacturacion;
                    entityCit.ModificadoPor = NomUsu;
                    entityCit.FechaModificado = DateTimeOffset.Now;
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("FacturarCita", ex.Message, null);
                throw;
            }
        }



        // Excel
        public byte[] ExcelAgendaMedica(string Fi, string Ff, int Im, string Nm)
        {
            try
            {
                DateTime FechaIni = Convert.ToDateTime(Fi);
                DateTime FechaFin = Convert.ToDateTime(Ff);

                List<Citas> Lista = GetAgendaMedica(FechaIni, FechaFin, Im);
                IXLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add(Nm);

                int irow = 1;
                worksheet.Cell(irow, 1).SetValue("Fecha").Style.Font.SetBold(true);
                worksheet.Cell(irow, 2).SetValue("Hora").Style.Font.SetBold(true);
                worksheet.Cell(irow, 3).SetValue("Paciente").Style.Font.SetBold(true);
                worksheet.Cell(irow, 4).SetValue("Identificación").Style.Font.SetBold(true);
                worksheet.Cell(irow, 5).SetValue("Teléfono").Style.Font.SetBold(true);
                worksheet.Cell(irow, 6).SetValue("Convenio").Style.Font.SetBold(true);
                worksheet.Cell(irow, 7).SetValue("Servicio").Style.Font.SetBold(true);

                foreach(Citas c in Lista)
                {
                    irow++;
                    worksheet.Cell(irow, 1).Value = c.SFecha;
                    worksheet.Cell(irow, 2).Value = c.Hora;
                    worksheet.Cell(irow, 3).Value = c.NombrePaciente;
                    worksheet.Cell(irow, 4).Value = c.Identificacion;
                    worksheet.Cell(irow, 5).Value = c.Telefono;
                    worksheet.Cell(irow, 6).Value = c.NombreConvenio;
                    worksheet.Cell(irow, 7).Value = c.NombreServicio;
                }

                MemoryStream ms = new MemoryStream();
                workbook.SaveAs(ms);

                return ms.ToArray();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetAgendaMedica", ex.Message, null);
                throw;
            }
        }

    }
}
