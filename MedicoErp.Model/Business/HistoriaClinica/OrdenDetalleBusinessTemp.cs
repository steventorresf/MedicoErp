using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.HistoriaClinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Business.HistoriaClinica
{
    public class OrdenDetalleBusinessTemp : IOrdenDetalleBusinessTemp
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public OrdenDetalleBusinessTemp(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public void Create(OrdenDetalleTemp entity)
        {
            try
            {
                context.OrdenDetalleTemp.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("OrdenDetalleTempCreate", ex, null);
                throw;
            }
        }

        public void Update(int IdDetalle, OrdenDetalleTemp entity)
        {
            try
            {
                OrdenDetalleTemp ob = context.OrdenDetalleTemp.Find(IdDetalle);
                ob.Cantidad = entity.Cantidad;
                ob.Tarifa = entity.Tarifa;
                ob.Descuento = entity.Descuento;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("OrdenDetalleTempCreate", ex, null);
                throw;
            }
        }

        public void Delete(int IdDetalle)
        {
            try
            {
                OrdenDetalleTemp entity = context.OrdenDetalleTemp.Find(IdDetalle);
                context.OrdenDetalleTemp.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("OrdenDetalleTempDelete", ex, null);
                throw;
            }
        }

        public List<OrdenDetalleTemp> GetAllByIdUsuario(int IdUsuario)
        {
            try
            {
                List<OrdenDetalleTemp> Lista = (from orddet in context.OrdenDetalleTemp.Where(x => x.IdUsuario == IdUsuario)
                                                join ser in context.Servicio on orddet.IdServicio equals ser.IdServicio
                                                select new OrdenDetalleTemp()
                                                {
                                                    IdDetalle = orddet.IdDetalle,
                                                    IdUsuario = orddet.IdUsuario,
                                                    IdServicio = orddet.IdServicio,
                                                    Cantidad = orddet.Cantidad,
                                                    Tarifa = orddet.Tarifa,
                                                    Descuento = orddet.Descuento,
                                                    NombreServicio = ser.NombreServicio
                                                }).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("OrdenDetalleTempGet", ex, null);
                throw;
            }
        }

    }
}
