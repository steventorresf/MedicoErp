using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.General.Entities
{
    [Table("IniciosSesion", Schema = "General")]
    public class IniciosSesion
    {
        [Key]
        public long IdSesion { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public DateTimeOffset FechaHoraInicio { get; set; }

        [Required]
        public bool Activo { get; set; }

        public DateTimeOffset? FechaHoraFin { get; set; }
    }
}
