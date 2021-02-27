using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Utiles
{
    public class CamposAuditables
    {
        [Required]
        public DateTimeOffset FechaCreado { get; set; }

        [Required]
        [StringLength(50)]
        public string CreadoPor { get; set; }

        public DateTimeOffset? FechaModificado { get; set; }

        [StringLength(50)]
        public string ModificadoPor { get; set; }
    }
}
