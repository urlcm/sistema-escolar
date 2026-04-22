using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controllers
{
    public class AlumnosMaterias
    {
        public Materia[] materias;
        public Alumno[] Alumnos;
        // Agrego las columnas de los listview con su respectivo nombre y ancho
        public void CargarListview(ListView lstAlmnos, ListView lstMaterias)
        {
            lstAlmnos.Columns.Add("ID", 50);
            lstAlmnos.Columns.Add("Nombre", 150);
            lstAlmnos.Columns.Add("Nivel", 100);

            lstMaterias.Columns.Add("ID", 50);
            lstMaterias.Columns.Add("Materia", 150);
            EstablecerPropiedades(lstAlmnos);
            EstablecerPropiedades(lstMaterias);
        }

        public void CargarListViewAlumno(ListView lstAlmnos)
        {
            lstAlmnos.Columns.Add("ID", 50);
            lstAlmnos.Columns.Add("Nombre", 150);
            lstAlmnos.Columns.Add("Nivel", 100);
            EstablecerPropiedades(lstAlmnos);
        }

        //establezco las propiedades del listview para que no el usuario no ingrese datos
        public void EstablecerPropiedades(ListView lstListado)
        {
            lstListado.View = View.Details;
            lstListado.FullRowSelect = true;
            lstListado.GridLines = true;
            lstListado.CheckBoxes = true;
        }

        //obtengo las materias y las guardo en un atributo de mi clase AlumnoMaterias
        public void ObtenerMaterias()
        {
            using (Models.vhmexEntities db = new Models.vhmexEntities())
            {
                Materia[] materias = db.Materia.ToArray();
                this.materias = materias;
            }
        }

        //Se utiliza el atributo de materias para ingresarlos en el listview
        public void cargarLstMaterias(ListView lstMaterias)
        {
            for (int i = 0; i < this.materias.Length; i++)
            {
                string[] datos = { materias[i].idMateria.ToString(), materias[i].nombreMateria };
                ListViewItem item = new ListViewItem(datos);
                lstMaterias.Items.Add(item);
            }
        }

        //Obtengo los alumnos de la base de datos y les cargo la relacion de usuarios
        public void ObtenerAlumnos(string nivel)
        {
            using (Models.vhmexEntities db = new Models.vhmexEntities())
            {
                Alumnos = db.Alumno.Where(a => a.nivel.Nivel1 == nivel).ToArray();
                int longitud = this.Alumnos.Length;
                for (int i = 0; i < longitud; i++)
                {
                    db.Entry(this.Alumnos[i]).Reference(a => a.Usuario).Load();
                    db.Entry(this.Alumnos[i]).Reference(n => n.nivel).Load();
                }
            }
        }

        /*
         Cargo los elementos al listview con el array datos, ingreso los datos del idAlumno,
        nombre, apellido y el nivel del alumno
         */
        public void cargarLstAlumnos(ListView lstAlumos)
        {
            foreach (Alumno alumno in Alumnos)
            {
                string[] datos =
                {
                    alumno.idAlumno.ToString(),
                    alumno.Usuario.nombre + " " +alumno.Usuario.apellido,
                    alumno.nivel.Nivel1
                };

                ListViewItem item = new ListViewItem(datos);
                lstAlumos.Items.Add(item);
            }
        }

        //obtengo los niveles de la base de datos
        public static nivel[] ObtenerNiveles()
        {
            using (Models.vhmexEntities db = new vhmexEntities())
            {
                nivel[] Nivel = db.nivel.ToArray();
                return Nivel;
            }
        }

        //Ingreso los niveles disponibles en el comboBox
        public void CargarNiveles(ComboBox comNiveles, nivel[] Niveles)
        {
            foreach (var nivel in Niveles)
            {
                comNiveles.Items.Add(nivel.Nivel1);
            }
        }

        public void AsignarMaterias()
        {

        }
    }
}
