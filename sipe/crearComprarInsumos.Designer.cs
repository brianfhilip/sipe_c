namespace sipe
{
    partial class crearComprarInsumos
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
            this.cajaCodigoProveedor = new System.Windows.Forms.TextBox();
            this.cajaNombre = new System.Windows.Forms.TextBox();
            this.tablaPedidoInsumo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNumeroCompra = new System.Windows.Forms.Label();
            this.cajaNit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.comboTipoCompra = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cajaBusqueda = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cajaCantidad = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.radioSi = new System.Windows.Forms.RadioButton();
            this.radioNo = new System.Windows.Forms.RadioButton();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.labelSubtotal = new System.Windows.Forms.Label();
            this.labelIva = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.listaBusqueda = new System.Windows.Forms.ListBox();
            this.TextObservaciones = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPedidoInsumo)).BeginInit();
            this.SuspendLayout();
            // 
            // cajaCodigoProveedor
            // 
            this.cajaCodigoProveedor.Location = new System.Drawing.Point(290, 32);
            this.cajaCodigoProveedor.Name = "cajaCodigoProveedor";
            this.cajaCodigoProveedor.Size = new System.Drawing.Size(78, 20);
            this.cajaCodigoProveedor.TabIndex = 0;
            this.cajaCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cajaCodigo_KeyPress);
            this.cajaCodigoProveedor.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // cajaNombre
            // 
            this.cajaNombre.Location = new System.Drawing.Point(374, 32);
            this.cajaNombre.Name = "cajaNombre";
            this.cajaNombre.Size = new System.Drawing.Size(147, 20);
            this.cajaNombre.TabIndex = 1;
            this.cajaNombre.Enter += new System.EventHandler(this.cajaNombre_Enter);
            // 
            // tablaPedidoInsumo
            // 
            this.tablaPedidoInsumo.AllowUserToAddRows = false;
            this.tablaPedidoInsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaPedidoInsumo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.tablaPedidoInsumo.Location = new System.Drawing.Point(59, 177);
            this.tablaPedidoInsumo.Name = "tablaPedidoInsumo";
            this.tablaPedidoInsumo.Size = new System.Drawing.Size(543, 147);
            this.tablaPedidoInsumo.TabIndex = 2;
            this.tablaPedidoInsumo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.tablaPedidoInsumo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.tablaPedidoInsumo_RowsAdded);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Codigo";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripcion";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Cant";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Precio Unit";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Subtotal";
            this.Column5.Name = "Column5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Proveedor:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(527, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nro Compra:";
            // 
            // labelNumeroCompra
            // 
            this.labelNumeroCompra.AutoSize = true;
            this.labelNumeroCompra.Location = new System.Drawing.Point(139, 35);
            this.labelNumeroCompra.Name = "labelNumeroCompra";
            this.labelNumeroCompra.Size = new System.Drawing.Size(19, 13);
            this.labelNumeroCompra.TabIndex = 6;
            this.labelNumeroCompra.Text = "00";
            // 
            // cajaNit
            // 
            this.cajaNit.Location = new System.Drawing.Point(374, 58);
            this.cajaNit.Name = "cajaNit";
            this.cajaNit.Size = new System.Drawing.Size(100, 20);
            this.cajaNit.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nit:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Location = new System.Drawing.Point(452, 107);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(65, 13);
            this.labelFecha.TabIndex = 10;
            this.labelFecha.Text = "yyyy/mm/dd";
            // 
            // comboTipoCompra
            // 
            this.comboTipoCompra.FormattingEnabled = true;
            this.comboTipoCompra.Location = new System.Drawing.Point(184, 104);
            this.comboTipoCompra.Name = "comboTipoCompra";
            this.comboTipoCompra.Size = new System.Drawing.Size(121, 21);
            this.comboTipoCompra.TabIndex = 11;
            this.comboTipoCompra.Text = "Seleccionar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tipo de Compra:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(93, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Codigo/Nombre:";
            // 
            // cajaBusqueda
            // 
            this.cajaBusqueda.Location = new System.Drawing.Point(184, 142);
            this.cajaBusqueda.Name = "cajaBusqueda";
            this.cajaBusqueda.Size = new System.Drawing.Size(177, 20);
            this.cajaBusqueda.TabIndex = 14;
            this.cajaBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cajaBusqueda_KeyPress);
            this.cajaBusqueda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cajaBusqueda_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(397, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Cantidad:";
            // 
            // cajaCantidad
            // 
            this.cajaCantidad.Location = new System.Drawing.Point(455, 142);
            this.cajaCantidad.Name = "cajaCantidad";
            this.cajaCantidad.Size = new System.Drawing.Size(100, 20);
            this.cajaCantidad.TabIndex = 16;
            this.cajaCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 344);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(273, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Desea recibir la mercaderia una vez realizada la compra:";
            // 
            // radioSi
            // 
            this.radioSi.AutoSize = true;
            this.radioSi.Location = new System.Drawing.Point(341, 340);
            this.radioSi.Name = "radioSi";
            this.radioSi.Size = new System.Drawing.Size(34, 17);
            this.radioSi.TabIndex = 18;
            this.radioSi.TabStop = true;
            this.radioSi.Text = "Si";
            this.radioSi.UseVisualStyleBackColor = true;
            // 
            // radioNo
            // 
            this.radioNo.AutoSize = true;
            this.radioNo.Location = new System.Drawing.Point(341, 357);
            this.radioNo.Name = "radioNo";
            this.radioNo.Size = new System.Drawing.Size(39, 17);
            this.radioNo.TabIndex = 19;
            this.radioNo.TabStop = true;
            this.radioNo.Text = "No";
            this.radioNo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(386, 363);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 23);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Crear Compra";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(386, 392);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 23);
            this.button3.TabIndex = 21;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(490, 340);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Subtotal";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(495, 367);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "IVA";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(497, 399);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Total";
            // 
            // labelSubtotal
            // 
            this.labelSubtotal.AutoSize = true;
            this.labelSubtotal.Location = new System.Drawing.Point(542, 340);
            this.labelSubtotal.Name = "labelSubtotal";
            this.labelSubtotal.Size = new System.Drawing.Size(13, 13);
            this.labelSubtotal.TabIndex = 25;
            this.labelSubtotal.Text = "$";
            // 
            // labelIva
            // 
            this.labelIva.AutoSize = true;
            this.labelIva.Location = new System.Drawing.Point(542, 368);
            this.labelIva.Name = "labelIva";
            this.labelIva.Size = new System.Drawing.Size(13, 13);
            this.labelIva.TabIndex = 26;
            this.labelIva.Text = "$";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(542, 399);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(13, 13);
            this.labelTotal.TabIndex = 27;
            this.labelTotal.Text = "$";
            // 
            // listaBusqueda
            // 
            this.listaBusqueda.FormattingEnabled = true;
            this.listaBusqueda.Location = new System.Drawing.Point(184, 161);
            this.listaBusqueda.Name = "listaBusqueda";
            this.listaBusqueda.Size = new System.Drawing.Size(177, 95);
            this.listaBusqueda.TabIndex = 28;
            this.listaBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listaBusqueda_KeyPress);
            // 
            // TextObservaciones
            // 
            this.TextObservaciones.Location = new System.Drawing.Point(65, 377);
            this.TextObservaciones.Name = "TextObservaciones";
            this.TextObservaciones.Size = new System.Drawing.Size(240, 62);
            this.TextObservaciones.TabIndex = 29;
            this.TextObservaciones.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Observaciones:";
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(386, 421);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(98, 23);
            this.btnModificar.TabIndex = 31;
            this.btnModificar.Text = "Guardar Cambios";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // crearComprarInsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 451);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TextObservaciones);
            this.Controls.Add(this.listaBusqueda);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelIva);
            this.Controls.Add(this.labelSubtotal);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.radioNo);
            this.Controls.Add(this.radioSi);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cajaCantidad);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cajaBusqueda);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboTipoCompra);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cajaNit);
            this.Controls.Add(this.labelNumeroCompra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tablaPedidoInsumo);
            this.Controls.Add(this.cajaNombre);
            this.Controls.Add(this.cajaCodigoProveedor);
            this.Name = "crearComprarInsumos";
            this.Text = "crearComprarInsumos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.crearComprarInsumos_FormClosed);
            this.Load += new System.EventHandler(this.crearComprarInsumos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaPedidoInsumo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.ComboBox comboTipoCompra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox cajaBusqueda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox cajaCantidad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox listaBusqueda;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label labelNumeroCompra;
        public System.Windows.Forms.TextBox cajaCodigoProveedor;
        public System.Windows.Forms.TextBox cajaNombre;
        public System.Windows.Forms.DataGridView tablaPedidoInsumo;
        public System.Windows.Forms.TextBox cajaNit;
        public System.Windows.Forms.RadioButton radioSi;
        public System.Windows.Forms.RadioButton radioNo;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Label labelSubtotal;
        public System.Windows.Forms.Label labelIva;
        public System.Windows.Forms.Label labelTotal;
        public System.Windows.Forms.RichTextBox TextObservaciones;
        public System.Windows.Forms.Button btnModificar;
    }
}