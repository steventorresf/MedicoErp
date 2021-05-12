using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Common;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicoErp.Model.Business.General
{
    public class CentroAtencionBusiness : ICentroAtencionBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public CentroAtencionBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public CentroAtencion GetById(int IdCentro)
        {
            try
            {
                CentroAtencion entity = context.CentroAtencion.Find(IdCentro);
                return entity;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetById", ex, null);
                throw;
            }
        }

        public List<CentroAtencion> GetAll(int IdCentro)
        {
            try
            {
                List<CentroAtencion> Lista = (from ce in context.CentroAtencion.Where(x => x.IdPadre == IdCentro || x.IdCentro == IdCentro)
                                              join mu in context.Municipio on new { M = ce.CodMunicipio, D = ce.CodDepartamento } equals new { M = mu.CodMunicipio, D = mu.CodDepartamento }
                                              join dp in context.Departamento on ce.CodDepartamento equals dp.CodDepartamento
                                              join es in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabEstados)) on ce.CodEstado equals es.CodValor
                                              where ce.CodEstado.Equals(Constantes.EstadoActivo)
                                              select new CentroAtencion()
                                              {
                                                  IdCentro = ce.IdCentro,
                                                  NitCentro = ce.NitCentro,
                                                  NombreCentro = ce.NombreCentro,
                                                  CodPrestador = ce.CodPrestador,
                                                  CodDepartamento = ce.CodDepartamento,
                                                  CodMunicipio = ce.CodMunicipio,
                                                  Direccion = ce.Direccion,
                                                  Telefono = ce.Telefono,
                                                  IdPadre = ce.IdPadre,
                                                  CodEstado = ce.CodEstado,
                                                  NomDepartamento = dp.NomDepartamento,
                                                  NomMunicipio = mu.NomMunicipio,
                                                  NombreEstado = es.Descripcion,
                                              }).OrderBy(x => x.NombreCentro).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllExternos", ex, null);
                throw;
            }
        }

        public List<CentroAtencion> GetAllExternos(int IdCentro)
        {
            try
            {
                List<CentroAtencion> Lista = (from ce in context.CentroAtencion.Where(x => x.IdPadre == IdCentro && x.Externo)
                                              join mu in context.Municipio on new { M = ce.CodMunicipio, D = ce.CodDepartamento } equals new { M = mu.CodMunicipio, D = mu.CodDepartamento }
                                              join dp in context.Departamento on ce.CodDepartamento equals dp.CodDepartamento
                                              join es in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabEstados)) on ce.CodEstado equals es.CodValor
                                              select new CentroAtencion()
                                              {
                                                  IdCentro = ce.IdCentro,
                                                  NitCentro = ce.NitCentro,
                                                  NombreCentro = ce.NombreCentro,
                                                  CodPrestador = ce.CodPrestador,
                                                  CodDepartamento = ce.CodDepartamento,
                                                  CodMunicipio = ce.CodMunicipio,
                                                  Direccion = ce.Direccion,
                                                  Telefono = ce.Telefono,
                                                  IdPadre = ce.IdPadre,
                                                  CodEstado = ce.CodEstado,
                                                  NomDepartamento = dp.NomDepartamento,
                                                  NomMunicipio = mu.NomMunicipio,
                                                  NombreEstado = es.Descripcion,
                                              }).OrderBy(x => x.NombreCentro).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllExternos", ex, null);
                throw;
            }
        }

        public void Create(CentroAtencion entity)
        {
            try
            {
                context.CentroAtencion.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateExterno", ex, null);
                throw;
            }
        }

        public void Update(int IdCentro, CentroAtencion entity)
        {
            try
            {
                CentroAtencion ob = context.CentroAtencion.Find(IdCentro);
                ob.NitCentro = entity.NitCentro;
                ob.NombreCentro = entity.NombreCentro;
                ob.CodPrestador = entity.CodPrestador;
                ob.CodDepartamento = entity.CodDepartamento;
                ob.CodMunicipio = entity.CodMunicipio;
                ob.Direccion = entity.Direccion;
                ob.Telefono = entity.Telefono;
                ob.CodEstado = entity.CodEstado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("Update", ex, null);
                throw;
            }
        }

        public void UpdateExterno(int IdCentro, CentroAtencion entity)
        {
            try
            {
                CentroAtencion ob = context.CentroAtencion.Find(IdCentro);
                ob.NitCentro = entity.NitCentro;
                ob.NombreCentro = entity.NombreCentro;
                ob.CodPrestador = entity.CodPrestador;
                ob.CodDepartamento = entity.CodDepartamento;
                ob.CodMunicipio = entity.CodMunicipio;
                ob.Direccion = entity.Direccion;
                ob.Telefono = entity.Telefono;
                ob.CodEstado = entity.CodEstado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateExterno", ex, null);
                throw;
            }
        }

    }
}
