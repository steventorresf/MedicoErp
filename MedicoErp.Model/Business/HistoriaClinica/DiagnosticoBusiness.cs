using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.HistoriaClinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Business.HistoriaClinica
{
    public class DiagnosticoBusiness : IDiagnosticoBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public DiagnosticoBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public List<Diagnostico> GetDiagnosticosPrefix(string StringPrefix)
        {
            try
            {
                string[] ListaPrefix = StringPrefix.Split(" ").Where(x => !x.Equals("")).ToArray();

                List<Diagnostico> Lista = context.Diagnostico.Where(x => x.NombreDiagnostico.Contains(ListaPrefix[0])).ToList();
                if (ListaPrefix.Length > 1)
                {
                    for (int i = 1; i < ListaPrefix.Length; i++)
                    {
                        Lista = Lista.Where(x => x.NombreDiagnostico.Contains(ListaPrefix[i])).ToList();
                    }
                }
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetDiagnosticosPrefix", ex, null);
                throw;
            }
        }
    }
}
