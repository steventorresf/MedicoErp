using MedicoErp.Model.Entities.Admision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.Admision
{
    public interface IPacienteBusiness
    {
        void Create(Paciente entity);
        void Update(long IdPaciente, Paciente entity);
        Paciente GetPacienteByIdent(string TipoIden, string NumIden);
    }
}
