using MedicoErp.Model.Entities.HistoriaClinica;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicoErp.Model.Abstract.HistoriaClinica
{
    public interface IFolioDetalleBusiness
    {
        void Update(long IdDetalle, FolioDetalle entity);
    }
}
