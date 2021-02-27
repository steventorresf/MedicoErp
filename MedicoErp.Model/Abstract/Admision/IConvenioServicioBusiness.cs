using MedicoErp.Model.Entities.Admision;
using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.Admision
{
    public interface IConvenioServicioBusiness
    {
        void Creates(List<ConvenioServicio> Lista);
        void UpdateTarifa(int IdDetalle, decimal VTarifa);
        void Delete(int IdDetalle);
        List<ConvenioServicio> GetServiciosContratado(int IdConvenio);
        List<Servicio> GetServiciosNoContratado(int IdCentro, int IdConvenio);
    }
}
