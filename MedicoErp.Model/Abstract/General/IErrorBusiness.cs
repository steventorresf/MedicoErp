using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.General
{
    public interface IErrorBusiness
    {
        void Create(string Metodo, Exception ex, int? IdUsuario);
    }
}
