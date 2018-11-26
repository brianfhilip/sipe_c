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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buscador = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablacliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buscador)).BeginInit();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar Cliente por Identificacion";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(222, 202);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 20);
            this.textBox1.TabIndex = 2;
            // 
            // buscador
            // 
            this.buscador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.buscador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.buscador.Location = new System.Drawing.Point(12, 246);
            this.buscador.Name = "buscador";
            this.buscador.Size = new System.Drawing.Size(547, 55);
            this.buscador.TabIndex = 3;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Id_Columna";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "NombreCliente";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Apellido_Cliente";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Telefono_cliente";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Direccion_Cliente";
            this.Column8.Name = "Column8";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(351, 321);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Actualizar datos cliente";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Crear Cliente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(400, 202);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Buscar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 392);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buscador);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tablacliente);
            this.Name = "Clientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablacliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buscador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView tablacliente;
        private System.Windows.Forms.DataGridViewButtonColumn IdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView buscador;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}