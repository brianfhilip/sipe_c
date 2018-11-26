using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sipe
{
    public partial class crearCliente : Form
    {
        public crearCliente()
        {
            InitializeComponent();
        }

        private void guardar_Click(object sender, EventArgs e)
        {

            MySqlCommand comando1 = new MySqlCommand("insertar_cliente",conexion.crearConexion());
            comando1.CommandType = CommandType.StoredProcedure;
            comando1.Parameters.AddWithValue("id",identificacion.Text);
            comando1.Parameters.AddWithValue("nombre", nombre.Text);
            comando1.Parameters.AddWithValue("apellido",apellido.Text);
            comando1.Parameters.AddWithValue("telefono",telefono.Text);
            comando1.Parameters.AddWithValue("Direccion",Direccion.Text);
            comando1.ExecuteScalar();
            MessageBox.Show("EL registro ha sido Exitoso!!!");

            Form nuevo = new Clientes();
            nuevo.Show();
            this.Close();
        }
    }
}
