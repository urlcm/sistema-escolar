namespace SistemaEscolar
{
    partial class DocenteGrupos
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
            this.cboNiveles = new System.Windows.Forms.ComboBox();
            this.listMaterias = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboGrupos = new System.Windows.Forms.ComboBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboNiveles
            // 
            this.cboNiveles.FormattingEnabled = true;
            this.cboNiveles.Location = new System.Drawing.Point(111, 74);
            this.cboNiveles.Name = "cboNiveles";
            this.cboNiveles.Size = new System.Drawing.Size(122, 21);
            this.cboNiveles.TabIndex = 0;
            this.cboNiveles.SelectedIndexChanged += new System.EventHandler(this.cboNiveles_SelectedIndexChanged);
            // 
            // listMaterias
            // 
            this.listMaterias.HideSelection = false;
            this.listMaterias.Location = new System.Drawing.Point(278, 50);
            this.listMaterias.Name = "listMaterias";
            this.listMaterias.Size = new System.Drawing.Size(327, 219);
            this.listMaterias.TabIndex = 1;
            this.listMaterias.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nivel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Grupo";
            // 
            // cboGrupos
            // 
            this.cboGrupos.FormattingEnabled = true;
            this.cboGrupos.Location = new System.Drawing.Point(111, 151);
            this.cboGrupos.Name = "cboGrupos";
            this.cboGrupos.Size = new System.Drawing.Size(122, 21);
            this.cboGrupos.TabIndex = 3;
            this.cboGrupos.SelectedIndexChanged += new System.EventHandler(this.cboGrupos_SelectedIndexChanged);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(103, 235);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(117, 34);
            this.btnAsignar.TabIndex = 5;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click_1);
            // 
            // DocenteGrupos
            // 
            this.ClientSize = new System.Drawing.Size(633, 318);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboGrupos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listMaterias);
            this.Controls.Add(this.cboNiveles);
            this.Name = "DocenteGrupos";
            this.Text = "Docentes Grupos";
            this.Load += new System.EventHandler(this.GruposMaterias_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.ListView lstAlumnos;
        //private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.Label label2;
        //private System.Windows.Forms.ListView lstMaterias;
        //private System.Windows.Forms.ComboBox comNiveles;
        //private System.Windows.Forms.Label label3;
        //private System.Windows.Forms.Button btnAsignar;
        //private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboNiveles;
        private System.Windows.Forms.ListView listMaterias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboGrupos;
        private System.Windows.Forms.Button btnAsignar;
    }
}