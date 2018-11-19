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
    public partial class crearComprarInsumos : Form
    {
        public crearComprarInsumos()
        {
            InitializeComponent();

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            MySqlCommand miSentencia = new MySqlCommand("validar_idProveedor",conexion.crearConexion());
            miSentencia.CommandType = CommandType.StoredProcedure;
            miSentencia.Parameters.AddWithValue("codigo",cajaCodigo.Text);
            MySqlDataReader reader = miSentencia.ExecuteReader();

            while (reader.Read())
            {
                if (reader.GetString(0).Equals("1"))
                {
                    
                    cajaCodigo.Focus();
                    MySqlCommand miSentencia2 = new MySqlCommand("select nombreProveedor,nitProveedor from proveedores where idProveedor='" + cajaCodigo.Text + "'", conexion.crearConexion());
                    MySqlDataReader reader2 = miSentencia2.ExecuteReader();

                    while (reader2.Read())
                    {
                        cajaNombre.Text = reader2.GetString(0);

                    }
                }
                else
                {
                    MessageBox.Show("El codigo no se encuentra registrado");
                }
            }
        }
    }
}
