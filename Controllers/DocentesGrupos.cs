using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controllers
{
    public class DocentesGrupos
    {
        private nivel[] niveles;
        private CicloEscolarGrupo[] gruposcicloEscolar;
        private DocenteMateria[] docentes;

        //Carga los nombres de las columnas que se mostrarán en el listview
        public void CargarListview(ListView lstListado)
        {
            lstListado.Columns.Add("ID Docente", 80);
            lstListado.Columns.Add("Nombre", 120);
            lstListado.Columns.Add("Materia que imparte", 130);

            lstListado.View = View.Details;
            lstListado.FullRowSelect = true;
            lstListado.GridLines = true;
            lstListado.CheckBoxes = true;
        }

        //obtiene los niveles desde la base de datos
        public void ObtenerNiveles()
        {
            using(Models.vhmexEntities db = new vhmexEntities())
            {
                this.niveles = db.nivel.ToArray();
            }
        }

        //carga los niveles al combobox de cboNiveles
        public void CargarNiveles(ComboBox comNiveles)
        {
            foreach (var nivel in this.niveles)
            {
                comNiveles.Items.Add(nivel.Nivel1);
            }
            comNiveles.Text = niveles[0].Nivel1;
        }

        public void CargarNivel(ComboBox comNivel)
        {

        }

        //Se utiliza el atributo de materias para ingresarlos en el listview
        public void CargarLstMaterias(ListView lstMaterias)
        {
            for (int i = 0; i < this.docentes.Length; i++)
            {
                string[] datos = { this.docentes[i].idDocente.ToString(), this.docentes[i].Docente.Usuario.nombre + " " + this.docentes[i].Docente.Usuario.apellido, this.docentes[i].Materia.nombreMateria };
                ListViewItem item = new ListViewItem(datos);
                lstMaterias.Items.Add(item);
            }
        }

        /*
         cargo los grupos que estan registrados en el ciclo actual mediante el metodo ObtenerCicloEscolarActual()
        y a los grupos que estan en el ciclo escolar actual cargo las entidades de grado grupo y su nivel
         */
        public void ObtenerGrupos(string nivel)
        {
            CicloEscolar cicloEscolar = AltaGrupo.ObtenerCicloEscolarActual();
            using (Models.vhmexEntities db = new vhmexEntities())
            {
                this.gruposcicloEscolar = db.CicloEscolarGrupo
                    .Include(gg => gg.Grado_Grupo.Grado)
                    .Include(ggG => ggG.Grado_Grupo.Grupo)
                    .Include(ggN => ggN.Grado_Grupo.nivel)
                    .Where(c => c.idCicloEscolar == cicloEscolar.idCicloEscolar && c.Grado_Grupo.nivel.Nivel1 == nivel)
                    .ToArray();
                //foreach (var gradogrupo in this.gruposcicloEscolar)
                //{
                //    db.Entry(gradogrupo).Reference(gg => gg.Grado_Grupo ).Load();
                //    //db.Entry(gradogrupo.Grado_Grupo).Reference(g => g.Grado).Load();
                //    db.Entry(gradogrupo.Grado_Grupo).Reference(gr => gr.Grupo).Load();
                //    db.Entry(gradogrupo.Grado_Grupo).Reference(n => n.nivel).Load();
                //}
            }
        }

        //cargo los grupos al combobox
        public void CargarGrupos(ComboBox comGrupos)
        {
            foreach (var item in this.gruposcicloEscolar)
            {
                comGrupos.Items.Add(item.Grado_Grupo.Grado.idGrado + " " + item.Grado_Grupo.Grupo.Grupo1);
            }
        }

        /*
         Esta método seleccionará los docentes que no están asignados al grupo con el idGradoGrupo específico definido en la variable 
        GradoGrupo, pero que sí tienen alguna materia asignada.
         */
        public void ObtenerMaestrosMaterias(int PosiciongradoGrupo)
        {
            int grupo = gruposcicloEscolar[PosiciongradoGrupo].idGradoGrupo;
            using (Models.vhmexEntities db = new vhmexEntities())
            {
                //Docente[] docentes = db.Docente
                //    .Include(b => b.Docente.DocenteMateria)
                //    .Where(c => c.idGradoGrupo != id && c.Grado_Grupo.CicloEscolarGrupo.Any(i => i.idCicloEscolarGrupo == cicloEscolarActual))
                //    .ToArray();

                //Docente[] docentes = db.Docente
                //    .Where(d => !db.DocenteGrupo.Any(adg => adg.idDocente == d.idDocente) &&
                //        !db.DocenteMateria.Any(adm => adm.idDocente == d.idDocente))
                //    .ToArray();

                //Docente[] docentes =  db.Docente
                //.Where(d => !db.DocenteGrupo.Any(adg => adg.idDocente == d.idDocente) &&
                //    db.DocenteMateria.Any(adm => adm.idDocente == d.idDocente))
                //.ToArray();

                //docentes = db.DocenteMateria
                //    .Include(u => u.Materia)
                //    .Include(dm => dm.Docente.Usuario)
                //    .Where(m =>
                //    !db.DocenteMateria.Any(gm =>
                //        gm.idMateria == m.idMateria ) && !db.DocenteGrupo.Any(dc => dc.idGradoGrupo == grupo))
                //    .ToArray();

                //            docentes = db.DocenteMateria
                //.Include(dm => dm.Docente.Usuario)
                //.Include(dm => dm.Materia)
                //.Where(dm =>
                //    !db.DocenteGrupo.Any(dg => dg.idDocente == dm.idDocente && dg.idGradoGrupo == grupo) &&
                //    db.DocenteMateria.Any(dm2 => dm2.idDocente == dm.idDocente))
                //.ToArray();

                docentes = db.DocenteMateria
                    .Include(u => u.Materia)
                    .Include(dm => dm.Docente.Usuario)
                    .Where(d => !db.DocenteGrupo
                    .Any(adg => adg.idDocente == d.idDocente && adg.idGradoGrupo == grupo) &&
                        db.DocenteMateria.Any(adm => adm.idDocente == d.idDocente))
                    .ToArray();
 
            }
        }

        public void AsignarMaterias(ListView lstMaterias, int indexGrupo)
        {
            int[] posiciones = Seleccionados(lstMaterias);
            if(posiciones.Length>0)
            {
                using (Models.vhmexEntities db = new vhmexEntities())
                {
                    for (int i = 0; i < posiciones.Length; i++)
                    {
                        DocenteGrupo dg = new DocenteGrupo()
                        {
                            idDocente = docentes[posiciones[i]].idDocente,
                            idGradoGrupo = gruposcicloEscolar[indexGrupo].idGradoGrupo,
                            idDocMat = docentes[posiciones[i]].IdDocMat,
                        };
                        db.DocenteGrupo.Add(dg);
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un grupo o maestro");
            }
        }

        /*Obtener el índice del elemento seleccionado*/
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

        //obtengo las posicones que esten checadas y las guardo en una lista que comvierto a un array
        public int[] Seleccionados(ListView lstMaterias)
        {
            List<int> pos = new List<int>();
            for (int i = 0; i < lstMaterias.Items.Count; i++)
            {
                // Obtener el ListViewItem actual
                ListViewItem item = lstMaterias.Items[i];

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
