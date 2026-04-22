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
    public partial class CalificarActividades : Form
    {
        private Docente docente;
        private Calificar calificar;
        public CalificarActividades(Docente Docente)
        {
            InitializeComponent();
            this.docente = Docente;
            this.calificar = new Calificar();
        }

        private void CalificarActividades_Load(object sender, EventArgs e)
        {
            this.calificar.prepararLstAsignacion(lstTareasExamenActividades);
            this.calificar.prepararLstAsignacionesAlumnos(lstCalificar);
            this.cboTipo.Items.Add("Actividades");
            this.cboTipo.Items.Add("Examenes");
            this.cboTipo.Items.Add("Tareas");
            this.cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lstTareasExamenActividades.Clear();
            this.calificar.prepararLstAsignacion(lstTareasExamenActividades);
            this.calificar.obtenerAsignaciones(docente, cboTipo.SelectedIndex);
            this.calificar.mostrarAsigacion(lstTareasExamenActividades, cboTipo.SelectedIndex);
            this.lstCalificar.Clear();
            this.calificar.prepararLstAsignacionesAlumnos(lstCalificar);
            this.calificar.mySet = new HashSet<int>();
        }

        private void lstTareasExamenActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lstCalificar.Clear();
            this.calificar.prepararLstAsignacionesAlumnos(lstCalificar);
            this.calificar.ObtenerAlumnos(cboTipo.SelectedIndex, this.calificar.PosicionSeleccionada(lstTareasExamenActividades), lstCalificar);
        }

        private void btnCalificar_Click(object sender, EventArgs e)
        {
            if(this.calificar.mySet.Count>0)
            {
                if (this.cboTipo.SelectedIndex == 0)
                    this.calificar.GuardarCambiosActividades();
                else if (this.cboTipo.SelectedIndex == 1)
                    this.calificar.GuardarCambiosExamenes();
                else
                    this.calificar.GuardarCambiosTareas();
            }
            else
            {
                MessageBox.Show("No ha calificado ninguna asignación","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void lstCalificar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int pos = this.calificar.PosicionSeleccionada(lstCalificar);
            if (pos != -1)
            {
                this.calificar.modificarNota(pos,cboTipo.SelectedIndex);
                this.lstCalificar.Clear();
                this.calificar.prepararLstAsignacionesAlumnos(lstCalificar);
                this.calificar.mostrarAlumnos(lstCalificar,cboTipo.SelectedIndex);
            }
        }
    }
}
