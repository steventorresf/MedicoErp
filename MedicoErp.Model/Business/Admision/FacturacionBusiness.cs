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
                    CentroAtencion entityCen = context.CentroAtencion.Find(entity.IdCentro);

                    if (entity.Tipo.Equals(Constantes.FactFactura))
                    {

                    }
                    else
                    {
                        entityCen.NoVolante++;
                        entity.TipoDocumento = entityCen.PrefijoVol;
                        entity.NumDocumento = entityCen.NoVolante;
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


        public Facturacion GetFacturacionImpresion(int IdFacturacion)
        {
            try
            {
                Facturacion entity = (from fac in context.Facturacion.Where(x => x.IdFacturacion == IdFacturacion)
                                      join pac in context.Paciente on fac.IdPaciente equals pac.IdPaciente
                                      join con in context.Convenio on fac.IdConvenio equals con.IdConvenio
                                      join cen in context.CentroAtencion on fac.IdCentro equals cen.IdCentro
                                      select new Facturacion()
                                      {
                                          IdFacturacion = fac.IdFacturacion,
                                          IdCentro = fac.IdCentro,
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
                                          CentroAtencion = cen,
                                          Paciente = pac,
                                          Convenio = con,
                                      }).FirstOrDefault();

                entity.ListaCitas = (from ci in context.Cita.Where(x => x.IdFacturacion == IdFacturacion)
                                     join se in context.Servicio on ci.IdServicio equals se.IdServicio
                                     join me in context.Usuario on ci.IdMedico equals me.IdUsuario
                                     select new Cita()
                                     {
                                         IdCita = ci.IdCita,
                                         IdServicio = ci.IdServicio,
                                         NombreServicio = se.NombreServicio,
                                         NombreMedico = me.NombreCompleto,
                                         Fecha = ci.Fecha,
                                         SFecha = ci.Fecha.ToString("dd/MM/yyyy"),
                                         Hora = ci.Hora,
                                         Cantidad = ci.Cantidad,
                                         Tarifa = ci.Tarifa,
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
