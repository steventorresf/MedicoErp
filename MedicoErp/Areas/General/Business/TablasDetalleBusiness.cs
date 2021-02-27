using MedicoErp.Areas.General.Entities;
using MedicoErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.General.Business
{
    public class TablasDetalleBusiness
    {
        public List<TablasDetalle> GetTabDetalleByCodTabla(string CodTabla)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<TablasDetalle> Lista = context.TablasDetalles.Where(x => x.CodTabla == CodTabla).OrderBy(x => x.Orden).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTabDetalleByCodTabla", ex.Message, null);
                throw;
            }
        }
    }
}
