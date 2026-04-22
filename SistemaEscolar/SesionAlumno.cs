using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEscolar
{
    public partial class SesionAlumno : Form
    {
        public Usuario user = null;
        private Inicio inicio;
        private Alumno alumno;
        private Grado_Grupo grado;
        public SesionAlumno()
        {
            InitializeComponent();
            //this.FormClosing += MainForm_FormClosing;
        }

        public SesionAlumno(Usuario usuario) :this()
        {
            this.user = usuario;
            ObtenerAlumno();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            inicio = new Inicio();
            inicio.Show();
            this.Close();
        }

        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if(this.activeForm != null)
            {
                this.activeForm.Close();
            }
            this.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlOpcion.Controls.Add(childForm);
            pnlOpcion.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void bntCalificaciones_Click(object sender, EventArgs e)
        {
            openChildForm(new Calificaciones());
        }

        private void btnActividades_Click(object sender, EventArgs e)
        {
            openChildForm(new ReporteActividades(alumno));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Itera sobre todos los formularios abiertos
            
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                var typeInstance = form.GetType();
                // Cierra los formularios ocultos
                if (form != this || (typeInstance != inicio.GetType()) )
                {
                    form.Close();
                }
            }
        }

        public void MostarNombre()
        {
            this.lblNombre.Text = user.nombre + " " + this.user.apellido;
        }

        private void SesionAlumno_Load(object sender, EventArgs e)
        {
            ObtenerAlumno();
            MostarNombre();
            mostrarGrado();
        }

        private void ObtenerAlumno()
        {
            int idC = Controllers.AltaGrupo.ObtenerCicloEscolarActual().idCicloEscolar;
            using (Models.vhmexEntities db = new vhmexEntities())
            {
                this.alumno = db.Alumno
                    .Include(u => u.Usuario)
                    .Where(id => id.idUsuario == user.idUsuario)
                    .FirstOrDefault();

                this.grado = db.Grado_Grupo
                    .Include(g => g.Grado)
                    .Include(gr => gr.Grupo)
                    .Where(cl => cl.CicloEscolarGrupo
                        .Any(cl2 => cl2.idCicloEscolar == idC) && cl.AlumnoGrupo.Any(id => id.idAlumno == alumno.idAlumno)).FirstOrDefault();

            }
        }

        public void mostrarGrado()
        {
            if (this.grado != null)
                lblGrado.Text = this.grado.Grado.idGrado + " " + this.grado.Grupo.Grupo1;
            else
                lblGrado.Text = "Sin Asignar";
        }

        private void btnActividad_Click(object sender, EventArgs e)
        {
            openChildForm(new TareasActividadesAlumnos(alumno.idAlumno));
        }
    }
}
