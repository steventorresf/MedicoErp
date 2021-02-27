using MedicoErp.Areas.HistoriaClinica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Utiles
{
    public class ImpresionHistoria
    {
        public string NombreCentro { get; set; }

        public string NitCentro { get; set; }

        public string DireccionCentro { get; set; }

        public string TelefonoCentro { get; set; }

        public long NoConsecutivo { get; set; }

        public string sFecha { get; set; }

        public string NombrePaciente { get; set; }

        public string DocIdentidad { get; set; }

        public string sFechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public string Ocupacion { get; set; }

        public string Direccion { get; set; }

        public string Telefonos { get; set; }

        public string Barrio { get; set; }

        public string EstadoCivil { get; set; }

        public string Correo { get; set; }

        public string NombreEps { get; set; }

        public string TipoUsuario { get; set; }

        public string NombreConvenio { get; set; }

        public string NombreAcomp { get; set; }

        public string TelefonoAcomp { get; set; }

        public string DiagnosticoPal { get; set; }

        public string DiagnosticoRel1 { get; set; }

        public string CreadoPor { get; set; }

        public string Firma { get; set; }

        public string Especialidad { get; set; }

        public string RegistroMedico { get; set; }

        public string TiempoEvo { get; set; }

        public string ProxControl { get; set; }

        public string Observaciones { get; set; }

        public List<FormulacionesDetalle> FormulacionDetalle { get; set; }

        public List<OrdenesDetalle> OrdenDetalle { get; set; }
    }
}
