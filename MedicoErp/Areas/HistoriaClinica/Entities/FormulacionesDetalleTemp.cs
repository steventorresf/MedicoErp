using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.HistoriaClinica.Entities
{
    [Table("FormulacionesDetalleTemp", Schema = "HistoriaClinica")]
    public class FormulacionesDetalleTemp
    {
        [Key]
        public int IdDetalle { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int IdMedicamento { get; set; }

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
    }
}
