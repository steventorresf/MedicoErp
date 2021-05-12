using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.Admision
{
    [Table("ConvenioServicio", Schema = "Admision")]
    public class ConvenioServicio
    {
        [Key]
        public int IdDetalle { get; set; }

        [Required]
        public int IdServicio { get; set; }

        [Required]
        public int IdConvenio { get; set; }

        [Required]
        public decimal Tarifa { get; set; }


        [NotMapped]
        public Servicio Servicio { get; set; }
    }
}
