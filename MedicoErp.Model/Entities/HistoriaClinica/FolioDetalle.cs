using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicoErp.Model.Entities.HistoriaClinica
{
    [Table("FolioDetalle", Schema = "HistoriaClinica")]
    public class FolioDetalle : Common.Auditoria
    {
        [Key]
        public long IdDetalle { get; set; }

        [Required]
        public long IdFolio { get; set; }

        [Required]
        public int IdPregunta { get; set; }

        [Required]
        [StringLength(2)]
        public string TipoDato { get; set; }

        public int? IdTipoRespuesta { get; set; }

        [Required]
        public string Valor { get; set; }

        [Required]
        public string Respuesta { get; set; }
    }
}
