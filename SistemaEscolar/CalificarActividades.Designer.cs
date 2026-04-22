namespace SistemaEscolar
{
    partial class CalificarActividades
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
            this.lstTareasExamenActividades = new System.Windows.Forms.ListView();
            this.lstCalificar = new System.Windows.Forms.ListView();
            this.btnCalificar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstTareasExamenActividades
            // 
            this.lstTareasExamenActividades.HideSelection = false;
            this.lstTareasExamenActividades.Location = new System.Drawing.Point(12, 12);
            this.lstTareasExamenActividades.Name = "lstTareasExamenActividades";
            this.lstTareasExamenActividades.Size = new System.Drawing.Size(311, 253);
            this.lstTareasExamenActividades.TabIndex = 0;
            this.lstTareasExamenActividades.UseCompatibleStateImageBehavior = false;
            this.lstTareasExamenActividades.SelectedIndexChanged += new System.EventHandler(this.lstTareasExamenActividades_SelectedIndexChanged);
            // 
            // lstCalificar
            // 
            this.lstCalificar.HideSelection = false;
            this.lstCalificar.Location = new System.Drawing.Point(329, 12);
            this.lstCalificar.Name = "lstCalificar";
            this.lstCalificar.Size = new System.Drawing.Size(321, 253);
            this.lstCalificar.TabIndex = 1;
            this.lstCalificar.UseCompatibleStateImageBehavior = false;
//            this.lstCalificar.SelectedIndexChanged += new System.EventHandler(this.lstCalificar_SelectedIndexChanged);
            this.lstCalificar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCalificar_MouseDoubleClick);
            // 
            // btnCalificar
            // 
            this.btnCalificar.Location = new System.Drawing.Point(440, 284);
            this.btnCalificar.Name = "btnCalificar";
            this.btnCalificar.Size = new System.Drawing.Size(89, 29);
            this.btnCalificar.TabIndex = 2;
            this.btnCalificar.Text = "Calificar";
            this.btnCalificar.UseVisualStyleBackColor = true;
            this.btnCalificar.Click += new System.EventHandler(this.btnCalificar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Oprima el boton de \"Calificar\" para guardar las asignaciones evaluadas";
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(123, 284);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(119, 21);
            this.cboTipo.TabIndex = 4;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo de asignacion";
            // 
            // CalificarActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(239)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(662, 325);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalificar);
            this.Controls.Add(this.lstCalificar);
            this.Controls.Add(this.lstTareasExamenActividades);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CalificarActividades";
            this.Text = "CalificarActividades";
            this.Load += new System.EventHandler(this.CalificarActividades_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstTareasExamenActividades;
        private System.Windows.Forms.ListView lstCalificar;
        private System.Windows.Forms.Button btnCalificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label2;
    }
}