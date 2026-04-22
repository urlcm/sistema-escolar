
using Microsoft.Office.Interop.Excel;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Controllers
{
    public class SesionAlumno
    {
        public Usuario usuario { get; set; }

        public void mostrarNombre(Usuario usuario)
        {

        }

        public void GenerarExcel(Alumno alumno)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;

            Workbook workbook = excelApp.Workbooks.Add();
            Worksheet worksheet = workbook.Sheets[1];
            CicloEscolar cicloActual = AltaGrupo.ObtenerCicloEscolarActual();

            Range rangeTitle = worksheet.Range["B1", "D1"];
            rangeTitle.Merge();
            rangeTitle.Value = alumno.Usuario.nombre + " " +alumno.Usuario.apellido;
            rangeTitle.Font.Bold = true;
            rangeTitle.Font.Size = 14;

            // Formato para las celdas A2 y B2 hasta D2
            Range rangePeriod = worksheet.Range["B2", "D2"];
            rangePeriod.Merge();
            rangePeriod.Value = cicloActual.periodo + " " +cicloActual.año;
            rangePeriod.Font.Bold = true;
            rangePeriod.Font.Size = 14;



            System.Data.DataTable data = GetYourData(alumno, cicloActual.idCicloEscolar);

            FillExcelWithData(worksheet, data);

            string tempFilePath = Path.GetTempFileName()+ ".xls";
            workbook.SaveAs(tempFilePath);
        }

        static System.Data.DataTable GetYourData(Alumno alumno, int cicloActual)
        {
            AlumnoActividad[] alumnoActividades;
            ExamenAlumno[] exaAL;
            TareaAlumno[] tareasAlumo;
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable.Columns.Add("Dato1", typeof(string));
            dataTable.Columns.Add("Dato2", typeof(string));
            dataTable.Columns.Add("Dato3", typeof(string));
            dataTable.Columns.Add("Dato4", typeof(string));

            // Ejemplo de datos de prueba
            dataTable.Rows.Add("Materia", "Actividad", "Puntos", "Valor");

            using (vhmexEntities db = new vhmexEntities())
            {
                alumnoActividades = db.AlumnoActividad
                .Include(a => a.Actividad)
                .Include(b => b.Actividad.DocenteMateria)
                .Include(c => c.Actividad.DocenteMateria.Materia)
                .Where(i => i.Alumno.idAlumno == alumno.idAlumno && i.idCicloEscolar == cicloActual)
                .ToArray();
                
                exaAL = db.ExamenAlumno
                .Include(a => a.Examen)
                .Include(b => b.Examen.DocenteMateria)
                .Include(c => c.Examen.DocenteMateria.Materia)
                .Where(i => i.Alumno.idAlumno == alumno.idAlumno && i.idCicloEscolar == cicloActual)
                .ToArray();

                tareasAlumo = db.TareaAlumno
                .Include(a => a.Tarea)
                .Include(b => b.Tarea.DocenteMateria)
                .Include(c => c.Tarea.DocenteMateria.Materia)
                .Where(i => i.Alumno.idAlumno == alumno.idAlumno && i.idCicloEscolar == cicloActual)
                .ToArray();
            }
            for (int i = 0; i < alumnoActividades.Length; i++)
            {
                dataTable.Rows.Add(alumnoActividades[i].Actividad.DocenteMateria.Materia.nombreMateria,
                    alumnoActividades[i].Actividad.Nombre, alumnoActividades[i].puntos,
                    alumnoActividades[i].Actividad.valor);
            }
            for (int i = 0; i < exaAL.Length; i++)
            {
                dataTable.Rows.Add(exaAL[i].Examen.DocenteMateria.Materia.nombreMateria,
                    exaAL[i].Examen.Nombre, exaAL[i].puntos,
                    exaAL[i].Examen.valor);
            }
            for (int i = 0; i < tareasAlumo.Length; i++)
            {
                dataTable.Rows.Add(tareasAlumo[i].Tarea.DocenteMateria.Materia.nombreMateria,
                tareasAlumo[i].Tarea.Nombre, tareasAlumo[i].puntos,
                 tareasAlumo[i].Tarea.valor);
            }
            // Agregar más filas según sea necesario

            return dataTable;
        }

        static void FillExcelWithData(Worksheet worksheet, System.Data.DataTable data)
        {
            int row = 3;
            foreach (DataRow dataRow in data.Rows)
            {
                int column = 1;
                foreach (var item in dataRow.ItemArray)
                {
                    worksheet.Cells[row, column] = item.ToString();
                    column++;
                }
                row++;
            }
        }

        //obtengo la posicion seleccionada de un padre en el listview
        public int PosicionSeleccionada(ListView lstPadre)
        {
            if (lstPadre.SelectedItems.Count > 0)
            {
                // Obtener el índice del elemento seleccionado
                int posicionSeleccionada = lstPadre.SelectedIndices[0];

                return posicionSeleccionada;
            }
            return -1;
        }

        //
        public void GenerarPDF(Alumno alumno)
        {
            //FileStream fs = new FileStream("C:\\Users\\Uriel Cruz\\OneDrive\\Documentos\\Materias UAT - 6to semestre\\Ingenieria de software\\Versiones\\SistemaEscolar", FileMode.CreateNew);
            //Document doc = new Document(PageSize.LETTER,5,5,7,7);
            //PdfWriter pw = PdfWriter.GetInstance(doc, fs);

            //doc.AddAuthor("VHMEX");
            //doc.AddTitle("NOSE");

            //iTextSharp.text.Font standarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            //doc.Add(new Paragraph("Boleta de calificaciones"));
            //doc.Add(Chunk.NEWLINE);

            //PdfPTable tbl = new PdfPTable(3);
            //tbl.WidthPercentage = 100;

            //PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", standarFont));
            //clNombre.BorderWidth = 0;
            //clNombre.BorderWidthBottom = 0.75f;

            //PdfPCell clMatera = new PdfPCell(new Phrase("Materia", standarFont));
            //clMatera.BorderWidth = 0;
            //clMatera.BorderWidthBottom = 0.75f;

            //PdfPCell clCalificacion = new PdfPCell(new Phrase("Ciclo", standarFont));
            //clCalificacion.BorderWidth = 0;
            //clCalificacion.BorderWidthBottom = 0.75f;

            //doc.Add(tbl);
            //doc.Close();
            //pw.Close();
            CicloEscolar CicloAnterior;
            AlumnoCalificacion[] alCal;
            using (vhmexEntities db = new vhmexEntities())
            {
                CicloAnterior = db.CicloEscolar.Where(i => i.estado == 2).FirstOrDefault();
                alCal = db.AlumnoCalificacion
                   .Include(c => c.Calificacion)
                   .Include(b => b.DocenteGrupo.DocenteMateria.Materia)
                   .Where(id => id.idAlumno == alumno.idAlumno && id.idCicloEscolar == CicloAnterior.idCicloEscolar).ToArray();
            }
            if (CicloAnterior != null)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;

                Workbook workbook = excelApp.Workbooks.Add();
                Worksheet worksheet = workbook.Sheets[1];

                Range rangeTitle = worksheet.Range["B1", "D1"];
                rangeTitle.Merge();
                rangeTitle.Value = alumno.Usuario.nombre + " " + alumno.Usuario.apellido;
                rangeTitle.Font.Bold = true;
                rangeTitle.Font.Size = 14;

                // Formato para las celdas A2 y B2 hasta D2
                Range rangePeriod = worksheet.Range["B2", "D2"];
                rangePeriod.Merge();
                rangePeriod.Value = CicloAnterior.periodo + " " + CicloAnterior.año;
                rangePeriod.Font.Bold = true;
                rangePeriod.Font.Size = 14;

                Range rangeAverage = worksheet.Range["B3", "D3"];
                rangeAverage.Merge();
                rangeAverage.Value = CicloAnterior.periodo + " " + CicloAnterior.año;
                rangeAverage.Font.Bold = true;
                rangeAverage.Font.Size = 14;

                System.Data.DataTable dataTable = new System.Data.DataTable();
                dataTable.Columns.Add("Dato1", typeof(string));
                dataTable.Columns.Add("Dato2", typeof(string));

                // Ejemplo de datos de prueba
                dataTable.Rows.Add("Materia", "Calificacion");
                for (int i = 0; i < alCal.Length; i++)
                {
                    dataTable.Rows.Add(alCal[i].DocenteGrupo.DocenteMateria.Materia.nombreMateria,
                        alCal[i].Calificacion.calificacion1);
                }

                int row = 3;
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    int column = 1;
                    foreach (var item in dataRow.ItemArray)
                    {
                        worksheet.Cells[row, column] = item.ToString();
                        column++;
                    }
                    row++;
                }
                string tempFilePath = Path.GetTempFileName() + ".xls";
                workbook.SaveAs(tempFilePath);
            }



        }

    }
}
