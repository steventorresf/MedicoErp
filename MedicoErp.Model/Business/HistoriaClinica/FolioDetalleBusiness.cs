using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Abstract.HistoriaClinica;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.HistoriaClinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicoErp.Model.Business.HistoriaClinica
{
    public class FolioDetalleBusiness : IFolioDetalleBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public FolioDetalleBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public void Update(long IdDetalle, FolioDetalle entity)
        {
            try
            {
                FolioDetalle entityFolDet = context.FolioDetalle.FirstOrDefault(x => x.IdDetalle == IdDetalle);
                entityFolDet.Valor = entity.Valor;
                entityFolDet.Respuesta = entity.Respuesta;
                entityFolDet.ModificadoPor = entity.ModificadoPor;
                entityFolDet.FechaModificado = DateTimeOffset.Now;
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                errorBusiness.Create("UpdateFolioDetalle", ex, null);
                throw;
            }
        }
    }
}
