using MedicoErp.Model.Entities.HistoriaClinica;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.HistoriaClinica
{
    public interface IMultimediaTemporalBusiness
    {
        List<MultimediaTemporal> GetAllTemporalesByIdUsuario(int IdUsuario);
        void SubirImagenTemporal(JObject data);
        void DeleteAll(int IdUsuario, int IdCentro);
        void Delete(int IdDetalle, int IdCentro);
    }
}
