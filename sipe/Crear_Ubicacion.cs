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
    public partial class Crear_Ubicacion : Form
    {
        String busquedad;
        public Crear_Ubicacion()
        {
            InitializeComponent();
        }

        public void ingresar() {

            try
            {

                MySqlCommand comando1 = new MySqlCommand("crearUbicacion", conexion.crearConexion());
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("id", CajaId.Text);
                comando1.Parameters.AddWithValue("nom", CajaNombre.Text.ToUpperInvariant());
                comando1.Parameters.AddWithValue("can", CajaCantidad.Text);
                comando1.ExecuteScalar();

                MessageBox.Show("La Nueva Ubicacion a sido Creada con Exito");

                CajaId.Text = "";
                CajaNombre.Text = "";
                CajaCantidad.Text = "";

                this.Close();
            }

            catch (Exception t) {

                MessageBox.Show("A ocurrido un erro al ingresar una nueva ubicacion",t.ToString());


            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try {

                if (CajaId.Equals(""))
                {

                    MessageBox.Show("La caja Identificacion esta vacia");
                    CajaId.Focus();


                }
                else if (CajaNombre.Equals(""))
                {

                    MessageBox.Show("La caja Nombre esta vacia");
                    CajaNombre.Focus();


                }
                else if (CajaCantidad.Equals(""))
                {

                    MessageBox.Show("La caja Cantidad esta vacia ");
                    CajaCantidad.Focus();
                }
                else {

                    MySqlCommand comando = new MySqlCommand("validarUbicacion", conexion.crearConexion());
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("id",CajaId.Text);
                    comando.Parameters.AddWithValue("nom",CajaNombre.Text);
                    comando.Parameters.AddWithValue("can",CajaCantidad.Text);
                    comando.ExecuteScalar();


                    MySqlDataReader r = comando.ExecuteReader();

                    while (r.Read()) {

                        busquedad = r.GetString(0);


                    }

                    if (busquedad.Equals("1"))
                    {

                        MessageBox.Show("El id Ubicacion o el Nombre de la Ubicacion ya Existe!!! ");
                        CajaCantidad.Text = "";
                        CajaId.Text = "";
                        CajaNombre.Text = "";



                    }
                    else {

                        ingresar();



                    }



                }




            } catch (Exception n)
            {

                MessageBox.Show("A ocurrido un erro al crear una ubicacion",n.ToString());



            }

        }

        private void CajaId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) {

                e.Handled = true;
                MessageBox.Show("Ingrese solo numeros");

            }
        }

        private void CajaNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) {

                e.Handled = true;
                MessageBox.Show("Ingrese solo Letras");


            }
        }

        private void CajaCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) {

                e.Handled = true;
                MessageBox.Show("Ingrese solo numeros");


            }
        }

        private void Crear_Ubicacion_Load(object sender, EventArgs e)
        {

        }
    }
}
