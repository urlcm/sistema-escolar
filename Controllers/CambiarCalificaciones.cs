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
    public class CambiarCalificaciones
    {
        private CicloEscolar[] ciclos;
        private Alumno[] alumnos;
        private AlumnoCalificacion[] alCal;

        /*Cargo las columnas y  aplico detalles como que se vean las lineas y
         permitir que se puedan marcar*/
        public void CargarListview(ListView lstListado)
        {
            lstListado.Columns.Add("ID", 60);
            lstListado.Columns.Add("Nombre Completo", 150);
            lstListado.Columns.Add("Nivel", 100);

            lstListado.View = View.Details;
            lstListado.FullRowSelect = true;
            lstListado.GridLines = true;
        }

        public void CargarPropiedadesListview(ListView lstListado)
        {
            lstListado.Columns.Add("Materia", 100);
            lstListado.Columns.Add("Calificacion", 100);

            lstListado.View = View.Details;
            lstListado.FullRowSelect = true;
            lstListado.GridLines = true;
        }


        public void ObtenerCiclos()
        {
            using (vhmexEntities db = new vhmexEntities())
            {
                ciclos = db.CicloEscolar.Where(e => e.estado == 2 || e.estado == 4).ToArray();
            }
        }

        public void CargarCiclos(ComboBox cboCiclos)
        {
            foreach (var ciclo in this.ciclos)
            {
                cboCiclos.Items.Add(ciclo.año + " " + ciclo.periodo);
            }
        }

        public void ObtenerAlumnos(int posicion)
        {
            int idCiclo = ciclos[posicion].idCicloEscolar;
            using (vhmexEntities db = new vhmexEntities())
            {
                alumnos = db.Alumno
                    .Include(u => u.Usuario)
                    .Include(n => n.nivel)
                    .Where(a => db.AlumnoCalificacion
                    .Any(ca => ca.idAlumno == a.idAlumno && ca.idCicloEscolar == idCiclo))
                    .ToArray();
            }
        }

        public void CargarAlumnos(ListView lstAlumnos)
        {
            foreach (var alumno in this.alumnos)
            {
                ListViewItem item = new ListViewItem(new string[] { alumno.idAlumno.ToString(), alumno.Usuario.nombre + " " + alumno.Usuario.apellido, alumno.nivel.Nivel1 });
                lstAlumnos.Items.Add(item);
            }
        }

        public void ObtenerCalifiacion(int posicion, int posCiclo, Label lblPromedio)
        {
            Alumno al = this.alumnos[posicion];
            int ciclo = this.ciclos[posCiclo].idCicloEscolar;
            using (vhmexEntities db = new vhmexEntities())
            {
                alCal = db.AlumnoCalificacion
                    .Include(c => c.Calificacion)
                    .Include(b => b.DocenteGrupo.DocenteMateria.Materia)
                    .Where(id => id.idAlumno == al.idAlumno && id.idCicloEscolar == ciclo).ToArray();

                //Sacar Criterios
                //int idMateria = alCal[1].DocenteGrupo.DocenteMateria.idMateria;
                //Models.Criterios criterio = db.Criterios.Where(i => i.idMateria == idMateria).FirstOrDefault();
                float sumaPromedioGeneral = 0;
                foreach (var item in alCal)
                {
                    int idMateria = item.DocenteGrupo.DocenteMateria.idMateria;
                    Models.Criterios criterio = db.Criterios.Where(i => i.idMateria == idMateria).FirstOrDefault();
                    //Sacar ponderado Asitencia
                    int idD = item.idDocenteGrupo;
                    int idAlumno = item.idAlumno;
                    int asistenciasTotales = db.Asistencia.Count(i => i.idDocenteGrupo == idD && i.idPresente == 0);
                    int asistenciasAsistidas = db.AlumnoAsistencia.Count(i => i.Asistencia.idDocenteGrupo == idD && i.Asistencia.idPresente == 1 && i.Alumno.idAlumno == idAlumno);

                    float asistenciasPorcentaje = ((float)asistenciasAsistidas / (float)asistenciasTotales) * (float)criterio.criterioAsistencia;

                    // sacar Actividades
                    List<AlumnoActividad> alumnoActividad = db.AlumnoActividad.Where(a => a.Actividad.idDocenteGrupo == idD && a.Alumno.idAlumno == idAlumno).ToList();
                    float sumaActividades = 0;
                    float ponderado = 0;
                    foreach (var actividadIndividual in alumnoActividad)
                    {
                        if (actividadIndividual.puntos != null)
                            sumaActividades += (float)((float)actividadIndividual.puntos / (float)actividadIndividual.Actividad.valor) * (float)criterio.criterioActividades;
                        else
                            sumaActividades += (float)((float)actividadIndividual.Actividad.valor / (float)actividadIndividual.Actividad.valor) * (float)criterio.criterioActividades;
                    }
                    if (alumnoActividad.Count > 0)
                    {
                        ponderado = ((float)sumaActividades / (float)alumnoActividad.Count) * ((float)criterio.criterioActividades / 100);
                    }

                    //Sacar Examen
                    List<ExamenAlumno> examenes = db.ExamenAlumno.Where(a => a.Examen.idDocenteGrupo == idD && a.Alumno.idAlumno == idAlumno).ToList();
                    float sumaExamen = 0;
                    float ponderadoExamen = 0;
                    foreach (var examen in examenes)
                    {
                        if (examen.puntos != null)
                            sumaExamen += (float)((float)examen.puntos / (float)examen.Examen.valor) * (float)criterio.criterioExamen;
                        else
                            sumaExamen += (float)((float)examen.Examen.valor / (float)examen.Examen.valor) * (float)criterio.criterioExamen;
                    }
                    if (examenes.Count > 0)
                    {
                        ponderadoExamen = ((float)sumaExamen / (float)examenes.Count) * ((float)criterio.criterioExamen / 100);
                    }


                    //Sacar tareas
                    List<TareaAlumno> tareas = db.TareaAlumno.Where(a => a.Tarea.idDocenteGrupo == idD && a.Alumno.idAlumno == idAlumno).ToList();
                    float sumaTareas = 0;
                    float ponderadoTareas = 0;
                    foreach (var tarea in tareas)
                    {
                        if (tarea.puntos != null)
                            sumaTareas += (float)((float)tarea.puntos / (float)tarea.Tarea.valor) * ((float)criterio.criterioTareas);
                        else
                            sumaTareas += (float)((float)tarea.Tarea.valor / (float)tarea.Tarea.valor) * ((float)criterio.criterioTareas);
                    }
                    if (tareas.Count > 0)
                    {
                        ponderadoTareas = (sumaTareas / tareas.Count) * ((float)criterio.criterioTareas / 100);
                    }
                    float promedio = (float)((asistenciasPorcentaje * ((float)criterio.criterioAsistencia / 100)) + (ponderado * ((float)criterio.criterioActividades / 100)) + (ponderadoExamen * ((float)criterio.criterioExamen / 100)) + (ponderadoTareas * ((float)criterio.criterioTareas / 100)));

                    sumaPromedioGeneral += promedio;
                    item.Calificacion.calificacion1 = promedio;
                    db.SaveChanges();
                }
                sumaPromedioGeneral /= alCal.Length;


                lblPromedio.Text = "Promedio general: " + sumaPromedioGeneral.ToString();
            }

        }

        //obtengo la posicion seleccionada de la materia en el listview
        public int PosicionSeleccionada(ListView lstAlumnos)
        {
            if (lstAlumnos.SelectedItems.Count > 0)
            {
                // Obtener el índice del elemento seleccionado
                int posicionSeleccionada = lstAlumnos.SelectedIndices[0];

                return posicionSeleccionada;
            }
            return -1;
        }

        public void cargarCalificaciones(ListView lstCalificaciones)
        {
            foreach (var calificacion in this.alCal)
            {
                ListViewItem item = new ListViewItem(new string[] { calificacion.DocenteGrupo.DocenteMateria.Materia.nombreMateria, calificacion.Calificacion.calificacion1.ToString() });
                lstCalificaciones.Items.Add(item);
            }
        }

        public void CalificarAsistencia(AlumnoAsistencia asistenciaAlumno)
        {

        }

        public void CalificarExamen()
        {
            
        }

        public void CalificarActividades()
        {

        }

        public void CalificarTareas()
        {

        }

        public void CambiarCalificacion(int posMateria)
        {
            int puntos;
            if (int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Ingrese la nota",
                    "Calificará a " + this.alCal[posMateria].Alumno.Usuario.nombre + " " + this.alCal[posMateria].Alumno.Usuario.apellido, "0"), out puntos)
                && (puntos >= 0 && puntos <= this.alCal[0].Calificacion.calificacion1))
            {
                this.alCal[posMateria].Calificacion.calificacion1 = puntos;
            }
            else
            {
                MessageBox.Show("El numero debe ser menor que el valor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
