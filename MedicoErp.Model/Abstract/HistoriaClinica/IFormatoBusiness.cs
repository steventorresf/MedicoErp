using MedicoErp.Model.Entities.HistoriaClinica;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicoErp.Model.Abstract.HistoriaClinica
{
    public interface IFormatoBusiness
    {
        List<Formato> GetAll(int IdCentro);
        List<Formato> GetAllNotEvento(int IdCentro, long IdEvento);
    }
}
