using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.General.Entities
{
    [Table("TablasDetalle", Schema = "General")]
    public class TablasDetalle
    {
        [Key]
        public int IdDetalle { get; set; }

        [Required]
        [StringLength(30)]
        public string CodTabla { get; set; }

        [Required]
        [StringLength(15)]
        public string CodValor { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public short Orden { get; set; }

        [Required]
        [StringLength(1)]
        public string CodEstado { get; set; }
    }
}
