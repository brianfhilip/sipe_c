namespace sipe
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tablaMostrar = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.tablaBuscar = new System.Windows.Forms.DataGridView();
            this.Buscar = new System.Windows.Forms.Button();
            this.cajaBuscar = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Crear_Ubicacion = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaMostrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaMostrar
            // 
            this.tablaMostrar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaMostrar.Location = new System.Drawing.Point(4, 12);
            this.tablaMostrar.Name = "tablaMostrar";
            this.tablaMostrar.Size = new System.Drawing.Size(795, 163);
            this.tablaMostrar.TabIndex = 0;
            this.tablaMostrar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaMostrar_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(724, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tablaBuscar
            // 
            this.tablaBuscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaBuscar.Location = new System.Drawing.Point(4, 232);
            this.tablaBuscar.Name = "tablaBuscar";
            this.tablaBuscar.Size = new System.Drawing.Size(795, 64);
            this.tablaBuscar.TabIndex = 2;
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(351, 193);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 23);
            this.Buscar.TabIndex = 3;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // cajaBuscar
            // 
            this.cajaBuscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cajaBuscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cajaBuscar.Location = new System.Drawing.Point(12, 193);
            this.cajaBuscar.Name = "cajaBuscar";
            this.cajaBuscar.Size = new System.Drawing.Size(333, 20);
            this.cajaBuscar.TabIndex = 4;
            this.cajaBuscar.TextChanged += new System.EventHandler(this.cajaBuscar_TextChanged);
            this.cajaBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cajaBuscar_KeyPress);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(37, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 59);
            this.button2.TabIndex = 5;
            this.button2.Text = "Crear_Categoria";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Crear_Ubicacion
            // 
            this.Crear_Ubicacion.Image = ((System.Drawing.Image)(resources.GetObject("Crear_Ubicacion.Image")));
            this.Crear_Ubicacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Crear_Ubicacion.Location = new System.Drawing.Point(197, 311);
            this.Crear_Ubicacion.Name = "Crear_Ubicacion";
            this.Crear_Ubicacion.Size = new System.Drawing.Size(132, 59);
            this.Crear_Ubicacion.TabIndex = 6;
            this.Crear_Ubicacion.Text = "Crear_Ubicacion";
            this.Crear_Ubicacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Crear_Ubicacion.UseVisualStyleBackColor = true;
            this.Crear_Ubicacion.Click += new System.EventHandler(this.Crear_Ubicacion_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(351, 312);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 58);
            this.button3.TabIndex = 7;
            this.button3.Text = "Actualizar _Inventario";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(498, 312);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(132, 58);
            this.button4.TabIndex = 8;
            this.button4.Text = "Crear_Producto";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 487);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Crear_Ubicacion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cajaBuscar);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.tablaBuscar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tablaMostrar);
            this.Name = "Form1";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaMostrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaBuscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaMostrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView tablaBuscar;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.TextBox cajaBuscar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Crear_Ubicacion;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

