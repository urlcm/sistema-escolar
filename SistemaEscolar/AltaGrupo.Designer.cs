namespace SistemaEscolar
{
    partial class AltaGrupo
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
            this.cboGrado = new System.Windows.Forms.ComboBox();
            this.cboGrupo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNivel = new System.Windows.Forms.ComboBox();
            this.btnAgregarGrupo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Grupo";
            // 
            // cboGrado
            // 
            this.cboGrado.FormattingEnabled = true;
            this.cboGrado.Location = new System.Drawing.Point(97, 48);
            this.cboGrado.Name = "cboGrado";
            this.cboGrado.Size = new System.Drawing.Size(121, 21);
            this.cboGrado.TabIndex = 2;
            // 
            // cboGrupo
            // 
            this.cboGrupo.FormattingEnabled = true;
            this.cboGrupo.Location = new System.Drawing.Point(97, 109);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(121, 21);
            this.cboGrupo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nivel";
            // 
            // cboNivel
            // 
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Location = new System.Drawing.Point(97, 168);
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Size = new System.Drawing.Size(121, 21);
            this.cboNivel.TabIndex = 5;
            // 
            // btnAgregarGrupo
            // 
            this.btnAgregarGrupo.Location = new System.Drawing.Point(97, 212);
            this.btnAgregarGrupo.Name = "btnAgregarGrupo";
            this.btnAgregarGrupo.Size = new System.Drawing.Size(104, 38);
            this.btnAgregarGrupo.TabIndex = 6;
            this.btnAgregarGrupo.Text = "Agregar";
            this.btnAgregarGrupo.UseVisualStyleBackColor = true;
            this.btnAgregarGrupo.Click += new System.EventHandler(this.btnAgregarGrupo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::SistemaEscolar.Properties.Resources.Panel_Login;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnAgregarGrupo);
            this.panel1.Controls.Add(this.cboNivel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboGrupo);
            this.panel1.Controls.Add(this.cboGrado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 291);
            this.panel1.TabIndex = 7;
            // 
            // AltaGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(305, 315);
            this.Controls.Add(this.panel1);
            this.Name = "AltaGrupo";
            this.Text = "AltaGrupo";
            this.Load += new System.EventHandler(this.AltaGrupo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboGrado;
        private System.Windows.Forms.ComboBox cboGrupo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNivel;
        private System.Windows.Forms.Button btnAgregarGrupo;
        private System.Windows.Forms.Panel panel1;
    }
}