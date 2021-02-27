using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.Admision
{
    [Table("Paciente", Schema = "Admision")]
    public class Paciente
    {
        [Key]
        public long IdPaciente { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        [StringLength(2)]
        public string TipoIden { get; set; }

        [Required]
        [StringLength(50)]
        public string NumIden { get; set; }

        [Required]
        [StringLength(50)]
        public string PrimerNombre { get; set; }

        [StringLength(50)]
        public string SegundoNombre { get; set; }

        [Required]
        [StringLength(205)]
        public string NombrePaciente { get; set; }

        [Required]
        [StringLength(50)]
        public string PrimerApellido { get; set; }

        [StringLength(50)]
        public string SegundoApellido { get; set; }

        [Required]
        [StringLength(1)]
        public string CodSexo { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

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
        public string Barrio { get; set; }

        [Required]
        [StringLength(100)]
        public string Ocupacion { get; set; }

        [Required]
        [StringLength(1)]
        public string CodEstadoCivil { get; set; }

        [Required]
        [StringLength(100)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(1)]
        public string CodZona { get; set; }

        [StringLength(50)]
        public string Correo { get; set; }


        [NotMapped]
        public string sFechaNacimiento { get { return this.FechaNacimiento.ToString("dd/MM/yyyy"); } }
    }
}
