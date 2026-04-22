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
    public partial class Roles : Form
    {
        Usuario user { get; set; }
        UsuarioRol[] usuarioRols;
        public Roles()
        {
            InitializeComponent();
        }
        public Roles(UsuarioRol[] users, Usuario user) : this()
        {
            this.usuarioRols = users;
            this.user = user;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            new SesionAdmin(user).Show();
        }

        private void btnCoordinador_Click(object sender, EventArgs e)
        {
            new SesionCoordinador().Show();
        }

        private void btnMaestro_Click(object sender, EventArgs e)
        {
            new SesionMaestro(user).Show();
        }

        private void btnPadre_Click(object sender, EventArgs e)
        {
            new SesionPadre(user).Show();
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            Controllers.Roles roles = new Controllers.Roles();
            roles.HacerInvisibles(btnAdmin, btnCoordinador, btnMaestro, btnPadre);
            roles.comprobarRoles(usuarioRols, btnAdmin, btnCoordinador, btnMaestro, btnPadre);
        }
    }
}
