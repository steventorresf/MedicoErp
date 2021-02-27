using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.HistoriaClinica.Entities
{
    [Table("Diagnosticos", Schema = "HistoriaClinica")]
    public class Diagnosticos
    {
        [Key]
        [StringLength(4)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(300)]
        public string Diagnostico { get; set; }

        [Required]
        [StringLength(1)]
        public string CodSexo { get; set; }

        [Required]
        public short TipoEdadInicial { get; set; }

        [Required]
        public short EdadInicial { get; set; }

        [Required]
        public short TipoEdadFinal { get; set; }

        [Required]
        public short EdadFinal { get; set; }
    }
}
