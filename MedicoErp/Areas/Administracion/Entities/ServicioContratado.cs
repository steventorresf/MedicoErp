using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.Administracion.Entities
{
    [Table("ServicioContratado", Schema = "Administracion")]
    public class ServicioContratado
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
