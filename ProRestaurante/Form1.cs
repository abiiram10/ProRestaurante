using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProRestaurante
{
    public partial class Form1 : Form
    {




        private clsUsuario tblUsuario = new clsUsuario();

        public Form1()
        {
            InitializeComponent();

            if (clsConexion.CheckConexion()) {
                Console.WriteLine("Conexion Establecida");
                clsConexion.GetConexionClient();
            }
            else
            {
                Console.WriteLine("Ocurrrio un error al establecer la conexion");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.FillGridView();

        }


        private void FillGridView() {
            dtDatos.DataSource = tblUsuario.Consulta();

            DataGridViewImageColumn colum = (DataGridViewImageColumn)dtDatos.Columns[4];
            colum.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dtDatos.Columns[0].Visible = false;
            dtDatos.Columns[6].Visible = false;
            dtDatos.Columns[7].Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apaterno = txtApaterno.Text;
            string amaterno = txtAmaterno.Text;

            string dtfnacimiento = dtFecha.Value.ToString("yyy-MM-dd HH:mm:ss");
            Boolean guardo = tblUsuario.Insert(nombre,apaterno,amaterno,pbImage, dtfnacimiento);

            if (guardo)
            {
                this.FillGridView();
                MessageBox.Show("Guardado Correctamente");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Selecione una imagen";
            dialog.Filter = "*.jpg|*.jpg";
            dialog.InitialDirectory = "C:\\Users\\A10\\Desktop\\Imagenes";
            
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = dialog.FileName;
            }
        }
    }
}
