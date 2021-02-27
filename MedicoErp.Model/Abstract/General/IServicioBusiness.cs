using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.General
{
    public interface IServicioBusiness
    {
        void Create(Servicio entity);
        void Update(int IdServicio, Servicio entity);
        void UpdateEstado(int IdServicio, bool Activo);
        List<Servicio> GetServicios(int IdCentro);
    }
}
