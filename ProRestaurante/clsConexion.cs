using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace ProRestaurante
{
    class clsConexion
    {
        public static MySqlConnection conexion;

        private static string cadena = "server=127.0.0.1;user id=Youtube; database=bd_restaurante; password=Prueba1234;";

        public static bool CheckConexion() {
            try
            {

                conexion = new MySqlConnection(cadena);
                conexion.Open();
                conexion.Close();
                return true;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e);
                return false;

            }
        }


        public static MySqlConnection GetConexionClient() {

            try
            {
                if(conexion == null || conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion = new MySqlConnection(cadena);
                    conexion.Open();
                }

            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e);
            }

            return conexion;

        }

    }
}
