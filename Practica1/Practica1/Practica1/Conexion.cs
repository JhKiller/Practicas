using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Conexion
    {
        static SqlConnection cnx;
        static string cadena = "Data Source=LENOVOL340;Initial Catalog=Miscelanea;Integrated Security=True";

        private static void Conectar()
        {
            cnx = new SqlConnection(cadena);
            cnx.Open();
        }
        private static void Desconectar()
        {
            cnx.Close();
        }
        public static int EjecutaConsulta(string consulta)
        {
            int filasAfectadas;
            Conectar();
            SqlCommand cmd = new SqlCommand(consulta, cnx);
            filasAfectadas = cmd.ExecuteNonQuery();
            Desconectar();
            return filasAfectadas;
        }
        public static DataTable EjecutaSeleccion(string consulta)
        {
            DataTable dt = new DataTable();
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cnx);

            da.Fill(dt);

            Desconectar();
            return dt;
            
        }
    }
}
