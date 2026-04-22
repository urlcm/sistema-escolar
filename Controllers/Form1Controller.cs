using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Controllers
{
    public class Form1Controller
    {
        public Usuario Usuario { get; set; }
        public UsuarioRol[] usuarioRols;
        public int ComprobarExistencia(string correo, string contra)
        {
            using (Models.vhmexEntities db = new Models.vhmexEntities())
            {
                Usuario usuario = db.Usuario.FirstOrDefault(u => u.correo == correo);
                if (usuario!=null && usuario.password == contra) 
                {
                    this.Usuario = usuario;
                    usuarioRols = db.UsuarioRol.Where(r=>r.idUsuario == usuario.idUsuario).ToArray();
                    return usuarioRols.Length;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void IniciarSesion()
        {

        }
    }
}
