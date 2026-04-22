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
    public partial class SesionMaestro : Form
    {
        private Usuario user { get; set; }
        private Form activeForm = null;
        private Docente Docente { get; set; }
        public SesionMaestro()
        {
            InitializeComponent();
        }

        public SesionMaestro(Usuario usuario) : this()
        {
            this.user = usuario;
            ObtenerMaestro();
        }

        private void openChildForm(Form childForm)
        {
            if (this.activeForm != null)
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

        private void SesionMaestro_Load_1(object sender, EventArgs e)
        {
            this.lblNombre.Text = user.nombre + " " + user.apellido;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Inicio().Show();
            this.Close();
        }

        private void ObtenerMaestro()
        {
            int idC = Controllers.AltaGrupo.ObtenerCicloEscolarActual().idCicloEscolar;
            using (Models.vhmexEntities db = new vhmexEntities())
            {
                this.Docente = db.Docente.Where(u => u.idUsuario == user.idUsuario).FirstOrDefault();
            }
        }

        private void btnActividadTarea_Click(object sender, EventArgs e)
        {
            openChildForm(new TareasActividades(Docente.idDocente));
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            openChildForm(new Asistencia(Docente));
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            openChildForm(new CalificarActividades(Docente));
        }

        private void SesionMaestro_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Itera sobre todos los formularios abiertos
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                // Cierra los formularios ocultos
                if (form != this )
                {
                    form.Close();
                }
            }
        }
    }
}
