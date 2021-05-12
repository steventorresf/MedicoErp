using MedicoErp.Model.Entities.Admision;
using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.HistoriaClinica
{
    [Table("OrdenDetalle", Schema = "HistoriaClinica")]
    public class OrdenDetalle : Common.Auditoria
    {
        [Key]
        public long IdDetalle { get; set; }

        [Required]
        public long IdOrden { get; set; }

        [Required]
        public int IdServicio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal Tarifa { get; set; }

        [Required]
        public decimal Descuento { get; set; }

        [NotMapped]
        public Servicio Servicio { get; set; }
    }
}
