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
            listaBusqueda.Visible = false;
            labelFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (cajaCodigo.Text.Equals(""))
            {
                cajaBusqueda.Focus();
            }
            else
            {
                MySqlCommand miSentencia = new MySqlCommand("validar_idProveedor", conexion.crearConexion());
                miSentencia.CommandType = CommandType.StoredProcedure;
                miSentencia.Parameters.AddWithValue("codigo", cajaCodigo.Text);
                MySqlDataReader reader = miSentencia.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(0).Equals("1"))
                    {

                        MySqlCommand miSentencia2 = new MySqlCommand("select nombreProveedor,nitProveedor from proveedores where idProveedor='" + cajaCodigo.Text + "'", conexion.crearConexion());
                        MySqlDataReader reader2 = miSentencia2.ExecuteReader();

                        while (reader2.Read())
                        {
                            cajaNombre.Text = reader2.GetString(0);
                            cajaNit.Text = reader2.GetString(1);

                        }
                        cajaBusqueda.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El codigo no se encuentra registrado");
                        cajaNombre.Text = "";
                        cajaNit.Text = "";
                        cajaCodigo.Focus();
                    }
                }
            }
        }

        private void cajaCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(int)Keys.Enter)
            {
                MySqlCommand miSentencia = new MySqlCommand("validar_idProveedor", conexion.crearConexion());
                miSentencia.CommandType = CommandType.StoredProcedure;
                miSentencia.Parameters.AddWithValue("codigo", cajaCodigo.Text);
                MySqlDataReader reader = miSentencia.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(0).Equals("1"))
                    {
                        MySqlCommand miSentencia2 = new MySqlCommand("select nombreProveedor,nitProveedor from proveedores where idProveedor='" + cajaCodigo.Text + "'", conexion.crearConexion());
                        MySqlDataReader reader2 = miSentencia2.ExecuteReader();

                        while (reader2.Read())
                        {
                            cajaNombre.Text = reader2.GetString(0);
                            cajaNit.Text = reader2.GetString(1);
                        }
                        cajaBusqueda.Focus();    
                    }
                    else
                    {
                        MessageBox.Show("El codigo no se encuentra registrado");
                        cajaNombre.Text = "";
                        cajaNit.Text = "";
                    }
                }
            }
        }

        private void cajaBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            MySqlCommand miSentencia = new MySqlCommand("autocompletar_productos", conexion.crearConexion());
            miSentencia.CommandType = CommandType.StoredProcedure;
            miSentencia.Parameters.AddWithValue("busq",cajaBusqueda.Text);
            MySqlDataReader reader = miSentencia.ExecuteReader();
            listaBusqueda.Visible = true;
            listaBusqueda.Items.Clear();

            while (reader.Read())
            {
                listaBusqueda.Items.Add(reader.GetString(0));
                listaBusqueda.SelectedIndex = 0;
            }

        }

        private void listaBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            //cajaBusqueda.Focus();
        }

        private void listaBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
         //   cajaBusqueda.Focus();
        }

        private void listaBusqueda_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //cajaBusqueda.Focus();
        }

        private void listaBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            //cajaBusqueda.Focus();
        }

        private void cajaBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            listaBusqueda.Focus();
        }

        private void listaBusqueda_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            cajaBusqueda.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(int)Keys.Enter)
            {
                if (cajaBusqueda.Text.IndexOf("-") >= 0)
                {
                    int posicionCaracter = cajaBusqueda.Text.IndexOf("-");
                    int codigo= Convert.ToInt32(cajaBusqueda.Text.Remove(posicionCaracter));
                    MessageBox.Show(Convert.ToString( codigo));
                    MySqlCommand miSentencia = new MySqlCommand("select idInsumo,nombreInsumo,costoInsumo from insumos where idInsumo='"+codigo+"'",conexion.crearConexion());
                    MySqlDataReader reader = miSentencia.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] fila = new string[4];
                        fila[0] = reader.GetString(0);
                        fila[1] = reader.GetString(1);
                        fila[2] = cajaCantidad.Text;
                        fila[3] = Convert.ToString(Convert.ToInt32(cajaCantidad.Text) * reader.GetInt32(2));

                        tablaPedidoInsumo.Rows.Add(fila);
                    }
                }
            }
            
        }
    }
}
