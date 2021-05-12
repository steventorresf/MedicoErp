using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicoErp.Model.Entities.HistoriaClinica
{
    [Table("Folio", Schema = "HistoriaClinica")]
    public class Folio : Common.Auditoria
    {
        [Key]
        public long IdFolio { get; set; }

        [Required]
        public long IdEvento { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        public int NoFolio { get; set; }

        [Required]
        public int IdFormato { get; set; }

        [Required]
        public DateTimeOffset FechaFolio { get; set; }

        [Required]
        [StringLength(2)]
        public string CodEstado { get; set; }


        [NotMapped]
        public Evento Evento { get; set; }

        [NotMapped]
        public Formato Formato { get; set; }

        [NotMapped]
        public string sFechaFolio { get; set; }

        [NotMapped]
        public string NombreConvenio { get; set; }

        [NotMapped]
        public string NombreMedico { get; set; }

        [NotMapped]
        public List<FolioDetalle> ListaFoliosDetalle { get; set; }

        [NotMapped]
        public List<Area> ListaAreas { get; set; }
    }
}
