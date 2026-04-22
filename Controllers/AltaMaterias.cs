using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controllers
{
    public class AltaMaterias
    {
        public void AgregarMateria(String nombre)
        {
            using (Models.vhmexEntities db = new Models.vhmexEntities())
            {
                Materia materia = new Materia
                {
                    nombreMateria = nombre
                };
                db.Materia.Add(materia);
                db.SaveChanges();
            }
        }

        public void vaciarTxt(TextBox txt)
        {
            txt.Clear();
            txt.Focus();
        }
    }
}
