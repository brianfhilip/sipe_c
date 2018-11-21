using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sipe
{
    public partial class Principal : Form
    {
        public recetas objRecetas=new recetas();

        public Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recetas objRecetas = new recetas();
            objRecetas.MdiParent = this.MdiParent;
            objRecetas.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ventanaProveedores objVentanaProveedores = new ventanaProveedores();
            objVentanaProveedores.MdiParent = this.MdiParent;
            objVentanaProveedores.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ventas objVentas = new Ventas();
            objVentas.MdiParent = this.MdiParent;
            objVentas.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.MdiParent = this.MdiParent;
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.MdiParent = this.MdiParent;
            cliente.Show();
        }
    }
}
