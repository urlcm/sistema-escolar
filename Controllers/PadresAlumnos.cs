using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Controllers
{
    public class PadresAlumnos
    {
        private PadreDeFamilia[] padres;
        private Alumno[] alumnos;

        /*Agrego las columnas y detalles a los listview*/
        public void PrepararListviews(ListView lstPadres, ListView lstAlumnos)
        {
            lstPadres.Columns.Add("ID Padre", 50);
            lstPadres.Columns.Add("Nombre", 150);

            lstAlumnos.Columns.Add("ID Alumno", 50);
            lstAlumnos.Columns.Add("Nombre", 150);
            lstAlumnos.Columns.Add("Nivel", 80);
            lstPadres.View = View.Details;
            lstPadres.FullRowSelect = true;
            lstPadres.GridLines = true;
            CargarDetalles(lstAlumnos);
        }
        //agrego detalles al listado que se de como parametro
        public void CargarDetalles(ListView listado)
        {
            listado.View = View.Details;
            listado.FullRowSelect = true;
            listado.GridLines = true;
            listado.CheckBoxes = true;
        }

        //recargo solo el listview alumnos 
        public void RecargarAlumnos(ListView lstAlumnos)
        {
            lstAlumnos.Columns.Add("ID Alumno", 50);
            lstAlumnos.Columns.Add("Nombre", 150);
            lstAlumnos.Columns.Add("Nivel", 80);
            CargarDetalles(lstAlumnos);
        }

        //obtengo los alumnos, para eso abro una conexion a la base de datos y los meto al array
        public void ObtenerAlumnos(string Nivel)
        {
            using (Models.vhmexEntities db = new Models.vhmexEntities())
            {
                this.alumnos = db.Alumno.Where(a => a.nivel.Nivel1 == Nivel &&  a.PadreAlumno.All(sp=> sp.idPadre == null)).ToArray();
            }
        }

        //obtengo los alumnos
        public void ObtenerAlumnos()
        {
            using (Models.vhmexEntities db = new Models.vhmexEntities())
            {
                this.alumnos = db.Alumno.Where(a=>a.PadreAlumno.All(sp => sp.idPadre == null)).ToArray();
                for (int i = 0; i < this.alumnos.Length; i++)
                {
                    db.Entry(this.alumnos[i]).Reference(a => a.Usuario).Load();
                    db.Entry(this.alumnos[i]).Reference(n => n.nivel).Load();
                }
            }

        }

        //obtengo todos los padres, para eso abro una conexion a la base de datos y los meto al array
        public void ObtenerPadres()
        {
            using (Models.vhmexEntities db = new Models.vhmexEntities())
            {
                this.padres = db.PadreDeFamilia.ToArray();
                for (int i = 0; i < this.padres.Length; i++)
                {
                    db.Entry(this.padres[i]).Reference(a => a.Usuario).Load();
                }
            }
        }

        //Cargo los padres obtenidos por el metodo de obtener padres, en el respectivo listview
        public void CargarPadres(ListView lstPadres)
        {
            for (int i = 0; i < this.padres.Length; i++) 
            {
                string[] datos = { this.padres[i].idPadre.ToString(), this.padres[i].Usuario.nombre + " " + this.padres[i].Usuario.apellido};
                ListViewItem item = new ListViewItem(datos);
                lstPadres.Items.Add(item);
            }
        }

        //Cargo los alumnmos obtenidos por el metodo de obtener padres, en el respectivo listview
        public void CargarAlumnos(ListView lstAlumnos)
        {
            for (int i = 0; i < this.alumnos.Length; i++)
            {
                string[] datos = { this.alumnos[i].idAlumno.ToString(), this.alumnos[i].Usuario.nombre + " " + this.alumnos[i].Usuario.apellido, this.alumnos[i].nivel.Nivel1 };
                ListViewItem item = new ListViewItem(datos);
                lstAlumnos.Items.Add(item);
            }
        }

        /*
         Asigno a los padres a sus respectivos hijos pueden ser uno o varios y a cada alumno
        que se le asigna su padre se guarda despues de eso una vez finalizada se limpia el listview
         */
        public void AsignarPadres(ListView lstPadre, ListView lstAlumno)
        {
            int posicion = PosicionSeleccionada(lstPadre);
            int[] posiciones = Seleccionados(lstAlumno);
            if ( posicion >= 0 && posiciones.Length >= 1)
            {
                using (Models.vhmexEntities db = new vhmexEntities())
                {
                    for (int i = 0; i < posiciones.Length; i++)
                    {
                        int idAlumno = alumnos[posiciones[i]].idAlumno;
                        PadreAlumno padreAlumno = db.PadreAlumno.Where(id => id.idAlumno == idAlumno).FirstOrDefault();
                        padreAlumno.idPadre = padres[posicion].idPadre;
                        db.Entry(padreAlumno).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                lstAlumno.Clear();
            }
            else
            {
                MessageBox.Show("Debe seleccioanar un padre y algún alumno");
            }
        }

        //obtengo la posicion seleccionada de un padre en el listview
        public int PosicionSeleccionada(ListView lstPadre)
        {
            if (lstPadre.SelectedItems.Count > 0)
            {
                // Obtener el índice del elemento seleccionado
                int posicionSeleccionada = lstPadre.SelectedIndices[0];

                return posicionSeleccionada;
            }
            return -1;
        }

        //obtengo las posicones que esten checadas y las guardo en una lista que comvierto a un array
        public int[] Seleccionados(ListView lstAlumnos) 
        {
            List<int> pos = new List<int>();
            for (int i = 0; i < lstAlumnos.Items.Count; i++)
            {
                // Obtener el ListViewItem actual
                ListViewItem item = lstAlumnos.Items[i];

                // Verificar si el CheckBox del elemento está seleccionado
                if (item.Checked)
                {
                    pos.Add(i);
                }
            }
            return pos.ToArray();
        }
    }
}
