using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controllers
{
    public class SesionPadre
    {
        private PadreDeFamilia padre;
        public PadreAlumno[] Alumnos;
        
        /*Obtengo los padres mediante el idUsuario que se extrae desde el inico sesion para buscar al padre*/
        public void ObtenerPadre(Usuario user)
        {
            using (vhmexEntities db = new vhmexEntities())
            {
                this.padre = db.PadreDeFamilia.Where(p => p.idUsuario == user.idUsuario).FirstOrDefault();
            }
        }

        /*Obtengo solo a los hijos que tiene relacionado el padre*/
        public void ObtenerHijos()
        {
            using (vhmexEntities db = new vhmexEntities()) 
            { 
            this.Alumnos = db.PadreAlumno.Include(a=> a.Alumno.Usuario)
                    .Include(b=> b.Alumno.nivel)
                    .Where(i => i.idPadre == padre.idPadre).ToArray();
            }
        }

        //Cargo las propiedades de listview
        public void PreprararListView(ListView lstHijos)
        {
            lstHijos.Columns.Add("ID Alumno", 80);
            lstHijos.Columns.Add("Nombre", 150);
            lstHijos.Columns.Add("Nivel", 100);

            lstHijos.View = View.Details;
            lstHijos.FullRowSelect = true;
            lstHijos.GridLines = true;
        }

        //Cargo a los hijos obtenidos desde el metodo de ObtenerHijos para despues ingresarlos como intems en el listview
        public void CargarHijosListview(ListView lstHijos)
        {
            for (int i = 0; i < this.Alumnos.Length; i++)
            {
                string[] datos = { this.Alumnos[i].idAlumno.ToString(), this.Alumnos[i].Alumno.Usuario.nombre + " " + this.Alumnos[i].Alumno.Usuario.apellido, this.Alumnos[i].Alumno.nivel.Nivel1 };
                ListViewItem item = new ListViewItem(datos);
                lstHijos.Items.Add(item);
            }
            
        }



    }

}
