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
    public partial class AltaUsuarios : Form
    {
        public AltaUsuarios()
        {
            InitializeComponent();
        }

        private void  button1_Click(object sender, EventArgs e)
        {
            //creo la instancia del controlador sesion
            Controllers.SesionAdmin sesion = new Controllers.SesionAdmin();

            //metodo parar verificar que los textbox esten marcados
            sesion.VerificarCheckBox(this.cbAlumno, this.cbPadre, this.cbDocente, this.cbCoordinador, this.cbAdmin);
            
            //metodo para dar de alta usuarios
            sesion.DarDeAlta(this.txtNombre.Text, this.txtApellido.Text, this.txtCorreo.Text, this.txtContra.Text, this.combNivel);

            //Regresa los valores a falso de los atributos de 
            sesion.ValorDefault(this.cbAlumno, this.cbPadre, this.cbDocente, this.cbCoordinador, this.cbAdmin);

            //Reinicia los textbox
            sesion.vaciarTxt(txtNombre, txtApellido, txtCorreo, txtContra);
        }

        //Al cargar el form se pondra estos valores por defecto
        private void AltaUsuarios_Load(object sender, EventArgs e)
        {
            this.combNivel.Text = "kinder";
            this.combNivel.Enabled = false;
            combNivel.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cbAlumno_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbAlumno.Checked)
            {
                combNivel.Enabled = true;
                this.cbAdmin.Enabled = false;
                this.cbPadre.Enabled = false;
                this.cbCoordinador.Enabled = false;
                this.cbDocente.Enabled = false;
            }
            else
            {
                combNivel.Enabled = false;
                this.cbAdmin.Enabled = true;
                this.cbPadre.Enabled = true;
                this.cbCoordinador.Enabled = true;
                this.cbDocente.Enabled = true;
            }
        }  
    }
}
