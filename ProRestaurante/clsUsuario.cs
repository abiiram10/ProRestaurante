using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace ProRestaurante
{
    class clsUsuario
    {

        protected internal DataTable Tabla;

        protected MySqlCommand comando;
        protected MySqlDataAdapter cmBuscar;

        public DataTable Consulta()
        {
            Tabla = new DataTable();
            try
            {
                string consulta = "SELECT 	idUsuario, vchNombre, vchApaterno, vchAmaterno, blbFoto, dtNacimiento, dtRegistro, enUso FROM tbl_usuario WHERE enUso = 1";
                cmBuscar = new MySqlDataAdapter(consulta,clsConexion.conexion);
                cmBuscar.Fill(Tabla);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Tabla;
        }



        public Boolean Insert(string Nombre, string Apaterno, string Amaterno, PictureBox Fotografia, string dtNacimiento)
        {
            try
            {

                string cadena = "INSERT INTO tbl_usuario SET vchNombre='"+Nombre+ "',vchApaterno='"+Apaterno+ "',vchAmaterno ='"+Amaterno+ "', blbFoto=@imagen, dtNacimiento='"+dtNacimiento+ "', dtRegistro=NOW(), enUso=1";
                Console.WriteLine(cadena);
                byte[] mifoto = clsImagen.ImageToByte(Fotografia.Image);
                comando = new MySqlCommand(cadena, clsConexion.conexion);
                comando.Parameters.AddWithValue("@imagen", mifoto);
                comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
