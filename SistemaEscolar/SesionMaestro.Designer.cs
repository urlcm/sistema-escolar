namespace SistemaEscolar
{
    partial class SesionMaestro
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
            this.pnlMenuAlumno = new System.Windows.Forms.Panel();
            this.btnActividadTarea = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnAsistencia = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlOpcion = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlMenuAlumno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenuAlumno
            // 
            this.pnlMenuAlumno.Controls.Add(this.btnActividadTarea);
            this.pnlMenuAlumno.Controls.Add(this.lblNombre);
            this.pnlMenuAlumno.Controls.Add(this.label2);
            this.pnlMenuAlumno.Controls.Add(this.pictureBox3);
            this.pnlMenuAlumno.Controls.Add(this.btnLogout);
            this.pnlMenuAlumno.Controls.Add(this.btnReporte);
            this.pnlMenuAlumno.Controls.Add(this.btnAsistencia);
            this.pnlMenuAlumno.Location = new System.Drawing.Point(198, 0);
            this.pnlMenuAlumno.Name = "pnlMenuAlumno";
            this.pnlMenuAlumno.Size = new System.Drawing.Size(601, 126);
            this.pnlMenuAlumno.TabIndex = 7;
            // 
            // btnActividadTarea
            // 
            this.btnActividadTarea.ForeColor = System.Drawing.Color.IndianRed;
            this.btnActividadTarea.Location = new System.Drawing.Point(65, 91);
            this.btnActividadTarea.Name = "btnActividadTarea";
            this.btnActividadTarea.Size = new System.Drawing.Size(120, 29);
            this.btnActividadTarea.TabIndex = 8;
            this.btnActividadTarea.Text = "Actividades y Tareas";
            this.btnActividadTarea.UseVisualStyleBackColor = true;
            this.btnActividadTarea.Click += new System.EventHandler(this.btnActividadTarea_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.IndianRed;
            this.lblNombre.Location = new System.Drawing.Point(316, 12);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(61, 20);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "++++";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(230, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::SistemaEscolar.Properties.Resources.Usuario;
            this.pictureBox3.Location = new System.Drawing.Point(518, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(62, 70);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.ForeColor = System.Drawing.Color.IndianRed;
            this.btnLogout.Location = new System.Drawing.Point(504, 91);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(85, 29);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Cerrar Sesión";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.ForeColor = System.Drawing.Color.IndianRed;
            this.btnReporte.Location = new System.Drawing.Point(329, 91);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(118, 29);
            this.btnReporte.TabIndex = 1;
            this.btnReporte.Text = "Calificar actividades";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnAsistencia
            // 
            this.btnAsistencia.ForeColor = System.Drawing.Color.IndianRed;
            this.btnAsistencia.Location = new System.Drawing.Point(211, 91);
            this.btnAsistencia.Name = "btnAsistencia";
            this.btnAsistencia.Size = new System.Drawing.Size(93, 29);
            this.btnAsistencia.TabIndex = 0;
            this.btnAsistencia.Text = "Asistencia";
            this.btnAsistencia.UseVisualStyleBackColor = true;
            this.btnAsistencia.Click += new System.EventHandler(this.btnAsistencia_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 126);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::SistemaEscolar.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(11, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlOpcion
            // 
            this.pnlOpcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(239)))), ((int)(((byte)(210)))));
            this.pnlOpcion.Location = new System.Drawing.Point(67, 126);
            this.pnlOpcion.Name = "pnlOpcion";
            this.pnlOpcion.Size = new System.Drawing.Size(662, 325);
            this.pnlOpcion.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SistemaEscolar.Properties.Resources.Salon;
            this.pictureBox2.Location = new System.Drawing.Point(0, 126);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(799, 325);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // SesionMaestro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(799, 451);
            this.Controls.Add(this.pnlOpcion);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pnlMenuAlumno);
            this.Controls.Add(this.panel1);
            this.Name = "SesionMaestro";
            this.Text = "SesionMaestro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SesionMaestro_FormClosing);
            this.Load += new System.EventHandler(this.SesionMaestro_Load_1);
            this.pnlMenuAlumno.ResumeLayout(false);
            this.pnlMenuAlumno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenuAlumno;
        private System.Windows.Forms.Button btnActividadTarea;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnAsistencia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlOpcion;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}