namespace sipe
{
    partial class Clientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tablacliente = new System.Windows.Forms.DataGridView();
            this.IdCliente = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Nombre_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tablacliente)).BeginInit();
            this.SuspendLayout();
            // 
            // tablacliente
            // 
            this.tablacliente.AllowUserToAddRows = false;
            this.tablacliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablacliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCliente,
            this.Nombre_Cliente,
            this.Column1,
            this.Column2,
            this.Column3});
            this.tablacliente.Location = new System.Drawing.Point(12, 12);
            this.tablacliente.MultiSelect = false;
            this.tablacliente.Name = "tablacliente";
            this.tablacliente.ReadOnly = true;
            this.tablacliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablacliente.Size = new System.Drawing.Size(547, 150);
            this.tablacliente.TabIndex = 0;
            this.tablacliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablacliente_CellContentClick);
            // 
            // IdCliente
            // 
            this.IdCliente.HeaderText = "Id_Columna";
            this.IdCliente.Name = "IdCliente";
            this.IdCliente.ReadOnly = true;
            // 
            // Nombre_Cliente
            // 
            this.Nombre_Cliente.HeaderText = "NombreCliente";
            this.Nombre_Cliente.Name = "Nombre_Cliente";
            this.Nombre_Cliente.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Apellido_Cliente";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Telefono_cliente";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Direccion_Cliente";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 392);
            this.Controls.Add(this.tablacliente);
            this.Name = "Clientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablacliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView tablacliente;
        private System.Windows.Forms.DataGridViewButtonColumn IdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}