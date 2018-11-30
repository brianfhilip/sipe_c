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
    public partial class recetas : Form
    {
        crearModificarInsumo objCrearModificar;
        crearComprarInsumos objCrearCompraInsumo;
        public recetas()
        {
            InitializeComponent();
            mostrarInventarioinsumos();
            mostrarCompraInsumos();
            mostrarRecetas();
        }

        private void recetas_Load(object sender, EventArgs e)
        {

        }

        public void mostrarInventarioinsumos()
        {
            MySqlCommand miSentencia = new MySqlCommand("call mostrar_insumos_busqueda", conexion.crearConexion());
            MySqlDataReader reader = miSentencia.ExecuteReader();


            while (reader.Read())
            {
                string[] fila = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    fila[i] = reader.GetString(i);
                }

                tablaInventarioInsumos.Rows.Add(fila);
            }
        }

        private void mostrarCompraInsumos()
        {
            try { 
            MySqlCommand miSentencia = new MySqlCommand("mostrar_compra_insumos", conexion.crearConexion());
            miSentencia.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader = miSentencia.ExecuteReader();


            while (reader.Read())
            {
                string[] fila = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                  fila[i] = reader.GetString(i);
                }
                tablaCompraInsumos.Rows.Add(fila);
            }
        }catch(MySqlException e)
            {

            }
        }
        private void mostrarRecetas()
        {
            MySqlCommand miSentencia = new MySqlCommand("call mostrar_recetas", conexion.crearConexion());
            MySqlDataReader reader = miSentencia.ExecuteReader();

            while (reader.Read())
            {
                string[] fila = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    fila[i] = reader.GetString(i);
                }
                tablaRecetas.Rows.Add(fila);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (objCrearCompraInsumo == null || objCrearCompraInsumo.IsDisposed)
            {
                objCrearCompraInsumo = new crearComprarInsumos();
                objCrearCompraInsumo.Show();
                this.Dispose();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }   

        private void btnCrearInsumo_Click_1(object sender, EventArgs e)
        {
            if (objCrearModificar==null || objCrearModificar.IsDisposed)
            {
                objCrearModificar = new crearModificarInsumo();
                objCrearModificar.Show();
                this.Dispose();
            }
            objCrearModificar.btnActualiar.Enabled = false;
            
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (tablaInventarioInsumos.CurrentRow.Index >= 0)
            {
                if (objCrearModificar == null || objCrearModificar.IsDisposed)
                {
                    objCrearModificar = new crearModificarInsumo();
                    objCrearModificar.Show();
                    objCrearModificar.cajaCantidad.Enabled = false;
                    objCrearModificar.cajaCosto.Enabled = false;
                    objCrearModificar.cajaCantidad.BackColor = Color.Red;
                    objCrearModificar.cajaCosto.BackColor = Color.Red;
                }

                int valorCelda = tablaInventarioInsumos.CurrentRow.Index;
                Console.WriteLine("el valor de la celda " + valorCelda);
                MySqlCommand miSentencia = new MySqlCommand("select * from insumos where idInsumo='" + tablaInventarioInsumos.Rows[valorCelda].Cells[0].Value + "'", conexion.crearConexion());

                MySqlDataReader reader = miSentencia.ExecuteReader();

                while (reader.Read())
                {
                    objCrearModificar.cajaCodigo.Text = reader.GetString(0);
                    objCrearModificar.cajaNombre.Text = reader.GetString(1);
                    objCrearModificar.cajaCosto.Text = reader.GetString(2);
                    objCrearModificar.cajaCantidad.Text = reader.GetString(3);
                    objCrearModificar.cajaStock.Text = reader.GetString(4);
                    ////aqui voy
                    
                    objCrearModificar.comboMedida.SelectedItem = reader.GetString(5);
                    objCrearModificar.cajaObservaciones.Text = reader.GetString(7);
                }
                objCrearModificar.btnGuardar.Enabled = false;
                this.Dispose();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tablaInventarioInsumos.CurrentRow.Index>=0)
            {
                int valorCelda = tablaInventarioInsumos.CurrentRow.Index;
                MySqlCommand miSentencia = new MySqlCommand("delete from insumos where idInsumo='" + tablaInventarioInsumos.Rows[valorCelda].Cells[0].Value + "'", conexion.crearConexion());
                miSentencia.ExecuteNonQuery();
                MessageBox.Show("Insumo eliminador correctamente");
                tablaInventarioInsumos.Rows.Clear();
                mostrarInventarioinsumos(); 
               
            }
        }

        private void tablaInventarioInsumos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnModificarCompra_Click(object sender, EventArgs e)
        {
            if (tablaCompraInsumos.CurrentRow.Index >= 0)
            {
                if (objCrearModificar == null || objCrearModificar.IsDisposed)
                { 
                    objCrearCompraInsumo = new crearComprarInsumos();
                    objCrearCompraInsumo.Show();
                }

                int valorCelda = tablaCompraInsumos.CurrentRow.Index;
                MySqlCommand miSentencia = new MySqlCommand("select * from facturas_de_compras where idFacturaCompra='" + tablaCompraInsumos.Rows[valorCelda].Cells[0].Value + "'", conexion.crearConexion());
                MySqlDataReader reader = miSentencia.ExecuteReader();
                while (reader.Read())        
                {
                    objCrearCompraInsumo.labelNumeroCompra.Text = reader.GetString(0);
                    objCrearCompraInsumo.cajaCodigoProveedor.Text = reader.GetString(1);
                        MySqlCommand miSentencia2 = new MySqlCommand("select nombreProveedor,nitProveedor from proveedores where idProveedor='" + reader.GetString(1) + "'",conexion.crearConexion());
                        MySqlDataReader reader2 = miSentencia2.ExecuteReader();
                        while (reader2.Read())
                        {
                    objCrearCompraInsumo.cajaNombre.Text = reader2.GetString(0);
                    objCrearCompraInsumo.cajaNit.Text = reader2.GetString(1);
                        }

               }

                this.Dispose();
            }
        }
    }
}

