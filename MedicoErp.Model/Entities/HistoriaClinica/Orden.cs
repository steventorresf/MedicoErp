using MedicoErp.Model.Entities.Admision;
using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.HistoriaClinica
{
    [Table("Orden", Schema = "HistoriaClinica")]
    public class Orden : Common.Auditoria
    {
        [Key]
        public long IdOrden { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        public int NoOrden { get; set; }

        [Required]
        public long IdEvento { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        public DateTimeOffset FechaOrden { get; set; }

        [StringLength(500)]
        public string Observaciones { get; set; }

        [Required]
        [StringLength(2)]
        public string CodEstado { get; set; }


        [NotMapped]
        public string sFechaOrden { get; set; }

        [NotMapped]
        public string NombreMedico { get; set; }

        [NotMapped]
        public string TipoUsuario { get; set; }

        [NotMapped]
        public string NombreConvenio { get; set; }

        [NotMapped]
        public CentroAtencion Centro { get; set; }

        [NotMapped]
        public Paciente Paciente { get; set; }

        [NotMapped]
        public Convenio Convenio { get; set; }

        [NotMapped]
        public Usuario Medico { get; set; }

        [NotMapped]
        public string sFechaNacimiento { get; set; }

        [NotMapped]
        public string Firma { get; set; }

        [NotMapped]
        public List<OrdenDetalle> ListOrdenDetalle { get; set; }
    }
}
