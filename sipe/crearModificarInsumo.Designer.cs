namespace sipe
{
    partial class crearModificarInsumo
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
            this.cajaCodigo = new System.Windows.Forms.TextBox();
            this.cajaCosto = new System.Windows.Forms.TextBox();
            this.cajaCantidad = new System.Windows.Forms.TextBox();
            this.cajaStock = new System.Windows.Forms.TextBox();
            this.cajaObservaciones = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboMedida = new System.Windows.Forms.ComboBox();
            this.cajaNombre = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cajaCodigo
            // 
            this.cajaCodigo.Location = new System.Drawing.Point(117, 51);
            this.cajaCodigo.Name = "cajaCodigo";
            this.cajaCodigo.Size = new System.Drawing.Size(117, 20);
            this.cajaCodigo.TabIndex = 2;
            this.cajaCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cajaCodigo_KeyPress);
            this.cajaCodigo.Leave += new System.EventHandler(this.cajaCodigo_Leave);
            // 
            // cajaCosto
            // 
            this.cajaCosto.Location = new System.Drawing.Point(117, 136);
            this.cajaCosto.Name = "cajaCosto";
            this.cajaCosto.Size = new System.Drawing.Size(117, 20);
            this.cajaCosto.TabIndex = 3;
            this.cajaCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cajaCosto_KeyPress);
            this.cajaCosto.Leave += new System.EventHandler(this.cajaCosto_Leave);
            // 
            // cajaCantidad
            // 
            this.cajaCantidad.Location = new System.Drawing.Point(117, 225);
            this.cajaCantidad.Name = "cajaCantidad";
            this.cajaCantidad.Size = new System.Drawing.Size(117, 20);
            this.cajaCantidad.TabIndex = 4;
            this.cajaCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cajaCantidad_KeyPress);
            // 
            // cajaStock
            // 
            this.cajaStock.Location = new System.Drawing.Point(117, 270);
            this.cajaStock.Name = "cajaStock";
            this.cajaStock.Size = new System.Drawing.Size(117, 20);
            this.cajaStock.TabIndex = 5;
            this.cajaStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cajaStock_KeyPress);
            // 
            // cajaObservaciones
            // 
            this.cajaObservaciones.Location = new System.Drawing.Point(285, 77);
            this.cajaObservaciones.Name = "cajaObservaciones";
            this.cajaObservaciones.Size = new System.Drawing.Size(184, 213);
            this.cajaObservaciones.TabIndex = 8;
            this.cajaObservaciones.Text = "";
            this.cajaObservaciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cajaObservaciones_KeyPress);
            this.cajaObservaciones.Leave += new System.EventHandler(this.cajaObservaciones_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Costo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Cantidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Stock Minimo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Medida";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(282, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Observaciones:";
            // 
            // comboMedida
            // 
            this.comboMedida.FormattingEnabled = true;
            this.comboMedida.Location = new System.Drawing.Point(117, 182);
            this.comboMedida.Name = "comboMedida";
            this.comboMedida.Size = new System.Drawing.Size(117, 21);
            this.comboMedida.TabIndex = 17;
            this.comboMedida.Text = "SELECCIONAR";
            this.comboMedida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboMedida_KeyPress);
            this.comboMedida.Leave += new System.EventHandler(this.comboMedida_Leave);
            // 
            // cajaNombre
            // 
            this.cajaNombre.Location = new System.Drawing.Point(117, 94);
            this.cajaNombre.Name = "cajaNombre";
            this.cajaNombre.Size = new System.Drawing.Size(117, 20);
            this.cajaNombre.TabIndex = 18;
            this.cajaNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cajaNombre_KeyPress);
            this.cajaNombre.Leave += new System.EventHandler(this.cajaNombre_Leave);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(117, 324);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualiar
            // 
            this.btnActualiar.Location = new System.Drawing.Point(223, 324);
            this.btnActualiar.Name = "btnActualiar";
            this.btnActualiar.Size = new System.Drawing.Size(85, 23);
            this.btnActualiar.TabIndex = 20;
            this.btnActualiar.Text = "ACTUALIZAR";
            this.btnActualiar.UseVisualStyleBackColor = true;
            this.btnActualiar.Click += new System.EventHandler(this.btnActualiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(336, 324);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // crearModificarInsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 359);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnActualiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cajaNombre);
            this.Controls.Add(this.comboMedida);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cajaObservaciones);
            this.Controls.Add(this.cajaStock);
            this.Controls.Add(this.cajaCantidad);
            this.Controls.Add(this.cajaCosto);
            this.Controls.Add(this.cajaCodigo);
            this.Name = "crearModificarInsumo";
            this.Text = "Crear-Modificar Insumo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.crearModificarInsumo_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.TextBox cajaNombre;
        public System.Windows.Forms.TextBox cajaCodigo;
        public System.Windows.Forms.TextBox cajaCosto;
        public System.Windows.Forms.TextBox cajaCantidad;
        public System.Windows.Forms.TextBox cajaStock;
        public System.Windows.Forms.RichTextBox cajaObservaciones;
        public System.Windows.Forms.ComboBox comboMedida;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button btnActualiar;
    }
}