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
    public partial class TareasActividades : Form
    {
        Controllers.TareasActividades ta;
        int idDocente;
        public TareasActividades(int idDocente)
        {
            InitializeComponent();
            ta = new Controllers.TareasActividades();
            this.idDocente = idDocente;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pos = ta.PosicionSeleccionada(this.lstMaterias);
            int valor;
            if (pos != -1 && int.TryParse(txtValor.Text, out valor)) {
                ta.Asignar(txtNombre.Text, txtDescripcion.Text, valor ,idDocente, ta.PosicionSeleccionada(this.lstMaterias), cboTipo.SelectedIndex);
                txtDescripcion.Text = "";
                txtNombre.Text = "";
                txtValor.Text = "";
            }
            else
            {
                MessageBox.Show("Debe agregar un valor numerico","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void TareasActividades_Load(object sender, EventArgs e)
        {
            this.cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ta.ObtenerGrupos(idDocente);
            this.txtDescripcion.Enabled = false;
            this.txtNombre.Enabled = false;
            this.cboTipo.Enabled = false;
            this.txtValor.Enabled = false;
            this.btnAsignar.Enabled = false;
            this.cboTipo.Items.Add("Activdad");
            this.cboTipo.Items.Add("Tarea");
            this.cboTipo.Items.Add("Examen");

            this.ta.CargarListview(lstMaterias);
            this.ta.CargarGrupos(lstMaterias);
        }

        private void lstMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            txtNombre.Enabled = true;
            this.cboTipo.Enabled = true;
            this.txtValor.Enabled = true;
            this.btnAsignar.Enabled = true;
        }
    }
}
