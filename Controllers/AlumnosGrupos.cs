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
    public class AlumnosGrupos
    {
        private Alumno[] alumnos;
        private Grado_Grupo[] GradosGrupos;
        private nivel[] Nivel;
        /*Cargo las columnas y  aplico detalles como que se vean las lineas y
         permitir que se puedan marcar*/
        public void CargarListview(ListView lstListado)
        {
            lstListado.Columns.Add("ID", 60);
            lstListado.Columns.Add("Nombre", 150);
            lstListado.Columns.Add("Nivel", 100);

            lstListado.View = View.Details;
            lstListado.FullRowSelect = true;
            lstListado.GridLines = true;
            lstListado.CheckBoxes = true;
        }

        /*
         Obtengo los alumnos a los cuales se le carga con su entidad usuario y nivel pero solo me devuelve
        los alumnos que no tienen un grupo y que pertenezcan a tal nivel
         */
        public void ObtenerAlumnos(ListView lstListado, string nivel)
        {
            using (Models.vhmexEntities db = new Models.vhmexEntities())
            {
                this.alumnos = db.Alumno
                    .Include(a => a.Usuario)
                    .Include(a => a.nivel)
                    .Where(a => !db.AlumnoGrupo.Any(ag => ag.idAlumno == a.idAlumno) && a.nivel.Nivel1 == nivel)
                    .ToArray();
            }
            CargarDatosListView(lstListado);
        }

        //cargo los datos al listview para mostralos con su id, nombre y apellido
        public void CargarDatosListView(ListView lstListado)
        {
            for (int i = 0; i < alumnos.Length; i++)
            {
                Usuario usuario = alumnos[i].Usuario;
                string[] datos = { alumnos[i].idAlumno.ToString(), usuario.nombre + " " + usuario.apellido, alumnos[i].nivel.Nivel1 };
                ListViewItem item = new ListViewItem(datos);
                lstListado.Items.Add(item);
            }
        }

        //Obtengo los niveles 
        public nivel[] ObtenerNiveles()
        {
            using(Models.vhmexEntities db = new vhmexEntities())
            {
                this.Nivel = db.nivel.ToArray();
                return Nivel;
            }
        }

        //Cargo los niveles a el combobox del nivel especifico
        public void CargarNiveles(ComboBox comNiveles, nivel[] Niveles)
        {
            foreach (var nivel in Niveles)
            {
                comNiveles.Items.Add(nivel.Nivel1);
            }
        }

        /*
        cargo los grupos que estan registrados en el ciclo actual mediante el metodo ObtenerCicloEscolarActual()
       y a los grupos que estan en el ciclo escolar actual cargo las entidades de grado, grupo y su nivel
        */
        public void ObtenerGrupos(string nivel)
        {
            CicloEscolar cicloEscolar = AltaGrupo.ObtenerCicloEscolarActual();
            using (Models.vhmexEntities db = new vhmexEntities())
            {
                GradosGrupos = db.Grado_Grupo
                    .Include(g => g.Grado)
                    .Include(gr => gr.Grupo)
                    .Include(n => n.nivel)
                    .Where(n => n.nivel.Nivel1 == nivel && n.CicloEscolarGrupo.Any(ce => ce.idCicloEscolar == cicloEscolar.idCicloEscolar))
                    .ToArray();
            }
        }

        //cargo los grupos al combobox
        public void CargarGrupos(ComboBox comGrupos)
        {
            foreach (var item in this.GradosGrupos)
            {
                    comGrupos.Items.Add(item.Grado.idGrado + ".- " + item.Grupo.Grupo1);
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

        /*
         Obtengo las posiciones de los alumnos seleccionados y despues abro una conexion a la base de datos 
        y con un for de las posciones que recolecte, creo un objeto y le ingreso los datos que el usuario
        selecciono y gracias a esas posiciones puedo saber a cual objeto hacen referencia
         */
        public void agregarAlumnosAGrupos(ListView lstAlumnos, ComboBox comNiveles, ComboBox comGrupo)
        {
            int[] posiciones = Seleccionados(lstAlumnos);
            if (( posiciones != null && posiciones.Length>0) && (comGrupo.Text != "") && comNiveles.Text != "")
            {
                using (Models.vhmexEntities db = new vhmexEntities())
                {
                    for (int i = 0; i < posiciones.Length; i++)
                    {
                        AlumnoGrupo alumnoGrupo = new AlumnoGrupo();
                        alumnoGrupo.idAlumno = alumnos[posiciones[i]].idAlumno;
                        alumnoGrupo.idGradoGrupo = GradosGrupos[comGrupo.SelectedIndex].idGradoGrupo;
                        db.AlumnoGrupo.Add(alumnoGrupo);
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                MessageBox.Show("Verique que tenga seleccionado alumnos, nivel y grupo");
            }
        }


    }
}
