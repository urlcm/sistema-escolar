using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Controllers
{
    public class AltaGrupo
    {
        private List<Grado> grados;
        private List<Grupo> grupos;
        private List<nivel> niveles;

        //metodo para obtener los datos de grado, grupo y nivel
        public void ObtenerDatos()
        {
            using (Models.vhmexEntities db = new Models.vhmexEntities())
            {
                this.grados = db.Grado.ToList();
                this.grupos = db.Grupo.ToList();
                this.niveles = db.nivel.ToList();
            }
        }

        //cargo los datos que obtuve de la consulta al comboBox grados
        public void CargarGrados(ComboBox comGrados)
        {
            foreach (var grado in this.grados)
            {
                comGrados.Items.Add(grado.grado1);
            }
        }

        //cargo los datos que obtuve de la consulta al comboBox grupos
        public void CargarGrupos(ComboBox comGrupos)
        {
            foreach (var grupo in this.grupos)
            {
                comGrupos.Items.Add(grupo.Grupo1);
            }
        }

        //cargo los datos que obtuve de la consulta al comboBox nivel
        public void CargarNiveles(ComboBox comNiveles)
        {
            foreach (var nivel in this.niveles)
            {
                comNiveles.Items.Add(nivel.Nivel1);
            }
        }

        //este metodo no permite que el usuario pueda modificar los comboBox's
        public void NoModificar(ComboBox comGrados, ComboBox comGrupos, ComboBox comNiveles)
        {
            comGrados.DropDownStyle = ComboBoxStyle.DropDownList;
            comGrupos.DropDownStyle = ComboBoxStyle.DropDownList;
            comNiveles.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /*
         En este metodo lo que hago es abrir una conexion en la base de datos para recuperar los niveles, grados y grupos
        posteriomente guardo la informacion en la tabla grado_grupo y por ultimo la agrego a la tabla ciclo_escolar_grupo
         */
        public void AgregarGrupo(ComboBox grado, ComboBox grupo, ComboBox Nivel)
        {
            using (Models.vhmexEntities db = new Models.vhmexEntities())
            {
                Grado_Grupo gg = new Grado_Grupo
                {
                    idGrado = grado.SelectedIndex + 1,
                    idGrupo = grupo.SelectedIndex + 1,
                    idNivel = Nivel.SelectedIndex + 1,
                };
                db.Grado_Grupo.Add(gg);
                db.SaveChanges();
                CicloEscolarGrupo cEg = new CicloEscolarGrupo();
                cEg.idGradoGrupo = gg.idGradoGrupo;
                cEg.idCicloEscolar = ObtenerCicloEscolarActual().idCicloEscolar;
                db.CicloEscolarGrupo.Add(cEg);
                db.SaveChanges();
            }
        }

        /*
         Creo un metodo estatico para recuperar el ciclo Escolar Actual para asignarselo 
        al grupo
         */
        public static CicloEscolar ObtenerCicloEscolarActual()
        {
            using (Models.vhmexEntities db = new Models.vhmexEntities())
            {
                CicloEscolar cicloActual = db.CicloEscolar.Where(cA => cA.estado == 1).First();
                return cicloActual;
            }
        }
    }
}
