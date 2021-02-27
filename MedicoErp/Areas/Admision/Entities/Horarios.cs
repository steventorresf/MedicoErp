using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.Admision.Entities
{
    [Table("Horarios", Schema = "Admision")]
    public class Horarios
    {
        [Key]
        public long IdHorario { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public DateTimeOffset HoraInicial { get; set; }

        [Required]
        public DateTimeOffset HoraFinal { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        [StringLength(2)]
        public string CodEstado { get; set; }


        [NotMapped]
        public string SHoraInicial { get; set; }

        [NotMapped]
        public string SHoraFinal { get; set; }

        [NotMapped]
        public string NombreEstado { get; set; }
    }
}
