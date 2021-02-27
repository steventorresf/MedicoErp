using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.General
{
    [Table("Tabla", Schema = "General")]
    public class Tabla
    {
        [Key]
        [StringLength(30)]
        public string CodTabla { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }
    }
}
