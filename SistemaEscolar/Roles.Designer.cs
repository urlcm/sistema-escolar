namespace SistemaEscolar
{
    partial class Roles
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnCoordinador = new System.Windows.Forms.Button();
            this.btnMaestro = new System.Windows.Forms.Button();
            this.btnPadre = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingresar como";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPadre);
            this.panel1.Controls.Add(this.btnMaestro);
            this.panel1.Controls.Add(this.btnCoordinador);
            this.panel1.Controls.Add(this.btnAdmin);
            this.panel1.Location = new System.Drawing.Point(121, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 96);
            this.panel1.TabIndex = 1;
            // 
            // btnAdmin
            // 
            this.btnAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdmin.Location = new System.Drawing.Point(0, 0);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(75, 96);
            this.btnAdmin.TabIndex = 0;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnCoordinador
            // 
            this.btnCoordinador.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCoordinador.Location = new System.Drawing.Point(75, 0);
            this.btnCoordinador.Name = "btnCoordinador";
            this.btnCoordinador.Size = new System.Drawing.Size(97, 96);
            this.btnCoordinador.TabIndex = 1;
            this.btnCoordinador.Text = "Coordinador";
            this.btnCoordinador.UseVisualStyleBackColor = true;
            this.btnCoordinador.Click += new System.EventHandler(this.btnCoordinador_Click);
            // 
            // btnMaestro
            // 
            this.btnMaestro.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMaestro.Location = new System.Drawing.Point(172, 0);
            this.btnMaestro.Name = "btnMaestro";
            this.btnMaestro.Size = new System.Drawing.Size(75, 96);
            this.btnMaestro.TabIndex = 2;
            this.btnMaestro.Text = "Maestro";
            this.btnMaestro.UseVisualStyleBackColor = true;
            this.btnMaestro.Click += new System.EventHandler(this.btnMaestro_Click);
            // 
            // btnPadre
            // 
            this.btnPadre.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPadre.Location = new System.Drawing.Point(247, 0);
            this.btnPadre.Name = "btnPadre";
            this.btnPadre.Size = new System.Drawing.Size(75, 96);
            this.btnPadre.TabIndex = 3;
            this.btnPadre.Text = "Padre";
            this.btnPadre.UseVisualStyleBackColor = true;
            this.btnPadre.Click += new System.EventHandler(this.btnPadre_Click);
            // 
            // Roles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 270);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Roles";
            this.Text = "Roles";
            this.Load += new System.EventHandler(this.Roles_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPadre;
        private System.Windows.Forms.Button btnMaestro;
        private System.Windows.Forms.Button btnCoordinador;
        private System.Windows.Forms.Button btnAdmin;
    }
}