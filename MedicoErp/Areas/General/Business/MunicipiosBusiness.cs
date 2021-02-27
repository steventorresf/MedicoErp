using MedicoErp.Areas.General.Entities;
using MedicoErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.General.Business
{
    public class MunicipiosBusiness
    {
        public List<Municipios> GetMunicipiosByDpto(string CodDepartamento)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Municipios> Lista = context.Municipios.Where(x => x.CodDepartamento.Equals(CodDepartamento)).OrderBy(x => x.NomMunicipio).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetMunicipiosByDpto", ex.Message, null);
                throw;
            }
        }
    }
}
