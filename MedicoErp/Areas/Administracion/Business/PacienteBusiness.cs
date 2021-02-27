using MedicoErp.Areas.Administracion.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.Administracion.Business
{
    public class PacienteBusiness
    {
        public void Create(Paciente entity)
        {
            try
            {
                entity.NombrePaciente = entity.PrimerNombre + (string.IsNullOrEmpty(entity.SegundoNombre) ? " " : " " + entity.SegundoNombre + " ") + entity.PrimerApellido + (string.IsNullOrEmpty(entity.SegundoApellido) ? "" : " " + entity.SegundoApellido);

                BaseContext context = new BaseContext();
                context.Pacientes.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreatePaciente", ex.Message, null);
                throw;
            }
        }

        public void Update(long IdPaciente, Paciente entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                Paciente obPac = context.Pacientes.Find(IdPaciente);
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
                ErroresBusiness.Create("UpdatePaciente", ex.Message, null);
                throw;
            }
        }

        public Paciente GetPacienteByIdent(string TipoIden,string NumIden)
        {
            try
            {
                BaseContext context = new BaseContext();
                Paciente entity = context.Pacientes.FirstOrDefault(x => x.NumIden.Equals(NumIden) && x.TipoIden.Equals(TipoIden));
                return entity;
            }
            catch(Exception ex)
            {
                ErroresBusiness.Create("GetPacienteByIdent", ex.Message, null);
                throw;
            }
        }
    }
}
