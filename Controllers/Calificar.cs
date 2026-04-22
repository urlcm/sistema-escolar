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
    public class Calificar
    {
        private CicloEscolar ce = AltaGrupo.ObtenerCicloEscolarActual();
        private Actividad[] actividad;
        private Examen[] examenes;
        private Tarea[] tareas;
        private AlumnoActividad[] alumnosActividad;
        private ExamenAlumno[] alumnosExamenes;
        private TareaAlumno[] alumnosTareas;
        public HashSet<int> mySet = new HashSet<int>();

        //Preparo el listview para para las asignaciones y me mostrara la materia,el nombre de la asignacion, grado y grupo
        public void prepararLstAsignacion(ListView lstTEA)
        {
            lstTEA.FullRowSelect = true;
            lstTEA.GridLines = true;
            lstTEA.View = View.Details;

            lstTEA.Columns.Add("Materia", 80);
            lstTEA.Columns.Add("Nombre de la asignacion", 150);
            lstTEA.Columns.Add("Grado y grupo", 80);
        }
        //Le asgino las propiedades del listvuew de lstCalificar
        public void prepararLstAsignacionesAlumnos(ListView lstCalificar)
        {
            lstCalificar.FullRowSelect = true;
            lstCalificar.GridLines = true;
            lstCalificar.View = View.Details;

            lstCalificar.Columns.Add("Id alumno", 80);
            lstCalificar.Columns.Add("Nombre alumno", 100);
            lstCalificar.Columns.Add("Puntos", 50);
            lstCalificar.Columns.Add("Valor", 50);
        }

        //Obtengo las asignaciones desde la base de datos dependiendo del tipo de asignacion que sea (Activiadad, tarea y examen) y las meto a un arreglo de su tipo
        public void obtenerAsignaciones(Docente docente, int tipoAsignacion)
        {
            using (vhmexEntities db = new vhmexEntities())
            {
                if(tipoAsignacion == 0)
                {
                    actividad = db.Actividad.Include(b=> b.DocenteMateria.Materia).Where(a => a.AlumnoActividad
                        .Any(b => b.idCicloEscolar == ce.idCicloEscolar) && a.idDocente == docente.idDocente).ToArray();
                }
                else if(tipoAsignacion == 1)
                {
                    examenes = db.Examen.Include(b => b.DocenteMateria.Materia).Where(a => a.ExamenAlumno
                        .Any(b => b.idCicloEscolar == ce.idCicloEscolar) && a.DocenteMateria.idDocente == docente.idDocente).ToArray();
                }
                else
                {
                    tareas = db.Tarea.Include(b => b.DocenteMateria.Materia).Where(a => a.TareaAlumno
                        .Any(b => b.idCicloEscolar == ce.idCicloEscolar) && a.DocenteMateria.idDocente == docente.idDocente).ToArray();
                }
            }
        }

        //De las asignaciones obtenidas  muestro las que se selecionen de su tipo en el combobox y laas ingreso al listview
        public void mostrarAsigacion(ListView lstTAE, int cbotipo)
        {
            ListViewItem item;
            if (cbotipo == 0) 
            {
                for (int i = 0; i < this.actividad.Length; i++)
                {
                    item = new ListViewItem(
                        new String[] 
                        { this.actividad[i].DocenteMateria.Materia.nombreMateria,
                          this.actividad[i].Nombre
                        }
                        );
                    lstTAE.Items.Add(item);
                }
            }
            else if(cbotipo == 1)
            {
                for (int i = 0; i < this.examenes.Length; i++)
                {
                    item = new ListViewItem(
                        new String[]
                        { this.examenes[i].DocenteMateria.Materia.nombreMateria,
                          this.examenes[i].Nombre
                        }
                        );
                    lstTAE.Items.Add(item);
                }
            }
            else
            {
                for (int i = 0; i < this.tareas.Length; i++)
                {
                    item = new ListViewItem(
                        new String[]
                        { this.tareas[i].DocenteMateria.Materia.nombreMateria,
                          this.tareas[i].Nombre
                        }
                        );
                    lstTAE.Items.Add(item);
                }
            }

        }

        /*
         
         */
        public void ObtenerAlumnos(int cboTipo, int posicion, ListView lstCalificar)
        {
            if (posicion != -1)
            {
                using (vhmexEntities db = new vhmexEntities())
                {
                    if (cboTipo == 0)
                    {
                        int idActividad = this.actividad[posicion].idActividad;
                        this.alumnosActividad = db.AlumnoActividad
                            .Include(ac => ac.Actividad)
                            .Include(a => a.Alumno)
                            .Include(u => u.Alumno.Usuario)
                            .Where(id => id.idActividad == idActividad).ToArray();
                    }
                    else if (cboTipo == 1)
                    {
                        int idExamen = this.examenes[posicion].idExamen;
                        this.alumnosExamenes = db.ExamenAlumno
                            .Include(e => e.Examen)
                            .Include(a => a.Alumno)
                            .Include(u => u.Alumno.Usuario)
                            .Where(id => id.idExamen == idExamen).ToArray();
                    }
                    else
                    {
                        int idTarea = this.tareas[posicion].idTarea;
                        this.alumnosTareas = db.TareaAlumno
                            .Include(t => t.Tarea)
                            .Include(a => a.Alumno)
                            .Include(u => u.Alumno.Usuario)
                            .Where(id => id.idTarea == idTarea).ToArray();
                    }
                }
                mostrarAlumnos(lstCalificar, cboTipo);
            }
        }

        /*
        Muestra los alumnos dependienddo de la asignacion que se haya seleccionado
        */
        public void mostrarAlumnos(ListView lstAlumnos, int cboTipo)
        {
            if (cboTipo == 0)
            {
                foreach (var alumnoActividad in this.alumnosActividad)
                {
                    ListViewItem item = new ListViewItem
                    (
                        new string[]
                        {
                            alumnoActividad.idAlumno.ToString(), alumnoActividad.Alumno.Usuario.nombre + " " + alumnoActividad.Alumno.Usuario.apellido,
                            alumnoActividad.puntos.ToString(), alumnoActividad.Actividad.valor.ToString()
                        }
                    );
                    lstAlumnos.Items.Add(item);
                }
            }
            else if (cboTipo == 1)
            {
                foreach (var alumnoExamen in this.alumnosExamenes)
                {
                    ListViewItem item = new ListViewItem
                    (
                        new string[]
                        {
                            alumnoExamen.idAlumno.ToString(), alumnoExamen.Alumno.Usuario.nombre + " " + alumnoExamen.Alumno.Usuario.apellido,
                            alumnoExamen.puntos.ToString(), alumnoExamen.Examen.valor.ToString()
                        }
                    );
                    lstAlumnos.Items.Add(item);
                }
            }
            else
            {
                foreach (var alumnoTarea in this.alumnosTareas)
                {
                    ListViewItem item = new ListViewItem
                    (
                        new string[]
                        {
                            alumnoTarea.idAlumno.ToString(), alumnoTarea.Alumno.Usuario.nombre + " " + alumnoTarea.Alumno.Usuario.apellido,
                            alumnoTarea.puntos.ToString(), alumnoTarea.Tarea.valor.ToString()
                        }
                    );
                    lstAlumnos.Items.Add(item);
                }
            }
        }

        //obtengo la posicion seleccionada de la materia en el listview
        public int PosicionSeleccionada(ListView lstMateria)
        {
            if (lstMateria.SelectedItems.Count > 0)
            {
                // Obtener el índice del elemento seleccionado
                int posicionSeleccionada = lstMateria.SelectedIndices[0];

                return posicionSeleccionada;
            }
            return -1;
        }

        //Se modifica la nota en el listview pero no en la base de datos y agrego las posiciones que se seleccionaron en un hast set
        //para evitar duplicados de estos
        public void modificarNota(int posicion, int tipo)
        {
            int puntos;
            if (tipo == 0)
            {
                if (int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Ingrese la nota",
                    "Calificará a " + this.alumnosActividad[posicion].Alumno.Usuario.nombre + " " + this.alumnosActividad[posicion].Alumno.Usuario.apellido, "0"), out puntos)
                && (puntos >= 0 && puntos <= this.actividad[0].valor))
                {
                    this.alumnosActividad[posicion].puntos = puntos;
                }
                else
                {
                    MessageBox.Show("El numero debe ser menor que el valor","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if(tipo == 1)
            {
                if (int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Ingrese la nota",
                    "Calificará a " + this.alumnosExamenes[posicion].Alumno.Usuario.nombre + " " + this.alumnosExamenes[posicion].Alumno.Usuario.apellido, "0"), out puntos)
                && (puntos >= 0 && puntos <= this.examenes[0].valor))
                {
                    this.alumnosExamenes[posicion].puntos = puntos;
                }
                else
                {
                    MessageBox.Show("El numero debe ser menor que el valor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Ingrese la nota",
                    "Calificará a " + this.alumnosTareas[posicion].Alumno.Usuario.nombre + " " + this.alumnosTareas[posicion].Alumno.Usuario.apellido, "0"), out puntos)
                && (puntos >= 0 && puntos <= this.tareas[0].valor))
                {
                    this.alumnosTareas[posicion].puntos = puntos;
                }
                else
                {
                    MessageBox.Show("El numero debe ser menor que el valor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.mySet.Add(posicion);
        }

        public void GuardarCambiosActividades()
        {
            using (vhmexEntities db = new vhmexEntities())
            {
                foreach (var posicion in mySet)
                {
                    db.Entry(alumnosActividad[posicion]).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                }
            }
            MessageBox.Show("Se han guardado los cambios correctamente","Guardado",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public void GuardarCambiosExamenes()
        {
            using (vhmexEntities db = new vhmexEntities())
            {
                foreach (var posicion in mySet)
                {
                    db.Entry(alumnosExamenes[posicion]).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                }
            }
            MessageBox.Show("Se han guardado los cambios correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void GuardarCambiosTareas()
        {
            using (vhmexEntities db = new vhmexEntities())
            {
                foreach (var posicion in mySet)
                {
                    db.Entry(alumnosTareas[posicion]).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                }
            }
            MessageBox.Show("Se han guardado los cambios correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
