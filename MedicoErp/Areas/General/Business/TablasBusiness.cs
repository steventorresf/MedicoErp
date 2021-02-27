using MedicoErp.Areas.General.Entities;
using MedicoErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.General.Business
{
    public class TablasBusiness
    {
        public Tablas GetTabByCod(string CodTabla)
        {
            try
            {
                BaseContext context = new BaseContext();
                Tablas entity = context.Tablas.FirstOrDefault(x => x.CodTabla.Equals(CodTabla));
                return entity;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTabByCod", ex.Message, null);
                throw;
            }
        }
    }
}
