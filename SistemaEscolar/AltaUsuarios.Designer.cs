namespace SistemaEscolar
{
    partial class AltaUsuarios
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cbAlumno = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.combNivel = new System.Windows.Forms.ComboBox();
            this.cbAdmin = new System.Windows.Forms.CheckBox();
            this.cbCoordinador = new System.Windows.Forms.CheckBox();
            this.cbDocente = new System.Windows.Forms.CheckBox();
            this.cbPadre = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Correo electronico";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contraseña";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(162, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(153, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(162, 94);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(153, 20);
            this.txtApellido.TabIndex = 5;
            // 
            // txtContra
            // 
            this.txtContra.Location = new System.Drawing.Point(162, 191);
            this.txtContra.Name = "txtContra";
            this.txtContra.Size = new System.Drawing.Size(153, 20);
            this.txtContra.TabIndex = 6;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(162, 141);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(153, 20);
            this.txtCorreo.TabIndex = 7;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(134, 313);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(106, 31);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar Usuario";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbAlumno
            // 
            this.cbAlumno.AutoSize = true;
            this.cbAlumno.Location = new System.Drawing.Point(16, 248);
            this.cbAlumno.Name = "cbAlumno";
            this.cbAlumno.Size = new System.Drawing.Size(61, 17);
            this.cbAlumno.TabIndex = 9;
            this.cbAlumno.Text = "Alumno";
            this.cbAlumno.UseVisualStyleBackColor = true;
            this.cbAlumno.CheckedChanged += new System.EventHandler(this.cbAlumno_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::SistemaEscolar.Properties.Resources.Panel_Login;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.combNivel);
            this.panel1.Controls.Add(this.cbAdmin);
            this.panel1.Controls.Add(this.cbCoordinador);
            this.panel1.Controls.Add(this.cbDocente);
            this.panel1.Controls.Add(this.cbPadre);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.cbAlumno);
            this.panel1.Controls.Add(this.txtCorreo);
            this.panel1.Controls.Add(this.txtContra);
            this.panel1.Controls.Add(this.txtApellido);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(43, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 365);
            this.panel1.TabIndex = 10;
            // 
            // combNivel
            // 
            this.combNivel.FormattingEnabled = true;
            this.combNivel.Items.AddRange(new object[] {
            "kinder",
            "primaria",
            "secundaria",
            "preparatoria"});
            this.combNivel.Location = new System.Drawing.Point(162, 275);
            this.combNivel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.combNivel.Name = "combNivel";
            this.combNivel.Size = new System.Drawing.Size(153, 21);
            this.combNivel.TabIndex = 14;
            // 
            // cbAdmin
            // 
            this.cbAdmin.AutoSize = true;
            this.cbAdmin.Location = new System.Drawing.Point(289, 248);
            this.cbAdmin.Name = "cbAdmin";
            this.cbAdmin.Size = new System.Drawing.Size(55, 17);
            this.cbAdmin.TabIndex = 13;
            this.cbAdmin.Text = "Admin";
            this.cbAdmin.UseVisualStyleBackColor = true;
            // 
            // cbCoordinador
            // 
            this.cbCoordinador.AutoSize = true;
            this.cbCoordinador.Location = new System.Drawing.Point(208, 248);
            this.cbCoordinador.Name = "cbCoordinador";
            this.cbCoordinador.Size = new System.Drawing.Size(83, 17);
            this.cbCoordinador.TabIndex = 12;
            this.cbCoordinador.Text = "Coordinador";
            this.cbCoordinador.UseVisualStyleBackColor = true;
            // 
            // cbDocente
            // 
            this.cbDocente.AutoSize = true;
            this.cbDocente.Location = new System.Drawing.Point(142, 248);
            this.cbDocente.Name = "cbDocente";
            this.cbDocente.Size = new System.Drawing.Size(67, 17);
            this.cbDocente.TabIndex = 11;
            this.cbDocente.Text = "Docente";
            this.cbDocente.UseVisualStyleBackColor = true;
            // 
            // cbPadre
            // 
            this.cbPadre.AutoSize = true;
            this.cbPadre.Location = new System.Drawing.Point(78, 248);
            this.cbPadre.Name = "cbPadre";
            this.cbPadre.Size = new System.Drawing.Size(54, 17);
            this.cbPadre.TabIndex = 10;
            this.cbPadre.Text = "Padre";
            this.cbPadre.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Nivel";
            // 
            // AltaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(446, 384);
            this.Controls.Add(this.panel1);
            this.Name = "AltaUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AltaUsuarios";
            this.Load += new System.EventHandler(this.AltaUsuarios_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.CheckBox cbAlumno;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbAdmin;
        private System.Windows.Forms.CheckBox cbCoordinador;
        private System.Windows.Forms.CheckBox cbDocente;
        private System.Windows.Forms.CheckBox cbPadre;
        private System.Windows.Forms.ComboBox combNivel;
        private System.Windows.Forms.Label label5;
    }
}