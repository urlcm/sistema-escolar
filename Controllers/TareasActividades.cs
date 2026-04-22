
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
    public class TareasActividades
    {
        DocenteGrupo[] DocenteGrupo;

        /*
         Se obtienen los grupos y se incluyen las entidades de grado y grupo
         */
        public void ObtenerGrupos(int idMaestro)
        {
            CicloEscolar cicloEscolar = AltaGrupo.ObtenerCicloEscolarActual();
            using (Models.vhmexEntities db = new vhmexEntities())
            {
                //this.GradosGrupos = db.Grado_Grupo
                //    .Include(g => g.Grado)
                //    .Include(gr => gr.Grupo)
                //    .Include(n => n.nivel)
                //    .Where(d => d.DocenteGrupo.Any(doc => doc.idDocente == idMaestro)
                //        && d.CicloEscolarGrupo.Any(ce => ce.idCicloEscolar == cicloEscolar.idCicloEscolar))
                //    .ToArray();

                this.DocenteGrupo = db.DocenteGrupo
                .Include(g => g.Grado_Grupo.Grado)
                .Include(gr => gr.Grado_Grupo.Grupo)
                .Include(n => n.Grado_Grupo.nivel)
                .Include(m => m.DocenteMateria.Materia)
                    .Where(d => d.idDocente == idMaestro
                && d.Grado_Grupo.CicloEscolarGrupo.Any(ce => ce.idCicloEscolar == cicloEscolar.idCicloEscolar))
                .ToArray();
            }
        }

        //Cargo los grupos obtenidos en el metodo ObtenerGrupos
        public void CargarGrupos(ListView lstMaterias)
        {
            for (int i = 0; i < this.DocenteGrupo.Length; i++)
            {
                string[] datos = { this.DocenteGrupo[i].DocenteMateria.Materia.nombreMateria.ToString(), this.DocenteGrupo[i].Grado_Grupo.Grado.idGrado  + " " + this.DocenteGrupo[i].Grado_Grupo.Grupo.Grupo1, this.DocenteGrupo[i].Grado_Grupo.nivel.Nivel1};
                ListViewItem item = new ListViewItem(datos);
                lstMaterias.Items.Add(item);
            }
        }

        //Cargo las propiedades del listview de materias 
        public void CargarListview(ListView lstMaterias)
        {
            lstMaterias.Columns.Add("Materia", 100);
            lstMaterias.Columns.Add("Grado y Grupo", 100);
            lstMaterias.Columns.Add("Nivel", 100);

            lstMaterias.View = View.Details;
            lstMaterias.FullRowSelect = true;
            lstMaterias.GridLines = true;
        }

        /*
         * Se abre una conexion a la base de datos y se obtienen 
         el id del grado de la posicion seleccionada y se obtiene el grupo del docente actual pero que
        sea de ese ciclo escolar.
        Despues creo un objeto actividad y se ingresan los datos de descripcion, idMaestro, nombre y el id del
        docenteGrupo
         */
        public void Asignar(string txtNombre,string txtDescripcion, int valor ,int idMaestro, int posicion, int tipoCriterio)
        {
            
            using (Models.vhmexEntities db = new vhmexEntities())
            {
                DocenteGrupo docenteGrupo = this.DocenteGrupo[posicion];
                //Models.DocenteGrupo docGrup =db.DocenteGrupo.Where(i => i.idGradoGrupo == docenteGrupo && i.idDocente== idMaestro ).FirstOrDefault();

                Alumno[] alumnos = db.Alumno
                .Where(d => d.AlumnoGrupo.Any(i => i.idGradoGrupo == docenteGrupo.idGradoGrupo)).ToArray();
                if (tipoCriterio == 0)
                {
                    Actividad actividad = CrearActividad(txtNombre, txtDescripcion, idMaestro,(int) docenteGrupo.idDocMat, valor,docenteGrupo.idDocenteGrupo);
                    db.Actividad.Add(actividad);
                    db.SaveChanges();
                    for (int i = 0; i < alumnos.Length; i++)
                    {
                        AlumnoActividad alAct = new AlumnoActividad()
                        {
                            idAlumno = alumnos[i].idAlumno,
                            idActividad = actividad.idActividad,
                            idCicloEscolar = AltaGrupo.ObtenerCicloEscolarActual().idCicloEscolar
                        };
                        db.AlumnoActividad.Add(alAct);
                    }
                }
                else if(tipoCriterio == 1)
                {
                    Tarea tarea = CrearTarea(txtNombre,txtDescripcion,valor,(int)docenteGrupo.idDocMat, docenteGrupo.idDocenteGrupo);
                    db.Tarea.Add(tarea);
                    db.SaveChanges();
                    for (int i = 0; i < alumnos.Length; i++)
                    {
                        TareaAlumno tareaAlumno = new TareaAlumno()
                        {
                            idAlumno = alumnos[i].idAlumno,
                            idTarea = tarea.idTarea,
                            idCicloEscolar = AltaGrupo.ObtenerCicloEscolarActual().idCicloEscolar
                        };
                        db.TareaAlumno.Add(tareaAlumno);
                    }
                }
                else
                {
                    Examen examen = CrearObjetoExamen(txtNombre, valor, (int)docenteGrupo.idDocMat, docenteGrupo.idDocenteGrupo);
                    db.Examen.Add(examen);
                    db.SaveChanges();
                    for (int i = 0; i < alumnos.Length; i++)
                    {
                        ExamenAlumno examenAlumno = new ExamenAlumno()
                        {
                            idAlumno = alumnos[i].idAlumno,
                            idExamen = examen.idExamen,
                            idCicloEscolar = AltaGrupo.ObtenerCicloEscolarActual().idCicloEscolar
                        };
                        db.ExamenAlumno.Add(examenAlumno);
                    }
                }

                db.SaveChanges();
            }
        }

        //Se crea un objeto Actividad y se retorna
        private Actividad CrearActividad(string txtNombre, string txtDescripcion, int idMaestro, int id, int valorAc, int idDocGrup)
        {
            Actividad actividad = new Actividad()
            {
                Nombre = txtNombre,
                descripcion = txtDescripcion,
                idDocente = idMaestro,
                idDocMat = id,
                valor = valorAc,
                idDocenteGrupo = idDocGrup
            };
            return actividad;
        }

        /*Creo un objeto tarea para despues retornalo*/
        private Tarea CrearTarea(string txtNombre, string txtDescripcion, int valorT,int id,int idDocGrup)
        {
            Tarea tarea = new Tarea()
            {
                Nombre = txtNombre,
                Descripcion = txtDescripcion,
                idDocMat = id,
                valor = valorT,
                idDocenteGrupo = idDocGrup
            };
            return tarea;
        }

        //Creo un objeto examen para despues retornarlo
        private Examen CrearObjetoExamen(string txtNombre, int valorE, int id, int idDocGrup)
        {
            Examen examen = new Examen()
            {
                Nombre = txtNombre,
                idDocMateria = id,
                valor = valorE,
                idDocenteGrupo = idDocGrup
            };

            return examen;
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

        
    }
}
