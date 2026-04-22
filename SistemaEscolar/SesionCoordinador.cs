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
    public partial class SesionCoordinador : Form
    {
        private Inicio inicio;
        public SesionCoordinador()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            inicio = new Inicio();
            inicio.Show();
            this.Close();
            this.Dispose();
        }

        private void btnAsignacion_Click(object sender, EventArgs e)
        {
            if (!panel4.Visible)
                panel4.Visible = true;
            else
                panel4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!pnlVer.Visible)
                pnlVer.Visible = true;
            else
                pnlVer.Visible = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Itera sobre todos los formularios abiertos

            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                var typeInstance = form.GetType();
                // Cierra los formularios ocultos
                if (form != this)
                {
                    form.Close();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AlumnosGrupos().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new DocenteMaterias().Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new DocenteGrupos().Show();
        }

        private void btnCriterios_Click(object sender, EventArgs e)
        {
            new Criterios().Show();
        }
    }
}
