using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Utiles
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

        public static string EncriptarMD52(string Texto)
        {
            string Conversion = "";
            byte[] data = UTF8Encoding.UTF8.GetBytes(Texto); // encrypt the incrypted text
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("f0xle@rn"));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    Conversion = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            return Conversion;
        }

        public static string DesEncriptarMD5(string Texto)
        {
            string Conversion = "";
            byte[] data = Convert.FromBase64String(Texto); // decrypt the incrypted text
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("f0xle@rn"));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    Conversion = UTF8Encoding.UTF8.GetString(results);
                }
            }
            return Conversion;
        }

        public static bool ValidarUsu(HttpContext context)
        {
            if (context.Session.GetString("IdUsu") != null)
            {
                return true;
            }
            else { return false; }
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
