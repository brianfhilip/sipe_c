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

            if (!cajaBusqueda.Text.Equals(""))
            {

            
            MySqlCommand miSentencia = new MySqlCommand("autocompletar_productos", conexion.crearConexion());
            miSentencia.CommandType = CommandType.StoredProcedure;
            miSentencia.Parameters.AddWithValue("busq",cajaBusqueda.Text);
            MySqlDataReader reader = miSentencia.ExecuteReader();
            
            listaBusqueda.Items.Clear();

            int flag = 0;
            while (reader.Read())
            {
                if (!reader.GetString(0).Equals("sin resultados"))
                {
                    listaBusqueda.Visible = true;
                    listaBusqueda.Items.Add(reader.GetString(0));
                    listaBusqueda.SelectedIndex = 0;
                    flag = 1;
                 }
            }

                if (flag==0)
                {
                    listaBusqueda.Visible = false;
                }

            listaBusqueda.Focus();
            }
            else
            {
                listaBusqueda.Visible = false;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(int)Keys.Enter)
            {
                if (!cajaCantidad.Text.Equals(""))
                {
                    if (cajaBusqueda.Text.IndexOf("-") >= 0)
                    {
                        int posicionCaracter = cajaBusqueda.Text.IndexOf("-");
                        int codigo = Convert.ToInt32(cajaBusqueda.Text.Remove(posicionCaracter));

                        MySqlCommand miSentencia = new MySqlCommand("select idInsumo,nombreInsumo,costoInsumo from insumos where idInsumo='" + codigo + "'", conexion.crearConexion());
                        MySqlDataReader reader = miSentencia.ExecuteReader();
                        while (reader.Read())
                        {
                            string[] fila = new string[5];

                            fila[0] = reader.GetString(0);
                            fila[1] = reader.GetString(1);
                            fila[2] = cajaCantidad.Text;
                            fila[3] = reader.GetString(2);
                            fila[4] = Convert.ToString(Convert.ToInt32(cajaCantidad.Text) * reader.GetInt32(2));

                            tablaPedidoInsumo.Rows.Add(fila);
                            cajaBusqueda.Text = "";
                            cajaCantidad.Text = "";
                            cajaBusqueda.Focus();
                        }

                    }
                }
            }
            
        }

        private void crearComprarInsumos_Load(object sender, EventArgs e)
        {
           
        }
       

        private void listaBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == (int)Keys.Enter)
            {
                cajaBusqueda.Text = listaBusqueda.SelectedItem.ToString();
                listaBusqueda.Visible = false;
                cajaCantidad.Focus();
            }
            else
            {
                if (e.KeyChar == (int)Keys.Back)
                {
                    if (cajaBusqueda.Text.Length > 0)
                    {
                        cajaBusqueda.Text = cajaBusqueda.Text.Remove(cajaBusqueda.Text.Length - 1);
                        cajaBusqueda.Focus();
                        // listaBusqueda.Visible = false;
                    }

                }
                else
                {
                    cajaBusqueda.Focus();
                    cajaBusqueda.Text = cajaBusqueda.Text + e.KeyChar;
                    cajaBusqueda.SelectionStart = cajaBusqueda.Text.Length;
                }
            }
        }

        private void cajaBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(int)Keys.Enter)
            {
                cajaCantidad.Focus();
            }
        }


        private void tablaPedidoInsumo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int acu = 0;
            for (int i = 0; i < tablaPedidoInsumo.Rows.Count; i++)
            {
                acu = acu + Convert.ToInt32(tablaPedidoInsumo.Rows[i].Cells[4].Value);
            }
            labelSubtotal.Text = "$ "+Convert.ToString(acu);
        }

        private void cajaCantidad_Enter(object sender, EventArgs e)
        {
            listaBusqueda.Visible = false;
        }

        
    }
}
