using MedicoErp.Areas.General.Entities;
using MedicoErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MedicoErp.Areas.General.Business
{
    public class ErroresBusiness
    {
        public static void Create(string Metodo,string MensajeError, int? IdUsuario)
        {
            try
            {
                Errores entity = new Errores();
                entity.Metodo = Metodo;
                entity.MensajeError = MensajeError;
                entity.IdUsuario = IdUsuario;
                entity.FechaError = DateTimeOffset.Now;

                BaseContext context = new BaseContext();
                context.Errores.Add(entity);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public List<Errores> GetErrores()
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Errores> Lista = context.Errores.ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                Create("GetErrores", ex.Message, null);
                throw;
            }
        }

    }
}
