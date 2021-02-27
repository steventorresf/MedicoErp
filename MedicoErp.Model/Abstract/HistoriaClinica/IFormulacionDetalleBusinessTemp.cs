using MedicoErp.Model.Entities.HistoriaClinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.HistoriaClinica
{
    public interface IFormulacionDetalleBusinessTemp
    {
        List<FormulacionDetalleTemp> GetAllByIdUsuario(int IdUsuario);
        void Create(FormulacionDetalleTemp entity);
        void Delete(int IdDetalle);
    }
}
