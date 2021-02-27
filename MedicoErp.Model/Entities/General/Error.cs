using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.General
{
    [Table("Error", Schema = "General")]
    public class Error
    {
        [Key]
        public int IdError { get; set; }

        [Required]
        [StringLength(100)]
        public string Metodo { get; set; }

        [Required]
        [StringLength(4000)]
        public string MensajeError { get; set; }

        [Required]
        public DateTimeOffset FechaError { get; set; }

        public int? IdUsuario { get; set; }
    }
}
