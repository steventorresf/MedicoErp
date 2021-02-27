using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.General
{
    [Table("TablaDetalle", Schema = "General")]
    public class TablaDetalle
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
