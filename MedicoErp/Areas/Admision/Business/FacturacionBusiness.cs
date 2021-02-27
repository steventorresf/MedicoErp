using MedicoErp.Areas.Administracion.Business;
using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.Admision.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Models;
using MedicoErp.Utiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.Admision.Business
{
    public class FacturacionBusiness
    {
        public int CreateByFacturacion(JObject data)
        {
            try
            {
                Facturacion entity = data["entity"].ToObject<Facturacion>();
                List<Citas> listaCitas = data["listaCitas"].ToObject<List<Citas>>();
                long[] IdsCita = listaCitas.Select(x => x.IdCita).ToArray();

                BaseContext context = new BaseContext();
                using(var tran = context.Database.BeginTransaction())
                {
                    CentroAtencion entityCen = context.CentrosAtencions.Find(entity.IdCentro);

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
                    context.Facturacions.Add(entity);
                    context.SaveChanges();

                    Facturacion obFact = context.Facturacions.FirstOrDefault(x => x.NumDocumento == entity.NumDocumento && x.TipoDocumento.Equals(entity.TipoDocumento));

                    List<Citas> ListaCitas = context.Citas.Where(x => x.IdPaciente == entity.IdPaciente && IdsCita.Contains(x.IdCita)).ToList();
                    foreach (Citas c in ListaCitas)
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
                ErroresBusiness.Create("CreateFacturacion", ex.Message, null);
                throw;
            }
        }


        public Facturacion GetFacturacionImpresion(int IdFacturacion)
        {
            try
            {
                BaseContext context = new BaseContext();
                Facturacion entity = (from fac in context.Facturacions.Where(x => x.IdFacturacion == IdFacturacion)
                                      join pac in context.Pacientes on fac.IdPaciente equals pac.IdPaciente
                                      join con in context.Convenios on fac.IdConvenio equals con.IdConvenio
                                      join cen in context.CentrosAtencions on fac.IdCentro equals cen.IdCentro
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

                entity.ListaCitas = (from ci in context.Citas.Where(x => x.IdFacturacion == IdFacturacion)
                                     join se in context.Servicios on ci.IdServicio equals se.IdServicio
                                     join me in context.Usuarios on ci.IdMedico equals me.IdUsuario
                                     select new Citas()
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
            catch(Exception ex)
            {
                ErroresBusiness.Create("GetFacturacionImpresion", ex.Message, null);
                throw;
            }
        }

    }
}
