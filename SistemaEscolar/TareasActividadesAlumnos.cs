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
    public partial class TareasActividadesAlumnos : Form
    {
        private Controllers.TareasActividadesAlumno TaA;
        private int idalumno;
        public TareasActividadesAlumnos()
        {
            InitializeComponent();
            TaA = new Controllers.TareasActividadesAlumno();
        }

        public TareasActividadesAlumnos(int alumno) : this()
        {
            this.idalumno = alumno;
        }

        private void TareasActividadesAlumnos_Load(object sender, EventArgs e)
        {
            TaA.prepararListView(this.lstActividades);
            TaA.ObtenerTareas(idalumno);
            TaA.CargarTareas(this.lstActividades);
        }

        private void lstActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaA.CargarAsignacion(this.lblTitulo, this.lblDesc, TaA.PosicionSeleccionada(lstActividades));
        }
    }
}
