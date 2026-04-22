namespace SistemaEscolar
{
    partial class AlumnosGrupos
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
            this.lstAlumnos = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comGrupo = new System.Windows.Forms.ComboBox();
            this.btnAgregarAlumnos = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comNiveles = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstAlumnos
            // 
            this.lstAlumnos.HideSelection = false;
            this.lstAlumnos.Location = new System.Drawing.Point(25, 48);
            this.lstAlumnos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstAlumnos.Name = "lstAlumnos";
            this.lstAlumnos.Size = new System.Drawing.Size(481, 267);
            this.lstAlumnos.TabIndex = 0;
            this.lstAlumnos.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Alumnos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(607, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Agregar a:";
            // 
            // comGrupo
            // 
            this.comGrupo.FormattingEnabled = true;
            this.comGrupo.Location = new System.Drawing.Point(551, 164);
            this.comGrupo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comGrupo.Name = "comGrupo";
            this.comGrupo.Size = new System.Drawing.Size(192, 24);
            this.comGrupo.TabIndex = 3;
            // 
            // btnAgregarAlumnos
            // 
            this.btnAgregarAlumnos.Location = new System.Drawing.Point(568, 228);
            this.btnAgregarAlumnos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarAlumnos.Name = "btnAgregarAlumnos";
            this.btnAgregarAlumnos.Size = new System.Drawing.Size(155, 47);
            this.btnAgregarAlumnos.TabIndex = 4;
            this.btnAgregarAlumnos.Text = "Agregar al grupo";
            this.btnAgregarAlumnos.UseVisualStyleBackColor = true;
            this.btnAgregarAlumnos.Click += new System.EventHandler(this.btnAgregarAlumnos_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::SistemaEscolar.Properties.Resources.Panel_Login;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.comNiveles);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnAgregarAlumnos);
            this.panel1.Controls.Add(this.comGrupo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lstAlumnos);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 374);
            this.panel1.TabIndex = 5;
            // 
            // comNiveles
            // 
            this.comNiveles.FormattingEnabled = true;
            this.comNiveles.Location = new System.Drawing.Point(120, 330);
            this.comNiveles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comNiveles.Name = "comNiveles";
            this.comNiveles.Size = new System.Drawing.Size(192, 24);
            this.comNiveles.TabIndex = 6;
            this.comNiveles.SelectedIndexChanged += new System.EventHandler(this.comNiveles_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 334);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nivel";
            // 
            // AlumnosGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(800, 398);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AlumnosGrupos";
            this.Text = "AlumnosGrupos";
            this.Load += new System.EventHandler(this.AlumnosGrupos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstAlumnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comGrupo;
        private System.Windows.Forms.Button btnAgregarAlumnos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comNiveles;
        private System.Windows.Forms.Label label3;
    }
}