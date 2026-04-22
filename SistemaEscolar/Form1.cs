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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            //this.FormClosing += MainForm_FormClosing;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controllers.Form1Controller controller = new Controllers.Form1Controller();
            int numRoles = controller.ComprobarExistencia(txtCorreo.Text, txtContraseña.Text);
            if (numRoles == 1)
            {
                if (controller.usuarioRols[0].idRol == 1)
                {
                    new SesionAdmin(controller.Usuario).Show();
                    
                }
                else if (controller.usuarioRols[0].idRol == 2)
                {
                    new SesionCoordinador().Show();
                }
                else if (controller.usuarioRols[0].idRol == 3)
                {
                    new SesionMaestro(controller.Usuario).Show();
                }
                else if (controller.usuarioRols[0].idRol == 4)
                {
                    new SesionAlumno(controller.Usuario).Show();
                }
                else
                {
                    new SesionPadre(controller.Usuario).Show();
                }
                this.Close();
                this.Dispose();
            }
            else if (numRoles > 1)
            {
                new Roles(controller.usuarioRols, controller.Usuario).Show();
                this.Close();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Verifique que los datos sean correctos");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Ay, que mal, ni modo:(");
        }

        //private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    // Itera sobre todos los formularios abiertos
        //    foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
        //    {
        //        // Cierra los formularios ocultos
        //        if (form != this)
        //        {
        //            form.Close();
        //        }
        //    }
        //}
    }
}
