using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Utiles
{
    public class Constantes
    {
        // Areas
        public const string Area_Administracion = "Administracion";
        public const string Area_Admision = "Admision";
        public const string Area_General = "General";
        public const string Area_HistoriaClinica = "HistoriaClinica";

        // Estados
        public const string EstadoActivo = "AC";
        public const string EstadoInactivo = "IN";
        public const string EstadoAgendado = "AG";
        public const string EstadoReprogramado = "RP";
        public const string EstadoCancelado = "CA";
        public const string EstadoLibre = "LI";
        public const string EstadoConfirmado = "CO";
        public const string EstadoPendiente = "PE";
        public const string EstadoFinalizado = "FI";

        // ClavePredeterminada
        public const string ClavePredeterminada = "12345";

        // Tablas Generales
        public const string TabEstados = "TabEstados";
        public const string TabEstadosCivil = "TabEstadosCivil";
        public const string TabCausasExterna = "TabCausasExterna";
        public const string TabFinalidadConsulta = "TabFinalidadConsulta";
        public const string TabTiposDiag = "TabTiposDiag";
        public const string TabRips = "TabRips";
        public const string TabTiposIden = "TabTiposIden";
        public const string TabTiposDato = "TabTiposDato";
        public const string TabTipoFact = "TabTipoFact";
        public const string TabTipoUsuario = "TabTipoUsuario";
        public const string TabViasAdmon = "TabViasAdmon";

        // Tipos de Facturacion Convenio
        public const string FactVolante = "VO";
        public const string FactFactura = "FA";

        // Campos de Eventos
        public const string CamEvolucion = "EV";
        public const string CamBiopsia = "BO";
        public const string CamAyudaDx = "AD";
        public const string CamAnexos = "AX";
        public const string CamDiagPal = "DP";
        public const string CamDiagRel = "DR";

        // Nombres de archivos de excel
        public const string NomExcelAgendaMedica = "AgendaMedica.xlsx";
    }
}
