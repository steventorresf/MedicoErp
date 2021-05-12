using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicoErp.Model.Entities.Admision
{
    [Table("ServicioOrdenado", Schema = "Admision")]
    public class ServicioOrdenado : Common.Auditoria
    {
        [Key]
        public long IdServicioOrdenado { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        public long IdPaciente { get; set; }

        public long? IdOrden { get; set; }

        [Required]
        public DateTimeOffset Fecha { get; set; }

        public int? IdMedico { get; set; }

        [Required]
        public int IdServicio { get; set; }

        [Required]
        public int IdConvenio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal Tarifa { get; set; }

        [Required]
        public decimal Descuento { get; set; }

        public int? IdFacturacion { get; set; }


        [NotMapped]
        public string sFecha { get; set; }

        [NotMapped]
        public string sFechaFormato { get; set; }

        [NotMapped]
        public Servicio Servicio { get; set; }

        [NotMapped]
        public string NoOrden { get; set; }

        [NotMapped]
        public string NombreMedico { get; set; }

    }
}
