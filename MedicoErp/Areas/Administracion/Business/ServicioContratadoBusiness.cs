using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.Administracion.Business
{
    public class ServicioContratadoBusiness
    {
        public void Creates(List<ServicioContratado> Lista)
        {
            try
            {
                BaseContext context = new BaseContext();
                context.ServiciosContratados.AddRange(Lista);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreatesServicioContratado", ex.Message, null);
                throw;
            }
        }

        public void UpdateTarifa(int IdDetalle, decimal VTarifa)
        {
            try
            {
                BaseContext context = new BaseContext();
                ServicioContratado entity = context.ServiciosContratados.Find(IdDetalle);
                entity.Tarifa = VTarifa;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateTarifa", ex.Message, null);
                throw;
            }
        }

        public void Delete(int IdDetalle)
        {
            try
            {
                BaseContext context = new BaseContext();
                ServicioContratado entity = context.ServiciosContratados.Find(IdDetalle);
                context.ServiciosContratados.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("DeleteServicioContratado", ex.Message, null);
                throw;
            }
        }

        public List<ServicioContratado> GetServiciosContratado(int IdConvenio)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<ServicioContratado> Lista = (from sc in context.ServiciosContratados.Where(x => x.IdConvenio == IdConvenio)
                                                    join s in context.Servicios on sc.IdServicio equals s.IdServicio
                                                    select new ServicioContratado()
                                                    {
                                                        IdDetalle = sc.IdDetalle,
                                                        Servicio = s,
                                                        IdConvenio = sc.IdConvenio,
                                                        IdServicio = sc.IdServicio,
                                                        Tarifa = sc.Tarifa,
                                                    }).OrderBy(x => x.Servicio.NombreServicio).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetServiciosContratado", ex.Message, null);
                throw;
            }
        }

        public List<Servicio> GetServiciosNoContratado(int IdCentro, int IdConvenio)
        {
            try
            {
                BaseContext context = new BaseContext();
                int[] ListSer = context.ServiciosContratados.Where(x => x.IdConvenio == IdConvenio).Select(x => x.IdServicio).ToArray();
                List<Servicio> Lista = context.Servicios.Where(x => x.IdCentro == IdCentro && !ListSer.Contains(x.IdServicio)).OrderBy(x => x.NombreServicio).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetServiciosNoContratado", ex.Message, null);
                throw;
            }
        }


    }
}
