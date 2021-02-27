using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.Administracion.Entities
{
    [Table("Resolucion", Schema = "Administracion")]
    public class Resolucion
    {
        [Key]
        public int IdResolucion { get; set; }

        [Required]
        [StringLength(100)]
        public string NoResolucion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int NumInicial { get; set; }

        [Required]
        public int NumFinal { get; set; }

        [Required]
        public int NumActual { get; set; }

        [Required]
        public int IdCentro { get; set; }
    }
}
