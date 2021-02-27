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
    public class TablaDetalleBusiness : ITablaDetalleBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public TablaDetalleBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public List<TablaDetalle> GetTabDetalleByCodTabla(string CodTabla)
        {
            try
            {
                List<TablaDetalle> Lista = context.TablaDetalle.Where(x => x.CodTabla == CodTabla).OrderBy(x => x.Orden).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetTabDetalleByCodTabla", ex, null);
                throw;
            }
        }
    }
}
