using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Models;
using MedicoErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.Administracion.Business
{
    public class ConvenioBusiness
    {
        public void Create(Convenio entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                context.Convenios.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateConvenio", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdConvenio, Convenio entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                Convenio obCon = context.Convenios.Find(IdConvenio);
                obCon.NombreConvenio = entity.NombreConvenio;
                obCon.NombreEps = entity.NombreEps;
                obCon.CodTipoUsuario = entity.CodTipoUsuario;
                obCon.CodTipoFact = entity.CodTipoFact;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateConvenio", ex.Message, null);
                throw;
            }
        }

        public void Inactivar(int IdConvenio)
        {
            try
            {
                BaseContext context = new BaseContext();
                Convenio obCon = context.Convenios.Find(IdConvenio);
                obCon.CodEstado = Constantes.EstadoInactivo;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("InactivarConvenio", ex.Message, null);
                throw;
            }
        }

        public void Activar(int IdConvenio)
        {
            try
            {
                BaseContext context = new BaseContext();
                Convenio obCon = context.Convenios.Find(IdConvenio);
                obCon.CodEstado = Constantes.EstadoActivo;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ActivarConvenio", ex.Message, null);
                throw;
            }
        }

        public List<Convenio> GetConvenios(int IdCentro)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Convenio> Lista = (from co in context.Convenios.Where(x => x.IdCentro == IdCentro)
                                         join es in context.TablasDetalles.Where(x => x.CodTabla.Equals(Constantes.TabEstados)) on co.CodEstado equals es.CodValor
                                         join tf in context.TablasDetalles.Where(x => x.CodTabla.Equals(Constantes.TabTipoFact)) on co.CodTipoFact equals tf.CodValor
                                         join tu in context.TablasDetalles.Where(x => x.CodTabla.Equals(Constantes.TabTipoUsuario)) on co.CodTipoUsuario equals tu.CodValor
                                         select new Convenio()
                                         {
                                             IdConvenio = co.IdConvenio,
                                             IdCentro = co.IdCentro,
                                             NombreConvenio = co.NombreConvenio,
                                             NombreEps = co.NombreEps,
                                             CodTipoUsuario = co.CodTipoUsuario,
                                             CodTipoFact = co.CodTipoFact,
                                             CodEstado = co.CodEstado,
                                             NombreEstado = es.Descripcion,
                                             TipoFacturacion = tf.Descripcion,
                                             TextTipoUsuario = tu.Descripcion,
                                         }).OrderBy(x => x.NombreConvenio).OrderBy(x => x.CodEstado).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetConvenios", ex.Message, null);
                throw;
            }
        }

        public List<Convenio> GetConveniosActivos(int IdCentro)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Convenio> Lista = context.Convenios.Where(x => x.IdCentro == IdCentro && x.CodEstado.Equals(Constantes.EstadoActivo)).OrderBy(x => x.NombreConvenio).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetConveniosActivos", ex.Message, null);
                throw;
            }
        }

    }
}
