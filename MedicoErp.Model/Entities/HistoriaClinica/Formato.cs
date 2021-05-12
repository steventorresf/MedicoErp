using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicoErp.Model.Entities.HistoriaClinica
{
    [Table("Formato", Schema = "HistoriaClinica")]
    public class Formato : Common.Auditoria
    {
        [Key]
        public int IdFormato { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreFormato { get; set; }

        [Required]
        public short Orden { get; set; }

        [Required]
        public bool IncluyeDiag { get; set; }

        [Required]
        public bool IncluyePlan { get; set; }

        [Required]
        public bool IncluyeRecom { get; set; }

        [Required]
        [StringLength(2)]
        public string CodEstado { get; set; }


        [NotMapped]
        public bool YaExiste { get; set; }
    }
}
