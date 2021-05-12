using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicoErp.Model.Business.General
{
    public class ClaseServicioBusiness : IClaseServicioBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public ClaseServicioBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public List<ClaseServicio> GetClasesServicios()
        {
            try
            {
                List<ClaseServicio> Lista = context.ClaseServicio.OrderBy(x => x.NombreClaseServicio).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetClasesServicios", ex, null);
                throw;
            }
        }
    }
}
