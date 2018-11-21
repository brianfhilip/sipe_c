namespace sipe
{
    partial class Crear_Ubicacion
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CajaId = new System.Windows.Forms.TextBox();
            this.CajaNombre = new System.Windows.Forms.TextBox();
            this.CajaCantidad = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id_Ubicacion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre_Ubicacion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(82, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "Crear _Ubicacion";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CajaId
            // 
            this.CajaId.Location = new System.Drawing.Point(168, 74);
            this.CajaId.Name = "CajaId";
            this.CajaId.Size = new System.Drawing.Size(170, 20);
            this.CajaId.TabIndex = 4;
            this.CajaId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaId_KeyPress);
            // 
            // CajaNombre
            // 
            this.CajaNombre.Location = new System.Drawing.Point(168, 117);
            this.CajaNombre.Name = "CajaNombre";
            this.CajaNombre.Size = new System.Drawing.Size(170, 20);
            this.CajaNombre.TabIndex = 5;
            this.CajaNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaNombre_KeyPress);
            // 
            // CajaCantidad
            // 
            this.CajaCantidad.Location = new System.Drawing.Point(168, 159);
            this.CajaCantidad.Name = "CajaCantidad";
            this.CajaCantidad.Size = new System.Drawing.Size(170, 20);
            this.CajaCantidad.TabIndex = 6;
            this.CajaCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaCantidad_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Crear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Crear_Ubicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CajaCantidad);
            this.Controls.Add(this.CajaNombre);
            this.Controls.Add(this.CajaId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Crear_Ubicacion";
            this.Text = "Crear_Ubicacion";
            this.Load += new System.EventHandler(this.Crear_Ubicacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CajaId;
        private System.Windows.Forms.TextBox CajaNombre;
        private System.Windows.Forms.TextBox CajaCantidad;
        private System.Windows.Forms.Button button1;
    }
}