using MedicoErp.Areas.General.Business;
using MedicoErp.Areas.HistoriaClinica.Entities;
using MedicoErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.HistoriaClinica.Business
{
    public class DiagnosticosBusiness
    {
        public List<Diagnosticos> GetDiagnosticosPrefix(string StringPrefix)
        {
            try
            {
                string[] ListaPrefix = StringPrefix.Split(" ").Where(x => !x.Equals("")).ToArray();

                BaseContext context = new BaseContext();
                List<Diagnosticos>  Lista = context.Diagnosticos.Where(x => x.Diagnostico.Contains(ListaPrefix[0])).ToList();

                if (ListaPrefix.Length > 1)
                {
                    for (int i = 1; i < ListaPrefix.Length; i++)
                    {
                        Lista = Lista.Where(x => x.Diagnostico.Contains(ListaPrefix[i])).ToList();
                    }
                }
                return Lista;
            }
            catch(Exception ex)
            {
                ErroresBusiness.Create("GetDiagnosticosPrefix", ex.Message, null);
                throw;
            }
        }
    }
}
