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
    public partial class Actualizar : Form
    {
        public Actualizar()
        {
            InitializeComponent();
        }

        private void Actualizar_Load(object sender, EventArgs e)
        {

        }

        private void Buscar_Click(object sender, EventArgs e)
        {

            MySqlCommand comando1 = new MySqlCommand("buscarCliente",conexion.crearConexion());
            comando1.CommandType = CommandType.StoredProcedure;
            comando1.Parameters.AddWithValue("id",id.Text);
            comando1.ExecuteScalar();

            MySqlDataReader leer = comando1.ExecuteReader();

            while (leer.Read()) {

                String[] fila = new string[leer.FieldCount];

                for (int i=0;i<leer.FieldCount;i++) {

                    fila[i] = leer.GetString(i);

                    Identificacion.Text = leer.GetString(0);
                    nombre.Text = leer.GetString(1);
                    apellido.Text = leer.GetString(2);
                    telefono.Text = leer.GetString(3);
                    Direccion.Text = leer.GetString(4);

                }

                busquedad.Rows.Add(fila);
            }





        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand comando2 = new MySqlCommand("modificarDatos",conexion.crearConexion());
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.Parameters.AddWithValue("idc",Identificacion.Text);
            comando2.Parameters.AddWithValue("nombrec",nombre.Text);
            comando2.Parameters.AddWithValue("apellidoc",apellido.Text);
            comando2.Parameters.AddWithValue("telefonoc",telefono.Text);
            comando2.Parameters.AddWithValue("direccionc",Direccion.Text);
            comando2.ExecuteScalar();

            MessageBox.Show("Datos Actualizados Correctamente");

            Form nuevo = new Clientes();
            nuevo.Show();
            this.Close();
        }
    }
}
