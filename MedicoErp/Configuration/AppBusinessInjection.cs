using Microsoft.Extensions.DependencyInjection;

namespace MedicoErp.Configuration
{
    public static class AppBusinessInjection
    {
        public static IServiceCollection AddBusinessInjection(this IServiceCollection services)
        {
            #region Admision Injection
            services.AddScoped<Model.Abstract.Admision.ICitaBusiness, Model.Business.Admision.CitaBusiness>();
            services.AddScoped<Model.Abstract.Admision.IConvenioBusiness, Model.Business.Admision.ConvenioBusiness>();
            services.AddScoped<Model.Abstract.Admision.IConvenioServicioBusiness, Model.Business.Admision.ConvenioServicioBusiness>();
            services.AddScoped<Model.Abstract.Admision.IFacturacionBusiness, Model.Business.Admision.FacturacionBusiness>();
            services.AddScoped<Model.Abstract.Admision.IHorarioBusiness, Model.Business.Admision.HorarioBusiness>();
            services.AddScoped<Model.Abstract.Admision.IPacienteBusiness, Model.Business.Admision.PacienteBusiness>();
            services.AddScoped<Model.Abstract.Admision.IServicioOrdenadoBusiness, Model.Business.Admision.ServicioOrdenadoBusiness>();
            #endregion

            #region General Injection
            services.AddScoped<Model.Abstract.General.ICentroAtencionBusiness, Model.Business.General.CentroAtencionBusiness>();
            services.AddScoped<Model.Abstract.General.IClaseServicioBusiness, Model.Business.General.ClaseServicioBusiness>();
            services.AddScoped<Model.Abstract.General.IDepartamentoBusiness, Model.Business.General.DepartamentoBusiness>();
            services.AddScoped<Model.Abstract.General.IErrorBusiness, Model.Business.General.ErrorBusiness>();
            services.AddScoped<Model.Abstract.General.IMenuUsuarioBusiness, Model.Business.General.MenuUsuarioBusiness>();
            services.AddScoped<Model.Abstract.General.IMunicipioBusiness, Model.Business.General.MunicipioBusiness>();
            services.AddScoped<Model.Abstract.General.IServicioBusiness, Model.Business.General.ServicioBusiness>();
            services.AddScoped<Model.Abstract.General.ITablaDetalleBusiness, Model.Business.General.TablaDetalleBusiness>();
            services.AddScoped<Model.Abstract.General.ITipoServicioBusiness, Model.Business.General.TipoServicioBusiness>();
            services.AddScoped<Model.Abstract.General.IUsuarioBusiness, Model.Business.General.UsuarioBusiness>();
            #endregion

            #region HistoriaClinica Injection
            services.AddScoped<Model.Abstract.HistoriaClinica.IDiagnosticoBusiness, Model.Business.HistoriaClinica.DiagnosticoBusiness>();
            services.AddScoped<Model.Abstract.HistoriaClinica.IEventoBusiness, Model.Business.HistoriaClinica.EventoBusiness>();
            services.AddScoped<Model.Abstract.HistoriaClinica.IFolioBusiness, Model.Business.HistoriaClinica.FolioBusiness>();
            services.AddScoped<Model.Abstract.HistoriaClinica.IFolioDetalleBusiness, Model.Business.HistoriaClinica.FolioDetalleBusiness>();
            services.AddScoped<Model.Abstract.HistoriaClinica.IFormatoBusiness, Model.Business.HistoriaClinica.FormatoBusiness>();
            services.AddScoped<Model.Abstract.HistoriaClinica.IFormulacionBusiness, Model.Business.HistoriaClinica.FormulacionBusiness>();
            services.AddScoped<Model.Abstract.HistoriaClinica.IFormulacionDetalleBusinessTemp, Model.Business.HistoriaClinica.FormulacionDetalleBusinessTemp>();
            services.AddScoped<Model.Abstract.HistoriaClinica.IMultimediaBusiness, Model.Business.HistoriaClinica.MultimediaBusiness>();
            services.AddScoped<Model.Abstract.HistoriaClinica.IMultimediaTemporalBusiness, Model.Business.HistoriaClinica.MultimediaTemporalBusiness>();
            services.AddScoped<Model.Abstract.HistoriaClinica.IOrdenBusiness, Model.Business.HistoriaClinica.OrdenBusiness>();
            services.AddScoped<Model.Abstract.HistoriaClinica.IOrdenDetalleBusinessTemp, Model.Business.HistoriaClinica.OrdenDetalleBusinessTemp>();
            #endregion

            #region Informes Injection
            services.AddScoped<Model.Abstract.Informes.IInformeBusiness, Model.Business.Informes.InformeBusiness>();
            #endregion

            return services;
        }
    }
}
