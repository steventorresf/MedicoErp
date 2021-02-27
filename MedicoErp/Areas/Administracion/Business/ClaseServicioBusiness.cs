using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.Administracion.Business
{
    public class ClaseServicioBusiness
    {
        public List<ClaseServicio> GetClasesServicios()
        {
            try
            {
                BaseContext context = new BaseContext();
                List<ClaseServicio> Lista = context.ClasesServicios.OrderBy(x => x.NombreClaseServicio).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetClasesServicios", ex.Message, null);
                throw;
            }
        }
    }
}
