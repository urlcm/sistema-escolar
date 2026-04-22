namespace SistemaEscolar
{
    partial class ReporteActividades
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCalificaciones = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(209, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Obten tu reporte de actividad";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SistemaEscolar.Properties.Resources.Microsoft_Excel_Logo_2013;
            this.pictureBox1.Location = new System.Drawing.Point(295, 193);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnCalificaciones
            // 
            this.btnCalificaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCalificaciones.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalificaciones.ForeColor = System.Drawing.Color.IndianRed;
            this.btnCalificaciones.Image = global::SistemaEscolar.Properties.Resources.fondoMejorado;
            this.btnCalificaciones.Location = new System.Drawing.Point(253, 142);
            this.btnCalificaciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCalificaciones.Name = "btnCalificaciones";
            this.btnCalificaciones.Padding = new System.Windows.Forms.Padding(133, 0, 0, 0);
            this.btnCalificaciones.Size = new System.Drawing.Size(335, 194);
            this.btnCalificaciones.TabIndex = 6;
            this.btnCalificaciones.Text = "Descarga aquí tu reporte de actividad";
            this.btnCalificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalificaciones.UseVisualStyleBackColor = true;
            this.btnCalificaciones.Click += new System.EventHandler(this.btnCalificaciones_Click);
            // 
            // ReporteActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(239)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(883, 400);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCalificaciones);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReporteActividades";
            this.Text = "ReporteActividades";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCalificaciones;
        private System.Windows.Forms.Label label1;
    }
}