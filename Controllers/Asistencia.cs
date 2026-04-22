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
    public class Asistencia
    {
        private Alumno[] alumnos;
        private DocenteGrupo[] GradosGrupos;
        public bool asistencia = false;

        /*
         Cargo las propiedades y columnas del listview
         */
        public void CargarListview(ListView lstAsistencia)
        {
            lstAsistencia.Columns.Add("ID Alumno", 50);
            lstAsistencia.Columns.Add("Nombre", 150);
            lstAsistencia.View = View.Details;
            lstAsistencia.FullRowSelect = true;
            lstAsistencia.GridLines = true;
            lstAsistencia.CheckBoxes = true;
        }

        /*
         Obtengo los grupos que pertenecen solo al id del maestro que sean del 
        ciclo escolar actual para agregarlos al arreglo GradosGrupos
         */
        public void ObtenerGrupos(int idMaestro)
        {
            CicloEscolar cicloEscolar = AltaGrupo.ObtenerCicloEscolarActual();
            using (Models.vhmexEntities db = new vhmexEntities())
            {
    //            this.GradosGrupos = db.DocenteGrupo
    //.Include(g => g.Grado_Grupo.Grado)
    //.Include(gr => gr.Grado_Grupo.Grupo)
    //.Include(n => n.Grado_Grupo.nivel)
    //.Where(d => d.DocenteGrupo.(doc => doc.idDocente == idMaestro)
    //    && d.CicloEscolarGrupo.Any(ce => ce.idCicloEscolar == cicloEscolar.idCicloEscolar))
    //.ToArray();

                this.GradosGrupos = db.DocenteGrupo
                    .Include(g => g.Grado_Grupo.Grado)
                    .Include(gr => gr.Grado_Grupo.Grupo)
                    .Include(n => n.Grado_Grupo.nivel)
                    .Where(d => d.idDocente == idMaestro
                        && d.Grado_Grupo.CicloEscolarGrupo.Any(ce => ce.idCicloEscolar == cicloEscolar.idCicloEscolar))
                    .ToArray();
            }
        }

        //Cargo los grupos obtenidos en el metodo ObtenerGrupos
        public void CargarGrupos(ComboBox cboGrupos)
        {
            for (int i = 0; i < GradosGrupos.Length; i++)
            {
                cboGrupos.Items.Add(GradosGrupos[i].Grado_Grupo.idGrado + " - " 
                    + GradosGrupos[i].Grado_Grupo.Grupo.Grupo1 + " " 
                    + GradosGrupos[i].Grado_Grupo.nivel.Nivel1);
            }
        }


        public void ObtenerAlumnos(int idMaestro, int posicion)
        {
            int cicloEscolar = AltaGrupo.ObtenerCicloEscolarActual().idCicloEscolar;
            int idGradoGrupo = this.GradosGrupos[posicion].idGradoGrupo;
            using (Models.vhmexEntities db = new Models.vhmexEntities())
            {
                //this.alumnos = db.Alumno
                //    .Include(u => u.Usuario)
                //    .Where(d => d.AlumnoGrupo.Any( id => id.Grado_Grupo.DocenteGrupo
                //        .Any(idD => idD.idDocente == idMaestro && idD.Grado_Grupo.CicloEscolarGrupo
                //        .Any(cea => cea.idCicloEscolar == cicloEscolar) && idD.idGradoGrupo == posicion) ) )
                //    .ToArray();
                this.alumnos = db.Alumno
                    .Include(u => u.Usuario)
                    .Where(d => d.AlumnoGrupo.Any(id => id.idGradoGrupo == idGradoGrupo)).ToArray();
            }
        }

        public void CargarAlumnos(ListView lstAlumnos)
        {
            for (int i = 0; i < this.alumnos.Length; i++)
            {
                string[] datos = { alumnos[i].idAlumno.ToString(), alumnos[i].Usuario.nombre + " " + alumnos[i].Usuario.apellido };
                ListViewItem item = new ListViewItem(datos);
                lstAlumnos.Items.Add(item);
            }
        }


        //Selecciono todos los alumnos que esten marcados en el checkbox
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

        public void ConfirmarAsistencia(ListView lstAsistencia, int posicion)
        {
            int[] posiciones = Seleccionados(lstAsistencia);
            if(posiciones.Length > 0)
            {
                int pos2 = 0;
                using (Models.vhmexEntities db = new vhmexEntities()) {
                    Models.Asistencia asistenciaValida = new Models.Asistencia()
                    {
                        fecha = DateTime.Today,
                        idGradoGrupo = GradosGrupos[posicion].idGradoGrupo,
                        idPresente = 1,
                        idDocenteGrupo = GradosGrupos[posicion].idDocenteGrupo
                    };
                    Models.Asistencia asistenciaNoValida = new Models.Asistencia()
                    {
                        fecha = DateTime.Today,
                        idGradoGrupo = GradosGrupos[posicion].idGradoGrupo,
                        idPresente = 0,
                        idDocenteGrupo = GradosGrupos[posicion].idDocenteGrupo
                    };
                    db.Asistencia.Add(asistenciaValida);
                    db.Asistencia.Add(asistenciaNoValida);
                    db.SaveChanges();
                    int idCicloEscolarActual = AltaGrupo.ObtenerCicloEscolarActual().idCicloEscolar;
                    for (int i = 0; i < this.alumnos.Length; i++)
                    {
                        AlumnoAsistencia AlAsistencia = new AlumnoAsistencia();
                        if (i == posiciones[pos2])
                        {
                            AlAsistencia = new AlumnoAsistencia()
                            {
                                idAlumno = this.alumnos[i].idAlumno,
                                idAsistencia = asistenciaValida.idAsistencia,
                                idCicloEscolar = idCicloEscolarActual,
                            };
                            pos2++;
                        }
                        else
                        {
                             AlAsistencia = new AlumnoAsistencia()
                            {
                                idAlumno = this.alumnos[i].idAlumno,
                                idAsistencia = asistenciaNoValida.idAsistencia,
                                idCicloEscolar = idCicloEscolarActual,
                            };
                        }
                        db.AlumnoAsistencia.Add(AlAsistencia);
                    }
                    db.SaveChanges();
                    MessageBox.Show("Alumnos confirmados");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar a algún alummno");
            }
        }

        public bool HayAsistenciaHoy(ComboBox cboGrupos, int idMaestro)
        {
            int idGradoGrupo = this.GradosGrupos[cboGrupos.SelectedIndex].idGradoGrupo;
            Models.Asistencia[] a;
            using (Models.vhmexEntities db = new vhmexEntities())
            {
                a = db.Asistencia.Where(igg => igg.idGradoGrupo == idGradoGrupo && 
                igg.Grado_Grupo.DocenteGrupo.Any(idD => idD.idDocente == idMaestro) && igg.fecha == DateTime.Today).ToArray();
            }
            if (a.Length > 0)
            {
                this.asistencia = true;
                return true;
            }
            else
            {
                this.asistencia = false;
                return false;
            }
        }

        public void CargarAlumnosConAsistencia(ComboBox cboGrupos, int idMaestro)
        {
            using (Models.vhmexEntities db = new vhmexEntities())
            {
                //this.alumnos = db.Alumno
                //    .Include(u => u.Usuario)
                //    .Where(igg => igg.AlumnoGrupo.Any( ag => ag.idGradoGrupo == cboGrupos.SelectedIndex) &&
                //igg.AlumnoGrupo.Any(agg => agg.Grado_Grupo.DocenteGrupo.Any(idD => idD.idDocente == idMaestro)
                //&& igg.AlumnoAsistencia.Any(fe => fe. == DateTime.Today))).ToArray();



            }
        }

        
    }
}
