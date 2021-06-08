using MedicoErp.Model.Abstract.Admision;
using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Common;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.Admision;
using MedicoErp.Model.Entities.General;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Business.Admision
{
    public class FacturacionBusiness : IFacturacionBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public FacturacionBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public int CreateByFacturacion(JObject data)
        {
            try
            {
                Facturacion entity = data["entity"].ToObject<Facturacion>();
                List<Cita> listaCitas = data["listaCitas"].ToObject<List<Cita>>();
                long[] IdsCita = listaCitas.Select(x => x.IdCita).ToArray();

                using (var tran = context.Database.BeginTransaction())
                {
                    if (entity.Tipo.Equals(Constantes.FactFactura))
                    {

                    }
                    else
                    {
                        Secuencia entitySec = context.Secuencia.FirstOrDefault(x => x.IdCentro == entity.IdCentro && x.TipoDoc.Equals("VS"));
                        entitySec.NumDoc++;
                        context.SaveChanges();

                        entity.TipoDocumento = entitySec.TipoDoc;
                        entity.NumDocumento = entitySec.NumDoc;
                    }

                    entity.FechaPago = DateTimeOffset.Now;
                    entity.FechaCreado = DateTimeOffset.Now;
                    context.Facturacion.Add(entity);
                    context.SaveChanges();

                    Facturacion obFact = context.Facturacion.FirstOrDefault(x => x.NumDocumento == entity.NumDocumento && x.TipoDocumento.Equals(entity.TipoDocumento));

                    List<Cita> ListaCitas = context.Cita.Where(x => x.IdPaciente == entity.IdPaciente && IdsCita.Contains(x.IdCita)).ToList();
                    foreach (Cita c in ListaCitas)
                    {
                        c.CodEstado = Constantes.EstadoConfirmado;
                        c.IdFacturacion = obFact.IdFacturacion;
                        c.NombreAcomp = obFact.NombreAcomp;
                        c.TelefonoAcomp = obFact.TelefonoAcomp;
                    }
                    context.SaveChanges();

                    tran.Commit();
                    return obFact.IdFacturacion;
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateFacturacion", ex, null);
                throw;
            }
        }

        public int CreateByFacturacionSinCita(JObject data)
        {
            try
            {
                Facturacion entity = data["dataEnc"].ToObject<Facturacion>();
                List<Cita> listaCitas = data["dataDet"].ToObject<List<Cita>>();

                using (var tran = context.Database.BeginTransaction())
                {
                    if (entity.Tipo.Equals(Constantes.FactFactura))
                    {

                    }
                    else
                    {
                        Secuencia entitySec = context.Secuencia.FirstOrDefault(x => x.IdCentro == entity.IdCentro && x.TipoDoc.Equals("VS"));
                        entitySec.NumDoc++;
                        context.SaveChanges();

                        entity.TipoDocumento = entitySec.TipoDoc;
                        entity.NumDocumento = entitySec.NumDoc;
                    }

                    entity.FechaPago = DateTimeOffset.Now;
                    entity.FechaCreado = DateTimeOffset.Now;
                    context.Facturacion.Add(entity);
                    context.SaveChanges();

                    Secuencia entitySecCit = context.Secuencia.FirstOrDefault(x => x.IdCentro == entity.IdCentro && x.TipoDoc.Equals("CI"));
                    Facturacion obFact = context.Facturacion.FirstOrDefault(x => x.NumDocumento == entity.NumDocumento && x.TipoDocumento.Equals(entity.TipoDocumento));
                    foreach (Cita c in listaCitas)
                    {
                        entitySecCit.NumDoc++;
                        c.IdFacturacion = obFact.IdFacturacion;
                        c.NoCita = entitySecCit.NumDoc;
                        c.IdReserva = null;
                        c.FechaCreado = DateTimeOffset.Now;

                        ServicioOrdenado entitySerOrd = context.ServicioOrdenado.FirstOrDefault(x => x.IdServicioOrdenado == c.IdServicioOrdenado);
                        entitySerOrd.IdFacturacion = obFact.IdFacturacion;
                        entitySerOrd.ModificadoPor = entity.CreadoPor;
                        entitySerOrd.FechaModificado = DateTimeOffset.Now;
                        context.SaveChanges();
                    }

                    context.Cita.AddRange(listaCitas);
                    context.SaveChanges();

                    tran.Commit();
                    return obFact.IdFacturacion;
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateFacturacion", ex, null);
                throw;
            }
        }

        public int GetIdDocumento(JObject data)
        {
            try
            {
                int IdFacturacion = -1;

                string TipoDocumento = data["tipoDoc"].ToObject<string>();
                long NumeroDocumento = data["numDoc"].ToObject<int>();
                int IdCentro = data["idCentro"].ToObject<int>();

                Facturacion entity = context.Facturacion.FirstOrDefault(x => x.NumDocumento == NumeroDocumento && x.TipoDocumento.Equals(TipoDocumento) && x.IdCentro == IdCentro);
                if (entity != null)
                {
                    IdFacturacion = entity.IdFacturacion;
                }

                return IdFacturacion;
            }
            catch(Exception ex)
            {
                errorBusiness.Create("GetIdDocumentoFacturacion", ex, null);
                throw;
            }
        }

        public List<Facturacion> GetAllByIdPaciente(long IdPaciente)
        {
            try
            {
                List<Facturacion> Lista = (from fa in context.Facturacion.Where(x => x.IdPaciente == IdPaciente)
                                           join co in context.Convenio on fa.IdConvenio equals co.IdConvenio
                                           select new Facturacion()
                                           {
                                               IdFacturacion = fa.IdFacturacion,
                                               TipoDocumento = fa.TipoDocumento,
                                               NumDocumento = fa.NumDocumento,
                                               FechaPago = fa.FechaPago,
                                               sFechaPago = fa.FechaPago.ToString("dd/MM/yyyy"),
                                               IdConvenio = fa.IdConvenio,
                                               Convenio = co,
                                               CreadoPor = fa.CreadoPor,
                                               CodEstado = fa.CodEstado,
                                           }).OrderBy(x => x.FechaPago).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllByIdPacienteFacturacion", ex, null);
                throw;
            }
        }

        public Facturacion GetFacturacionImpresion(int IdFacturacion)
        {
            try
            {
                Facturacion entity = (from fac in context.Facturacion.Where(x => x.IdFacturacion == IdFacturacion)
                                      join pac in context.Paciente on fac.IdPaciente equals pac.IdPaciente
                                      join con in context.Convenio on fac.IdConvenio equals con.IdConvenio
                                      join tus in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabTipoUsuario)) on con.CodTipoUsuario equals tus.CodValor
                                      join med in context.Usuario on fac.IdMedico equals med.IdUsuario
                                      join cer in context.CentroAtencion on fac.IdCentroRemision equals cer.IdCentro
                                      select new Facturacion()
                                      {
                                          IdFacturacion = fac.IdFacturacion,
                                          IdCentro = fac.IdCentro,
                                          IdCentroRemision = fac.IdCentroRemision,
                                          IdPaciente = pac.IdPaciente,
                                          IdConvenio = fac.IdConvenio,
                                          FechaPago = fac.FechaPago,
                                          FechaCreado = fac.FechaCreado,
                                          CreadoPor = fac.CreadoPor,
                                          FechaModificado = fac.FechaModificado,
                                          ModificadoPor = fac.ModificadoPor,
                                          Tipo = fac.Tipo,
                                          TipoDocumento = fac.TipoDocumento,
                                          NumDocumento = fac.NumDocumento,
                                          CodEstado = fac.CodEstado,
                                          IdResolucion = fac.IdResolucion,
                                          MotivoAnu = fac.MotivoAnu,
                                          Medico = med,
                                          CentroAtencionNombre = cer.Externo ? cer.NombreCentro : med.NombreCompleto,
                                          CentroAtencionNit = cer.Externo ? cer.NitCentro : med.NumIden,
                                          CentroAtencionDireccion = cer.Externo ? cer.Direccion : med.Direccion,
                                          CentroAtencionTelefono = cer.Externo ? cer.Telefono : med.Telefono,
                                          Paciente = pac,
                                          Convenio = con,
                                          sFechaPago = fac.FechaPago.ToString("dd/MM/yyyy"),
                                          sFechaNacimiento = pac.FechaNacimiento.ToString("dd/MM/yyyy"),
                                          TipoUsuario = tus.Descripcion,
                                      }).FirstOrDefault();

                entity.ListaCitas = (from ci in context.Cita.Where(x => x.IdFacturacion == IdFacturacion)
                                     join se in context.Servicio on ci.IdServicio equals se.IdServicio
                                     join me in context.Usuario on ci.IdMedico equals me.IdUsuario into LeftJoin
                                     from LF in LeftJoin.DefaultIfEmpty()
                                     select new Cita()
                                     {
                                         IdCita = ci.IdCita,
                                         IdServicio = ci.IdServicio,
                                         CodigoRef = se.CodigoRef,
                                         NombreServicio = se.NombreServicio,
                                         NombreMedico = LF != null ? LF.NombreCompleto : "",
                                         Fecha = ci.Fecha,
                                         SFecha = ci.Fecha.ToString("dd/MM/yyyy"),
                                         Hora = ci.Hora,
                                         Cantidad = ci.Cantidad,
                                         Tarifa = ci.Tarifa,
                                         Descuento = ci.Descuento,
                                         VrTotal = ci.Tarifa - ci.Descuento,
                                     }).ToList();
                return entity;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetFacturacionImpresion", ex, null);
                throw;
            }
        }
    }
}
