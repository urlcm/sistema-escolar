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
    public partial class Asistencia : Form
    {
        Usuario usuario;
        Controllers.Asistencia asistencia;
        Docente docente;
        public Asistencia(Docente doc)
        {
            InitializeComponent();
            this.docente = doc;
            this.asistencia = new Controllers.Asistencia();
        }

        private void Asistencia_Load(object sender, EventArgs e)
        {
            this.asistencia.ObtenerGrupos(docente.idDocente);
            this.asistencia.CargarGrupos(this.cboGrupos);
            this.asistencia.CargarListview(this.lstAsistencia);
        }

        private void cboGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.asistencia.ObtenerAlumnos(docente.idDocente, this.cboGrupos.SelectedIndex);
            this.lstAsistencia.Clear();
            this.asistencia.CargarListview(this.lstAsistencia);
            this.asistencia.CargarAlumnos(this.lstAsistencia);

        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            this.asistencia.ConfirmarAsistencia(lstAsistencia, this.cboGrupos.SelectedIndex);

        }
    }
}
