using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.Administracion.Business
{
    public class CentroAtencionBusiness
    {
        public CentroAtencion GetCentroAtencion(int IdCentro)
        {
            try
            {
                BaseContext context = new BaseContext();
                CentroAtencion entity = context.CentrosAtencions.Find(IdCentro);
                return entity;
            }
            catch(Exception ex)
            {
                ErroresBusiness.Create("GetCentroAtencion", ex.Message, null);
                throw;
            }
        }

        public static long GetNoVolante(int IdCentro)
        {
            try
            {
                BaseContext context = new BaseContext();
                CentroAtencion entity = context.CentrosAtencions.Find(IdCentro);
                entity.NoVolante += 1;
                context.SaveChanges();
                return entity.NoVolante;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetNoVolante", ex.Message, null);
                throw;
            }
        }

        public static long GetNoCita(int IdCentro)
        {
            try
            {
                BaseContext context = new BaseContext();
                CentroAtencion entity = context.CentrosAtencions.Find(IdCentro);
                entity.NoCita += 1;
                context.SaveChanges();
                return entity.NoCita;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetNoCita", ex.Message, null);
                throw;
            }
        }

        public static long GetNoEvento(int IdCentro)
        {
            try
            {
                BaseContext context = new BaseContext();
                CentroAtencion entity = context.CentrosAtencions.Find(IdCentro);
                entity.NoEvento += 1;
                context.SaveChanges();
                return entity.NoEvento;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetNoEvento", ex.Message, null);
                throw;
            }
        }

        public static long GetNoFolio(int IdCentro)
        {
            try
            {
                BaseContext context = new BaseContext();
                CentroAtencion entity = context.CentrosAtencions.Find(IdCentro);
                entity.NoFolio += 1;
                context.SaveChanges();
                return entity.NoFolio;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetNoFolio", ex.Message, null);
                throw;
            }
        }

        public static long GetNoFormulacion(int IdCentro)
        {
            try
            {
                BaseContext context = new BaseContext();
                CentroAtencion entity = context.CentrosAtencions.Find(IdCentro);
                entity.NoFormulacion += 1;
                context.SaveChanges();
                return entity.NoFormulacion;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetNoFormulacion", ex.Message, null);
                throw;
            }
        }

        public static long GetNoOrden(int IdCentro)
        {
            try
            {
                BaseContext context = new BaseContext();
                CentroAtencion entity = context.CentrosAtencions.Find(IdCentro);
                entity.NoOrden += 1;
                context.SaveChanges();
                return entity.NoOrden;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetNoOrden", ex.Message, null);
                throw;
            }
        }
    }
}
