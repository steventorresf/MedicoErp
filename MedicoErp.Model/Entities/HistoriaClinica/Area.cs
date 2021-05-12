using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicoErp.Model.Entities.HistoriaClinica
{
    [Table("Area", Schema = "HistoriaClinica")]
    public class Area : Common.Auditoria
    {
        [Key]
        public int IdArea { get; set; }

        [Required]
        public int IdFormato { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreArea { get; set; }

        [Required]
        public short Orden { get; set; }

        [Required]
        public bool Visible { get; set; }

        [Required]
        [StringLength(2)]
        public string CodEstado { get; set; }



        [NotMapped]
        public List<Pregunta> ListaPreguntas { get; set; }
    }
}
