using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.Admision
{
    [Table("Facturacion", Schema = "Admision")]
    public class Facturacion : Common.Auditoria
    {
        [Key]
        public int IdFacturacion { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        public int IdCentroRemision { get; set; }

        [Required]
        [StringLength(2)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(15)]
        public string TipoDocumento { get; set; }

        [Required]
        public long NumDocumento { get; set; }

        [Required]
        public long IdPaciente { get; set; }

        [StringLength(100)]
        public string NombreAcomp { get; set; }

        [StringLength(100)]
        public string TelefonoAcomp { get; set; }

        [Required]
        public int IdConvenio { get; set; }

        [Required]
        public DateTimeOffset FechaPago { get; set; }

        public int? IdResolucion { get; set; }

        [Required]
        [StringLength(2)]
        public string CodEstado { get; set; }

        public string MotivoAnu { get; set; }


        [NotMapped]
        public CentroAtencion CentroAtencion { get; set; }

        [NotMapped]
        public CentroAtencion CentroRemision { get; set; }

        [NotMapped]
        public Convenio Convenio { get; set; }

        [NotMapped]
        public Paciente Paciente { get; set; }

        [NotMapped]
        public string sFechaNacimiento { get; set; }

        [NotMapped]
        public string sFechaPago { get; set; }

        [NotMapped]
        public string TipoUsuario { get; set; }

        [NotMapped]
        public List<Cita> ListaCitas { get; set; }
    }
}
