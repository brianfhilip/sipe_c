namespace sipe
{
    partial class Actualizar
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.busquedad = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.Identificacion = new System.Windows.Forms.TextBox();
            this.Direccion = new System.Windows.Forms.TextBox();
            this.telefono = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Buscar = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.busquedad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = " ingresa la identificacion del cliente al que quieras  hacer cambios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Identificacion";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(99, 56);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(204, 20);
            this.id.TabIndex = 2;
            // 
            // busquedad
            // 
            this.busquedad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.busquedad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.busquedad.Location = new System.Drawing.Point(15, 105);
            this.busquedad.Name = "busquedad";
            this.busquedad.Size = new System.Drawing.Size(540, 64);
            this.busquedad.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Datos a Modificar";
            // 
            // Identificacion
            // 
            this.Identificacion.Location = new System.Drawing.Point(85, 219);
            this.Identificacion.Name = "Identificacion";
            this.Identificacion.Size = new System.Drawing.Size(100, 20);
            this.Identificacion.TabIndex = 5;
            // 
            // Direccion
            // 
            this.Direccion.Location = new System.Drawing.Point(85, 311);
            this.Direccion.Name = "Direccion";
            this.Direccion.Size = new System.Drawing.Size(100, 20);
            this.Direccion.TabIndex = 6;
            // 
            // telefono
            // 
            this.telefono.Location = new System.Drawing.Point(287, 270);
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(100, 20);
            this.telefono.TabIndex = 7;
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(287, 219);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(100, 20);
            this.nombre.TabIndex = 8;
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(85, 263);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(100, 20);
            this.apellido.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "identificacion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Apellido";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(214, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Telefono";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Direccion";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(288, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(312, 53);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 23);
            this.Buscar.TabIndex = 16;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Identificacion";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Apellido";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Telefono";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Direccion";
            this.Column5.Name = "Column5";
            // 
            // Actualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 399);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.apellido);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.telefono);
            this.Controls.Add(this.Direccion);
            this.Controls.Add(this.Identificacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.busquedad);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Actualizar";
            this.Text = "Actualizar";
            this.Load += new System.EventHandler(this.Actualizar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.busquedad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.DataGridView busquedad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Identificacion;
        private System.Windows.Forms.TextBox Direccion;
        private System.Windows.Forms.TextBox telefono;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}