using MedicoErp.Areas.Administracion.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.HistoriaClinica.Entities
{
    [Table("Formulaciones", Schema = "HistoriaClinica")]
    public class Formulaciones : Utiles.CamposAuditables
    {
        [Key]
        public long IdFormulacion { get; set; }

        [Required]
        public long NoFormulacion { get; set; }

        [Required]
        public long IdEvento { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        public DateTimeOffset FechaFormulacion { get; set; }

        [StringLength(50)]
        public string TiempoEvo { get; set; }

        [StringLength(50)]
        public string ProxControl { get; set; }

        [Required]
        [StringLength(2)]
        public string CodEstado { get; set; }


        [NotMapped]
        public string sFechaFormulacion { get; set; }

        [NotMapped]
        public string NombreMedico { get; set; }

        [NotMapped]
        public string NombreConvenio { get; set; }

        [NotMapped]
        public string TipoUsuario { get; set; }

        [NotMapped]
        public CentroAtencion Centro { get; set; }

        [NotMapped]
        public Paciente Paciente { get; set; }

        [NotMapped]
        public Convenio Convenio { get; set; }

        [NotMapped]
        public Usuario Medico { get; set; }

        [NotMapped]
        public string sFechaNacimiento { get; set; }

        [NotMapped]
        public string Firma { get; set; }

        [NotMapped]
        public List<FormulacionesDetalle> ListFormulacionDetalle { get; set; }
    }
}
