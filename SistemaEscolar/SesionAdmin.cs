using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEscolar
{
    public partial class SesionAdmin : Form
    {
        Controllers.SesionAdmin sAdmin = new Controllers.SesionAdmin();
        
        public SesionAdmin()
        {
            InitializeComponent();
        }

        public SesionAdmin(Usuario usuario) : this()
        {
            this.sAdmin.usuario = usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!pnlAltas.Visible)
                pnlAltas.Visible = true;
            else
                pnlAltas.Visible = false;
        }

        private void SesionAdmin_Load(object sender, EventArgs e)
        {
            this.lblNombre.Text = this.sAdmin.usuario.nombre + " " + this.sAdmin.usuario.apellido;
            pnlAsignar.Visible = false;
            pnlAltas.Visible = false;
            this.pnlEditar.Visible = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Itera sobre todos los formularios abiertos
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                // Cierra los formularios ocultos
                if (form != this)
                {
                    form.Close();
                }
            }
        }

        private void btnCerraSesion_Click(object sender, EventArgs e)
        {
            new Inicio().Show();
            this.Close();
        }

        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            new AltaGrupo().Show();
        }

        private void btnCrearUsuarios_Click(object sender, EventArgs e)
        {
            new AltaUsuarios().Show();
        }

        private void btnCrearMaterias_Click(object sender, EventArgs e)
        {
            new AltaMaterias().Show();
        }

        private void pnlOpcion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (!pnlAsignar.Visible)
                pnlAsignar.Visible = true;
            else
                pnlAsignar.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new DocenteGrupos().Show();
        }

        private void btnDocMat_Click(object sender, EventArgs e)
        {
            new DocenteMaterias().Show(); 
        }

        private void btnAlumnosAGrupos_Click(object sender, EventArgs e)
        {
            new AlumnosGrupos().Show();
        }

        private void btnPadreAlumno_Click(object sender, EventArgs e)
        {
            new PadresAlumnos().Show();
        }

        private void btnCriterios_Click(object sender, EventArgs e)
        {
            new Criterios().Show();
        }

        private void btnTerminarCiclo_Click(object sender, EventArgs e)
        {
            sAdmin.AcabarCiclo();
        }

        private void btnCalificaciones_Click(object sender, EventArgs e)
        {
            if (!this.pnlEditar.Visible)
                this.pnlEditar.Visible = true;
            else
                this.pnlEditar.Visible = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            new ModificarUsuarios().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new CambiarCalificaciones().Show();
        }
    }
}
