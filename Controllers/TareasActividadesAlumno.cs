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
    public class TareasActividadesAlumno
    {
        private AlumnoActividad[] alumnoActividades;
        private Actividad actividad;

        /*
         Se establecen las propiedades del listview de actividades para que se vena por 
        filas y tenga un grid
         */
        public void prepararListView(ListView lsTareas)
        {
            lsTareas.Columns.Add("Nombre Asignación",150);
            lsTareas.Columns.Add("Materia", 100);

            lsTareas.View = View.Details;
            lsTareas.FullRowSelect = true;
            lsTareas.GridLines = true;
        }

        /*
         Se obtienen las tareas del alumno actual en base al idAlumno y se carga las ebtidades
        de de actividad, docenteMateria y materia donde estas actividades sean del ciclo actual
         */
        public void ObtenerTareas(int alumno)
        {
            int cicloEscolarActual = AltaGrupo.ObtenerCicloEscolarActual().idCicloEscolar;
            using (vhmexEntities db = new vhmexEntities())
            {
                alumnoActividades = db.AlumnoActividad
                    .Include(a => a.Actividad)
                    .Include(b => b.Actividad.DocenteMateria)
                    .Include(c => c.Actividad.DocenteMateria.Materia)
                    .Where(i => i.Alumno.idAlumno == alumno && i.idCicloEscolar == cicloEscolarActual)
                    .ToArray();
            }
        }

        /*
         Se cargan las tareas obtenidas del metodo obtenerAsignaciones y se guardan en un arreglo que se 
        almacenan en un listviewItem y se agregan al listview
         */
        public void CargarTareas(ListView lstTareas)
        {
            for (int i = 0; i < this.alumnoActividades.Length; i++)
            {
                string[] datos = { this.alumnoActividades[i].Actividad.Nombre , this.alumnoActividades[i].Actividad.DocenteMateria.Materia.nombreMateria };
                ListViewItem lvi = new ListViewItem(datos);
                lstTareas.Items.Add(lvi);
            }
        }

        /*Se obtiene la asignacion actual desde la base de datos dada la condicion
         de la idActividad
         */
        public void obtenerAsignacion(int idAct)
        {
            using (vhmexEntities db = new vhmexEntities())
            {
                actividad = db.Actividad.Where(id => id.idActividad == idAct).FirstOrDefault();
            }
        }

        /*
         Se carga la actividad y se muestra el nombre y la descripcion de la actividad
         */
        public void CargarAsignacion(Label lblT, Label lblD, int pos)
        {
            obtenerAsignacion(this.alumnoActividades[pos].idActividad);
            lblT.Text = actividad.Nombre;
            lblD.Text = actividad.descripcion;
        }

        /*
         Obtener el índice del elemento seleccionado
         */
        public int PosicionSeleccionada(ListView lstMaestros)
        {
            if (lstMaestros.SelectedItems.Count > 0)
            {
                // Obtener el índice del elemento seleccionado
                int posicionSeleccionada = lstMaestros.SelectedIndices[0];

                return posicionSeleccionada;
            }
            return -1;
        }

    }
}
