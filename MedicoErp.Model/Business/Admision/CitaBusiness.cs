using ClosedXML.Excel;
using MedicoErp.Model.Abstract.Admision;
using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Common;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.Admision;
using MedicoErp.Model.Entities.General;
using Newtonsoft.Json.Linq;
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


        public long Create(Cita entity)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    long idCita = -1;

                    Horario horario = context.Horario.Find(entity.IdReserva);
                    if (horario.CodEstado.Equals(Constantes.EstadoAgendado))
                    {
                        idCita = -1;
                    }
                    else
                    {
                        Secuencia entitySec = context.Secuencia.FirstOrDefault(x => x.IdCentro == entity.IdCentro && x.TipoDoc.Equals("CI"));
                        entitySec.NumDoc++;
                        context.SaveChanges();
                        
                        horario.CodEstado = Constantes.EstadoAgendado;

                        entity.NoCita = entitySec.NumDoc;
                        entity.Hora = horario.HoraInicial.ToString("hh:mm tt", new CultureInfo("en-US"));
                        entity.FechaCreado = DateTimeOffset.Now;
                        context.Cita.Add(entity);
                        context.SaveChanges();

                        idCita = context.Cita.FirstOrDefault(x => x.NoCita == entity.NoCita && x.IdCentro == entity.IdCentro).IdCita;
                    }

                    tran.Commit();

                    return idCita;
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
                        long IdHorarioOld = Convert.ToInt64(obCita.IdReserva);

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

        public void UpdateTarifaDescuento(JObject data)
        {
            try
            {
                long IdCita = data["idCita"].ToObject<long>();
                decimal Tarifa = data["tarifa"].ToObject<decimal>();
                decimal Descuento = data["descuento"].ToObject<decimal>();

                Cita entity = context.Cita.Find(IdCita);
                entity.Tarifa = Tarifa;
                entity.Descuento = Descuento;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateTarifaDescuento", ex, null);
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
                                        Descuento = ci.Descuento,
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
                List<Cita> Lista = (from ci in context.Cita.Where(x => x.IdMedico == IdMedico && x.Fecha == Fecha && !x.CodEstado.Equals(Constantes.EstadoCancelado))
                                    join se in context.Servicio on ci.IdServicio equals se.IdServicio
                                    join co in context.Convenio on ci.IdConvenio equals co.IdConvenio
                                    join pa in context.Paciente on ci.IdPaciente equals pa.IdPaciente
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
                                        Hora = ci.Hora,
                                        Tarifa = ci.Tarifa,
                                        Descuento = ci.Descuento,
                                    }).OrderBy(x => x.IdReserva).OrderBy(x => x.Fecha).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetMiAgendaFecha", ex, null);
                throw;
            }
        }

        public Cita GetImpresion(int IdCita)
        {
            try
            {
                Cita entity = (from ci in context.Cita.Where(x => x.IdCita == IdCita)
                               join ce in context.CentroAtencion on ci.IdCentro equals ce.IdCentro
                               join pa in context.Paciente on ci.IdPaciente equals pa.IdPaciente
                               join co in context.Convenio on ci.IdConvenio equals co.IdConvenio
                               join se in context.Servicio on ci.IdServicio equals se.IdServicio
                               join me in context.Usuario on ci.IdMedico equals me.IdUsuario
                               select new Cita()
                               {
                                   IdCita = ci.IdCita,
                                   NoCita = ci.NoCita,
                                   NombrePaciente = pa.NombrePaciente,
                                   Identificacion = pa.TipoIden + " " + pa.NumIden,
                                   NombreConvenio = co.NombreConvenio,
                                   NombreServicio = se.CodigoRef + " - " + se.NombreServicio,
                                   NombreCentro = ce.NombreCentro,
                                   DireccionCentro = ce.Direccion,
                                   NombreMedico = me.NombreCompleto,
                                   SFecha = ci.Fecha.ToString("dd/MM/yyyy"),
                                   Hora = ci.Hora,
                               }).FirstOrDefault();
                return entity;
            }
            catch(Exception ex)
            {
                errorBusiness.Create("GetCitaImpresion", ex, null);
                throw;
            }
        }

        public void Facturar(Cita obCita, string NomUsu)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {

                    Secuencia entitySec = context.Secuencia.FirstOrDefault(x => x.IdCentro == obCita.IdCentro && x.TipoDoc.Equals("VS"));
                    entitySec.NumDoc++;
                    context.SaveChanges();

                    Facturacion entityFac = new Facturacion();
                    entityFac.Tipo = "VO";
                    entityFac.TipoDocumento = entitySec.TipoDoc;
                    entityFac.NumDocumento = entitySec.NumDoc;
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



        // Informes
        public List<Cita> GetActividades(string FechaIni, string FechaFin, int IdCentro)
        {
            try
            {
                DateTime FechaInicial = Convert.ToDateTime(FechaIni);
                DateTime FechaFinal = Convert.ToDateTime(FechaFin);

                List<Cita> Lista = (from ci in context.Cita.Where(x => x.Fecha >= FechaInicial && x.Fecha <= FechaFinal && x.IdCentro == IdCentro && !x.CodEstado.Equals(Constantes.EstadoCancelado))
                                    join pa in context.Paciente on ci.IdPaciente equals pa.IdPaciente
                                    join se in context.Servicio on ci.IdServicio equals se.IdServicio
                                    join cs in context.ClaseServicio on se.IdClaseServicio equals cs.IdClaseServicio
                                    join co in context.Convenio on ci.IdConvenio equals co.IdConvenio
                                    join cr in context.CentroAtencion on ci.IdCentroRemision equals cr.IdCentro
                                    join me in context.Usuario on ci.IdMedico equals me.IdUsuario into LeftJoinUs
                                    from LJMe in LeftJoinUs.DefaultIfEmpty()
                                    join fa in context.Facturacion on ci.IdFacturacion equals fa.IdFacturacion into LeftJoinFa
                                    from LJFa in LeftJoinFa.DefaultIfEmpty()
                                    select new Cita()
                                    {
                                        Fecha = ci.Fecha,
                                        TipoDocumento = LJFa == null ? "" : LJFa.TipoDocumento,
                                        NumDocumento = LJFa == null ? "" : LJFa.NumDocumento.ToString(),
                                        NombreCentro = cr.NombreCentro,
                                        TipoIdentificacion = pa.TipoIden,
                                        Identificacion = pa.NumIden,
                                        NombrePaciente = pa.NombrePaciente,
                                        Telefono = pa.Telefono,
                                        NombreConvenio = co.NombreConvenio,
                                        NombreMedico = LJMe == null ? "" : LJMe.NombreCompleto,
                                        CodigoRef = se.CodigoRef,
                                        NombreClaseServicio = cs.NombreClaseServicio,
                                        NombreServicio = se.NombreServicio,
                                        Cantidad = ci.Cantidad,
                                        Tarifa = ci.Tarifa - ci.Descuento,
                                        Descuento = ci.Descuento,
                                        VrTotal = ci.Cantidad * (ci.Tarifa - ci.Descuento),
                                    }).OrderBy(x => x.Fecha).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetActividades", ex, null);
                throw;
            }
        }
    }
}
