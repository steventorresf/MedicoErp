using MedicoErp.Model.Entities.HistoriaClinica;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.HistoriaClinica
{
    public interface IFormulacionBusiness
    {
        List<Formulacion> GetAllByIdEvento(long IdEvento);
        List<Formulacion> GetAllByIdPaciente(long IdPaciente);
        void Create(Formulacion entity);
        int Anular(JObject data);
        Formulacion GetFormulacionImp(long IdFormulacion);
    }
}
