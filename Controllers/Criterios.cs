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
    public class Criterios
    {
        private Materia[] materiasSinCriterio;

        /*Se verifica que la suma de los criterios sea igual a 100 y que sea en formato numerico entero
         y retornara verdadero o falso dependiendo si son o no entero e igual a 100
         */
        public bool verificarCriterios(string c1, string c2, string c3, string c4)
        {
            int a, b, c, d;
            if((int.TryParse(c1, out a) && int.TryParse(c2, out b) && 
                int.TryParse(c3, out c) && int.TryParse(c4,out d)) && a+b+c+d==100)
                return true;
            else
                return false;
        }

        //Hago una conexion a la base de datos y obtengo a todas la materias que no estan en la tabal de criterios
        public void ObtenerMaterias()
        {
            using (vhmexEntities db = new vhmexEntities())
            {
                materiasSinCriterio = db.Materia
                    .Where(m => !db.Criterios.Any(c => c.idMateria == m.idMateria))
                    .ToArray();
            }
        }

        //Cargo todas las materias sin criterios al combobox
        public void CargarMaterias(ComboBox cboMaterias)
        {
            foreach (var materia in this.materiasSinCriterio)
            {
                cboMaterias.Items.Add(materia.nombreMateria);
            }
        }
        //Asigna los criterios a la materia y la guardo en la base de datos
        public void AsignarCriterios(TextBox txtActividades, TextBox asistencia, TextBox examen, TextBox tarea, int posicion)
        {
            Models.Criterios criterios = new Models.Criterios()
            {
                criterioActividades = int.Parse(txtActividades.Text),
                criterioExamen = int.Parse(examen.Text),
                criterioAsistencia = int.Parse(asistencia.Text),
                criterioTareas = int.Parse(tarea.Text),
                idMateria = materiasSinCriterio[posicion].idMateria
            };
            using (vhmexEntities db = new vhmexEntities())
            {
                db.Criterios.Add(criterios);
                db.SaveChanges();
            }
        }

        //Limpio los textbox una vez que se haya guardado los criterios junto con el comboBox
        public void ReiniciarCriterios(TextBox txtActividades, TextBox asistencia, TextBox examen, TextBox tarea)
        {
            txtActividades.Clear();
            txtActividades.Focus();
            asistencia.Clear();
            examen.Clear();
            tarea.Clear();
        }
    }
}
