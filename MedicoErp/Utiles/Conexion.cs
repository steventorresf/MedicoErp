using MedicoErp.Areas.General.Business;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Utiles
{
    public class Conexion
    {
        private static IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

        public static long ExecuteLong(string Query)
        {
            try
            {
                string Cadconexion = builder.Build().GetConnectionString("MedicoErpDbContext");
                SqlConnection Con = new SqlConnection(Cadconexion);
                SqlDataAdapter adapter = new SqlDataAdapter(Query, Con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Con.Close();
                return Convert.ToInt64(dt.Rows[0]["Respuesta"].ToString());
            }
            catch (Exception e)
            {
                ErroresBusiness.Create("ExecuteLong", e.Message, null);
                return -1;
            }
        }

        public static DataTable ExecuteTable(string Query)
        {
            try
            {
                string Cadconexion = builder.Build().GetConnectionString("MedicoErpDbContext");
                SqlConnection Con = new SqlConnection(Cadconexion);
                SqlDataAdapter adapter = new SqlDataAdapter(Query, Con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Con.Close();
                return dt;
            }
            catch (Exception e)
            {
                ErroresBusiness.Create("ExecuteTable", e.Message, null);
                return null;
            }
        }
    }
}
