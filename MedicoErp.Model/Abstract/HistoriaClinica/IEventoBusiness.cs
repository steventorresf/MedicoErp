using MedicoErp.Model.Entities.HistoriaClinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.HistoriaClinica
{
    public interface IEventoBusiness
    {
        long AtenderCita(long IdCita, string CreadoPor);
        Evento GetByIdEvento(long IdEvento);
        List<Evento> GetAllByIdPaciente(long IdPaciente);
        void Update(long IdEvento, string Campo, string Dato, string NombreUsuario);
        void FinalizarEvento(long IdEvento, string NombreUsuario);
    }
}
