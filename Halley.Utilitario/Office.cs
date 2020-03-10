using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
namespace Halley.Utilitario
{
    public class Office
    {
        StreamWriter w;
        public int DoExcell(string ruta, DataTable DtCuerpo, string Titulo)
        {
            try
            {
                FileStream fs = new FileStream(ruta, FileMode.Create,
                                                FileAccess.ReadWrite);
                w = new StreamWriter(fs);
                EscribeCabecera(Titulo);
                Cuerpo(DtCuerpo);
                EscribePiePagina();
                w.Close();
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        private void EscribeCabecera(string Titulo)
        {
            StringBuilder html = new StringBuilder(); 
            html.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
            html.Append("<html>");
            html.Append("  <head>");
            html.Append("<title>www.rrv.com.pe/</title>");
            html.Append("<meta http-equiv=\"Content-Type\"content=\"text/html; charset=UTF-8\" />");
            html.Append("  </head>");
            html.Append("<body>");
            html.Append("<p>");
            html.Append("<table>");
            html.Append("<tr></tr>");
            html.Append("<tr style=\"font-weight: bold;font-size: 10px;color: white;color: #F7F8E0;\">");
            html.Append("<td></td> <td colspan=2 bgcolor=\"#084B8A\">" + Titulo + "</td>");
            html.Append("</tr>");
            html.Append("<tr></tr>");
            w.Write(html.ToString());
        }
  
        private void Cuerpo(DataTable DtCuerpo)
        {
            string bgColor1 = "", fontColor1 = "", bgColor2 = "", fontColor2 = "", bgColor3 = "", fontColor3 = "",  FilaAcu = "";
            Int16 Num = 0;

            //titulo de las columnas
            FilaAcu += "<tr>";
            for (int i=0;i<DtCuerpo.Columns.Count;i++)
            {
                FilaAcu += "<td {4} {5}>" + DtCuerpo.Columns[i].ColumnName + "</td>";
            }
            FilaAcu += "</tr>";

            //formato de celdas
            bgColor1 = " bgcolor=\"LightBlue\" ";
            fontColor1 = " style=\"font-size: 12px;color: black;\" ";
            bgColor3 = " bgcolor=\"#0080FF\" ";
            fontColor3 = " style=\"font-size: 12px;color: white;\" ";

            //aca se crea el cuerpo
            foreach (DataRow Dr in DtCuerpo.Rows)
            {
                FilaAcu += "<tr >";
                foreach (DataColumn Dc in DtCuerpo.Columns)
                {
                    //formato según el numero de fila
                    if (Num % 2 == 0)
                    {
                        FilaAcu += "<td {0} {1}>" + Dr[Dc].ToString() + "</td>";
                    }
                    else
                    {
                        FilaAcu += "<td {2} {3}>" + Dr[Dc].ToString() + "</td>";
                    }
                }
                Num++;
                FilaAcu += "</tr>";
            }
            w.Write(FilaAcu, bgColor1, fontColor1, bgColor2, fontColor2, bgColor3, fontColor3);
        }
  
        private void EscribePiePagina()
        {
            StringBuilder html = new StringBuilder();       
            html.Append("  </table>");
            html.Append("</p>");
            html.Append(" </body>");
            html.Append("</html>");
            w.Write(html.ToString());
        }

        

    }
}
