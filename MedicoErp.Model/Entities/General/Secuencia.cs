using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicoErp.Model.Entities.General
{
    [Table("Secuencia", Schema = "General")]
    public class Secuencia : Common.Auditoria
    {
        [Key]
        public int IdSecuencia { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        [StringLength(15)]
        public string TipoDoc { get; set; }

        [Required]
        public int NumDoc { get; set; }

    }
}
