using MedicoErp.Model.Entities.Admision;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.Admision
{
    public interface IHorarioBusiness
    {
        void Creates(List<Horario> Listado);
        List<Horario> GetHorariosMedico(int IdMedico);
        string GetSCreatesHorarios(JObject data);
        string GetValidacionHorasFecha(DateTime[] Fechas, DateTimeOffset HoraI, DateTimeOffset HoraF, int IdMedico);
        List<Horario> GetListHorarios(DateTime[] Fechas, DateTimeOffset HoraI, short Min, short Num, int IdMedico, int IdCentro);
        string[] GetFechasMed(int IdMedico);
        List<Horario> GetFechaHorasMed(int IdMedico, DateTime Fecha);
    }
}
