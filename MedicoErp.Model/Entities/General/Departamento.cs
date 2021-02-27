using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.General
{
    [Table("Departamento", Schema = "General")]
    public class Departamento
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
