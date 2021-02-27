using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.General.Entities
{
    [Table("Menu", Schema = "General")]
    public class Menu
    {
        [Key]
        public int IdMenu { get; set; }

        [Required]
        [StringLength(15)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [StringLength(15)]
        public string CodPadre { get; set; }
    }
}
