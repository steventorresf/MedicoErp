using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.Admision.Entities;
using MedicoErp.Areas.General.Entities;
using MedicoErp.Areas.HistoriaClinica.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MedicoErp.Models
{
    public class BaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            optionsBuilder.UseSqlServer(builder.Build().GetConnectionString("MedicoErpDbContext"), options => { });
        }

        #region Administracion
        public virtual DbSet<CentroAtencion> CentrosAtencions { get; set; }

        public virtual DbSet<ClaseServicio> ClasesServicios { get; set; }

        public virtual DbSet<Convenio> Convenios { get; set; }

        public virtual DbSet<Especialidad> Especialidades { get; set; }

        public virtual DbSet<Paciente> Pacientes { get; set; }

        public virtual DbSet<Resolucion> Resoluciones { get; set; }

        public virtual DbSet<Servicio> Servicios { get; set; }

        public virtual DbSet<ServicioContratado> ServiciosContratados { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        #endregion

        #region Admision
        public virtual DbSet<Citas> Citas { get; set; }

        public virtual DbSet<Facturacion> Facturacions { get; set; }

        public virtual DbSet<Horarios> Horarios { get; set; }

        public virtual DbSet<HorariosLog> HorariosLogs { get; set; }
        #endregion

        #region General
        public virtual DbSet<Departamentos> Departamentos { get; set; }

        public virtual DbSet<Errores> Errores { get; set; }

        public virtual DbSet<IniciosSesion> IniciosSesions { get; set; }

        public virtual DbSet<Municipios> Municipios { get; set; }

        public virtual DbSet<Menu> Menu { get; set; }

        public virtual DbSet<MenuUsuario> MenuUsuarios { get; set; }

        public virtual DbSet<Tablas> Tablas { get; set; }

        public virtual DbSet<TablasDetalle> TablasDetalles { get; set; }
        #endregion

        #region HistoriaClinica
        public virtual DbSet<Diagnosticos> Diagnosticos { get; set; }

        public virtual DbSet<Eventos> Eventos { get; set; }

        public virtual DbSet<Formulaciones> Formulaciones { get; set; }

        public virtual DbSet<FormulacionesDetalle> FormulacionesDetalle { get; set; }

        public virtual DbSet<FormulacionesDetalleTemp> FormulacionesDetalleTemp { get; set; }

        public virtual DbSet<Multimedia> Multimedia { get; set; }

        public virtual DbSet<MultimediaTemporal> MultimediaTemporal { get; set; }

        public virtual DbSet<Ordenes> Ordenes { get; set; }

        public virtual DbSet<OrdenesDetalle> OrdenesDetalle { get; set; }

        public virtual DbSet<OrdenesDetalleTemp> OrdenesDetalleTemp { get; set; }
        #endregion
    }
}
