using MedicoErp.Model.Abstract.Admision;
using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.Admision;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicoErp.Model.Business.Admision
{
    public class ServicioOrdenadoBusiness : IServicioOrdenadoBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public ServicioOrdenadoBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public List<ServicioOrdenado> getAllByIdPacAndIdCon(int IdCentro, long IdPaciente, int IdConvenio)
        {
            try
            {
                List<ServicioOrdenado> Lista = (from so in context.ServicioOrdenado.Where(x => x.IdPaciente == IdPaciente && x.IdConvenio == IdConvenio && x.IdCentro == IdCentro && x.IdFacturacion == null)
                                                join se in context.Servicio on so.IdServicio equals se.IdServicio
                                                join od in context.Orden on so.IdOrden equals od.IdOrden into LeftJoinOrd
                                                from LOrd in LeftJoinOrd.DefaultIfEmpty()
                                                join me in context.Usuario on so.IdMedico equals me.IdUsuario into LeftJoinMed
                                                from LMed in LeftJoinMed.DefaultIfEmpty()
                                                select new ServicioOrdenado()
                                                {
                                                    IdServicioOrdenado = so.IdServicioOrdenado,
                                                    Fecha = so.Fecha,
                                                    sFecha = so.Fecha.ToString("dd/MM/yyyy"),
                                                    sFechaFormato = so.Fecha.ToString("yyyy-MM-dd"),
                                                    IdPaciente = so.IdPaciente,
                                                    IdConvenio = so.IdConvenio,
                                                    IdServicio = so.IdServicio,
                                                    FechaCreado = so.FechaCreado,
                                                    CreadoPor = so.CreadoPor,
                                                    FechaModificado = so.FechaModificado,
                                                    ModificadoPor = so.ModificadoPor,
                                                    Cantidad = so.Cantidad,
                                                    Tarifa = so.Tarifa,
                                                    Descuento = so.Descuento,
                                                    IdOrden = so.IdOrden,
                                                    NoOrden = LOrd == null ? "" : LOrd.NoOrden.ToString(),
                                                    Servicio = se,
                                                    IdMedico = so.IdMedico,
                                                    NombreMedico = LMed.NombreCompleto,
                                                }).OrderByDescending(x => x.Fecha).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("getAllByIdPacAndIdCon", ex, null);
                throw;
            }
        }

        public void Create(ServicioOrdenado entity)
        {
            try
            {
                entity.Fecha = DateTimeOffset.Now;
                entity.FechaCreado = DateTimeOffset.Now;
                context.ServicioOrdenado.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateServicioOrdenado", ex, null);
                throw;
            }
        }

        public void UpdateTarifaDescuento(JObject data)
        {
            try
            {
                long IdServicioOrdenado = data["idServicioOrdenado"].ToObject<long>();
                decimal Tarifa = data["tarifa"].ToObject<decimal>();
                decimal Descuento = data["descuento"].ToObject<decimal>();

                ServicioOrdenado entity = context.ServicioOrdenado.Find(IdServicioOrdenado);
                entity.Tarifa = Tarifa;
                entity.Descuento = Descuento;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateTarifaDescuento", ex, null);
                throw;
            }
        }

        public void Delete(long IdServicioOrdenado)
        {
            try
            {
                ServicioOrdenado entity = context.ServicioOrdenado.FirstOrDefault(x => x.IdServicioOrdenado == IdServicioOrdenado);
                context.ServicioOrdenado.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("DeleteServicioOrdenado", ex, null);
                throw;
            }
        }

    }
}
