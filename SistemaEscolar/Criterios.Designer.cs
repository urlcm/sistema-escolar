namespace SistemaEscolar
{
    partial class Criterios
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtActividades = new System.Windows.Forms.TextBox();
            this.txtTareas = new System.Windows.Forms.TextBox();
            this.txtExamen = new System.Windows.Forms.TextBox();
            this.txtAsistencia = new System.Windows.Forms.TextBox();
            this.cboMaterias = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Asignar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Asignar Criterios";
            // 
            // txtActividades
            // 
            this.txtActividades.Location = new System.Drawing.Point(189, 158);
            this.txtActividades.Name = "txtActividades";
            this.txtActividades.Size = new System.Drawing.Size(121, 20);
            this.txtActividades.TabIndex = 2;
            // 
            // txtTareas
            // 
            this.txtTareas.Location = new System.Drawing.Point(189, 322);
            this.txtTareas.Name = "txtTareas";
            this.txtTareas.Size = new System.Drawing.Size(121, 20);
            this.txtTareas.TabIndex = 3;
            // 
            // txtExamen
            // 
            this.txtExamen.Location = new System.Drawing.Point(189, 266);
            this.txtExamen.Name = "txtExamen";
            this.txtExamen.Size = new System.Drawing.Size(121, 20);
            this.txtExamen.TabIndex = 4;
            // 
            // txtAsistencia
            // 
            this.txtAsistencia.Location = new System.Drawing.Point(189, 208);
            this.txtAsistencia.Name = "txtAsistencia";
            this.txtAsistencia.Size = new System.Drawing.Size(121, 20);
            this.txtAsistencia.TabIndex = 5;
            // 
            // cboMaterias
            // 
            this.cboMaterias.FormattingEnabled = true;
            this.cboMaterias.Location = new System.Drawing.Point(189, 100);
            this.cboMaterias.Name = "cboMaterias";
            this.cboMaterias.Size = new System.Drawing.Size(121, 21);
            this.cboMaterias.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Materia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Actividades";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Examen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Asistencia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tareas";
            // 
            // Criterios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 446);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboMaterias);
            this.Controls.Add(this.txtAsistencia);
            this.Controls.Add(this.txtExamen);
            this.Controls.Add(this.txtTareas);
            this.Controls.Add(this.txtActividades);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Criterios";
            this.Text = "Criterios";
            this.Load += new System.EventHandler(this.Criterios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtActividades;
        private System.Windows.Forms.TextBox txtTareas;
        private System.Windows.Forms.TextBox txtExamen;
        private System.Windows.Forms.TextBox txtAsistencia;
        private System.Windows.Forms.ComboBox cboMaterias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}