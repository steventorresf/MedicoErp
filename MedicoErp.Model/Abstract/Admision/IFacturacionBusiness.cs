using MedicoErp.Model.Entities.Admision;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.Admision
{
    public interface IFacturacionBusiness
    {
        int CreateByFacturacion(JObject data);
        int CreateByFacturacionSinCita(JObject data);
        int GetIdDocumento(JObject data);
        List<Facturacion> GetAllByIdPaciente(long IdPaciente);
        Facturacion GetFacturacionImpresion(int IdFacturacion);
    }
}
