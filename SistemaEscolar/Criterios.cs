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
    public partial class Criterios : Form
    {
        private Controllers.Criterios criterios;
        public Criterios()
        {
            InitializeComponent();
            criterios = new Controllers.Criterios();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(criterios.verificarCriterios(txtActividades.Text, txtAsistencia.Text, txtExamen.Text, txtTareas.Text))
            {
                this.criterios.AsignarCriterios(txtActividades, txtAsistencia, txtExamen, txtTareas, cboMaterias.SelectedIndex);
                this.criterios.ReiniciarCriterios(txtActividades, txtAsistencia, txtExamen, txtTareas);
                this.cboMaterias.Items.Clear();
                this.criterios.ObtenerMaterias();
                this.criterios.CargarMaterias(cboMaterias);
            }
            else
            {
                MessageBox.Show("Verifique que los criterios sean enteros y que la suma de estos sea igual a 100","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Criterios_Load(object sender, EventArgs e)
        {
            this.cboMaterias.DropDownStyle = ComboBoxStyle.DropDownList;
            this.criterios.ObtenerMaterias();
            this.criterios.CargarMaterias(cboMaterias);
        }
    }
}
