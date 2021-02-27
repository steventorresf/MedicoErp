﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicoErp.Areas.Administracion.Entities
{
    [Table("ClaseServicio", Schema = "Administracion")]
    public class ClaseServicio
    {
        [Key]
        public int IdClaseServicio { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreClaseServicio { get; set; }

        [Required]
        [StringLength(2)]
        public string TipoRips { get; set; }

        [Required]
        public bool Visible { get; set; }
    }
}
