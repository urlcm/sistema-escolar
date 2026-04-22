namespace SistemaEscolar
{
    partial class PadresAlumnos
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
            this.lstPadres = new System.Windows.Forms.ListView();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstAlumnos
            // 
            this.lstAlumnos.HideSelection = false;
            this.lstAlumnos.Location = new System.Drawing.Point(393, 82);
            this.lstAlumnos.Name = "lstAlumnos";
            this.lstAlumnos.Size = new System.Drawing.Size(395, 237);
            this.lstAlumnos.TabIndex = 0;
            this.lstAlumnos.UseCompatibleStateImageBehavior = false;
            // 
            // lstPadres
            // 
            this.lstPadres.HideSelection = false;
            this.lstPadres.Location = new System.Drawing.Point(12, 82);
            this.lstPadres.Name = "lstPadres";
            this.lstPadres.Size = new System.Drawing.Size(312, 236);
            this.lstPadres.TabIndex = 1;
            this.lstPadres.UseCompatibleStateImageBehavior = false;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(340, 365);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(115, 44);
            this.btnAsignar.TabIndex = 2;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Padres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Alumnos";
            // 
            // PadresAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.lstPadres);
            this.Controls.Add(this.lstAlumnos);
            this.Name = "PadresAlumnos";
            this.Text = "PadresAlumnos";
            this.Load += new System.EventHandler(this.PadresAlumnos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstAlumnos;
        private System.Windows.Forms.ListView lstPadres;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}