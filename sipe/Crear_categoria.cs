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
    public partial class Crear_categoria : Form
    {

        public String x;

        public Crear_categoria()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void ingresar()
        {

            try
            {

                MySqlCommand comando1 = new MySqlCommand("crearCategoria", conexion.crearConexion());
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("idC", id.Text.ToUpperInvariant());
                comando1.Parameters.AddWithValue("nomC", nombreCa.Text.ToUpperInvariant());
                comando1.ExecuteScalar();

                MessageBox.Show("La Nueva categoria fue creada con exito!!");

                id.Text = "";
                nombreCa.Text = "";

                this.Close();

            }
            catch (Exception t)
            {

                MessageBox.Show("A ocurrido un error", t.ToString());


            }


        }





        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                if (id.Text.Equals(""))
                {

                    MessageBox.Show("El campo Id Categoria esta vacio");
                    id.Focus();


                }
                else if (nombreCa.Text.Equals(""))
                {

                    MessageBox.Show("El campo nombre categoria esta vacio");

                    nombreCa.Focus();


                }
                else
                {




                    MySqlCommand comando = new MySqlCommand("validarcategoria", conexion.crearConexion());
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("idC", id.Text);
                    comando.Parameters.AddWithValue("nomC", nombreCa.Text);
                    comando.ExecuteScalar();

                    MySqlDataReader dr = comando.ExecuteReader();


                    while (dr.Read())
                    {


                        x = dr.GetString(0);


                    }

                    if (x.Equals("1"))
                    {

                        MessageBox.Show("La ubicacion o el nombre de la ubicacion ya existe en la base de datos ");
                        id.Text = "";
                        nombreCa.Text = "";

                    }
                    else
                    {

                        ingresar();


                    }
                }



            }
            catch (Exception f)
            {

                MessageBox.Show("A ocurrido un error ", f.ToString());

            }


        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            /*
            int num = 0;
            

            if (!int.TryParse(id.Text, out num))
            {
                id.Text = "";
                MessageBox.Show("Ingrese un valor numérico");
               
                return; //Salimos
                
            }*/
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (Char.IsLetter(e.KeyChar)) {

                e.Handled = true;
                MessageBox.Show("Ingrese solo Numeros");
                


            }

            
        }

        private void nombreCa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsDigit(e.KeyChar)) {

                e.Handled = true;
                MessageBox.Show("Ingrese solo Letras");



            }
        }


        public void autocompletar(TextBox nom) {
            
           



        }

        private void Crear_categoria_Load(object sender, EventArgs e)
        {

        }
    }
}
