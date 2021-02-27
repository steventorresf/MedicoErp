using MedicoErp.Model.Abstract.Admision;
using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Common;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.Admision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Business.Admision
{
    public class ConvenioBusiness : IConvenioBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public ConvenioBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public void Create(Convenio entity)
        {
            try
            {
                context.Convenio.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateConvenio", ex, null);
                throw;
            }
        }

        public void Update(int IdConvenio, Convenio entity)
        {
            try
            {
                Convenio obCon = context.Convenio.Find(IdConvenio);
                obCon.NombreConvenio = entity.NombreConvenio;
                obCon.NombreEps = entity.NombreEps;
                obCon.CodTipoUsuario = entity.CodTipoUsuario;
                obCon.CodTipoFact = entity.CodTipoFact;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateConvenio", ex, null);
                throw;
            }
        }

        public void Inactivar(int IdConvenio)
        {
            try
            {
                Convenio obCon = context.Convenio.Find(IdConvenio);
                obCon.CodEstado = Constantes.EstadoInactivo;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("InactivarConvenio", ex, null);
                throw;
            }
        }

        public void Activar(int IdConvenio)
        {
            try
            {
                Convenio obCon = context.Convenio.Find(IdConvenio);
                obCon.CodEstado = Constantes.EstadoActivo;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("ActivarConvenio", ex, null);
                throw;
            }
        }

        public List<Convenio> GetConvenios(int IdCentro)
        {
            try
            {
                List<Convenio> Lista = (from co in context.Convenio.Where(x => x.IdCentro == IdCentro)
                                        join es in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabEstados)) on co.CodEstado equals es.CodValor
                                        join tf in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabTipoFact)) on co.CodTipoFact equals tf.CodValor
                                        join tu in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabTipoUsuario)) on co.CodTipoUsuario equals tu.CodValor
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
                errorBusiness.Create("GetConvenios", ex, null);
                throw;
            }
        }

        public List<Convenio> GetConveniosActivos(int IdCentro)
        {
            try
            {
                List<Convenio> Lista = context.Convenio.Where(x => x.IdCentro == IdCentro && x.CodEstado.Equals(Constantes.EstadoActivo)).OrderBy(x => x.NombreConvenio).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetConveniosActivos", ex, null);
                throw;
            }
        }
    }
}
