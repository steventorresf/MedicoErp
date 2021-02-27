using MedicoErp.Model.Entities.Admision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.Admision
{
    public interface IConvenioBusiness
    {
        void Create(Convenio entity);
        void Update(int IdConvenio, Convenio entity);
        void Inactivar(int IdConvenio);
        void Activar(int IdConvenio);
        List<Convenio> GetConvenios(int IdCentro);
        List<Convenio> GetConveniosActivos(int IdCentro);
    }
}
