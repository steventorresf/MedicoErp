using MedicoErp.Model.Entities.Admision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.Admision
{
    public interface ICitaBusiness
    {
        bool Create(Cita entity);
        bool Update(long IdCita, Cita entity);
        void UpdateTarifa(long IdCita, decimal Tarifa);
        void Delete(long IdCita, string NomUsu);
        List<Cita> GetAsignadas(long IdPac);
        List<Cita> GetAsignadasConvenio(long IdPac, int IdCon);
        List<Cita> GetAgendaMedica(DateTime FechaIni, DateTime FechaFin, int IdMedico);
        List<Cita> GetMiAgendaFecha(int IdMedico, DateTime Fecha);
        void Facturar(Cita obCita, string NomUsu);
        byte[] ExcelAgendaMedica(string Fi, string Ff, int Im, string Nm);
    }
}
