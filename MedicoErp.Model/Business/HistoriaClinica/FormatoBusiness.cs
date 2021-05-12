using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Common;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.HistoriaClinica;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MedicoErp.Model.Business.HistoriaClinica
{
    public class FormatoBusiness : IFormatoBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public FormatoBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public List<Formato> GetAll(int IdCentro)
        {
            try
            {
                List<Formato> Lista = context.Formato.Where(x => x.IdCentro == IdCentro).OrderBy(x => x.NombreFormato).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetFormatosAll", ex, null);
                throw;
            }
        }

        public List<Formato> GetAllNotEvento(int IdCentro, long IdEvento)
        {
            try
            {
                List<Formato> Lista = (from f in context.Formato.Where(x => x.IdCentro == IdCentro)
                                       join fo in context.Folio.Where(x => x.IdEvento == IdEvento && !x.CodEstado.Equals(Constantes.EstadoAnulado)) on f.IdFormato equals fo.IdFormato into LeftJoin
                                       from LJ in LeftJoin.DefaultIfEmpty()
                                       select new Formato()
                                       {
                                           IdFormato = f.IdFormato,
                                           NombreFormato = f.NombreFormato,
                                           Orden = f.Orden,
                                           IdCentro = f.IdCentro,
                                           YaExiste = LJ == null ? false : true,
                                       }).OrderBy(x => x.NombreFormato).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetFormatosAllNotEvento", ex, null);
                throw;
            }
        }
    }
}
