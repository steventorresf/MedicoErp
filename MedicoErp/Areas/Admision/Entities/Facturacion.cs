using MedicoErp.Areas.Administracion.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.Admision.Entities
{
    [Table("Facturacion", Schema = "Admision")]
    public class Facturacion : Utiles.CamposAuditables
    {
        [Key]
        public int IdFacturacion { get; set; }

        [Required]
        public int IdCentro { get; set; }

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
        public Convenio Convenio { get; set; }

        [NotMapped]
        public Paciente Paciente { get; set; }

        [NotMapped]
        public List<Citas> ListaCitas { get; set; }
    }
}
