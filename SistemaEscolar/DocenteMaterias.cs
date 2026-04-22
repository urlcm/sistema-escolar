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
    public partial class DocenteMaterias : Form
    {
        private Controllers.DocentesMaterias docentesMaterias;
        public DocenteMaterias()
        {
            InitializeComponent();
            docentesMaterias = new Controllers.DocentesMaterias();
        }

        private void DocenteMaterias_Load(object sender, EventArgs e)
        {
            docentesMaterias.CargarAparienciaLst(lstMaestros, lstMaterias);
            docentesMaterias.ObtenerMaterias();
            docentesMaterias.CargarLstMaterias(lstMaterias);
            docentesMaterias.ObtenerMaestros();
            docentesMaterias.CargarLstDocentes(lstMaestros);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            docentesMaterias.AsignarMaterias(lstMaestros, lstMaterias);
        }
    }
}
