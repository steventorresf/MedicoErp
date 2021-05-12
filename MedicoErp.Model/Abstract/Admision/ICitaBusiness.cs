using MedicoErp.Model.Entities.Admision;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.Admision
{
    public interface ICitaBusiness
    {
        long Create(Cita entity);
        bool Update(long IdCita, Cita entity);
        void UpdateTarifaDescuento(JObject data);
        void Delete(long IdCita, string NomUsu);
        List<Cita> GetAsignadas(long IdPac);
        List<Cita> GetAsignadasConvenio(long IdPac, int IdCon);
        List<Cita> GetAgendaMedica(DateTime FechaIni, DateTime FechaFin, int IdMedico);
        List<Cita> GetMiAgendaFecha(int IdMedico, DateTime Fecha);
        Cita GetImpresion(int IdCita);
        void Facturar(Cita obCita, string NomUsu);
        List<Cita> GetActividades(string FechaIni, string FechaFin, int IdCentro);
    }
}
