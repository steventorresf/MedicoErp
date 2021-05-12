using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net;
using System.Net.NetworkInformation;

namespace MedicoErp.Model.Common
{
    public class Util
    {
        private static string MAC_Servidor = "D02788D04106";
        //private static string MAC_Servidor = "E4E749C23E43";

        public static string EncriptarMD5(string Conversion)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(Conversion);
            bs = x.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string Texto = s.ToString();
            return Texto;
        }

        public static string GetDataArchivo(string Extension)
        {
            string data = "";
            switch (Extension)
            {
                case "pdf": data = Constantes.DataPdf; break;
                case "jpeg": data = Constantes.DataJpeg; break;
                case "jpg": data = Constantes.DataJpeg; break;
                case "png": data = Constantes.DataPng; break;
            }
            return data;
        }

        public static string GetFirmaMedico(string Usuario)
        {
            string Ruta = Parametros.RutaFirmas + Usuario + ".png";
            if (File.Exists(Ruta))
            {
                Image image = Image.FromFile(Ruta);
                MemoryStream ms = new MemoryStream();
                image.Save(ms, image.RawFormat);
                byte[] bytes = ms.ToArray();
                string Imagen = Convert.ToBase64String(bytes);
                return Imagen;
            }
            else { return null; }
        }

        public static string GetNombreDocumentoByCod(string CodigoDocumento)
        {
            string NombreDocumento = "";
            switch (CodigoDocumento)
            {
                case Constantes.CodigoConsentimiento:
                    NombreDocumento = Constantes.NombreConsentimiento;
                    break;
            }

            return NombreDocumento;
        }

        public static string GetBase64Pdf(string Ruta)
        {
            try
            {
                FileStream file = File.OpenRead(Ruta);
                byte[] vs = new byte[file.Length];
                file.Read(vs, 0, vs.Length);
                file.Close();

                return Convert.ToBase64String(vs);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string GetImagen(string Ruta)
        {
            string Imagen = "";
            Image image = Image.FromFile(Ruta);
            MemoryStream ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            byte[] bytes = ms.ToArray();
            Imagen = Convert.ToBase64String(bytes);
            return Imagen;
        }

        public static bool ValidarServidor()
        {
            bool Valido = false;
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                string MAC = adapter.GetPhysicalAddress().ToString();
                if (MAC.Equals(MAC_Servidor))
                {
                    Valido = true;
                }
                //IPInterfaceProperties properties = adapter.GetIPProperties();
                //Console.WriteLine(adapter.Description);
                //Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                //Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                //Console.WriteLine("  Physical Address ........................ : {0}", MAC);
                //Console.WriteLine("  Is receive only.......................... : {0}", adapter.IsReceiveOnly);
                //Console.WriteLine("  Multicast................................ : {0}", adapter.SupportsMulticast);
                //Console.WriteLine();
            }

            return Valido;
        }
    }
}
