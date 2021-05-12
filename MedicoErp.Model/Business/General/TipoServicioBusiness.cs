using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicoErp.Model.Business.General
{
    public class TipoServicioBusiness : ITipoServicioBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public TipoServicioBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public List<TipoServicio> GetTiposServicios()
        {
            try
            {
                List<TipoServicio> Lista = context.TipoServicio.OrderBy(x => x.NombreTipoServicio).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetTiposServicios", ex, null);
                throw;
            }
        }
    }
}
