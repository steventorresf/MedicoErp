using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicoErp.Model.Entities.HistoriaClinica
{
    [Table("TipoRespuesta", Schema = "HistoriaClinica")]
    public class TipoRespuesta : Common.Auditoria
    {
        [Key]
        public int IdTipoRespuesta { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreTipoRespuesta { get; set; }
    }
}
