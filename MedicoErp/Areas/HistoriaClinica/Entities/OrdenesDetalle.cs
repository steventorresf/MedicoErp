using MedicoErp.Areas.Administracion.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.HistoriaClinica.Entities
{
    [Table("OrdenesDetalle", Schema = "HistoriaClinica")]
    public class OrdenesDetalle : Utiles.CamposAuditables
    {
        [Key]
        public long IdDetalle { get; set; }

        [Required]
        public long IdOrden { get; set; }

        [Required]
        public int IdServicio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [NotMapped]
        public Servicio Servicio { get; set; }
    }
}
