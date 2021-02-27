using MedicoErp.Areas.General.Business;
using MedicoErp.Areas.HistoriaClinica.Entities;
using MedicoErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.HistoriaClinica.Business
{
    public class FormulacionesDetalleBusinessTemp
    {
        public List<FormulacionesDetalleTemp> GetAllByIdUsuario(int IdUsuario)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<FormulacionesDetalleTemp> Lista = context.FormulacionesDetalleTemp.Where(x => x.IdUsuario == IdUsuario).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("FormulacionDetalleTempGet", ex.Message, null);
                throw;
            }
        }

        public void Create(FormulacionesDetalleTemp entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                context.FormulacionesDetalleTemp.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("FormulacionDetalleTempCreate", ex.Message, null);
                throw;
            }
        }

        public void Delete(int IdDetalle)
        {
            try
            {
                BaseContext context = new BaseContext();
                FormulacionesDetalleTemp entity = context.FormulacionesDetalleTemp.Find(IdDetalle);
                context.FormulacionesDetalleTemp.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("FormulacionDetalleTempDelete", ex.Message, null);
                throw;
            }
        }
    }
}
