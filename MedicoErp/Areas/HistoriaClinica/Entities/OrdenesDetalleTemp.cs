using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.HistoriaClinica.Entities
{
    [Table("OrdenesDetalleTemp", Schema = "HistoriaClinica")]
    public class OrdenesDetalleTemp
    {
        [Key]
        public int IdDetalle { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int IdServicio { get; set; }

        [Required]
        public int Cantidad { get; set; }


        [NotMapped]
        public string NombreServicio { get; set; }
    }
}
