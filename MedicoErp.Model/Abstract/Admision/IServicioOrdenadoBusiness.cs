using MedicoErp.Model.Entities.Admision;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicoErp.Model.Abstract.Admision
{
    public interface IServicioOrdenadoBusiness
    {
        List<ServicioOrdenado> getAllByIdPacAndIdCon(int IdCentro, long IdPaciente, int IdConvenio);
        void Create(ServicioOrdenado entity);
        void UpdateTarifaDescuento(JObject data);
        void Delete(long IdServicioOrdenado);
    }
}
