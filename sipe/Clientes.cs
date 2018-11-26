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
    public partial class Clientes : Form
    {
        public Clientes()
        {

            
            InitializeComponent();
            mostrarClientes();

        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }
        private  void mostrarClientes()
        {
            MySqlCommand miSentencia1 = new MySqlCommand("mostrar_clientes", conexion.crearConexion());
            miSentencia1.CommandType = CommandType.StoredProcedure;
            miSentencia1.ExecuteScalar();
            MySqlDataReader reader = miSentencia1.ExecuteReader();


            while (reader.Read())
            {
                string[] fila = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    fila[i] = reader.GetString(i);
                }

                tablacliente.Rows.Add(fila);
               
            }
        }

        private void tablacliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void llamarRegistro() {

            MySqlCommand comando1 = new MySqlCommand("buscarCliente",conexion.crearConexion());
            comando1.CommandType = CommandType.StoredProcedure;
            comando1.Parameters.AddWithValue("id",textBox1.Text);
            comando1.ExecuteScalar();

            MySqlDataReader leer = comando1.ExecuteReader();

            while (leer.Read()) {

                String[] fila = new string[leer.FieldCount];
                for (int i = 0; i < leer.FieldCount; i++) {

                    fila[i] = leer.GetString(i);


                }

                buscador.Rows.Add(fila);

            }



        }

        private void button3_Click(object sender, EventArgs e)
        {

            llamarRegistro();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int b = 0;

            var frm = Application.OpenForms.OfType<crearCliente>().FirstOrDefault();
            if (frm != null)
            {

                b = 1;



            }
            else
            {

                Form Ubicacion = new crearCliente();
                this.Hide();
                Ubicacion.Show();
                

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int c = 0;

            var frm = Application.OpenForms.OfType<Actualizar>().FirstOrDefault();
            if (frm != null)
            {

                c = 1;



            }
            else
            {

                Form actualizar = new Actualizar();
                this.Hide();
                actualizar.Show();


            }

        }
    }
}
