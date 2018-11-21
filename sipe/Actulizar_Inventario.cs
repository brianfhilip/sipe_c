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
    public partial class Actulizar_Inventario : Form
    {
        DataTable r;
        public Actulizar_Inventario()
        {
            InitializeComponent();
            actualizar();
            Almacenanmiento();
            tipo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           


        }


        public void actualizar() {

            MySqlCommand comando = new MySqlCommand("llamarNombreProducto", conexion.crearConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteScalar();
            MySqlDataAdapter a = new MySqlDataAdapter(comando);
            DataSet ds = new DataSet();
            a.Fill(ds);

            MySqlDataReader r = comando.ExecuteReader();


            while (r.Read())
            {

                comboBox1.Items.Add(r.GetString(0));


            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarBusquedad();
        }

        private void cargarBusquedad()
        {
            try
            {
                MySqlCommand comando1 = new MySqlCommand("SeleccionarProducto", conexion.crearConexion());
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("nom", comboBox1.SelectedItem);
                comando1.ExecuteScalar();
                r = new DataTable();
                MySqlDataAdapter ds = new MySqlDataAdapter(comando1);
                ds.Fill(r);
                Tabla.DataSource = r;
               
                caja1.Text = (string)Tabla.Rows[0].Cells[0].Value;
                caja2.Text = (string)Tabla.Rows[0].Cells[1].Value;
                caja3.Text = (string)Tabla.Rows[0].Cells[2].Value;
                caja4.Text = (string)Tabla.Rows[0].Cells[3].Value;
                caja5.Text =(string)Tabla.Rows[0].Cells[4].Value.ToString();
                caja6.Text = (string)Tabla.Rows[0].Cells[5].Value.ToString();
                caja7.Text = (string)Tabla.Rows[0].Cells[6].Value.ToString();
            }
            catch (Exception F) {

                MessageBox.Show("A Ocrrido un Error",F.ToString());

            }

        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
          


        }


        public void Almacenanmiento() {

            try
            {

                MySqlCommand comando1 = new MySqlCommand("llamarbodega", conexion.crearConexion());
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.ExecuteScalar();

                MySqlDataReader leer = comando1.ExecuteReader();

                while (leer.Read())
                {

                    comboBox2.Items.Add(leer.GetString(0));




                }


            }
            catch (Exception y)
            {

                MessageBox.Show("A Ocurrido un error al cargar el combobox", y.ToString());

            }



        }

        public void tipo() {

            MySqlCommand comando2 = new MySqlCommand("llamarTipo", conexion.crearConexion());
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.ExecuteScalar();
            MySqlDataReader l = comando2.ExecuteReader();


            while (l.Read()) {

                comboBox3.Items.Add(l.GetString(0));



            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (caja1.Text.Equals(""))
            {

                MessageBox.Show("El campo Numero Factura esta vacio");
                caja1.Focus();

            }
            else if (caja2.Equals(""))
            {

                MessageBox.Show("El campo Id_Ubicacion esta vacio");
                caja2.Focus();



            }
            else if (caja3.Equals(""))
            {

                MessageBox.Show("El campo Id_Categoria esta vacio");
                caja3.Focus();


            }
            else if (caja4.Equals(""))
            {

                MessageBox.Show("El campo Nombre esta Vacio");
                caja4.Focus();


            }
            else if (caja5.Equals(""))
            {

                MessageBox.Show("El campo Precio Unidad esta vacio");
                caja5.Focus();


            }
            else if (caja6.Equals(""))
            {

                MessageBox.Show("El campo Precio por Mayor esta vacio");
                caja6.Focus();
            }
            else if (caja7.Equals(""))
            {

                MessageBox.Show("El campo Cantidad esta vacio");
                caja7.Focus();

            }
            else {

                MySqlCommand comando3 = new MySqlCommand("modificarProducto", conexion.crearConexion());
                comando3.CommandType = CommandType.StoredProcedure;
                comando3.Parameters.AddWithValue("nombre",caja4.Text);
                comando3.Parameters.AddWithValue("cantidad",caja7.Text);
                comando3.Parameters.AddWithValue("unidad",caja5.Text);
                comando3.Parameters.AddWithValue("precio",caja6.Text);
                comando3.Parameters.AddWithValue("recibo",comboBox1.SelectedItem.ToString());
                comando3.ExecuteScalar();

                Form n = new Form1();
                n.Show();
                
                this.Close();
                
                



            }
        }

        private void Actulizar_Inventario_Load(object sender, EventArgs e)
        {

        }
    }
    }

