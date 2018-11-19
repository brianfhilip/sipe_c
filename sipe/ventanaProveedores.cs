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
    public partial class ventanaProveedores : Form
    {
       // MultipleActiveResultSets=true;
        public string celdaSeleccionada;
        public ventanaProveedores()
        {
            InitializeComponent();
            tablaProveedores.ClearSelection();
            mostrar_proveedores();
            buttonactualizar.Enabled = false;
            cargarComboDepartamentos();
        }

        private void cargarComboDepartamentos()
        {
            
            combodepartamento.Items.Add("SELECCIONAR");
            MySqlCommand misentencia2 = new MySqlCommand("select nombreDepartamento from departamentos", conexion.crearConexion());
            MySqlDataReader reader2 = misentencia2.ExecuteReader();
            while (reader2.Read())
            {

                if (reader2.GetString(0).Equals("NINGUNO"))
                {

                }
                else
                {
                    combodepartamento.Items.Add(reader2.GetString(0));
                }
            }
        }

        public void mostrarMunicipio()
        {
            try
            {

                string departamentoSeleccionado = combodepartamento.SelectedItem.ToString();

                MySqlCommand miSentencia =new MySqlCommand("SELECT nombreMunicipio from municipios where idDepartamento=(SELECT idDepartamento FROM departamentos WHERE nombreDepartamento='"+departamentoSeleccionado+"') order by nombreMunicipio asc",conexion.crearConexion());
                MySqlDataReader reader = miSentencia.ExecuteReader();

                combomunicipio.Items.Clear();
                
                while (reader.Read())
                {
                    combomunicipio.Items.Add(reader.GetString(0));

                }
            }
            catch ( MySqlException e)
            {
                
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarMunicipio();
            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void mostrar_proveedores()

        {
            MySqlCommand misentencia = new MySqlCommand("mostrar_vista_proveedores", conexion.crearConexion());
            misentencia.CommandType = CommandType.StoredProcedure;
            //misentencia.ExecuteNonQuery();

            MySqlDataReader reader = misentencia.ExecuteReader();

            int cantidadcolumnas = tablaProveedores.ColumnCount;

            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(1));

                string[] fila = new string[cantidadcolumnas];
                for (int i = 0; i < cantidadcolumnas; i++)
                {
                    fila[i] = reader.GetString(i);

                }
                tablaProveedores.Rows.Add(fila);

            }

        }

        private void tablaProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(tablaProveedores.CurrentCell.Value.ToString());
            try
            {
                celdaSeleccionada= tablaProveedores.Rows[e.RowIndex].Cells[0].Value.ToString();
                Console.WriteLine("el valor del codigo es: "+celdaSeleccionada);
            }
            catch (Exception ex)
            {

            }

        }

        private void buttonmodificar_Click(object sender, EventArgs e)
        {
            buttonactualizar.Enabled = true;
            buttonguardar.Enabled = false;
            CREAR_EMPRESA.SelectedIndex = 1;
            


            Console.WriteLine("La celda seleccionada es "+celdaSeleccionada);

            MySqlCommand miSentencia = new MySqlCommand("traer_datos_proveedor", conexion.crearConexion());
            miSentencia.CommandType = CommandType.StoredProcedure;
            miSentencia.Parameters.AddWithValue("codigo",celdaSeleccionada);
            //MySqlDataReader reader = miSentencia.ExecuteReader();
            using (var reader = miSentencia.ExecuteReader(CommandBehavior.CloseConnection))
            {    //Console.WriteLine("parte");
                while (reader.Read())
                {
                    Console.WriteLine("el valor de reader(1)es: " + reader.GetString(0));
                    codigo.Text = reader.GetString(0);
                    MySqlConnection conexion1 = new MySqlConnection("server=127.0.0.1;database=sipe;Uid=root;pwd=;");
                    MySqlCommand miSentencia2 = new MySqlCommand("traer_departamento", conexion1);
                    miSentencia2.CommandType = CommandType.StoredProcedure;

                    miSentencia.Parameters.AddWithValue("nomMuni", reader.GetString(1));

                    using (var reader2 = miSentencia.ExecuteReader(CommandBehavior.CloseConnection))
                    {//MySqlDataReader reader2 = miSentencia.ExecuteReader();
                        while (reader2.Read())
                        {
                            for (int i = 0; i < combodepartamento.Items.Count; i++)
                            {
                                if (combodepartamento.Items[i].Equals(reader2.GetString(0)))
                                {
                                    combodepartamento.SelectedIndex = i;
                                }

                            }


                        }
                    }
                    nombre.Text = reader.GetString(1);
                    nit.Text = reader.GetString(1);
                    //combomunicipio.SelectedValue = reader.GetString(1);

                }
            }
        }

       
    }
}
