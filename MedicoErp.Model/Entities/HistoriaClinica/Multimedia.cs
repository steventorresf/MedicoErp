using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.HistoriaClinica
{
    [Table("Multimedia", Schema = "HistoriaClinica")]
    public class Multimedia : Common.Auditoria
    {
        [Key]
        public int IdMultimedia { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        public long IdPaciente { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreArchivo { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreRuta { get; set; }

        public string Observaciones { get; set; }


        [NotMapped]
        public string sFechaCreacion { get; set; }
    }
}
