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
    public class DepartamentoBusiness : IDepartamentoBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public DepartamentoBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public List<Departamento> GetDepartamentos()
        {
            try
            {
                List<Departamento> Lista = context.Departamento.OrderBy(x => x.NomDepartamento).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetDepartamentos", ex, null);
                throw;
            }
        }
    }
}
