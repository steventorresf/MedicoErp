using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.HistoriaClinica.Entities
{
    [Table("FormulacionesDetalle", Schema = "HistoriaClinica")]
    public class FormulacionesDetalle : Utiles.CamposAuditables
    {
        [Key]
        public long IdDetalle { get; set; }

        [Required]
        public long IdFormulacion { get; set; }

        public int? IdMedicamento { get; set; }

        [Required]
        [StringLength(550)]
        public string Medicamento { get; set; }

        [Required]
        [StringLength(2)]
        public string CodViaAdmon { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [StringLength(1000)]
        public string Posologia { get; set; }        

        [Required]
        public decimal Valor { get; set; }

        [NotMapped]
        public string ViaAdmon { get; set; }
    }
}
