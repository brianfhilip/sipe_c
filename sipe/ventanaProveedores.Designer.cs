namespace sipe
{
    partial class ventanaProveedores
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventanaProveedores));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tablaProveedores = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonmodificar = new System.Windows.Forms.Button();
            this.CREAR_EMPRESA = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonactualizar = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonguardar = new System.Windows.Forms.Button();
            this.areanotaadicional = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.telvendedor = new System.Windows.Forms.TextBox();
            this.paginaweb = new System.Windows.Forms.TextBox();
            this.codigopostal = new System.Windows.Forms.TextBox();
            this.combomunicipio = new System.Windows.Forms.ComboBox();
            this.combodepartamento = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.fax = new System.Windows.Forms.TextBox();
            this.telefono = new System.Windows.Forms.TextBox();
            this.razonsocial = new System.Windows.Forms.TextBox();
            this.direccion = new System.Windows.Forms.TextBox();
            this.nit = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.codigo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProveedores)).BeginInit();
            this.CREAR_EMPRESA.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tablaProveedores);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.buttonmodificar);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(852, 641);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Proveedores";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tablaProveedores
            // 
            this.tablaProveedores.AllowUserToAddRows = false;
            this.tablaProveedores.AllowUserToDeleteRows = false;
            this.tablaProveedores.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaProveedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablaProveedores.DefaultCellStyle = dataGridViewCellStyle2;
            this.tablaProveedores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tablaProveedores.Location = new System.Drawing.Point(7, 6);
            this.tablaProveedores.Name = "tablaProveedores";
            this.tablaProveedores.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaProveedores.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tablaProveedores.Size = new System.Drawing.Size(548, 627);
            this.tablaProveedores.TabIndex = 4;
            this.tablaProveedores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaProveedores_CellClick);
            this.tablaProveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "CODIGO";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "NOMBRE";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "NIT";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "DIRECCION";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // label15
            // 
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Image = ((System.Drawing.Image)(resources.GetObject("label15.Image")));
            this.label15.Location = new System.Drawing.Point(561, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(285, 303);
            this.label15.TabIndex = 6;
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(573, 590);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(259, 43);
            this.button4.TabIndex = 5;
            this.button4.Text = "SALIR";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(573, 498);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(259, 86);
            this.button3.TabIndex = 3;
            this.button3.Text = "BUSCAR";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(573, 405);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(259, 87);
            this.button2.TabIndex = 2;
            this.button2.Text = "ELIMINAR";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // buttonmodificar
            // 
            this.buttonmodificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonmodificar.ForeColor = System.Drawing.Color.Black;
            this.buttonmodificar.Location = new System.Drawing.Point(573, 312);
            this.buttonmodificar.Name = "buttonmodificar";
            this.buttonmodificar.Size = new System.Drawing.Size(259, 87);
            this.buttonmodificar.TabIndex = 1;
            this.buttonmodificar.Text = "MODIFICAR\r\n";
            this.buttonmodificar.UseVisualStyleBackColor = true;
            this.buttonmodificar.Click += new System.EventHandler(this.buttonmodificar_Click);
            // 
            // CREAR_EMPRESA
            // 
            this.CREAR_EMPRESA.Controls.Add(this.tabPage1);
            this.CREAR_EMPRESA.Controls.Add(this.tabPage2);
            this.CREAR_EMPRESA.Location = new System.Drawing.Point(0, 1);
            this.CREAR_EMPRESA.Name = "CREAR_EMPRESA";
            this.CREAR_EMPRESA.SelectedIndex = 0;
            this.CREAR_EMPRESA.Size = new System.Drawing.Size(860, 683);
            this.CREAR_EMPRESA.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.MediumAquamarine;
            this.tabPage2.Controls.Add(this.buttonactualizar);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.buttonguardar);
            this.tabPage2.Controls.Add(this.areanotaadicional);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.telvendedor);
            this.tabPage2.Controls.Add(this.paginaweb);
            this.tabPage2.Controls.Add(this.codigopostal);
            this.tabPage2.Controls.Add(this.combomunicipio);
            this.tabPage2.Controls.Add(this.combodepartamento);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.email);
            this.tabPage2.Controls.Add(this.fax);
            this.tabPage2.Controls.Add(this.telefono);
            this.tabPage2.Controls.Add(this.razonsocial);
            this.tabPage2.Controls.Add(this.direccion);
            this.tabPage2.Controls.Add(this.nit);
            this.tabPage2.Controls.Add(this.nombre);
            this.tabPage2.Controls.Add(this.codigo);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(852, 641);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Crear/Modificar Empresa";
            // 
            // buttonactualizar
            // 
            this.buttonactualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonactualizar.ForeColor = System.Drawing.Color.Black;
            this.buttonactualizar.Location = new System.Drawing.Point(521, 417);
            this.buttonactualizar.Name = "buttonactualizar";
            this.buttonactualizar.Size = new System.Drawing.Size(273, 51);
            this.buttonactualizar.TabIndex = 30;
            this.buttonactualizar.Text = "ACTUALIZAR";
            this.buttonactualizar.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(521, 541);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(273, 45);
            this.button6.TabIndex = 29;
            this.button6.Text = "CANCELAR";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // buttonguardar
            // 
            this.buttonguardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonguardar.ForeColor = System.Drawing.Color.Black;
            this.buttonguardar.Location = new System.Drawing.Point(521, 483);
            this.buttonguardar.Name = "buttonguardar";
            this.buttonguardar.Size = new System.Drawing.Size(273, 44);
            this.buttonguardar.TabIndex = 28;
            this.buttonguardar.Text = "GUARDAR";
            this.buttonguardar.UseVisualStyleBackColor = true;
            // 
            // areanotaadicional
            // 
            this.areanotaadicional.BackColor = System.Drawing.Color.Black;
            this.areanotaadicional.ForeColor = System.Drawing.Color.White;
            this.areanotaadicional.Location = new System.Drawing.Point(521, 63);
            this.areanotaadicional.Multiline = true;
            this.areanotaadicional.Name = "areanotaadicional";
            this.areanotaadicional.Size = new System.Drawing.Size(273, 340);
            this.areanotaadicional.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(553, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(213, 29);
            this.label14.TabIndex = 26;
            this.label14.Text = "Notas Adicionales:";
            // 
            // telvendedor
            // 
            this.telvendedor.BackColor = System.Drawing.Color.Black;
            this.telvendedor.ForeColor = System.Drawing.Color.White;
            this.telvendedor.Location = new System.Drawing.Point(198, 552);
            this.telvendedor.Name = "telvendedor";
            this.telvendedor.Size = new System.Drawing.Size(249, 35);
            this.telvendedor.TabIndex = 25;
            // 
            // paginaweb
            // 
            this.paginaweb.BackColor = System.Drawing.Color.Black;
            this.paginaweb.ForeColor = System.Drawing.Color.White;
            this.paginaweb.Location = new System.Drawing.Point(198, 509);
            this.paginaweb.Name = "paginaweb";
            this.paginaweb.Size = new System.Drawing.Size(249, 35);
            this.paginaweb.TabIndex = 24;
            // 
            // codigopostal
            // 
            this.codigopostal.BackColor = System.Drawing.Color.Black;
            this.codigopostal.ForeColor = System.Drawing.Color.White;
            this.codigopostal.Location = new System.Drawing.Point(198, 464);
            this.codigopostal.Name = "codigopostal";
            this.codigopostal.Size = new System.Drawing.Size(249, 35);
            this.codigopostal.TabIndex = 23;
            // 
            // combomunicipio
            // 
            this.combomunicipio.BackColor = System.Drawing.Color.Black;
            this.combomunicipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combomunicipio.ForeColor = System.Drawing.Color.White;
            this.combomunicipio.FormattingEnabled = true;
            this.combomunicipio.Location = new System.Drawing.Point(198, 424);
            this.combomunicipio.Name = "combomunicipio";
            this.combomunicipio.Size = new System.Drawing.Size(249, 24);
            this.combomunicipio.TabIndex = 22;
            this.combomunicipio.Text = "Seleccionar";
            // 
            // combodepartamento
            // 
            this.combodepartamento.BackColor = System.Drawing.Color.Black;
            this.combodepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combodepartamento.ForeColor = System.Drawing.Color.White;
            this.combodepartamento.FormattingEnabled = true;
            this.combodepartamento.Location = new System.Drawing.Point(198, 376);
            this.combodepartamento.Name = "combodepartamento";
            this.combodepartamento.Size = new System.Drawing.Size(249, 24);
            this.combodepartamento.TabIndex = 21;
            this.combodepartamento.Text = "Seleccionar";
            this.combodepartamento.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(21, 557);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(167, 29);
            this.label13.TabIndex = 20;
            this.label13.Text = "Tel Vendedor:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(21, 513);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 29);
            this.label12.TabIndex = 19;
            this.label12.Text = "Pagina Web:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(21, 471);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(171, 29);
            this.label11.TabIndex = 18;
            this.label11.Text = "Codigo Postal:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(21, 424);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 29);
            this.label10.TabIndex = 17;
            this.label10.Text = "Municipio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(21, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 29);
            this.label9.TabIndex = 16;
            this.label9.Text = "Departamento:";
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.Color.Black;
            this.email.ForeColor = System.Drawing.Color.White;
            this.email.Location = new System.Drawing.Point(174, 323);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(273, 35);
            this.email.TabIndex = 15;
            // 
            // fax
            // 
            this.fax.BackColor = System.Drawing.Color.Black;
            this.fax.ForeColor = System.Drawing.Color.White;
            this.fax.Location = new System.Drawing.Point(174, 280);
            this.fax.Name = "fax";
            this.fax.Size = new System.Drawing.Size(273, 35);
            this.fax.TabIndex = 14;
            // 
            // telefono
            // 
            this.telefono.BackColor = System.Drawing.Color.Black;
            this.telefono.ForeColor = System.Drawing.Color.White;
            this.telefono.Location = new System.Drawing.Point(174, 236);
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(273, 35);
            this.telefono.TabIndex = 13;
            // 
            // razonsocial
            // 
            this.razonsocial.BackColor = System.Drawing.Color.Black;
            this.razonsocial.ForeColor = System.Drawing.Color.White;
            this.razonsocial.Location = new System.Drawing.Point(174, 192);
            this.razonsocial.Name = "razonsocial";
            this.razonsocial.Size = new System.Drawing.Size(273, 35);
            this.razonsocial.TabIndex = 12;
            // 
            // direccion
            // 
            this.direccion.BackColor = System.Drawing.Color.Black;
            this.direccion.ForeColor = System.Drawing.Color.White;
            this.direccion.Location = new System.Drawing.Point(174, 149);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(273, 35);
            this.direccion.TabIndex = 11;
            // 
            // nit
            // 
            this.nit.BackColor = System.Drawing.Color.Black;
            this.nit.ForeColor = System.Drawing.Color.White;
            this.nit.Location = new System.Drawing.Point(174, 106);
            this.nit.Name = "nit";
            this.nit.Size = new System.Drawing.Size(273, 35);
            this.nit.TabIndex = 10;
            // 
            // nombre
            // 
            this.nombre.BackColor = System.Drawing.Color.Black;
            this.nombre.ForeColor = System.Drawing.Color.White;
            this.nombre.Location = new System.Drawing.Point(174, 63);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(273, 35);
            this.nombre.TabIndex = 9;
            // 
            // codigo
            // 
            this.codigo.BackColor = System.Drawing.Color.Black;
            this.codigo.ForeColor = System.Drawing.Color.White;
            this.codigo.Location = new System.Drawing.Point(174, 21);
            this.codigo.Name = "codigo";
            this.codigo.Size = new System.Drawing.Size(273, 35);
            this.codigo.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(21, 329);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 29);
            this.label8.TabIndex = 7;
            this.label8.Text = "E-mail:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(21, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 29);
            this.label7.TabIndex = 6;
            this.label7.Text = "Fax:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(21, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 29);
            this.label6.TabIndex = 5;
            this.label6.Text = "Telefono:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Razon Social:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(21, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Direcccion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nit:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo:";
            // 
            // ventanaProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 684);
            this.Controls.Add(this.CREAR_EMPRESA);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "ventanaProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                                                                 " +
    "                  MODULO PROVEEDORES";
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablaProveedores)).EndInit();
            this.CREAR_EMPRESA.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonmodificar;
        private System.Windows.Forms.TabControl CREAR_EMPRESA;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView tablaProveedores;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox combodepartamento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox fax;
        private System.Windows.Forms.TextBox telefono;
        private System.Windows.Forms.TextBox razonsocial;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.TextBox nit;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.TextBox codigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox telvendedor;
        private System.Windows.Forms.TextBox paginaweb;
        private System.Windows.Forms.TextBox codigopostal;
        private System.Windows.Forms.ComboBox combomunicipio;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buttonguardar;
        private System.Windows.Forms.TextBox areanotaadicional;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button buttonactualizar;
    }
}

