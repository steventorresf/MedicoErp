using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.Admision.Entities
{
    [Table("HorariosLog", Schema = "Admision")]
    public class HorariosLog
    {
        [Key]
        public long IdDetalle { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public short MinPac { get; set; }

        [Required]
        public short NumPac { get; set; }

        [Required]
        public DateTimeOffset HoraInicial { get; set; }

        [Required]
        public DateTimeOffset HoraFinal { get; set; }

        [Required]
        [StringLength(2)]
        public string CodEstado { get; set; }

        [Required]
        public int IdUsuario { get; set; }
    }
}
