namespace windLaboratorio001
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sPuerto = new System.IO.Ports.SerialPort(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHora = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.porcentajeActual = new System.Windows.Forms.Label();
            this.BarraProgreso = new System.Windows.Forms.ProgressBar();
            this.btnEnviarArchivo = new System.Windows.Forms.Button();
            this.txtNombreArchivoCreado = new System.Windows.Forms.TextBox();
            this.btnInfoDirectorioRecibir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_InfoArchivoEnviar = new System.Windows.Forms.Button();
            this.txtRutaRecibida = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreArchivoEnviar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.bttEnvio = new System.Windows.Forms.Button();
            this.hora = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(90)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblHora);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 17);
            this.panel1.TabIndex = 0;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.SystemColors.Window;
            this.lblHora.Location = new System.Drawing.Point(545, 2);
            this.lblHora.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(22, 13);
            this.lblHora.TabIndex = 3;
            this.lblHora.Text = "     ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(90)))));
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 17);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 396);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(232, 392);
            this.panel4.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(48, 297);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 34);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(107, 297);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 32);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(160, 297);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 37);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(73, 226);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bryan Amaya";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(53, 66);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 131);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(50)))));
            this.panel5.Controls.Add(this.porcentajeActual);
            this.panel5.Controls.Add(this.BarraProgreso);
            this.panel5.Controls.Add(this.btnEnviarArchivo);
            this.panel5.Controls.Add(this.txtNombreArchivoCreado);
            this.panel5.Controls.Add(this.btnInfoDirectorioRecibir);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.btn_InfoArchivoEnviar);
            this.panel5.Controls.Add(this.txtRutaRecibida);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.txtNombreArchivoEnviar);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txtChat);
            this.panel5.Controls.Add(this.txtMensaje);
            this.panel5.Controls.Add(this.bttEnvio);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(232, 17);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(707, 396);
            this.panel5.TabIndex = 2;
            // 
            // porcentajeActual
            // 
            this.porcentajeActual.AutoSize = true;
            this.porcentajeActual.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.porcentajeActual.Location = new System.Drawing.Point(314, 256);
            this.porcentajeActual.Name = "porcentajeActual";
            this.porcentajeActual.Size = new System.Drawing.Size(44, 13);
            this.porcentajeActual.TabIndex = 26;
            this.porcentajeActual.Text = "Avance";
            // 
            // BarraProgreso
            // 
            this.BarraProgreso.Location = new System.Drawing.Point(310, 281);
            this.BarraProgreso.Name = "BarraProgreso";
            this.BarraProgreso.Size = new System.Drawing.Size(340, 23);
            this.BarraProgreso.TabIndex = 25;
            // 
            // btnEnviarArchivo
            // 
            this.btnEnviarArchivo.Location = new System.Drawing.Point(444, 241);
            this.btnEnviarArchivo.Name = "btnEnviarArchivo";
            this.btnEnviarArchivo.Size = new System.Drawing.Size(75, 23);
            this.btnEnviarArchivo.TabIndex = 24;
            this.btnEnviarArchivo.Text = "Enviar Archivo";
            this.btnEnviarArchivo.UseVisualStyleBackColor = true;
            this.btnEnviarArchivo.Click += new System.EventHandler(this.btnEnviarArchivo_Click_2);
            // 
            // txtNombreArchivoCreado
            // 
            this.txtNombreArchivoCreado.Location = new System.Drawing.Point(430, 179);
            this.txtNombreArchivoCreado.Name = "txtNombreArchivoCreado";
            this.txtNombreArchivoCreado.Size = new System.Drawing.Size(102, 20);
            this.txtNombreArchivoCreado.TabIndex = 23;
            // 
            // btnInfoDirectorioRecibir
            // 
            this.btnInfoDirectorioRecibir.Location = new System.Drawing.Point(575, 175);
            this.btnInfoDirectorioRecibir.Name = "btnInfoDirectorioRecibir";
            this.btnInfoDirectorioRecibir.Size = new System.Drawing.Size(75, 23);
            this.btnInfoDirectorioRecibir.TabIndex = 22;
            this.btnInfoDirectorioRecibir.Text = "Seleccionar";
            this.btnInfoDirectorioRecibir.UseVisualStyleBackColor = true;
            this.btnInfoDirectorioRecibir.Click += new System.EventHandler(this.btnInfoDirectorioRecibir_Click_2);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(316, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Archivo Nuevo:";
            // 
            // btn_InfoArchivoEnviar
            // 
            this.btn_InfoArchivoEnviar.Location = new System.Drawing.Point(575, 75);
            this.btn_InfoArchivoEnviar.Name = "btn_InfoArchivoEnviar";
            this.btn_InfoArchivoEnviar.Size = new System.Drawing.Size(75, 23);
            this.btn_InfoArchivoEnviar.TabIndex = 20;
            this.btn_InfoArchivoEnviar.Text = "Seleccionar";
            this.btn_InfoArchivoEnviar.UseVisualStyleBackColor = true;
            this.btn_InfoArchivoEnviar.Click += new System.EventHandler(this.btn_InfoArchivoEnviar_Click_1);
            // 
            // txtRutaRecibida
            // 
            this.txtRutaRecibida.Location = new System.Drawing.Point(430, 127);
            this.txtRutaRecibida.Name = "txtRutaRecibida";
            this.txtRutaRecibida.Size = new System.Drawing.Size(222, 20);
            this.txtRutaRecibida.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(316, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Directorio:";
            // 
            // txtNombreArchivoEnviar
            // 
            this.txtNombreArchivoEnviar.Location = new System.Drawing.Point(430, 46);
            this.txtNombreArchivoEnviar.Name = "txtNombreArchivoEnviar";
            this.txtNombreArchivoEnviar.Size = new System.Drawing.Size(222, 20);
            this.txtNombreArchivoEnviar.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(316, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Archivo:";
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(32, 27);
            this.txtChat.Margin = new System.Windows.Forms.Padding(2);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(229, 271);
            this.txtChat.TabIndex = 2;
            // 
            // txtMensaje
            // 
            this.txtMensaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.txtMensaje.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.Location = new System.Drawing.Point(32, 324);
            this.txtMensaje.Margin = new System.Windows.Forms.Padding(2);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(230, 47);
            this.txtMensaje.TabIndex = 1;
            // 
            // bttEnvio
            // 
            this.bttEnvio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(50)))));
            this.bttEnvio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bttEnvio.FlatAppearance.BorderSize = 0;
            this.bttEnvio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttEnvio.ForeColor = System.Drawing.Color.Transparent;
            this.bttEnvio.Image = ((System.Drawing.Image)(resources.GetObject("bttEnvio.Image")));
            this.bttEnvio.Location = new System.Drawing.Point(272, 324);
            this.bttEnvio.Margin = new System.Windows.Forms.Padding(0);
            this.bttEnvio.Name = "bttEnvio";
            this.bttEnvio.Size = new System.Drawing.Size(52, 45);
            this.bttEnvio.TabIndex = 0;
            this.bttEnvio.UseVisualStyleBackColor = false;
            this.bttEnvio.Click += new System.EventHandler(this.button1_Click);
            // 
            // hora
            // 
            this.hora.Enabled = true;
            this.hora.Tick += new System.EventHandler(this.hora_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 413);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort sPuerto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bttEnvio;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer hora;
        private System.Windows.Forms.Label porcentajeActual;
        private System.Windows.Forms.ProgressBar BarraProgreso;
        private System.Windows.Forms.Button btnEnviarArchivo;
        private System.Windows.Forms.TextBox txtNombreArchivoCreado;
        private System.Windows.Forms.Button btnInfoDirectorioRecibir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_InfoArchivoEnviar;
        private System.Windows.Forms.TextBox txtRutaRecibida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombreArchivoEnviar;
        private System.Windows.Forms.Label label2;
    }
}

