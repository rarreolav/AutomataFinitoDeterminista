namespace Automata
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.ofdArchivo = new System.Windows.Forms.OpenFileDialog();
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.btnSimular = new System.Windows.Forms.Button();
            this.txtContenido = new System.Windows.Forms.TextBox();
            this.lblContenidoArchivo = new System.Windows.Forms.Label();
            this.lblResultadoT = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.sbPrincipal = new System.Windows.Forms.StatusStrip();
            this.slblTitulo = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.sbPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdArchivo
            // 
            this.ofdArchivo.DefaultExt = "txt";
            this.ofdArchivo.Filter = "archivos txt (*.txt)|*.txt|All files (*.*)|*.*";
            this.ofdArchivo.InitialDirectory = "C:\\Users\\rafael.arreola\\Documents\\";
            this.ofdArchivo.RestoreDirectory = true;
            this.ofdArchivo.Title = "Seleccione el archivo";
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRutaArchivo.Location = new System.Drawing.Point(35, 21);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.ReadOnly = true;
            this.txtRutaArchivo.Size = new System.Drawing.Size(188, 21);
            this.txtRutaArchivo.TabIndex = 2;
            this.txtRutaArchivo.Text = "Por favor, seleccione el archivo...";
            // 
            // btnExaminar
            // 
            this.btnExaminar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExaminar.Location = new System.Drawing.Point(229, 21);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(83, 21);
            this.btnExaminar.TabIndex = 0;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // btnSimular
            // 
            this.btnSimular.Enabled = false;
            this.btnSimular.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimular.Location = new System.Drawing.Point(35, 62);
            this.btnSimular.Name = "btnSimular";
            this.btnSimular.Size = new System.Drawing.Size(83, 21);
            this.btnSimular.TabIndex = 1;
            this.btnSimular.Text = "Simular Autómata";
            this.btnSimular.UseVisualStyleBackColor = true;
            this.btnSimular.Click += new System.EventHandler(this.btnSimular_Click);
            // 
            // txtContenido
            // 
            this.txtContenido.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContenido.Location = new System.Drawing.Point(147, 83);
            this.txtContenido.Multiline = true;
            this.txtContenido.Name = "txtContenido";
            this.txtContenido.ReadOnly = true;
            this.txtContenido.Size = new System.Drawing.Size(272, 150);
            this.txtContenido.TabIndex = 4;
            // 
            // lblContenidoArchivo
            // 
            this.lblContenidoArchivo.AutoSize = true;
            this.lblContenidoArchivo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContenidoArchivo.Location = new System.Drawing.Point(158, 64);
            this.lblContenidoArchivo.Name = "lblContenidoArchivo";
            this.lblContenidoArchivo.Size = new System.Drawing.Size(133, 16);
            this.lblContenidoArchivo.TabIndex = 3;
            this.lblContenidoArchivo.Text = "Contenido del Archivo:";
            // 
            // lblResultadoT
            // 
            this.lblResultadoT.AutoSize = true;
            this.lblResultadoT.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadoT.Location = new System.Drawing.Point(32, 251);
            this.lblResultadoT.Name = "lblResultadoT";
            this.lblResultadoT.Size = new System.Drawing.Size(65, 16);
            this.lblResultadoT.TabIndex = 5;
            this.lblResultadoT.Text = "Resultado:";
            this.lblResultadoT.Visible = false;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(33, 274);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(21, 15);
            this.lblResultado.TabIndex = 6;
            this.lblResultado.Text = "xD";
            this.lblResultado.Visible = false;
            // 
            // txtResultado
            // 
            this.txtResultado.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultado.Location = new System.Drawing.Point(147, 248);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.Size = new System.Drawing.Size(272, 186);
            this.txtResultado.TabIndex = 7;
            this.txtResultado.Visible = false;
            // 
            // sbPrincipal
            // 
            this.sbPrincipal.Enabled = false;
            this.sbPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblTitulo});
            this.sbPrincipal.Location = new System.Drawing.Point(0, 454);
            this.sbPrincipal.Name = "sbPrincipal";
            this.sbPrincipal.Size = new System.Drawing.Size(541, 22);
            this.sbPrincipal.TabIndex = 8;
            // 
            // slblTitulo
            // 
            this.slblTitulo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slblTitulo.Name = "slblTitulo";
            this.slblTitulo.Size = new System.Drawing.Size(515, 17);
            this.slblTitulo.Text = "Realizado por: Rafael Arreola Villaseñor para la materia de Teoría de la Computac" +
    "ión.";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(446, 22);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(83, 21);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 476);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.sbPrincipal);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.lblResultadoT);
            this.Controls.Add(this.lblContenidoArchivo);
            this.Controls.Add(this.txtContenido);
            this.Controls.Add(this.btnSimular);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.txtRutaArchivo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulación de Autómata Finito Determinista";
            this.sbPrincipal.ResumeLayout(false);
            this.sbPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdArchivo;
        private System.Windows.Forms.TextBox txtRutaArchivo;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.Button btnSimular;
        private System.Windows.Forms.TextBox txtContenido;
        private System.Windows.Forms.Label lblContenidoArchivo;
        private System.Windows.Forms.Label lblResultadoT;
        public System.Windows.Forms.Label lblResultado;
        public System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.StatusStrip sbPrincipal;
        private System.Windows.Forms.ToolStripStatusLabel slblTitulo;
        private System.Windows.Forms.Button btnLimpiar;
    }
}

