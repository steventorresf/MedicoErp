using MedicoErp.Areas.General.Entities;
using MedicoErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.General.Business
{
    public class DepartamentosBusiness
    {
        public List<Departamentos> GetDepartamentos()
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Departamentos> Lista = context.Departamentos.OrderBy(x => x.NomDepartamento).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetDepartamentos", ex.Message, null);
                throw;
            }
        }
    }
}
