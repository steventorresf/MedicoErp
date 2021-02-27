using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.Administracion.Business
{
    public class ServicioBusiness
    {
        public void Create(Servicio entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                context.Servicios.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateServicio", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdServicio, Servicio entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                Servicio obSer = context.Servicios.Find(IdServicio);
                obSer.CodigoRef = entity.CodigoRef;
                obSer.NombreServicio = entity.NombreServicio;
                obSer.IdEspecialidad = entity.IdEspecialidad;
                obSer.IdClaseServicio = entity.IdClaseServicio;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateServicio", ex.Message, null);
                throw;
            }
        }

        public void UpdateEstado(int IdServicio, bool Activo)
        {
            try
            {
                BaseContext context = new BaseContext();
                Servicio obSer = context.Servicios.Find(IdServicio);
                obSer.Activo = Activo;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateEstadoServicio", ex.Message, null);
                throw;
            }
        }

        public List<Servicio> GetServicios(int IdCentro)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Servicio> Lista = (from se in context.Servicios.Where(x => x.IdCentro == IdCentro && x.Activo)
                                         join es in context.Especialidades on se.IdEspecialidad equals es.IdEspecialidad
                                         join cs in context.ClasesServicios on se.IdClaseServicio equals cs.IdClaseServicio
                                         select new Servicio()
                                         {
                                             IdServicio = se.IdServicio,
                                             NombreServicio = se.NombreServicio,
                                             IdEspecialidad = se.IdEspecialidad,
                                             IdClaseServicio = se.IdClaseServicio,
                                             CodigoRef = se.CodigoRef,
                                             Activo = se.Activo,
                                             IdCentro = se.IdCentro,
                                             Especialidad = es,
                                             ClaseServicio = cs,
                                         }).OrderBy(x => x.NombreServicio).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetServicios", ex.Message, null);
                throw;
            }
        }
    }
}
