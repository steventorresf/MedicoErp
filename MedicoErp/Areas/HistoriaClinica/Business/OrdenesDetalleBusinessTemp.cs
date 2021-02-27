using MedicoErp.Areas.General.Business;
using MedicoErp.Areas.HistoriaClinica.Entities;
using MedicoErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.HistoriaClinica.Business
{
    public class OrdenesDetalleBusinessTemp
    {
        public List<OrdenesDetalleTemp> GetAllByIdUsuario(int IdUsuario)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<OrdenesDetalleTemp> Lista = (from orddet in context.OrdenesDetalleTemp.Where(x => x.IdUsuario == IdUsuario)
                                                  join ser in context.Servicios on orddet.IdServicio equals ser.IdServicio
                                                  select new OrdenesDetalleTemp()
                                                  {
                                                      IdDetalle = orddet.IdDetalle,
                                                      IdUsuario = orddet.IdUsuario,
                                                      IdServicio = orddet.IdServicio,
                                                      Cantidad = orddet.Cantidad,
                                                      NombreServicio = ser.NombreServicio
                                                  }).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("OrdenDetalleTempGet", ex.Message, null);
                throw;
            }
        }

        public void Create(OrdenesDetalleTemp entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                context.OrdenesDetalleTemp.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("OrdenDetalleTempCreate", ex.Message, null);
                throw;
            }
        }

        public void Delete(int IdDetalle)
        {
            try
            {
                BaseContext context = new BaseContext();
                OrdenesDetalleTemp entity = context.OrdenesDetalleTemp.Find(IdDetalle);
                context.OrdenesDetalleTemp.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("OrdenDetalleTempDelete", ex.Message, null);
                throw;
            }
        }
    }
}
