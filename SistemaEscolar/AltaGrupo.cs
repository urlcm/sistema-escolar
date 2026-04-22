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
    public partial class AltaGrupo : Form
    {
        private Controllers.AltaGrupo ag = new Controllers.AltaGrupo();
        public AltaGrupo()
        {
            InitializeComponent();
        }

        private void btnAgregarGrupo_Click(object sender, EventArgs e)
        {
            ag.AgregarGrupo(cboGrado, cboGrupo, cboNivel);
        }

        private void AltaGrupo_Load(object sender, EventArgs e)
        {
            ag.NoModificar(cboGrado, cboGrupo, cboNivel);
            ag.ObtenerDatos();
            ag.CargarGrados(cboGrado);
            ag.CargarGrupos(cboGrupo);
            ag.CargarNiveles(cboNivel);
        }
    }
}
