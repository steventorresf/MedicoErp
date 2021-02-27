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
    public class MunicipioBusiness : IMunicipioBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public MunicipioBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public List<Municipio> GetMunicipiosByDpto(string CodDepartamento)
        {
            try
            {
                List<Municipio> Lista = context.Municipio.Where(x => x.CodDepartamento.Equals(CodDepartamento)).OrderBy(x => x.NomMunicipio).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetMunicipiosByDpto", ex, null);
                throw;
            }
        }
    }
}
