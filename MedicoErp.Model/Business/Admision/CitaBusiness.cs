using ClosedXML.Excel;
using MedicoErp.Model.Abstract.Admision;
using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Common;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.Admision;
using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Business.Admision
{
    public class CitaBusiness : ICitaBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public CitaBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public bool Create(Cita entity)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    bool Valido = true;

                    Horario horario = context.Horario.Find(entity.IdReserva);
                    if (horario.CodEstado.Equals(Constantes.EstadoAgendado))
                    {
                        Valido = false;
                    }
                    else
                    {
                        horario.CodEstado = Constantes.EstadoAgendado;

                        entity.Hora = horario.HoraInicial.ToString("hh:mm tt", new CultureInfo("en-US"));
                        entity.FechaCreado = DateTimeOffset.Now;
                        context.Cita.Add(entity);
                        context.SaveChanges();
                    }

                    tran.Commit();

                    return Valido;
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateCita", ex, null);
                throw;
            }
        }

        public bool Update(long IdCita, Cita entity)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    bool Valido = true;

                    Horario horarioNew = context.Horario.Find(entity.IdReserva);
                    if (horarioNew.CodEstado.Equals(Constantes.EstadoAgendado))
                    {
                        Valido = false;
                    }
                    else
                    {
                        horarioNew.CodEstado = Constantes.EstadoAgendado;
                        context.SaveChanges();

                        Cita obCita = context.Cita.Find(IdCita);
                        long IdHorarioOld = obCita.IdReserva;

                        obCita.IdReserva = horarioNew.IdHorario;
                        obCita.Fecha = horarioNew.Fecha;
                        obCita.Hora = horarioNew.HoraInicial.ToString("hh:mm tt", new CultureInfo("en-US"));
                        obCita.ModificadoPor = entity.ModificadoPor;
                        obCita.FechaModificado = DateTimeOffset.Now;
                        context.SaveChanges();

                        Horario horarioOld = context.Horario.Find(IdHorarioOld);
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
                errorBusiness.Create("TrasladarCita", ex, null);
                throw;
            }
        }

        public void UpdateTarifa(long IdCita, decimal Tarifa)
        {
            try
            {
                Cita entity = context.Cita.Find(IdCita);
                entity.Tarifa = Tarifa;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateTarifa", ex, null);
                throw;
            }
        }

        public void Delete(long IdCita, string NomUsu)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    Cita entity = context.Cita.Find(IdCita);
                    entity.CodEstado = Constantes.EstadoCancelado;
                    entity.ModificadoPor = NomUsu;
                    entity.FechaModificado = DateTimeOffset.Now;
                    context.SaveChanges();

                    Horario entityHor = context.Horario.Find(entity.IdReserva);
                    entityHor.CodEstado = Constantes.EstadoLibre;
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("DeleteCita", ex, null);
                throw;
            }
        }

        public List<Cita> GetAsignadas(long IdPac)
        {
            try
            {
                List<Cita> Lista = (from ci in context.Cita.Where(x => x.IdPaciente == IdPac && x.CodEstado.Equals(Constantes.EstadoAgendado))
                                    join se in context.Servicio on ci.IdServicio equals se.IdServicio
                                    join co in context.Convenio on ci.IdConvenio equals co.IdConvenio
                                    join me in context.Usuario on ci.IdMedico equals me.IdUsuario
                                    select new Cita()
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
                errorBusiness.Create("GetAsignadasCita", ex, null);
                throw;
            }
        }

        public List<Cita> GetAsignadasConvenio(long IdPac, int IdCon)
        {
            try
            {
                List<Cita> Lista = (from ci in context.Cita.Where(x => x.IdPaciente == IdPac && x.IdConvenio == IdCon && x.CodEstado.Equals(Constantes.EstadoAgendado))
                                    join se in context.Servicio on ci.IdServicio equals se.IdServicio
                                    join me in context.Usuario on ci.IdMedico equals me.IdUsuario
                                    select new Cita()
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
                errorBusiness.Create("GetAsignadasCita", ex, null);
                throw;
            }
        }

        public List<Cita> GetAgendaMedica(DateTime FechaIni, DateTime FechaFin, int IdMedico)
        {
            try
            {
                List<Cita> Lista = (from ci in context.Cita.Where(x => x.IdMedico == IdMedico && x.Fecha >= FechaIni && x.Fecha <= FechaFin && !x.CodEstado.Equals(Constantes.EstadoCancelado))
                                    join se in context.Servicio on ci.IdServicio equals se.IdServicio
                                    join co in context.Convenio on ci.IdConvenio equals co.IdConvenio
                                    join pa in context.Paciente on ci.IdPaciente equals pa.IdPaciente
                                    join ho in context.Horario on ci.IdReserva equals ho.IdHorario
                                    join es in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabEstados)) on ci.CodEstado equals es.CodValor
                                    select new Cita()
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
                errorBusiness.Create("GetAgendaMedica", ex, null);
                throw;
            }
        }

        public List<Cita> GetMiAgendaFecha(int IdMedico, DateTime Fecha)
        {
            try
            {
                List<Cita> Lista = (from ci in context.Cita.Where(x => x.IdMedico == IdMedico && x.Fecha == Fecha && (x.CodEstado.Equals(Constantes.EstadoAgendado) || x.CodEstado.Equals(Constantes.EstadoConfirmado)))
                                    join se in context.Servicio on ci.IdServicio equals se.IdServicio
                                    join co in context.Convenio on ci.IdConvenio equals co.IdConvenio
                                    join pa in context.Paciente on ci.IdPaciente equals pa.IdPaciente
                                    join ho in context.Horario on ci.IdReserva equals ho.IdHorario
                                    join es in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabEstados)) on ci.CodEstado equals es.CodValor
                                    select new Cita()
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
                errorBusiness.Create("GetMiAgendaFecha", ex, null);
                throw;
            }
        }

        public void Facturar(Cita obCita, string NomUsu)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {

                    CentroAtencion entityCen = context.CentroAtencion.Find(obCita.IdCentro);
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
                    context.Facturacion.Add(entityFac);
                    context.SaveChanges();

                    entityFac = context.Facturacion.FirstOrDefault(x => x.NumDocumento == entityFac.NumDocumento && x.TipoDocumento.Equals(entityFac.TipoDocumento) && x.IdCentro == entityFac.IdCentro);

                    Cita entityCit = context.Cita.Find(obCita.IdCita);
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
                errorBusiness.Create("FacturarCita", ex, null);
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

                List<Cita> Lista = GetAgendaMedica(FechaIni, FechaFin, Im);
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

                foreach (Cita c in Lista)
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
                errorBusiness.Create("GetAgendaMedica", ex, null);
                throw;
            }
        }
    }
}
