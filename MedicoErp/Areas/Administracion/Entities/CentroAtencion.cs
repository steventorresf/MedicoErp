using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.Administracion.Entities
{
    [Table("CentroAtencion", Schema = "Administracion")]
    public class CentroAtencion
    {
        [Key]
        public int IdCentro { get; set; }

        [Required]
        [StringLength(50)]
        public string NitCentro { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreCentro { get; set; }

        [Required]
        [StringLength(50)]
        public string CodPrestador { get; set; }

        [Required]
        [StringLength(2)]
        public string CodDepartamento { get; set; }

        [Required]
        [StringLength(3)]
        public string CodMunicipio { get; set; }

        [Required]
        [StringLength(150)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(100)]
        public string Telefono { get; set; }

        [Required]
        public int IdResolucion { get; set; }

        [StringLength(4000)]
        public string EncFact { get; set; }

        [StringLength(4000)]
        public string PieFact { get; set; }

        [Required]
        [StringLength(2)]
        public string CodEstado { get; set; }

        [StringLength(10)]
        public string PrefijoVol { get; set; }

        [Required]
        public long NoVolante { get; set; }

        [Required]
        public long NoCita { get; set; }

        [Required]
        public long NoEvento { get; set; }

        [Required]
        public long NoFolio { get; set; }

        [Required]
        public long NoFormulacion { get; set; }

        [Required]
        public long NoOrden { get; set; }
    }
}
