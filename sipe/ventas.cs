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


        public Ventas()
        {
            InitializeComponent();

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
            

           /* if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                try
                {
                    MySqlCommand miSentencia = new MySqlCommand("MostrarIDproducto", ConexionSipe.Conexion());
                    miSentencia.CommandType = CommandType.StoredProcedure;

                    miSentencia.Parameters.AddWithValue("nombre", txtProducto.Text);
                    MySqlDataReader reader = miSentencia.ExecuteReader();

                    while (reader.Read())
                    {


                        lblCodigoProducto.Text = reader.GetString(0);


                    }

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex);
                }
            }*/
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            this.Focus();
            if (txtProducto.Focus())
            {
                

            }
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
    }
}
