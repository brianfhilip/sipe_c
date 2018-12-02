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
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();
            mostrar_Factura();
            cargarNombre();
            cargarProveedor();
            TipoPago();
            DestinoCompra();
            cantidadCompra();


        }

        private void Compras_Load(object sender, EventArgs e)
        {

        }

        public void mostrar_Factura() {

            MySqlCommand comando1 = new MySqlCommand("traer_numero_factura_compra",conexion.crearConexion());
            comando1.CommandType = CommandType.StoredProcedure;
            comando1.ExecuteScalar();

            MySqlDataReader leer = comando1.ExecuteReader();

            while (leer.Read()) {


                caja1.Text = leer.GetString(0);


            }

        



        }


        public void cargarNombre()
        {

            MySqlCommand comando2 = new MySqlCommand("mostrarProducto",conexion.crearConexion());
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.ExecuteScalar();


            MySqlDataReader leer1 = comando2.ExecuteReader();

            while (leer1.Read()) {


                nombre.Items.Add(leer1.GetString(0));


            }


        }

        public void cantidadCompra()
        {

            MySqlCommand comando2 = new MySqlCommand("llamarTipo", conexion.crearConexion());
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.ExecuteScalar();


            MySqlDataReader leer1 = comando2.ExecuteReader();

            while (leer1.Read())
            {


                cantidad.Items.Add(leer1.GetString(0));


            }


        }

        public void DestinoCompra()
        {

            MySqlCommand comando2 = new MySqlCommand("llamarbodega", conexion.crearConexion());
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.ExecuteScalar();


            MySqlDataReader leer4 = comando2.ExecuteReader();

            while (leer4.Read())
            {


                destino.Items.Add(leer4.GetString(0));


            }


        }

        public void TipoPago()
        {

            MySqlCommand comando2 = new MySqlCommand("seleccionarPago", conexion.crearConexion());
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.ExecuteScalar();


            MySqlDataReader leer3 = comando2.ExecuteReader();

            while (leer3.Read())
            {


                tipo.Items.Add(leer3.GetString(0));


            }


        }


        public void cargarProveedor()
        {

            MySqlCommand comando2 = new MySqlCommand("mostrarproveedor", conexion.crearConexion());
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.ExecuteScalar();


            MySqlDataReader leer2 = comando2.ExecuteReader();

            while (leer2.Read())
            {


                proveedor.Items.Add(leer2.GetString(0));


            }


        }

    }
}
