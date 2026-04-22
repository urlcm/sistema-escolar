using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEscolar
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Inicio inicio = new Inicio();
            inicio.Show();
            inicio.FormClosed += MainForm_Closed;


            //SesionAdmin sa = new SesionAdmin();
            //sa.Show();
            //sa.FormClosed += MainForm_Closed;

            //SesionAlumno sa = new SesionAlumno();
            //sa.Show();
            //sa.FormClosed += MainForm_Closed;

            //SesionCoordinador sc = new SesionCoordinador();
            //sc.Show();
            //sc.FormClosed += MainForm_Closed;

            Application.Run();
        }

        private static void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= MainForm_Closed;

            if (Application.OpenForms.Count == 0)
            {
                Application.ExitThread();
            }
            else
            {
                Application.OpenForms[0].FormClosed += MainForm_Closed;
            }
        }
    }
}
