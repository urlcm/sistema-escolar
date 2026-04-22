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
    public partial class CambiarCalificaciones : Form
    {
        private Controllers.CambiarCalificaciones cc;
        public CambiarCalificaciones()
        {
            InitializeComponent();
            this.cc = new Controllers.CambiarCalificaciones();
        }

        private void CambiarCalificaciones_Load(object sender, EventArgs e)
        {
            this.cc.ObtenerCiclos();
            this.cc.CargarCiclos(this.cboCiclos);
            this.cboCiclos.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cc.CargarListview(this.lstAlumnos);
            this.cc.CargarPropiedadesListview(this.lstCalificaciones);
        }

        private void cboCiclos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lstAlumnos.Clear();
            this.cc.CargarListview(this.lstAlumnos);
            this.cc.ObtenerAlumnos(this.cboCiclos.SelectedIndex);
            this.cc.CargarAlumnos(this.lstAlumnos);
        }

        private void lstAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pos = this.cc.PosicionSeleccionada(this.lstAlumnos);
            if (pos != -1)
            {
                this.lstCalificaciones.Clear();
                this.cc.CargarPropiedadesListview(this.lstCalificaciones);
                this.cc.ObtenerCalifiacion(pos, cboCiclos.SelectedIndex, this.lblCalificacionGeneral);
                this.cc.cargarCalificaciones(this.lstCalificaciones);
            }
        }

        private void lstCalificaciones_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.cc.PosicionSeleccionada(this.lstCalificaciones)!=-1)
            {
                this.cc.CambiarCalificacion(this.cc.PosicionSeleccionada(this.lstCalificaciones));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.cc.PosicionSeleccionada(lstAlumnos) != -1)
            {
                
            }
        }
    }
}
