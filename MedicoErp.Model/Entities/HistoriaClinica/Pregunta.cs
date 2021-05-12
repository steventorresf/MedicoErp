using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicoErp.Model.Entities.HistoriaClinica
{
    [Table("Pregunta", Schema = "HistoriaClinica")]
    public class Pregunta : Common.Auditoria
    {
        [Key]
        public int IdPregunta { get; set; }

        [Required]
        public int IdArea { get; set; }

        [Required]
        [StringLength(100)]
        public string NombrePregunta { get; set; }

        [Required]
        public short Orden { get; set; }

        [Required]
        [StringLength(2)]
        public string TipoDato { get; set; }

        public int? IdTipoRespuesta { get; set; }

        [Required]
        public bool EsRequerido { get; set; }

        [Required]
        public string RespPredeterminada { get; set; }

        [Required]
        [StringLength(2)]
        public string CodEstado { get; set; }


        
        [NotMapped]
        public long IdDetalle { get; set; }
        
        [NotMapped]
        public List<TipoRespuestaDetalle> ListaTipoRespuesta { get; set; }
        
        [NotMapped]
        public string Valor { get; set; }

        [NotMapped]
        public string Respuesta { get; set; }
    }
}
