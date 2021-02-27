using MedicoErp.Model.Abstract.Admision;
using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.Admision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Business.Admision
{
    public class PacienteBusiness : IPacienteBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public PacienteBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public void Create(Paciente entity)
        {
            try
            {
                entity.NombrePaciente = entity.PrimerNombre + (string.IsNullOrEmpty(entity.SegundoNombre) ? " " : " " + entity.SegundoNombre + " ") + entity.PrimerApellido + (string.IsNullOrEmpty(entity.SegundoApellido) ? "" : " " + entity.SegundoApellido);
                context.Paciente.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreatePaciente", ex, null);
                throw;
            }
        }

        public void Update(long IdPaciente, Paciente entity)
        {
            try
            {
                Paciente obPac = context.Paciente.Find(IdPaciente);
                obPac.PrimerNombre = entity.PrimerNombre;
                obPac.SegundoNombre = entity.SegundoNombre;
                obPac.PrimerApellido = entity.PrimerApellido;
                obPac.SegundoApellido = entity.SegundoApellido;
                obPac.NombrePaciente = entity.PrimerNombre + (string.IsNullOrEmpty(entity.SegundoNombre) ? " " : " " + entity.SegundoNombre + " ") + entity.PrimerApellido + (string.IsNullOrEmpty(entity.SegundoApellido) ? "" : " " + entity.SegundoApellido);
                obPac.CodSexo = entity.CodSexo;
                obPac.CodDepartamento = entity.CodDepartamento;
                obPac.CodMunicipio = entity.CodMunicipio;
                obPac.FechaNacimiento = entity.FechaNacimiento;
                obPac.Direccion = entity.Direccion;
                obPac.Telefono = entity.Telefono;
                obPac.Barrio = entity.Barrio;
                obPac.Ocupacion = entity.Ocupacion;
                obPac.CodEstadoCivil = entity.CodEstadoCivil;
                obPac.CodZona = entity.CodZona;
                obPac.Correo = entity.Correo;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdatePaciente", ex, null);
                throw;
            }
        }

        public Paciente GetPacienteByIdent(string TipoIden, string NumIden)
        {
            try
            {
                Paciente entity = context.Paciente.FirstOrDefault(x => x.NumIden.Equals(NumIden) && x.TipoIden.Equals(TipoIden));
                return entity;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetPacienteByIdent", ex, null);
                throw;
            }
        }
    }
}
