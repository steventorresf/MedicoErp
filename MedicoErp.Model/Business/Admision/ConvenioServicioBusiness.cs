using MedicoErp.Model.Abstract.Admision;
using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.Admision;
using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Business.Admision
{
    public class ConvenioServicioBusiness : IConvenioServicioBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public ConvenioServicioBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public void Creates(List<ConvenioServicio> Lista)
        {
            try
            {
                context.ConvenioServicio.AddRange(Lista);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreatesServicioContratado", ex, null);
                throw;
            }
        }

        public void UpdateTarifa(int IdDetalle, decimal VTarifa)
        {
            try
            {
                ConvenioServicio entity = context.ConvenioServicio.Find(IdDetalle);
                entity.Tarifa = VTarifa;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateTarifa", ex, null);
                throw;
            }
        }

        public void Delete(int IdDetalle)
        {
            try
            {
                ConvenioServicio entity = context.ConvenioServicio.Find(IdDetalle);
                context.ConvenioServicio.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("DeleteServicioContratado", ex, null);
                throw;
            }
        }

        public ConvenioServicio GetByIdServicio(int IdConvenio, int IdServicio)
        {
            try
            {
                ConvenioServicio entity = context.ConvenioServicio.FirstOrDefault(x => x.IdServicio == IdServicio && x.IdConvenio == IdConvenio);
                return entity;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetByIdServicio", ex, null);
                throw;
            }
        }

        public List<ConvenioServicio> GetServiciosContratado(int IdConvenio)
        {
            try
            {
                List<ConvenioServicio> Lista = (from sc in context.ConvenioServicio.Where(x => x.IdConvenio == IdConvenio)
                                                join s in context.Servicio on sc.IdServicio equals s.IdServicio
                                                select new ConvenioServicio()
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
                errorBusiness.Create("GetServiciosContratado", ex, null);
                throw;
            }
        }

        public List<Servicio> GetServiciosNoContratado(int IdCentro, int IdConvenio)
        {
            try
            {
                int[] ListSer = context.ConvenioServicio.Where(x => x.IdConvenio == IdConvenio).Select(x => x.IdServicio).ToArray();
                List<Servicio> Lista = context.Servicio.Where(x => x.IdCentro == IdCentro && !ListSer.Contains(x.IdServicio)).OrderBy(x => x.NombreServicio).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetServiciosNoContratado", ex, null);
                throw;
            }
        }
    }
}
