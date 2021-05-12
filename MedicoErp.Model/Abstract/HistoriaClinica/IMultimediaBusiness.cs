using MedicoErp.Model.Entities.HistoriaClinica;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.HistoriaClinica
{
    public interface IMultimediaBusiness
    {
        List<Multimedia> GetAllByIdPaciente(long IdPaciente);
        Multimedia GetBase64ArchivoByIdMultimedia(int IdMultimedia);
        string GetBase64PdfByIdMultimedia(int IdMultimedia);
        bool MultimediaPdfVistaPrevia(JObject data);
        void MultimediaPdfReal(JObject data);
        void MultimediaSubirArch(Multimedia entity);
    }
}
