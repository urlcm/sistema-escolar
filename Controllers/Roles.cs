using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controllers
{
    public class Roles
    {

        /*
         Se comprueba que tipo de rol es el que esta ingresando una vez ya comprobado que existe 
        en la base de datos
         */
        public void comprobarRoles(UsuarioRol[] usuarioRols, Button btnAdmin, Button btnCoordinador, Button btnMaestro, Button btnPadre)
        {
            for (int i = 0; i < usuarioRols.Length; i++)
            {
                if (usuarioRols[i].idRol == 1)
                {
                    btnAdmin.Visible = true;
                }
                else if(usuarioRols[i].idRol == 2)
                {
                    btnCoordinador.Visible = true;
                }
                else if(usuarioRols[i].idRol == 3)
                {
                    btnMaestro.Visible = true;
                }
                else
                {
                    btnPadre.Visible = true;
                }
            }
        }

        /*
         Aqui una vez ejecutada el metodo el solo se veran los botonos dependiendo los roles que tenga 
        el usuario y este solo se vere cuando tenga mas de uno
         */
        public void HacerInvisibles(Button btnAdmin, Button btnCoordinador, Button btnMaestro, Button btnPadre)
        {
            btnAdmin.Visible = false;
            btnCoordinador.Visible = false;
            btnMaestro.Visible = false;
            btnPadre.Visible = false;
        }
    }
}
