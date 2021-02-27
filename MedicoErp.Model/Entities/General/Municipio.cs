using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.General
{
    [Table("Municipio", Schema = "General")]
    public class Municipio
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
