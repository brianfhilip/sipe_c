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
    public partial class Ventas : Form
    {

        public void tipoDePago()
        {
            MySqlCommand miSentencia = new MySqlCommand("tipo_de_pago", conexion.crearConexion());
            miSentencia.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader = miSentencia.ExecuteReader();
        }


        public Ventas()
        {
            InitializeComponent();
            //DateTime fechaConversion = DateTime.Parse(this.lblFecha.Text);

        }



        private void txtNumCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                try
                {
                    MySqlCommand miSentencia = new MySqlCommand("buscarCliente", conexion.crearConexion());
                    miSentencia.CommandType = CommandType.StoredProcedure;

                    miSentencia.Parameters.AddWithValue("id", txtNumCedula.Text);
                    MySqlDataReader reader = miSentencia.ExecuteReader();

                    while (reader.Read())
                    {



                        if (reader.GetString(0).Equals("0"))
                        {

                            MessageBox.Show("El cliente no existe");

                        }
                        else
                        {
                            txtNombreCliente.Text = reader.GetString(1) + " " + reader.GetString(2);

                        }


                    }

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
         
        }

        protected override void OnLostFocus(EventArgs e)
        {

            base.OnLostFocus(e);
        }

        private void ElFoco_LostFocus(object sender, EventArgs e)
        {
           
     
        }

        private void txtProducto_Enter(object sender, EventArgs e)
        {
           
        }

        public void agregar()
        {

        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            agregar();

        }

        private void txtProducto_Leave(object sender, EventArgs e)
        {
            agregar();
        }

        private void txtProducto_Validated(object sender, EventArgs e)
        {

            try
            {
                MySqlCommand miSentencia = new MySqlCommand("MostrarIDproducto", conexion.crearConexion());
                MySqlCommand miSentencia2 = new MySqlCommand("mostrarCantidadProducto", conexion.crearConexion());
                miSentencia.CommandType = CommandType.StoredProcedure;
                miSentencia2.CommandType = CommandType.StoredProcedure;

                miSentencia.Parameters.AddWithValue("nombre", txtProducto.Text);
                miSentencia2.Parameters.AddWithValue("CantProdu", txtProducto.Text);

                MySqlDataReader reader = miSentencia.ExecuteReader();
                MySqlDataReader reader1 = miSentencia2.ExecuteReader();


                while (reader.Read () )
                {
                    
                    lblCodigoProducto.Text = reader.GetString(0);
                    
                }
                while (reader1.Read())
                {

                    lblCanttidadExistente.Text = reader1.GetString(0);

                }


                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex);
                }

            


            
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {

        }

        private void txtNumCedula_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblVenta_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlCommand misentencia = new MySqlCommand("");


            }
            catch { }
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {
           // string fecha = fechaHoy.ToString("d");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rdbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            tipoDePago();
        }

        private void rbtTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            tipoDePago();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dgvFactura.Rows.Add();
            int cantFilas = dgvFactura.Rows.Count - 1;
            dgvFactura[0, cantFilas].Value = txtProducto.Text;
            dgvFactura[1, cantFilas].Value = lblCodigoProducto.Text;
            dgvFactura[2, cantFilas].Value = txtCantidadAVender.Text;
            dgvFactura[3, cantFilas].Value = lblValorProducto.Text;
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MySqlCommand misentencia = new MySqlCommand("guardarFactura",conexion.crearConexion());
            misentencia.CommandType = CommandType.StoredProcedure;

            misentencia.Parameters.AddWithValue("idC",lblVenta.Text);
            misentencia.Parameters.AddWithValue("nomVend", lblVendedor.Text);
            misentencia.Parameters.AddWithValue("idTipoP", grbTipoDePago.Text);
            misentencia.Parameters.AddWithValue("fecha", lblFecha.Text);
            misentencia.Parameters.AddWithValue("vVenta", lblValorProducto.Text);

        }

        private void grbTipoDePago_Enter(object sender, EventArgs e)
        {
            tipoDePago();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MySqlCommand miSentencia = new MySqlCommand("llamarPrecio", conexion.crearConexion());
            miSentencia.CommandType = CommandType.StoredProcedure;

           // miSentencia.Parameters.AddWithValue("nombre", txtProducto.());
        }

        private void lblVendedor_Click(object sender, EventArgs e)
        {

        }
    }
}
