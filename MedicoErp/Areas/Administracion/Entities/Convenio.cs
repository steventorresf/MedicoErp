using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.Administracion.Entities
{
    [Table("Convenio", Schema = "Administracion")]
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
