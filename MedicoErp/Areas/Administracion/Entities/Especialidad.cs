using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.Administracion.Entities
{
    [Table("Especialidad", Schema = "Administracion")]
    public class Especialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreEspecialidad { get; set; }

        [Required]
        public bool Visible { get; set; }
    }
}
