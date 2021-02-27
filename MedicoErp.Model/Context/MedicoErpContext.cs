using MedicoErp.Model.Entities.Admision;
using MedicoErp.Model.Entities.General;
using MedicoErp.Model.Entities.HistoriaClinica;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Context
{
    public class MedicoErpContext : DbContext
    {
        public MedicoErpContext(DbContextOptions<MedicoErpContext> options) : base(options)
        {
        }


        #region Admision
        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<Convenio> Convenio { get; set; }
        public virtual DbSet<Facturacion> Facturacion { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<HorarioLog> HorarioLog { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<ConvenioServicio> ConvenioServicio { get; set; }
        #endregion

        #region General
        public virtual DbSet<CentroAtencion> CentroAtencion { get; set; }
        public virtual DbSet<ClaseServicio> ClaseServicio { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Error> Error { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuUsuario> MenuUsuario { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<Tabla> Tabla { get; set; }
        public virtual DbSet<TablaDetalle> TablaDetalle { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        #endregion

        #region HistoriaClinica
        public virtual DbSet<Diagnostico> Diagnostico { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Formulacion> Formulacion { get; set; }
        public virtual DbSet<FormulacionDetalle> FormulacionDetalle { get; set; }
        public virtual DbSet<FormulacionDetalleTemp> FormulacionDetalleTemp { get; set; }
        public virtual DbSet<Multimedia> Multimedia { get; set; }
        public virtual DbSet<MultimediaTemporal> MultimediaTemporal { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<OrdenDetalle> OrdenDetalle { get; set; }
        public virtual DbSet<OrdenDetalleTemp> OrdenDetalleTemp { get; set; }
        #endregion
    }
}
