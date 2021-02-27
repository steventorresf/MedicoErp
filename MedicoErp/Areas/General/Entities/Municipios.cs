using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.General.Entities
{
    [Table("Municipios", Schema = "General")]
    public class Municipios
    {
        [Key]
        public int IdMunicipio { get; set; }

        [Required]
        [StringLength(3)]
        public string CodMunicipio { get; set; }

        [Required]
        [StringLength(100)]
        public string NomMunicipio { get; set; }

        [Required]
        [StringLength(2)]
        public string CodDepartamento { get; set; }
    }
}
