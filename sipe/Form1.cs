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
    public partial class Form1 : Form
    {
        DataTable dt;
        MySqlDataAdapter da;
        DataTable de;

        public int b = 0;

        public Form1()
        {

            InitializeComponent();
            buscarDatos(tablaMostrar);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand("Select NombreProductoMarca from productos_marcas", conexion.crearConexion());
                MySqlDataReader leer;
                leer = comando.ExecuteReader();
                AutoCompleteStringCollection myColeccion = new AutoCompleteStringCollection();

                while (leer.Read())
                {


                    myColeccion.Add(leer.GetString(0));


                }

                cajaBuscar.AutoCompleteCustomSource = myColeccion;

            }
            catch (Exception h)
            {


                MessageBox.Show("A ocurrido un problema ", h.ToString());

            }

        }

        public void buscarDatos(DataGridView tab)
        {
            try
            {
                da = new MySqlDataAdapter("Select idProductoMarca,idUbicacion,idCategotia,NombreProductoMarca,CantidaProductoMarca,precio_unidad,precio_cantidad from productos_marcas", ConexionBase.Conexion());

                dt = new DataTable();
                // MessageBox.Show("hola");



                da.Fill(dt);
                tab.DataSource = dt;
            }
            catch (Exception e)
            {


                MessageBox.Show("No se pudo cargar la Tabla", e.ToString());
            }





        }

        private void tablaMostrar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscarDatos(tablaMostrar);
        }

        private void Buscar_Click(object sender, EventArgs e)
        {

            ///
            try
            {

                de = new DataTable();
                MySqlCommand comando = new MySqlCommand("buscarInventario", conexion.crearConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("nombre", cajaBuscar.Text);
                comando.ExecuteScalar();
                MySqlDataAdapter df = new MySqlDataAdapter(comando);
                df.Fill(de);
                tablaBuscar.DataSource = de;


            }
            catch (Exception t)
            {

                MessageBox.Show("Hola este es un error", t.ToString());

            }


        }



        private void button2_Click(object sender, EventArgs e)
        {
            /// validar si la ventana esta abierta , si lo esta la variable a se vuelve igual a 1
            /// si no lo esta sigue en 0 y muestra la ventana 


            int a = 0;


            foreach (Form frm in Application.OpenForms)

            {
                lock (frm)
                {

                    if (frm.GetType() == typeof(Crear_categoria))

                    {

                        a = 1;

                        break;

                    }

                }
            }

            if (a == 0)
            {

                Form Categoria = new Crear_categoria();
                Categoria.Show();



            }


        }

        public void autocompletar(TextBox nom)
        {




        }

        private void cajaBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cajaBuscar_TextChanged(object sender, EventArgs e)
        {

        }





        private void Crear_Ubicacion_Click(object sender, EventArgs e)
        {
            int b = 0;

            var frm = Application.OpenForms.OfType<Crear_Ubicacion>().FirstOrDefault();
            if (frm != null)
            {

                b = 1;



            }
            else {

                Form Ubicacion = new Crear_Ubicacion();
                Ubicacion.Show();

            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            int c = 0;
            var fm = Application.OpenForms.OfType<Actulizar_Inventario>().FirstOrDefault();
            if (fm != null)
            {


                c = 1;
            }
            else {

             

                Form Actualizar = new Actulizar_Inventario();
                Actualizar.Show();
                this.Hide();
               
            


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int t = 0;
            var rf = Application.OpenForms.OfType<Crear_Producto>().FirstOrDefault();

            if (rf != null)
            {

                t = 1;

            }
            else {


                Form Crear = new Crear_Producto();
                Crear.Show();

            }

        }
    }










        }

    
  

