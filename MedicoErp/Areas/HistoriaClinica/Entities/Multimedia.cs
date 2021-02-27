using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.HistoriaClinica.Entities
{
    [Table("Multimedia", Schema = "HistoriaClinica")]
    public class Multimedia : Utiles.CamposAuditables
    {
        [Key]
        public int IdMultimedia { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        public long IdPaciente { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreArchivo { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreRuta { get; set; }

        public string Observaciones { get; set; }


        [NotMapped]
        public string sFechaCreacion { get; set; }
    }
}
