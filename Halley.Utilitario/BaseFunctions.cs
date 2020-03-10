using System;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using C1.Win.C1Chart;
using System.ComponentModel;

namespace Halley.Utilitario
{
    public class BaseFunctions
    {
        public string GetXML(DataTable table)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sr = new StringWriter(sb);
            XmlTextWriter tw = new XmlTextWriter(sr);
            table.WriteXml(tw);
            tw.Flush();
            tw.Close();
            sr.Flush();
            sr.Dispose();
            sr.Close();
            string result = sb.ToString();
            return result;

        }
        public string GetXML(DataSet dataSet)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sr = new StringWriter(sb);
            XmlTextWriter tw = new XmlTextWriter(sr);
            dataSet.WriteXml(tw);
            tw.Flush();
            tw.Close();
            sr.Flush();
            sr.Dispose();
            sr.Close();
            string result = sb.ToString();
            return result;

        }
        public byte[] Image2Bytes(Image img)
        {
            if (img != null)
            {
                string sTemp = Path.GetTempFileName();
                FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                //img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                img.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                fs.Position = 0;
                //
                int imgLength = Convert.ToInt32(fs.Length);
                byte[] bytes = new byte[imgLength];
                fs.Read(bytes, 0, imgLength);
                fs.Close();
                return bytes;
            }
            else
            { return null; }
        }

        public Image Bytes2Image(byte[] bytes)
        {
            if (bytes == null) return null;
            //
            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bm = null;
            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return bm;
        }

        //**************************************************************************************

        public Image GetImageFromByteArray(byte[] picData)
        {
            if (picData == null) return null;

            // is this is an embedded object?
            int bmData = (picData[0] == 0x15 && picData[1] == 0x1c) ? 78 : 0;

            // load the picture
            Image img = null;
            try
            {
                MemoryStream ms = new MemoryStream(picData, bmData, picData.Length - bmData);
                img = Image.FromStream(ms);
            }
            catch { }

            // return what we got
            return img;
        }

        //**************************************************************************************

        public void FillTreeView(TreeView objtreeView, int nodeParentID, DataTable _dt, TreeNode nodeParent)
        {
            DataView dvHijos = new DataView(_dt);
            dvHijos.RowFilter = "TablaPadreID=" + nodeParentID ;

            foreach (DataRowView drvHijos in dvHijos)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = drvHijos["Descripcion"].ToString();
                nuevoNodo.ImageIndex = Convert.ToInt32(drvHijos["Icono"]);
                nuevoNodo.SelectedImageIndex = Convert.ToInt32(drvHijos["Icono"]);
                nuevoNodo.Tag = drvHijos["Tag"].ToString();
                if (nodeParent == null)
                {
                    //nodeParent.StateImageIndex = 1;
                    nuevoNodo.NodeFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    objtreeView.Nodes.Add(nuevoNodo);
                }
                else
                {
                    nodeParent.Nodes.Add(nuevoNodo);
                }
                //nodeParent.ForeColor = Color.Black;  
                //nodeParent.BackColor = Color.Tomato; 
                FillTreeView(objtreeView,Convert.ToInt32(drvHijos["TablaID"]), _dt, nuevoNodo);
            }
        }

        public string Get_GUID()
        {
            System.Guid guid = System.Guid.NewGuid();
            string _newGUID = guid.ToString();
            return _newGUID;
        }

        public bool IsNull(object obj)
        {
            if (obj.GetType().FullName == "System.DBNull")
            { return true; }
            else
            { return false; }
        }

        public bool DateIsNull(string obj)
        {
            if (obj == "01/01/0001 12:00:00 a.m.")
            { return true; }
            else
            { return false; }
        }
        
        public void SendToEmail(string SmtpServer, string content, string subject, string SupportEmail,string userEmail)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            //mail.From = new System.Net.Mail.MailAddress(SupportEmail); //Quien Envia
            mail.From = new System.Net.Mail.MailAddress("eloysilvav@hotmail.com"); //Quien Envia


            //mail.To.Add(userEmail);  //Mail de la persona a enviar
            mail.To.Add("rleon@aspi-systems.com");  //Mail de la persona a enviar

            mail.Body = content;
            mail.IsBodyHtml = true;
            mail.Priority = System.Net.Mail.MailPriority.High;  //Esto deberia evitar que los mails vayan al folder Junk-Email.            
           
            mail.Subject = subject;
            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient("aspi-systems.com");

                      
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Send(mail);
        }

        public bool ValPercent(decimal value)
        {
            bool _ret = false;
            if (value >= 0M && value <= 100M)
            {
                _ret = true;
            }
            else
            { _ret = false; }

            return _ret;
        }

        public string CadenaUnidadNegocio(string Cadena)
        {
            string cad = "";

            cad = Cadena.Substring(0, Cadena.Length - 1);

            return "(" + cad + ")";
        }

        public string CadenaString(string Cadena)
        {
            StringBuilder _cadena = new StringBuilder();

            _cadena.Append("'");
            _cadena.Append(Cadena);
            _cadena.Append("'");
            _cadena.Append(",");

            return _cadena.ToString();
        }

        public DataTable SelectDistinct(DataTable SourceTable, params string[] FieldNames)
        {
            object[] lastValues;
            DataTable newTable;
            DataRow[] orderedRows;

            if (FieldNames == null || FieldNames.Length == 0)
                throw new ArgumentNullException("FieldNames");

            lastValues = new object[FieldNames.Length];
            newTable = new DataTable();

            foreach (string fieldName in FieldNames)
                newTable.Columns.Add(fieldName, SourceTable.Columns[fieldName].DataType);

            orderedRows = SourceTable.Select("", string.Join(", ", FieldNames));

            foreach (DataRow row in orderedRows)
            {
                if (!fieldValuesAreEqual(lastValues, row, FieldNames))
                {
                    newTable.Rows.Add(createRowClone(row, newTable.NewRow(), FieldNames));

                    setLastValues(lastValues, row, FieldNames);
                }
            }

            return newTable;
        }


        private bool fieldValuesAreEqual(object[] lastValues, DataRow currentRow, string[] fieldNames)
        {
            bool areEqual = true;

            for (int i = 0; i < fieldNames.Length; i++)
            {
                if (lastValues[i] == null || !lastValues[i].Equals(currentRow[fieldNames[i]]))
                {
                    areEqual = false;
                    break;
                }
            }

            return areEqual;
        }

        private DataRow createRowClone(DataRow sourceRow, DataRow newRow, string[] fieldNames)
        {
            foreach (string field in fieldNames)
                newRow[field] = sourceRow[field];

            return newRow;
        }

        private static void setLastValues(object[] lastValues, DataRow sourceRow, string[] fieldNames)
        {
            for (int i = 0; i < fieldNames.Length; i++)
                lastValues[i] = sourceRow[fieldNames[i]];
        }

        public bool IsDate(string Expression)
        {
            bool isDate = true;

            try
            {
                DateTime dt = DateTime.Parse(Expression);
            }
            catch
            {
                isDate = false;
            }

            return isDate;
        }

        public DateTime ObtenerFechaUltimoDia(DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        } 

        public string ArmaMensaje(string Cliente, string Producto, string PeriodoBase)
        {
            StringBuilder _mensaje = new StringBuilder();
            _mensaje.Append("**************************** PRODUCTO AJUSTAR ******************************\n\n");
            _mensaje.Append("Cliente:\t{0}\n");
            _mensaje.Append("Producto:\t{1}\n");
            _mensaje.Append("PeriodoBase:\t{2}\n");
            
            string _cad = string.Empty;
            _cad = _mensaje.ToString();
            return string.Format(_cad,Cliente,Producto,PeriodoBase);

        }

        public string ArmaMensajeConsolidadoCompra(string Producto, string Via , string Cantidad, string FechaDespacho, string FechaLlegada, string Comentario)
        {
            StringBuilder _mensaje = new StringBuilder();
            _mensaje.Append("------------------------------------------------------------------------------------\n");
            _mensaje.Append("Producto:\t{0}\n");
            _mensaje.Append("Via:\t{1}\n");
            _mensaje.Append("Cantidad:\t{2}\n");
            _mensaje.Append("FechaDespacho:\t{3}\n");
            _mensaje.Append("FechaLlegada:\t{4}\n");
            _mensaje.Append("Comentario:\t{5}\n");
            
            string _cad = string.Empty;
            _cad = _mensaje.ToString();
            return string.Format(_cad, Producto, Via, Cantidad, FechaDespacho, FechaLlegada,Comentario);

        }

        public string ArmaMensajeCabeceraProveedor(string Proveedor)
        {
            StringBuilder _mensaje = new StringBuilder();
            _mensaje.Append("**************************** CONSOLIDADO PLAN COMPRAS ******************************\n\n");
            _mensaje.Append("Proveedor:\t{0}\n");
   
            string _cad = string.Empty;
            _cad = _mensaje.ToString();
            return string.Format(_cad, Proveedor);

        }

        public void BindSeries(C1Chart c1c, int series, object dataSource, string field, string labels)
        {
            try
            {
                ITypedList il = (ITypedList)dataSource;
                IList list = (IList)dataSource;
                if (list == null || il == null)
                    throw new ApplicationException("Datos no válidos en el objeto de origen");

                ChartDataSeriesCollection coll = c1c.ChartGroups[0].ChartData.SeriesList;
                while (series >= coll.Count)
                    coll.AddNewSeries();

                if (list.Count == 0) return;
                PointF[] data = (PointF[])Array.CreateInstance(typeof(PointF), list.Count);
                PropertyDescriptorCollection pdc = il.GetItemProperties(null);
                PropertyDescriptor pd = pdc[field];
                if (pd == null)
                    throw new ApplicationException(string.Format("Nombre no válido de campo utilizados para Y los valores ({0}).", field));

                int i;
                for (i = 0; i < list.Count; i++)
                {
                    data[i].X = i;
                    try
                    {
                        data[i].Y = float.Parse(pd.GetValue(list[i]).ToString());
                    }
                    catch
                    {
                        data[i].Y = float.NaN;
                    }
                    coll[series].PointData.CopyDataIn(data);
                    coll[series].Label = field;
                }

                if (labels != null && labels.Length > 0)
                {
                    pd = pdc[labels];
                    if (pd == null)
                        throw new ApplicationException(string.Format("Nombre no válido de campo utilizados para los valores de X ({0}).", labels));
                    Axis ax = c1c.ChartArea.AxisX;
                    ax.ValueLabels.Clear();
                    for (i = 0; i < list.Count; i++)
                    {
                        string label = pd.GetValue(list[i]).ToString();
                        ax.ValueLabels.Add(i, label);
                    }
                    ax.AnnoMethod = AnnotationMethodEnum.ValueLabels;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nMetodo : BindSeries()", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        
    }
}
