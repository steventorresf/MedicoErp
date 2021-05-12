using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicoErp.Model.Entities.General
{
    [Table("TipoServicio", Schema = "General")]
    public class TipoServicio
    {
        [Key]
        public int IdTipoServicio { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreTipoServicio { get; set; }

        [Required]
        [StringLength(2)]
        public string TipoRips { get; set; }
    }
}
