using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Utiles
{
    public class Parametros
    {
        public static Dictionary<string, string> AppSettings { get; set; }

        public static string RutaGeneral = "C://SaludOfficeWebC//";
        public static string RutaMultimedia = "C://SaludOfficeWebC//Multimedia//";
        public static string RutaImagenesTemporales = "C://SaludOfficeWebC//ImagenesTemporales//";
    }
}
