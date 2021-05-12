using System;
using System.Collections.Generic;
using System.Text;

namespace MedicoErp.Model.Abstract.Informes
{
    public interface IInformeBusiness
    {
        byte[] ExcelAgendaMedica(string Fi, string Ff, int Im);
        byte[] GetActividades(string FechaInicial, string FechaFinal, int IdCentro);
    }
}
