using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.General.Entities
{
    [Table("MenuUsuario", Schema = "General")]
    public class MenuUsuario
    {
        [Key]
        public int IdMenuUsuario { get; set; }

        [Required]
        public int IdMenu { get; set; }

        [Required]
        public int IdUsuario { get; set; }


        [NotMapped]
        public Menu Menu { get; set; }
    }
}
