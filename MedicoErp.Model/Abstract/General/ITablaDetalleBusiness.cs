using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.General
{
    public interface ITablaDetalleBusiness
    {
        List<TablaDetalle> GetTabDetalleByCodTabla(string CodTabla);
    }
}
