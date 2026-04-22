using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEscolar
{
    public partial class AlumnosGrupos : Form
    {
        private Controllers.AlumnosGrupos alumnosGrupos;
        private int idNivelCoordinador;
        
        public AlumnosGrupos()
        {
            InitializeComponent();
            alumnosGrupos = new Controllers.AlumnosGrupos();
        }

        public AlumnosGrupos(int idUser) : this()
        {
            nivel Nivel;
            using (vhmexEntities db = new vhmexEntities())
            {
                UsuarioRol usuarioRol = db.UsuarioRol.Include(ur => ur.nivel).Where(id => id.idUsuario == idUser && id.idRol == 2).FirstOrDefault();
                Nivel = db.nivel.Where(id => id.IdRolCoordinador == usuarioRol.idUsuarioRol).FirstOrDefault();
            }
            //Todavia
            idNivelCoordinador = Nivel.idNivel;
        }

        private void AlumnosGrupos_Load(object sender, EventArgs e)
        {
            comNiveles.DropDownStyle = ComboBoxStyle.DropDownList;
            comGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            alumnosGrupos.CargarListview(lstAlumnos);
            alumnosGrupos.CargarNiveles(comNiveles, alumnosGrupos.ObtenerNiveles());
        }

        private void btnAgregarAlumnos_Click(object sender, EventArgs e)
        {
            alumnosGrupos.agregarAlumnosAGrupos(lstAlumnos, comNiveles, comGrupo);
            lstAlumnos.Clear();
            alumnosGrupos.CargarListview(lstAlumnos);
            alumnosGrupos.ObtenerAlumnos(lstAlumnos, comNiveles.Text);
        }

        private void comNiveles_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAlumnos.Clear();
            comGrupo.Items.Clear();
            alumnosGrupos.CargarListview(lstAlumnos);
            alumnosGrupos.ObtenerAlumnos(lstAlumnos, comNiveles.Text);
            alumnosGrupos.ObtenerGrupos(comNiveles.Text);
            alumnosGrupos.CargarGrupos(comGrupo);
        }
    }
}
