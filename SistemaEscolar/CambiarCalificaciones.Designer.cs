namespace SistemaEscolar
{
    partial class CambiarCalificaciones
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
            this.cboCiclos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstCalificaciones = new System.Windows.Forms.ListView();
            this.lblCalificacionGeneral = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstAlumnos
            // 
            this.lstAlumnos.HideSelection = false;
            this.lstAlumnos.Location = new System.Drawing.Point(32, 69);
            this.lstAlumnos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstAlumnos.Name = "lstAlumnos";
            this.lstAlumnos.Size = new System.Drawing.Size(463, 457);
            this.lstAlumnos.TabIndex = 0;
            this.lstAlumnos.UseCompatibleStateImageBehavior = false;
            this.lstAlumnos.SelectedIndexChanged += new System.EventHandler(this.lstAlumnos_SelectedIndexChanged);
            // 
            // cboCiclos
            // 
            this.cboCiclos.FormattingEnabled = true;
            this.cboCiclos.Location = new System.Drawing.Point(420, 36);
            this.cboCiclos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboCiclos.Name = "cboCiclos";
            this.cboCiclos.Size = new System.Drawing.Size(207, 24);
            this.cboCiclos.TabIndex = 1;
            this.cboCiclos.SelectedIndexChanged += new System.EventHandler(this.cboCiclos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(472, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ciclo Escolar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Alumnos";
            // 
            // lstCalificaciones
            // 
            this.lstCalificaciones.HideSelection = false;
            this.lstCalificaciones.Location = new System.Drawing.Point(579, 69);
            this.lstCalificaciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstCalificaciones.Name = "lstCalificaciones";
            this.lstCalificaciones.Size = new System.Drawing.Size(443, 213);
            this.lstCalificaciones.TabIndex = 4;
            this.lstCalificaciones.UseCompatibleStateImageBehavior = false;
            this.lstCalificaciones.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCalificaciones_MouseDoubleClick);
            // 
            // lblCalificacionGeneral
            // 
            this.lblCalificacionGeneral.AutoSize = true;
            this.lblCalificacionGeneral.Location = new System.Drawing.Point(703, 318);
            this.lblCalificacionGeneral.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalificacionGeneral.Name = "lblCalificacionGeneral";
            this.lblCalificacionGeneral.Size = new System.Drawing.Size(44, 16);
            this.lblCalificacionGeneral.TabIndex = 5;
            this.lblCalificacionGeneral.Text = "label3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(725, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 48);
            this.button1.TabIndex = 6;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CambiarCalificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCalificacionGeneral);
            this.Controls.Add(this.lstCalificaciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCiclos);
            this.Controls.Add(this.lstAlumnos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CambiarCalificaciones";
            this.Text = "CambiarCalificaciones";
            this.Load += new System.EventHandler(this.CambiarCalificaciones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstAlumnos;
        private System.Windows.Forms.ComboBox cboCiclos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstCalificaciones;
        private System.Windows.Forms.Label lblCalificacionGeneral;
        private System.Windows.Forms.Button button1;
    }
}