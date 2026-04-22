using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controllers
{
    public class DocentesMaterias
    {
        Materia[] Materias;
        Docente[] Docentes;

        /*Creo una conexion a la base de datos para poder obtener todas las materias
         y guardarlas en un array*/
        public void ObtenerMaterias()
        {
            using (Models.vhmexEntities db = new Models.vhmexEntities())
            {
                Materia[] materias = db.Materia.ToArray();
                this.Materias = materias;
            }
        }

        //Se utiliza el atributo de materias para ingresarlos en el listview
        public void CargarLstMaterias(ListView lstMaterias)
        {
            for (int i = 0; i < this.Materias.Length; i++)
            {
                string[] datos = { this.Materias[i].idMateria.ToString(),this.Materias[i].nombreMateria };
                ListViewItem item = new ListViewItem(datos);
                lstMaterias.Items.Add(item);
            }
        }

        //Obtengo los maestros y a los maestros les cargo la entidad de usuario
        public void ObtenerMaestros()
        {
            using (Models.vhmexEntities db = new vhmexEntities())
            {
                this.Docentes = db.Docente.ToArray();
                foreach (Docente docente in Docentes)
                {
                    db.Entry(docente).Reference(user => user.Usuario).Load();
                }
            }
        }

        /*
         En un listview ingreso los datos de los profesores en el cual se 
        carga su ID y su usuario como el nombre y apellido
         */
        public void CargarLstDocentes(ListView lstDocentes)
        {
            for (int i = 0; i < this.Docentes.Length; i++)
            {
                string[] datos = { this.Docentes[i].idDocente.ToString(), this.Docentes[i].Usuario.nombre + " " + this.Docentes[i].Usuario.apellido };
                ListViewItem item = new ListViewItem(datos);
                lstDocentes.Items.Add(item);
            }
        }

        /*
         Se cargan las propiedades del ambos listview usados en la vista 
        de docentesMaterias
         */
        public void CargarAparienciaLst(ListView lstMaestros, ListView lstMaterias)
        {
            lstMaestros.Columns.Add("ID Maestro", 50);
            lstMaestros.Columns.Add("Nombre", 200);

            lstMaterias.Columns.Add("ID", 50);
            lstMaterias.Columns.Add("Materia", 150);
            EstablecerPropiedadesSinCheck(lstMaestros);
            EstablecerPropiedades(lstMaterias);
        }

        /*Este es para que vuelva a cargar las propiedades cuando se hace una 
         actualizacion/Nuevo ingreso de dato
         */
        public void EstablecerPropiedades(ListView lstListado)
        {
            lstListado.View = View.Details;
            lstListado.FullRowSelect = true;
            lstListado.GridLines = true;
            lstListado.CheckBoxes = true;
        }

        /*Este es para que vuelva a cargar las propiedades cuando se hace una 
 actualizacion/Nuevo ingreso de dato pero sin el check
 */
        public void EstablecerPropiedadesSinCheck(ListView lstListado)
        {
            lstListado.View = View.Details;
            lstListado.FullRowSelect = true;
            lstListado.GridLines = true;
        }

        //obtengo la posicion seleccionada de un padre en el listview
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

        /*
         Una vez que encuentro la poscion del padre que necesito ahora busco las posiciones de 
        las materias qeu han sido marcadas para agregarselas al profesor
         */
        public void AsignarMaterias(ListView lstDocentes, ListView lstMaterias)
        {
            int posicion = PosicionSeleccionada(lstDocentes);
            int[] posiciones = Seleccionados(lstMaterias);
            if (posicion >= 0 && posiciones.Length >= 1)
            {
                using (Models.vhmexEntities db = new vhmexEntities())
                {
                    for (int i = 0; i < posiciones.Length; i++)
                    {
                        int idMateria = this.Materias[posiciones[i]].idMateria;
                        int idDocente = this.Docentes[posicion].idDocente;
                        DocenteMateria docMat = new DocenteMateria();
                        docMat.idMateria = idMateria;
                        docMat.idDocente = idDocente;
                        db.DocenteMateria.Add(docMat);
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un padre y algún alumno");
            }
        }
    }
}
