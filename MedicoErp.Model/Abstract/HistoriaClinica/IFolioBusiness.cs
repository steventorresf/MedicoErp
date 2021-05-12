using MedicoErp.Model.Entities.HistoriaClinica;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicoErp.Model.Abstract.HistoriaClinica
{
    public interface IFolioBusiness
    {
        List<Folio> GetAllByIdEvento(long IdEvento);
        List<Folio> GetAllByIdPaciente(long IdPaciente, int IdCentro);
        long Create(Folio entity);
        int Anular(JObject data);
        Folio GetAllByIdFolio(long IdFolio);
    }
}
