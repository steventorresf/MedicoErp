﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.HistoriaClinica
{
    [Table("MultimediaTemporal", Schema = "HistoriaClinica")]
    public class MultimediaTemporal
    {
        [Key]
        public int IdDetalle { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreImg { get; set; }

        [Required]
        public int Orden { get; set; }
    }
}
