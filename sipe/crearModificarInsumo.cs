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
    public partial class crearModificarInsumo : Form
    {
        public crearModificarInsumo()
        {
            InitializeComponent();
            cargarComboMedida();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            MySqlCommand miSentencia = new MySqlCommand("insertar_insumo", conexion.crearConexion());
            miSentencia.CommandType = CommandType.StoredProcedure;
            miSentencia.Parameters.AddWithValue("id", cajaCodigo.Text.ToUpper());
            miSentencia.Parameters.AddWithValue("nombre", cajaNombre.Text.ToUpper());
            miSentencia.Parameters.AddWithValue("costo", float.Parse(cajaCosto.Text.ToUpper()));
            miSentencia.Parameters.AddWithValue("cantidad", float.Parse(cajaCantidad.Text.ToUpper()));
            miSentencia.Parameters.AddWithValue("stock", int.Parse(cajaStock.Text.ToUpper()));
                MySqlCommand miSentencia2 = new MySqlCommand("select idTipoCantidad from tipos_de_cantidades where nombreTipoCantidad='" + comboMedida.SelectedItem + "'", conexion.crearConexion());
                MySqlDataReader reader = miSentencia2.ExecuteReader();

                while (reader.Read())
                {
            miSentencia.Parameters.AddWithValue("tipoCant", reader.GetString(0));
                }

            miSentencia.Parameters.AddWithValue("facturarSin", "");
            miSentencia.Parameters.AddWithValue("comen", cajaObservaciones.Text);
            miSentencia.ExecuteNonQuery();
            
            MessageBox.Show("Insumo registrado correctamente");
            
        }

        private void btnActualiar_Click(object sender, EventArgs e)
        {
            MySqlCommand miSentencia = new MySqlCommand("actualizar_insumo", conexion.crearConexion());
            miSentencia.CommandType = CommandType.StoredProcedure;
            miSentencia.Parameters.AddWithValue("nombre",cajaNombre.Text);
            miSentencia.Parameters.AddWithValue("cantidadMin",cajaStock.Text);
            miSentencia.Parameters.AddWithValue("idTipo",comboMedida.SelectedItem );
            Console.WriteLine("valor de la medida es "+comboMedida.SelectedValue);
            miSentencia.Parameters.AddWithValue("aunFacturar","SI");
            miSentencia.Parameters.AddWithValue("comentario", cajaObservaciones.Text);
            miSentencia.Parameters.AddWithValue("id",cajaCodigo.Text );
            miSentencia.ExecuteNonQuery();
            MessageBox.Show("Insumo actualizado correctamente");
        }

        private void cargarComboMedida()
        {
            MySqlCommand miSentencia = new MySqlCommand("call llamarTipo", conexion.crearConexion());
            MySqlDataReader reader = miSentencia.ExecuteReader();

            while (reader.Read())
            {
                comboMedida.Items.Add(reader.GetString(0));
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           
            this.Dispose();
            recetas objRecetas = new recetas();
            objRecetas.MdiParent = this.MdiParent;
            objRecetas.Show();
        }

        private void cajaCodigo_Leave(object sender, EventArgs e)
        {
            if (btnGuardar.Enabled==true)
            {

            
            cajaNombre.Focus();
            MySqlCommand comando = new MySqlCommand("validar_idInsumo", conexion.crearConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("codigo", cajaCodigo.Text);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0).Equals("1"))
                {
                    cajaCodigo.BackColor = Color.Red;
                    cajaCodigo.Focus();
                }else
                {
                    cajaCodigo.BackColor = Color.Empty;
                }
            }
            }
           

        }

        private void crearModificarInsumo_FormClosed(object sender, FormClosedEventArgs e)
        {
            recetas objRecetas = new recetas();
            objRecetas.MdiParent = this.MdiParent;
            objRecetas.Show();
        }

        private void cajaNombre_Leave(object sender, EventArgs e)
        {
            cajaCosto.Focus();
        }

        private void cajaCosto_Leave(object sender, EventArgs e)
        {
            comboMedida.Focus();
        }

        private void comboMedida_Leave(object sender, EventArgs e)
        {
            cajaCantidad.Focus();
        }

        private void cajaObservaciones_Leave(object sender, EventArgs e)
        {
            btnGuardar.Focus();
        }

        private void cajaCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==(int)Keys.Enter)
            {
                cajaNombre.Focus();
            }
        }

        private void cajaNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                cajaCosto.Focus();
            }
        }

        private void comboMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                cajaCantidad.Focus();
            }
        }

        private void cajaCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                cajaStock.Focus();
            }
        }

        private void cajaStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                cajaObservaciones.Focus();
            }
        }

        private void cajaCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                comboMedida.Focus();
            }
        }

        private void cajaObservaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                if (btnGuardar.Enabled==false)
                {
                    btnActualiar.Focus();
                }else
                {
                    btnGuardar.Focus();
                }
            }
        }

        private void crearModificarInsumo_Load(object sender, EventArgs e)
        {

        }
    }
}
