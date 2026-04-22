using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Controllers
{
    public class SesionAdmin
    {
        public Usuario usuario { get; set; }
        private bool alumno;
        private bool padre;
        private bool maestro;
        private bool coordinador;
        private bool admin;
        private bool checado;

        /*
         Se dan de alta los roles mediante una condicion que nos ayuda a verificar
         si los checkbox fueron marcados si lo son agrega el rol sino manda un mensaje
         */
        public void DarDeAlta(string nombre, string apellido, string email, string password, ComboBox cboNivel)
        {
            if (this.checado)
            {
                using (Models.vhmexEntities db = new Models.vhmexEntities())
                {
                    Usuario user = new Usuario();
                    user.nombre = nombre;
                    user.apellido = apellido;
                    user.correo = email;
                    user.password = password;
                    db.Usuario.Add(user);
                    db.SaveChanges();
                    this.AsignarRol(user, cboNivel);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una o mas casillas");
            }
        }

        /*Mediante este metodo se asigna todos los roles que el usuario puede tener
         siempre y cuando el admin haya selecionado uno o mas de estos*/
        public void AsignarRol(Usuario user, ComboBox cboNivel)
        {
            using (Models.vhmexEntities db = new Models.vhmexEntities())
            {
                if (this.padre)
                {
                    db.UsuarioRol.Add(CrearObjetoUsuarioRol(user, 5));
                    db.PadreDeFamilia.Add(CrearObjetoPadre(user));
                }
                if (this.alumno)
                {
                    db.UsuarioRol.Add(CrearObjetoUsuarioRol(user, 4));
                    int nivel = ObtenerNivel(cboNivel);
                    Alumno al = (CrearObjetoAlumno(user, nivel));
                    db.Alumno.Add(al);
                    if (nivel < 4)
                    {
                        db.SaveChanges();
                        db.PadreAlumno.Add(CrearObjetoPadreAlumno(al));
                    }
                }
                if(this.maestro)
                {
                    db.UsuarioRol.Add(CrearObjetoUsuarioRol(user, 3));
                    db.Docente.Add(CrearObjetoDocente(user));
                }
                if(this.coordinador)
                {
                    db.UsuarioRol.Add(CrearObjetoUsuarioRol(user, 2));
                }
                if(this.admin)
                {
                    db.UsuarioRol.Add(CrearObjetoUsuarioRol(user, 1));
                }
                db.SaveChanges();
            }
        }
        
        //creo un objeto UsuarioRol mediante un método 
        public UsuarioRol CrearObjetoUsuarioRol(Usuario user, int idRol)
        {
            UsuarioRol ur = new UsuarioRol();
            ur.idUsuario = user.idUsuario;
            ur.idRol = idRol;
            return ur;
        }

        //Creo un objeto alumno mediante un método 
        public Alumno CrearObjetoAlumno(Usuario user, int nivel)
        {
            Alumno alumno = new Alumno();
            alumno.idUsuario = user.idUsuario;
            alumno.IdNivel = nivel;
            return alumno;
        }

        //creo un objeto padre de familia
        public PadreDeFamilia CrearObjetoPadre(Usuario user) 
        {
            PadreDeFamilia padreFamilia = new PadreDeFamilia
            {
                idUsuario = user.idUsuario
            };
            return padreFamilia;
        }
        //creo un objeto Docente
        public Docente CrearObjetoDocente(Usuario user)
        {
            Docente docente = new Docente
            {
                idUsuario = user.idUsuario
            };
            return docente;
        }

        public PadreAlumno CrearObjetoPadreAlumno(Alumno alum)
        {
            PadreAlumno pa = new PadreAlumno()
            {
                idAlumno = alum.idAlumno
            };
            return pa;
        }

        //Verifico que algunos de los checkbox del form esten marcados, si no, retornara falso y no lo dejará
        public bool VerificarCheckBox(CheckBox cbAlumno, CheckBox cbPadre, CheckBox cbMaestro, CheckBox cbCoordinador, CheckBox cbAdmin)
        {
            this.alumno = cbAlumno.Checked;
            this.padre = cbPadre.Checked;
            this.maestro = cbMaestro.Checked;
            this.coordinador = cbCoordinador.Checked;
            this.admin = cbAdmin.Checked;

            if(this.alumno || this.padre || this.maestro || this.coordinador || this.admin)
            {
                this.checado=true;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /*
         Una vez que se haya pasado por el metodo 
         */
        public void ValorDefault(CheckBox cbAlumno, CheckBox cbPadre, CheckBox cbMaestro, CheckBox cbCoordinador, CheckBox cbAdmin)
        {
            this.alumno = false;
            cbAlumno.Checked = false;
            this.padre = false;
            cbPadre.Checked = false;
            this.maestro = false;
            cbMaestro.Checked = false;
            this.coordinador = false;
            cbCoordinador.Checked = false ;
            this.admin = false;
            cbAdmin.Checked = false;
            this.checado = false;
        }

        /*
         Se obtienen todos los niveles disponibles
         */
        public int ObtenerNivel(ComboBox cboNivel)
        {
            int nivel;
            if (cboNivel.Text == "kinder")
                nivel = 1;
            else if (cboNivel.Text == "primaria")
                nivel = 2;
            else if (cboNivel.Text == "secundaria")
                nivel = 3;
            else
                nivel = 4;
            return nivel;
        }

        /*
         Se vacian los textbox para evitar que se vuelvan a duplicar los datos
         */
        public void vaciarTxt(TextBox txtNombre, TextBox txtApellido, TextBox txtcorreo, TextBox txtcontra)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtcorreo.Clear();
            txtcontra.Clear();
            txtNombre.Focus();
        }

        public void AcabarCiclo()
        {
            using (vhmexEntities db = new vhmexEntities())
            {
                CicloEscolar ca = db.CicloEscolar.Where(e => e.estado == 2).FirstOrDefault();
                if (ca != null)
                {
                    ca.estado = 4;
                    db.Entry(ca).State = System.Data.Entity.EntityState.Modified;
                }
                CicloEscolar cicloEscolar = AltaGrupo.ObtenerCicloEscolarActual();
                cicloEscolar.estado = 2;
                db.Entry(cicloEscolar).State = System.Data.Entity.EntityState.Modified;
                int id = cicloEscolar.idCicloEscolar;
                CicloEscolar ciclo = db.CicloEscolar.Find(id + 1);
                int Sinciclo = 0;
                while (ciclo == null || Sinciclo == 3)
                {
                    id++;
                    ciclo = db.CicloEscolar.Find(id);
                    Sinciclo++;
                }
                ciclo.estado = 1;
                db.SaveChanges();

                //List<Alumno> alumnosLista = db.Alumno.Where(a => a.AlumnoGrupo
                //.Any(b=> b.Grado_Grupo.CicloEscolarGrupo.Any(c=> c.idCicloEscolar == cicloEscolar.idCicloEscolar))).ToList();
                List<DocenteGrupo> Grupos = db.DocenteGrupo.Where(c => c.Grado_Grupo.CicloEscolarGrupo.Any(b => b.idCicloEscolar == cicloEscolar.idCicloEscolar) ).ToList();
                foreach (var grupo in Grupos)
                {
                    List<Alumno> alumnos = db.Alumno.Where(a => a.AlumnoGrupo.Any(ag => ag.idGradoGrupo == grupo.idGradoGrupo)).ToList();
                    if (alumnos.Count > 0)
                    {
                        foreach (var alumnoIndividual in alumnos)
                        {
                            Calificacion calificacion = new Calificacion
                            {
                                calificacion1 = -1
                            };
                            db.Calificacion.Add(calificacion);
                            db.SaveChanges();
                            AlumnoCalificacion alumnoCalificacion = new AlumnoCalificacion
                            {
                                idAlumno = alumnoIndividual.idAlumno,
                                idCalificacion = calificacion.idCalificacion,
                                idDocenteGrupo = grupo.idDocenteGrupo,
                                idCicloEscolar = cicloEscolar.idCicloEscolar
                            };
                            db.AlumnoCalificacion.Add(alumnoCalificacion);
                        }
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
