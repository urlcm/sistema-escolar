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
    public partial class ModificarUsuarios : Form
    {
        private Controllers.ModificarUsuarios modUs;
        public ModificarUsuarios()
        {
            InitializeComponent();
            this.modUs = new Controllers.ModificarUsuarios();
        }

        private void ModificarUsuarios_Load(object sender, EventArgs e)
        {
            this.modUs.ObtenerUsuarios();
            this.modUs.PrepararUsuarios(this.lstUsuarios);
            this.modUs.mostrarUsuarios(this.lstUsuarios);
        }

        private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int posicion = this.modUs.PosicionSeleccionada(this.lstUsuarios);
            if (posicion != -1)
            {
                modUs.DatosTxt(this.txtNombre, this.txtApellido, this.txtCorreo, this.txtContra, posicion);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int posicion = this.modUs.PosicionSeleccionada(this.lstUsuarios);
            if (posicion != -1)
            {
                this.modUs.CambiarDatos(this.txtNombre.Text, this.txtApellido.Text, this.txtCorreo.Text, this.txtContra.Text, posicion);
                this.lstUsuarios.Clear();
                this.modUs.PrepararUsuarios(lstUsuarios);
                this.modUs.mostrarUsuarios(lstUsuarios);
            }
            else
            {
                MessageBox.Show("Seleccione un usuario");
            }
        }
    }
}
