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
    public partial class Crear_Producto : Form
    {
        public Crear_Producto()
        {
            InitializeComponent();
            CargarUbicacion();
            SeleccionarCategoria();
            seleccionar_tipo();
            almacenamiento();
        }

        private void Crear_Producto_Load(object sender, EventArgs e)
        {

        }


        public void CargarUbicacion() {


            try {

                MySqlCommand comando1 = new MySqlCommand("seleccionarUbicacion", conexion.crearConexion());
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.ExecuteScalar();
                MySqlDataReader leer = comando1.ExecuteReader();

                while (leer.Read()) {

                    comboBox1.Items.Add(leer.GetString(0));


                }


            }
            catch (Exception r) {

                MessageBox.Show("A ocurrido un error al cargar el primer comboBox", r.ToString());


            }




        }


        public void SeleccionarCategoria() {

            try {

                MySqlCommand comando1 = new MySqlCommand("seleccionarCategoria", conexion.crearConexion());
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.ExecuteScalar();

                MySqlDataReader leer1 = comando1.ExecuteReader();

                while (leer1.Read()) {

                    comboBox2.Items.Add(leer1.GetString(0));


                }




            }
            catch (Exception b) {

                MessageBox.Show("A ocurrido un error al cargar el segundo ComboBox",b.ToString());


            }





        }

        public void seleccionar_tipo() {

            try {

                MySqlCommand comando2 = new MySqlCommand("llamarTipo", conexion.crearConexion());
                comando2.CommandType = CommandType.StoredProcedure;
                comando2.ExecuteScalar();

                MySqlDataReader leer2 = comando2.ExecuteReader();

                while (leer2.Read()) {

                    comboBox3.Items.Add(leer2.GetString(0));



                }


            }
            catch (Exception i)
            {

                MessageBox.Show("A ocurrido un error en la carga del tercer ComboBox");


            }



        }


        public void almacenamiento() {


            try {

                MySqlCommand comando3 = new MySqlCommand("llamarbodega", conexion.crearConexion());
                comando3.CommandType = CommandType.StoredProcedure;
                comando3.ExecuteScalar();

                MySqlDataReader leer3 = comando3.ExecuteReader();

                while (leer3.Read()) {

                    comboBox4.Items.Add(leer3.GetString(0));


                }


            }
            catch (Exception rr) {


                MessageBox.Show("A ocurrido un error al llenar el combobox 4",rr.ToString());


            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {

                MySqlCommand comando4 = new MySqlCommand("ingresarProductosMarca", conexion.crearConexion());
                comando4.CommandType = CommandType.StoredProcedure;
                comando4.Parameters.AddWithValue("idP",caja1.Text);
                comando4.Parameters.AddWithValue("idU",comboBox1.SelectedItem.ToString());
                comando4.Parameters.AddWithValue("idC",comboBox2.SelectedItem.ToString());
                comando4.Parameters.AddWithValue("nombre",caja2.Text);
                comando4.Parameters.AddWithValue("unidad",caja4.Text);
                comando4.Parameters.AddWithValue("precio",caja3.Text);
                comando4.Parameters.AddWithValue("tipoC",comboBox3.SelectedItem.ToString());
                comando4.Parameters.AddWithValue("idB",comboBox4.SelectedItem.ToString());
                comando4.ExecuteScalar();


                MessageBox.Show("El producto a sido registrado con exito");

                Form m = new Form1();
                m.Show();
                this.Close();

            }
            catch (Exception tr) {

                MessageBox.Show("A ocurrido un error al guardar la informacion",tr.ToString());

            }

        }
    }
}
