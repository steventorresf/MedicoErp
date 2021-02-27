using MedicoErp.Areas.Administracion.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.HistoriaClinica.Entities
{
    [Table("Eventos", Schema = "HistoriaClinica")]
    public class Eventos : Utiles.CamposAuditables
    {
        [Key]
        public long IdEvento { get; set; }

        [Required]
        public long NoEvento { get; set; }

        [Required]
        public DateTimeOffset FechaEvento { get; set; }

        [Required]
        [StringLength(1)]
        public string TipoEvento { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        public long IdPaciente { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        [StringLength(2)]
        public string TipoIden { get; set; }

        [Required]
        [StringLength(50)]
        public string NumIden { get; set; }

        [StringLength(100)]
        public string NombreAcomp { get; set; }

        [StringLength(100)]
        public string TelefonoAcomp { get; set; }

        [Required]
        public int IdContrato { get; set; }

        public string Evolucion { get; set; }

        public string BiopsiaAnterior { get; set; }

        public string AyudasDiagnosticas { get; set; }

        public string Anexos { get; set; }

        [StringLength(4)]
        public string CodDiagPal { get; set; }

        [StringLength(4)]
        public string CodDiagRel1 { get; set; }

        [StringLength(4)]
        public string CodDiagRel2 { get; set; }

        [StringLength(4)]
        public string CodDiagRel3 { get; set; }

        [StringLength(2)]
        public string CodFinalCons { get; set; }

        [StringLength(2)]
        public string CodCausaExt { get; set; }

        [StringLength(2)]
        public string TipoDiag { get; set; }

        [Required]
        [StringLength(2)]
        public string CodEstado { get; set; }

        public DateTimeOffset? FechaFinalizado { get; set; }

        [StringLength(50)]
        public string FinalizadoPor { get; set; }

        
        // Not Mapped
        [NotMapped]
        public CentroAtencion Centro { get; set; }

        [NotMapped]
        public Paciente Paciente { get; set; }

        [NotMapped]
        public string Edad { get; set; }

        [NotMapped]
        public string TipoUsuario { get; set; }

        [NotMapped]
        public string EstadoCivil { get; set; }

        [NotMapped]
        public Convenio Convenio { get; set; }

        [NotMapped]
        public Usuario Medico { get; set; }

        [NotMapped]
        public string sFechaEvento { get; set; }

        [NotMapped]
        public string sFechaNacimiento { get; set; }

        [NotMapped]
        public Diagnosticos DiagnosticoPal { get; set; }

        [NotMapped]
        public Diagnosticos DiagnosticoRel1 { get; set; }

        [NotMapped]
        public string Firma { get; set; }
    }
}
