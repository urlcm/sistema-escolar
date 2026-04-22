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
    public partial class SesionPadre : Form
    {
        public Usuario usuario;
        private Controllers.SesionPadre sesionPadre;
        Controllers.SesionAlumno sa = new Controllers.SesionAlumno();
        public SesionPadre()
        {
            InitializeComponent();
            sesionPadre  = new Controllers.SesionPadre();
        }

        public SesionPadre(Usuario user) : this()
        {
            this.usuario = user;
        }

        private void SesionPadre_Load(object sender, EventArgs e)
        {
            this.lblNombre.Text = this.usuario.nombre + " " + this.usuario.apellido;
            this.sesionPadre.ObtenerPadre(this.usuario);
            this.sesionPadre.ObtenerHijos();
            this.sesionPadre.PreprararListView(this.lstHijos);
            this.sesionPadre.CargarHijosListview(this.lstHijos);

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new Inicio().Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int posicion = sa.PosicionSeleccionada(lstHijos);
            Alumno alumno = new Alumno();
            alumno.idAlumno = sesionPadre.Alumnos[posicion].idAlumno;
            alumno.Usuario = new Usuario();
            alumno.Usuario.nombre = sesionPadre.Alumnos[posicion].Alumno.Usuario.nombre;
            alumno.Usuario.apellido = sesionPadre.Alumnos[posicion].Alumno.Usuario.apellido;
            sa.GenerarExcel(alumno);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int posicion = sa.PosicionSeleccionada(lstHijos);
            Alumno alumno = new Alumno();
            alumno.idAlumno = sesionPadre.Alumnos[posicion].idAlumno;
            alumno.Usuario = new Usuario();
            alumno.Usuario.nombre = sesionPadre.Alumnos[posicion].Alumno.Usuario.nombre;
            alumno.Usuario.apellido = sesionPadre.Alumnos[posicion].Alumno.Usuario.apellido;
            sa.GenerarPDF(alumno);
        }
    }
}
