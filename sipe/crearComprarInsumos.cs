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
            labelFecha.Text = DateTime.Now.ToString("yyyy/MM/dd");
            mostrarConsecutivo();
            mostrarTipoCompra();
            radioSi.Checked = true;
        }

        private void mostrarTipoCompra()
        {
            MySqlCommand miSentencia = new MySqlCommand("select nombreTipoCompra from tipos_de_compras", conexion.crearConexion());
            MySqlDataReader reader = miSentencia.ExecuteReader();
            while (reader.Read())
            {
                comboTipoCompra.Items.Add(reader.GetString(0));
                comboTipoCompra.SelectedIndex = 0;
            }
        }

        private void mostrarConsecutivo()
        {
            MySqlCommand miSentencia = new MySqlCommand("traer_numero_factura_compra",conexion.crearConexion());
            miSentencia.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader = miSentencia.ExecuteReader();
            while (reader.Read())
            {
                labelNumeroCompra.Text = reader.GetString(0);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            /**/
        }

        private void cajaCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(int)Keys.Enter)
            {
                MySqlCommand miSentencia = new MySqlCommand("validar_idProveedor", conexion.crearConexion());
                miSentencia.CommandType = CommandType.StoredProcedure;
                miSentencia.Parameters.AddWithValue("codigo", cajaCodigoProveedor.Text);
                MySqlDataReader reader = miSentencia.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(0).Equals("1"))
                    {
                        MySqlCommand miSentencia2 = new MySqlCommand("select nombreProveedor,nitProveedor from proveedores where idProveedor='" + cajaCodigoProveedor.Text + "'", conexion.crearConexion());
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
            miSentencia.Parameters.AddWithValue("busq",cajaBusqueda.Text.ToUpper());
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
                        cajaBusqueda.Text.Remove(posicionCaracter);
                        MySqlCommand miSentencia = new MySqlCommand("select idInsumo,nombreInsumo,costoInsumo from insumos where idInsumo='" + cajaBusqueda.Text.Remove(posicionCaracter) + "'", conexion.crearConexion());
                        MySqlDataReader reader = miSentencia.ExecuteReader();
                        int cont = 0;
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
                            cont = 1;
                        }
                        if (cont ==0)
                        {
                            MessageBox.Show("Verifique que el nombre o codigo del producto ingresado son correctos");
                            cajaBusqueda.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Verifique que el nombre o codigo del producto ingresado son correctos");
                        cajaBusqueda.Focus();
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
            int iva = (acu * 16) / 100 ;
            int subtotal = acu - ((acu * 16) / 100);
            labelSubtotal.Text = "$ " + subtotal.ToString("N0");
            labelIva.Text = "$ " + iva.ToString("N0");
            labelTotal.Text= "$ " + acu.ToString("N0");
        }

        private void cajaCantidad_Enter(object sender, EventArgs e)
        {
            listaBusqueda.Visible = false;
        }

        private void cajaNombre_Enter(object sender, EventArgs e)
        {
            if (cajaCodigoProveedor.Text.Equals(""))
            {
                cajaBusqueda.Focus();
            }
            else
            {
                MySqlCommand miSentencia = new MySqlCommand("validar_idProveedor", conexion.crearConexion());
                miSentencia.CommandType = CommandType.StoredProcedure;
                miSentencia.Parameters.AddWithValue("codigo", cajaCodigoProveedor.Text);
                MySqlDataReader reader = miSentencia.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(0).Equals("1"))
                    {

                        MySqlCommand miSentencia2 = new MySqlCommand("select nombreProveedor,nitProveedor from proveedores where idProveedor='" + cajaCodigoProveedor.Text + "'", conexion.crearConexion());
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
                        cajaCodigoProveedor.Focus();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            recetas objRecetas = new recetas();
            objRecetas.MdiParent = this.MdiParent;
            objRecetas.Show();

            objRecetas.tabControl1.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            if (cajaCodigoProveedor.Text.Equals(""))
            {
                MessageBox.Show("No ha seleccionado un proveedor");
                cajaCodigoProveedor.Focus();
            }
            else if (tablaPedidoInsumo.Rows.Count==0)
            {
                MessageBox.Show("No ha ingresado productos a la venta");
                cajaBusqueda.Focus();
            }
            else
            {

            MySqlCommand miSentencia = new MySqlCommand("insertar_factura_compra", conexion.crearConexion());
            miSentencia.CommandType = CommandType.StoredProcedure;
            miSentencia.Parameters.AddWithValue("idProve",cajaCodigoProveedor.Text);
            miSentencia.Parameters.AddWithValue("idTipoCom",comboTipoCompra.SelectedItem.ToString());
            miSentencia.Parameters.AddWithValue("fechaCom",Convert.ToDateTime(labelFecha.Text));
            string valorSinSigno =  labelTotal.Text.Substring(1);
            float valorSin = Convert.ToInt64(Convert.ToDouble(valorSinSigno));
          
            miSentencia.Parameters.AddWithValue("valTotal",valorSin);
            miSentencia.Parameters.AddWithValue("idBod","2");
            if (radioSi.Checked)
            {
            miSentencia.Parameters.AddWithValue("estado","RECIBIDO");
            }
            else
            {
            miSentencia.Parameters.AddWithValue("estado", "SIN RECIBIR");
            }
            miSentencia.ExecuteNonQuery();

            MessageBox.Show("Factura guardada exitosamente");

                limpiarIncrementarFactura();
            }
        }

        private void limpiarIncrementarFactura()
        {
            mostrarConsecutivo();
            cajaCodigoProveedor.Text = "";
            cajaNombre.Text = "";
            cajaNit.Text = "";
            tablaPedidoInsumo.Rows.Clear();
            TextObservaciones.Text = "";
            labelIva.Text = "$";
            labelSubtotal.Text = "$";
            labelTotal.Text = "$";
        }

        private void crearComprarInsumos_FormClosed(object sender, FormClosedEventArgs e)
        {
            recetas objRecetas = new recetas();
            objRecetas.MdiParent = this.MdiParent;
            objRecetas.Show();
            objRecetas.tabControl1.SelectedIndex = 1;
        }
    }
}
