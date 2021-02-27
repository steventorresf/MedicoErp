using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.Administracion.Entities
{
    [Table("Usuario", Schema = "Administracion")]
    public class Usuario : Utiles.CamposAuditables
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(2)]
        public string TipoIden { get; set; }

        [Required]
        [StringLength(50)]
        public string NumIden { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreCompleto { get; set; }

        [Required]
        [StringLength(1)]
        public string CodSexo { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [StringLength(150)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(100)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string NomUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string Clave { get; set; }

        [Required]
        public bool EsMedico { get; set; }

        [StringLength(100)]
        public string Especialidad { get; set; }

        [Required]
        [StringLength(50)]
        public string Registro { get; set; }

        [Required]
        public DateTimeOffset FechaIngreso { get; set; }

        [Required]
        [StringLength(2)]
        public string CodEstado { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        [StringLength(50)]
        public string Avatar { get; set; }

        public string FilePdf { get; set; }



        [NotMapped]
        public string DocIdentidad { get; set; }

        [NotMapped]
        public string NombreEstado { get; set; }

        [NotMapped]
        public string EsMedicoDesc { get; set; }
    }
}
