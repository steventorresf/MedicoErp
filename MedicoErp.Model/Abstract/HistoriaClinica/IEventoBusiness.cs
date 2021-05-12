using MedicoErp.Model.Entities.HistoriaClinica;
using Newtonsoft.Json.Linq;
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
        void CreateExt(Evento entity);
        int Anular(JObject data);
        Evento GetByIdEvento(long IdEvento);
        List<Evento> GetAllByIdPaciente(long IdPaciente);
        Evento GetEventoImpresion(long IdEvento, long IdFolio);
        void Update(long IdEvento, string Campo, string Dato, string NombreUsuario);
        void FinalizarEvento(long IdEvento, string NombreUsuario);
    }
}
