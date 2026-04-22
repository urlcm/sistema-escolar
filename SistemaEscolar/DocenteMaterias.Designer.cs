namespace SistemaEscolar
{
    partial class DocenteMaterias
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
            this.lstMaestros = new System.Windows.Forms.ListView();
            this.lstMaterias = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMaestros
            // 
            this.lstMaestros.HideSelection = false;
            this.lstMaestros.Location = new System.Drawing.Point(33, 73);
            this.lstMaestros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstMaestros.Name = "lstMaestros";
            this.lstMaestros.Size = new System.Drawing.Size(319, 221);
            this.lstMaestros.TabIndex = 0;
            this.lstMaestros.UseCompatibleStateImageBehavior = false;
            // 
            // lstMaterias
            // 
            this.lstMaterias.HideSelection = false;
            this.lstMaterias.Location = new System.Drawing.Point(419, 73);
            this.lstMaterias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstMaterias.Name = "lstMaterias";
            this.lstMaterias.Size = new System.Drawing.Size(288, 221);
            this.lstMaterias.TabIndex = 1;
            this.lstMaterias.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Maestros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Materias";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(292, 316);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 46);
            this.button1.TabIndex = 4;
            this.button1.Text = "Asignar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::SistemaEscolar.Properties.Resources.Panel_Login;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lstMaterias);
            this.panel1.Controls.Add(this.lstMaestros);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 372);
            this.panel1.TabIndex = 5;
            // 
            // DocenteMaterias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(756, 393);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DocenteMaterias";
            this.Text = "DocenteMaterias";
            this.Load += new System.EventHandler(this.DocenteMaterias_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstMaestros;
        private System.Windows.Forms.ListView lstMaterias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}