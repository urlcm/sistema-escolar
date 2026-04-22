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
    public partial class AltaMaterias : Form
    {
        public AltaMaterias()
        {
            InitializeComponent();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            Controllers.AltaMaterias altamaterias = new Controllers.AltaMaterias();
            altamaterias.AgregarMateria(txtNombreMateria.Text);
            altamaterias.vaciarTxt(txtNombreMateria);
        }
    }
}
