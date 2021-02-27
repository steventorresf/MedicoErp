using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MedicoErp.Model.Common
{
    public class Util
    {
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

        public static string GetFirmaMedico(string Usuario)
        {
            string Ruta = "C:/SaludOfficeWebC/Firmas/" + Usuario + ".png";
            Image image = Image.FromFile(Ruta);
            MemoryStream ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            byte[] bytes = ms.ToArray();
            string Imagen = Convert.ToBase64String(bytes);
            return Imagen;
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
    }
}
