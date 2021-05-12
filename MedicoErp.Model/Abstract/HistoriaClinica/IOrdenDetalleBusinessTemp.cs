using MedicoErp.Model.Entities.HistoriaClinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.HistoriaClinica
{
    public interface IOrdenDetalleBusinessTemp
    {
        void Create(OrdenDetalleTemp entity);
        void Update(int IdDetalle, OrdenDetalleTemp entity);
        void Delete(int IdDetalle);
        List<OrdenDetalleTemp> GetAllByIdUsuario(int IdUsuario);
    }
}
