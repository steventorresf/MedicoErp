using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.General.Entities
{
    [Table("Errores", Schema = "General")]
    public class Errores
    {
        [Key]
        public int IdError { get; set; }

        [Required]
        [StringLength(100)]
        public string Metodo { get; set; }

        [Required]
        [StringLength(4000)]
        public string MensajeError { get; set; }

        [Required]
        public DateTimeOffset FechaError { get; set; }

        public int? IdUsuario { get; set; }
    }
}
