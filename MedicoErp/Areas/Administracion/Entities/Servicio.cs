using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.Administracion.Entities
{
    [Table("Servicio", Schema = "Administracion")]
    public class Servicio
    {
        [Key]
        public int IdServicio { get; set; }

        [Required]
        [StringLength(50)]
        public string CodigoRef { get; set; }

        [Required]
        [StringLength(500)]
        public string NombreServicio { get; set; }

        [Required]
        public int IdEspecialidad { get; set; }

        [Required]
        public int IdClaseServicio { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public int IdCentro { get; set; }


        [NotMapped]
        public Especialidad Especialidad { get; set; }

        [NotMapped]
        public ClaseServicio ClaseServicio { get; set; }
    }
}
