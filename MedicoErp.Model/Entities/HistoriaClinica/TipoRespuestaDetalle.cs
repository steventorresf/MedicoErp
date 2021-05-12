using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicoErp.Model.Entities.HistoriaClinica
{
    [Table("TipoRespuestaDetalle", Schema = "HistoriaClinica")]
    public class TipoRespuestaDetalle : Common.Auditoria
    {
        [Key]
        public int IdDetalle { get; set; }

        [Required]
        public int IdTipoRespuesta { get; set; }

        [Required]
        [StringLength(50)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreRespuesta { get; set; }
    }
}
