using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.Administracion.Business
{
    public class EspecialidadBusiness
    {
        public List<Especialidad> GetEspecialidades()
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Especialidad> Lista = context.Especialidades.OrderBy(x => x.NombreEspecialidad).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetEspecialidades", ex.Message, null);
                throw;
            }
        }
    }
}
