using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicoErp.Model.Abstract.General
{
    public interface ICentroAtencionBusiness
    {
        CentroAtencion GetById(int IdCentro);
        List<CentroAtencion> GetAll(int IdCentro);
        List<CentroAtencion> GetAllExternos(int IdCentro);
        void Create(CentroAtencion entity);
        void Update(int IdCentro, CentroAtencion entity);
        void UpdateExterno(int IdCentro, CentroAtencion entity);
    }
}
