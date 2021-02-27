using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.General.Entities
{
    [Table("Departamentos", Schema = "General")]
    public class Departamentos
    {
        [Key]
        public int IdDepartamento { get; set; }

        [Required]
        [StringLength(2)]
        public string CodDepartamento { get; set; }

        [Required]
        [StringLength(50)]
        public string NomDepartamento { get; set; }
    }
}
