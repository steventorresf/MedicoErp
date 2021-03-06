﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Entities.Admision
{
    [Table("Cita", Schema = "Admision")]
    public class Cita : Common.Auditoria
    {
        [Key]
        public long IdCita { get; set; }

        [Required]
        public int NoCita { get; set; }

        public int? IdFacturacion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(20)]
        public string Hora { get; set; }

        public long? IdReserva { get; set; }

        [Required]
        public long IdPaciente { get; set; }

        [StringLength(100)]
        public string NombreAcomp { get; set; }

        [StringLength(100)]
        public string TelefonoAcomp { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        public int IdCentroRemision { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        public int IdConvenio { get; set; }

        [Required]
        public int IdServicio { get; set; }

        [Required]
        public short Cantidad { get; set; }

        [Required]
        public decimal Tarifa { get; set; }

        [Required]
        public decimal Descuento { get; set; }

        public long? IdEvento { get; set; }

        [Required]
        [StringLength(2)]
        public string CodEstado { get; set; }



        // NotMapped
        [NotMapped]
        public string TipoDocumento { get; set; }

        [NotMapped]
        public string NumDocumento { get; set; }

        [NotMapped]
        public string NombreCentro { get; set; }

        [NotMapped]
        public string DireccionCentro { get; set; }

        [NotMapped]
        public string CodigoRef { get; set; }

        [NotMapped]
        public string NombreMedico { get; set; }

        [NotMapped]
        public string NombreClaseServicio { get; set; }

        [NotMapped]
        public string NombreServicio { get; set; }

        [NotMapped]
        public string NombreConvenio { get; set; }

        [NotMapped]
        public string NombrePaciente { get; set; }

        [NotMapped]
        public string NombreEstado { get; set; }

        [NotMapped]
        public string TipoIdentificacion { get; set; }

        [NotMapped]
        public string Identificacion { get; set; }

        [NotMapped]
        public string Telefono { get; set; }

        [NotMapped]
        public string SFecha { get; set; }

        [NotMapped]
        public DateTime HoraDate { get; set; }

        [NotMapped]
        public long IdServicioOrdenado { get; set; }

        [NotMapped]
        public decimal VrTotal { get; set; }
    }
}
