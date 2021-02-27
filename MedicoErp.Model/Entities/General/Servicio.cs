using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.General
{
    [Table("Servicio", Schema = "General")]
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
        public ClaseServicio ClaseServicio { get; set; }
    }
}
