using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Business.General
{
    public class ServicioBusiness : IServicioBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public ServicioBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public void Create(Servicio entity)
        {
            try
            {
                context.Servicio.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateServicio", ex, null);
                throw;
            }
        }

        public void Update(int IdServicio, Servicio entity)
        {
            try
            {
                Servicio obSer = context.Servicio.Find(IdServicio);
                obSer.CodigoRef = entity.CodigoRef;
                obSer.NombreServicio = entity.NombreServicio;
                obSer.IdEspecialidad = entity.IdEspecialidad;
                obSer.IdClaseServicio = entity.IdClaseServicio;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateServicio", ex, null);
                throw;
            }
        }

        public void UpdateEstado(int IdServicio, bool Activo)
        {
            try
            {
                Servicio obSer = context.Servicio.Find(IdServicio);
                obSer.Activo = Activo;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateEstadoServicio", ex, null);
                throw;
            }
        }

        public List<Servicio> GetServicios(int IdCentro)
        {
            try
            {
                List<Servicio> Lista = (from se in context.Servicio.Where(x => x.IdCentro == IdCentro && x.Activo)
                                        join cs in context.ClaseServicio on se.IdClaseServicio equals cs.IdClaseServicio
                                        select new Servicio()
                                        {
                                            IdServicio = se.IdServicio,
                                            NombreServicio = se.NombreServicio,
                                            IdEspecialidad = se.IdEspecialidad,
                                            IdClaseServicio = se.IdClaseServicio,
                                            CodigoRef = se.CodigoRef,
                                            Activo = se.Activo,
                                            IdCentro = se.IdCentro,                                            
                                            ClaseServicio = cs,
                                        }).OrderBy(x => x.NombreServicio).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetServicios", ex, null);
                throw;
            }
        }
    }
}
