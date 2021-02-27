using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.General.Entities
{
    [Table("Tablas", Schema = "General")]
    public class Tablas
    {
        [Key]
        [StringLength(30)]
        public string CodTabla { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }
    }
}
