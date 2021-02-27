using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.General
{
    [Table("ClaseServicio", Schema = "General")]
    public class ClaseServicio
    {
        [Key]
        public int IdClaseServicio { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreClaseServicio { get; set; }

        [Required]
        [StringLength(2)]
        public string TipoRips { get; set; }

        [Required]
        public bool Visible { get; set; }
    }
}
