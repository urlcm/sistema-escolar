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
    public partial class DocenteGrupos : Form
    {
        private Controllers.DocentesGrupos DocentesGrupos;
        public DocenteGrupos()
        {
            InitializeComponent();
            DocentesGrupos = new Controllers.DocentesGrupos();
        }

        private void GruposMaterias_Load(object sender, EventArgs e)
        {
            this.cboNiveles.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboGrupos.DropDownStyle = ComboBoxStyle.DropDownList;
            //if (Nivel != null) 
            //{
                this.DocentesGrupos.ObtenerNiveles();
                this.DocentesGrupos.CargarNiveles(this.cboNiveles);
            //}
            //else
            //{
            //    gruposMaterias.CargarNivel(this.cboNiveles,Nivel);
            //    gruposMaterias.ObtenerGrupos();
            //    this.cboNiveles.Enabled = false;
            //}
            //gruposMaterias.ObtenerGrupos();
            //gruposMaterias.CargarGrupos(this.cboGrupos, cboNiveles.Text);
            this.DocentesGrupos.CargarListview(this.listMaterias);
            //gruposMaterias.ObtenerMaterias();
            //DocentesGrupos.CargarLstMaterias(this.listMaterias);
        }

        private void cboNiveles_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboGrupos.Items.Clear();
            this.DocentesGrupos.ObtenerGrupos(this.cboNiveles.Text);
            this.DocentesGrupos.CargarGrupos(this.cboGrupos);
        }

        private void btnAsignar_Click_1(object sender, EventArgs e)
        {
            this.DocentesGrupos.AsignarMaterias(this.listMaterias,this.cboGrupos.SelectedIndex);
            this.listMaterias.Clear();
            this.DocentesGrupos.ObtenerMaestrosMaterias(this.cboGrupos.SelectedIndex);
            this.DocentesGrupos.CargarListview(this.listMaterias);
            this.DocentesGrupos.CargarLstMaterias(this.listMaterias);
        }

        private void cboGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listMaterias.Clear();
            this.DocentesGrupos.ObtenerMaestrosMaterias(this.cboGrupos.SelectedIndex);
            this.DocentesGrupos.CargarListview(this.listMaterias);
            this.DocentesGrupos.CargarLstMaterias(this.listMaterias);
        }
    }
}
