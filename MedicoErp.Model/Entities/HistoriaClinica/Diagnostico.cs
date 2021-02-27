using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.HistoriaClinica
{
    [Table("Diagnostico", Schema = "HistoriaClinica")]
    public class Diagnostico
    {
        [Key]
        [StringLength(4)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(300)]
        public string NombreDiagnostico { get; set; }

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
