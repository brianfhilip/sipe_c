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
    }
}
