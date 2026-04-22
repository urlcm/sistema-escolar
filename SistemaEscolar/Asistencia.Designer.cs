namespace SistemaEscolar
{
    partial class Asistencia
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
            this.lstAsistencia = new System.Windows.Forms.ListView();
            this.cboGrupos = new System.Windows.Forms.ComboBox();
            this.btnAsistencia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grupo";
            // 
            // lstAsistencia
            // 
            this.lstAsistencia.HideSelection = false;
            this.lstAsistencia.Location = new System.Drawing.Point(277, 59);
            this.lstAsistencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstAsistencia.Name = "lstAsistencia";
            this.lstAsistencia.Size = new System.Drawing.Size(541, 278);
            this.lstAsistencia.TabIndex = 2;
            this.lstAsistencia.UseCompatibleStateImageBehavior = false;
            // 
            // cboGrupos
            // 
            this.cboGrupos.FormattingEnabled = true;
            this.cboGrupos.Location = new System.Drawing.Point(68, 177);
            this.cboGrupos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboGrupos.Name = "cboGrupos";
            this.cboGrupos.Size = new System.Drawing.Size(165, 24);
            this.cboGrupos.TabIndex = 3;
            this.cboGrupos.SelectedIndexChanged += new System.EventHandler(this.cboGrupos_SelectedIndexChanged);
            // 
            // btnAsistencia
            // 
            this.btnAsistencia.Location = new System.Drawing.Point(68, 249);
            this.btnAsistencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAsistencia.Name = "btnAsistencia";
            this.btnAsistencia.Size = new System.Drawing.Size(165, 59);
            this.btnAsistencia.TabIndex = 4;
            this.btnAsistencia.Text = "Confirmar asistencia";
            this.btnAsistencia.UseVisualStyleBackColor = true;
            this.btnAsistencia.Click += new System.EventHandler(this.btnAsistencia_Click);
            // 
            // Asistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 400);
            this.Controls.Add(this.btnAsistencia);
            this.Controls.Add(this.cboGrupos);
            this.Controls.Add(this.lstAsistencia);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Asistencia";
            this.Text = "Asistencia";
            this.Load += new System.EventHandler(this.Asistencia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstAsistencia;
        private System.Windows.Forms.ComboBox cboGrupos;
        private System.Windows.Forms.Button btnAsistencia;
    }
}