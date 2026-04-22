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
    public partial class PadresAlumnos : Form
    {
        public Controllers.PadresAlumnos padreAlumno;
        public PadresAlumnos()
        {
            InitializeComponent();
            padreAlumno = new Controllers.PadresAlumnos();
        }

        private void PadresAlumnos_Load(object sender, EventArgs e)
        {
            padreAlumno.PrepararListviews(lstPadres, lstAlumnos);
            padreAlumno.ObtenerAlumnos();
            padreAlumno.ObtenerPadres();
            padreAlumno.CargarPadres(lstPadres);
            padreAlumno.CargarAlumnos(lstAlumnos);
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            padreAlumno.AsignarPadres(lstPadres, lstAlumnos);
            padreAlumno.ObtenerAlumnos();
            padreAlumno.RecargarAlumnos(lstAlumnos);
            padreAlumno.CargarAlumnos(lstAlumnos);

        }
    }
}
