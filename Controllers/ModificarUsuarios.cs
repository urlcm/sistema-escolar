using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controllers
{
    public class ModificarUsuarios
    {
        Usuario[] usuarios;
        public void ObtenerUsuarios()
        {
            using (vhmexEntities db = new vhmexEntities())
            {
                this.usuarios = db.Usuario.ToArray();
            }
        }

        public void mostrarUsuarios(ListView lstUsuarios)
        {
            foreach (var usuario in this.usuarios)
            {
                ListViewItem item = new ListViewItem
                    (
                        new string[]{ usuario.idUsuario.ToString(), usuario.nombre +" "+usuario.apellido, usuario.correo}
                    );
                lstUsuarios.Items.Add(item);
            }
        }

        public void PrepararUsuarios(ListView lstUsuarios)
        {
            lstUsuarios.Columns.Add("ID Usuario", 100);
            lstUsuarios.Columns.Add("Nombre completo", 150);
            lstUsuarios.Columns.Add("Correo electronico", 100);

            lstUsuarios.View = View.Details;
            lstUsuarios.FullRowSelect = true;
            lstUsuarios.GridLines = true;
        }

        public int PosicionSeleccionada(ListView lstUsuarios)
        {
            if (lstUsuarios.SelectedItems.Count > 0)
            {
                // Obtener el índice del elemento seleccionado
                int posicionSeleccionada = lstUsuarios.SelectedIndices[0];

                return posicionSeleccionada;
            }
            return -1;
        }

        public void CambiarDatos(string nombre, string apellido, string email, string password, int posicion)
        {
            if((nombre != ""  && apellido != "" && email != "" && password != "") && (nombre != null && apellido != null && email != null && password != null))
            {
                string correoActual = this.usuarios[posicion].correo;
                try
                {
                    using (vhmexEntities db = new vhmexEntities())
                    {
                        this.usuarios[posicion].nombre = nombre;
                        this.usuarios[posicion].apellido = apellido;
                        this.usuarios[posicion].correo = email;
                        this.usuarios[posicion].password = password;
                        db.Entry(this.usuarios[posicion]).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    MessageBox.Show("Cambios guardados correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    this.usuarios[posicion].correo = correoActual;
                    MessageBox.Show("Ese correo ya esta asignado");
                }
            }
            else
            {
                MessageBox.Show("No deje campos vacios");
            }
        }

        public void DatosTxt(TextBox nombre, TextBox apellido, TextBox email, TextBox contrasena, int posicion)
        {
            nombre.Text =this.usuarios[posicion].nombre;
            apellido.Text =this.usuarios[posicion].apellido;
            email.Text = this.usuarios[posicion].correo;
            contrasena.Text = this.usuarios[posicion].password;
        }
    }
}
