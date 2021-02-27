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
    public class FormulacionDetalleBusinessTemp : IFormulacionDetalleBusinessTemp
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public FormulacionDetalleBusinessTemp(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public List<FormulacionDetalleTemp> GetAllByIdUsuario(int IdUsuario)
        {
            try
            {
                List<FormulacionDetalleTemp> Lista = context.FormulacionDetalleTemp.Where(x => x.IdUsuario == IdUsuario).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("FormulacionDetalleTempGet", ex, null);
                throw;
            }
        }

        public void Create(FormulacionDetalleTemp entity)
        {
            try
            {
                context.FormulacionDetalleTemp.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("FormulacionDetalleTempCreate", ex, null);
                throw;
            }
        }

        public void Delete(int IdDetalle)
        {
            try
            {
                FormulacionDetalleTemp entity = context.FormulacionDetalleTemp.Find(IdDetalle);
                context.FormulacionDetalleTemp.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("FormulacionDetalleTempDelete", ex, null);
                throw;
            }
        }
    }
}
