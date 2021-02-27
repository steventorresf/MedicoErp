using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.Admision
{
    [Table("Convenio", Schema = "Admision")]
    public class Convenio
    {
        [Key]
        public int IdConvenio { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreConvenio { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreEps { get; set; }

        [Required]
        [StringLength(2)]
        public string CodTipoUsuario { get; set; }

        [Required]
        [StringLength(2)]
        public string CodTipoFact { get; set; }

        [Required]
        [StringLength(2)]
        public string CodEstado { get; set; }



        [NotMapped]
        public string TipoFacturacion { get; set; }

        [NotMapped]
        public string NombreEstado { get; set; }

        [NotMapped]
        public string TextTipoUsuario { get; set; }
    }
}
