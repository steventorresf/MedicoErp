using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicoErp.Model.Abstract.General
{
    public interface IClaseServicioBusiness
    {
        List<ClaseServicio> GetClasesServicios();
    }
}
