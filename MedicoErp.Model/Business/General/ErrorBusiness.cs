using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Business.General
{
    public class ErrorBusiness : IErrorBusiness
    {
        private readonly MedicoErpContext context;

        public ErrorBusiness(MedicoErpContext _context)
        {
            this.context = _context;
        }


        public void Create(string Metodo, Exception ex, int? IdUsuario)
        {
            try
            {
                var message = ex.StackTrace.ToString();
                Error entity = new Error
                {
                    Metodo = Metodo,
                    MensajeError = message.Length > 500 ? message.Substring(0, 500) : message,
                    IdUsuario = IdUsuario,
                    FechaError = DateTimeOffset.Now
                };
                context.Error.Add(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
