using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Halley.CapaDatos.Almacen;
using Halley.Configuracion;
using System.Data;
using Halley.Utilitario;
using Halley.Entidad.Almacen;

namespace Halley.CapaLogica.Almacen
{
    public class CL_Kardex
    {
        public static string Name
        {
            get { return "Kardex"; }
        }

        public DataTable getKardex(string EmpresaID, string ProductoID, int TipoMovimiento, int UsuarioID,DateTime FechaInicial, DateTime FechaFinal)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Kardex.getKardex(EmpresaID, ProductoID, TipoMovimiento, UsuarioID,FechaInicial, FechaFinal);
            return dtTMP;

        }

        public DataTable getKardex2(DataTable dtTMP)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);

            decimal Cantidad=0, CantidadAcumulada=0, PrecioPonderado=0, CostoAcumulado=0;
            
            //Creamos tabla para ordenar los datos
            DataTable DtKardex = new DataTable("GetKardex");
            DtKardex.Columns.Add("ProductoID", typeof(string));
            DtKardex.Columns.Add("Producto", typeof(string));
            DtKardex.Columns.Add("UM", typeof(string));
            DtKardex.Columns.Add("Fecha", typeof(string));
            DtKardex.Columns.Add("Tipo", typeof(string));
            DtKardex.Columns.Add("Serie", typeof(string));
            DtKardex.Columns.Add("Numero", typeof(string));
            DtKardex.Columns.Add("Operacion", typeof(string));
            DtKardex.Columns.Add("ECantidad", typeof(decimal));
            DtKardex.Columns.Add("ECostoUnitario", typeof(decimal));
            DtKardex.Columns.Add("ECostoTotal", typeof(decimal));
            DtKardex.Columns.Add("SCantidad", typeof(decimal));
            DtKardex.Columns.Add("SCostoUnitario", typeof(decimal));
            DtKardex.Columns.Add("SCostoTotal", typeof(decimal));
            DtKardex.Columns.Add("FCantidad", typeof(decimal));
            DtKardex.Columns.Add("FCostoUnitario", typeof(decimal));
            DtKardex.Columns.Add("FCostoTotal", typeof(decimal));
            DtKardex.Columns.Add("KardexID", typeof(int));
            DtKardex.Columns.Add("TipoExistencia", typeof(string));
            DtKardex.Columns.Add("Tabla", typeof(string));

            //Seleccionamos disticnt de los productos
            DataTable DtProductos = new DataTable();
            DtProductos = dtTMP.DefaultView.ToTable(true, "ProductoID");

            foreach (DataRow DRP in DtProductos.Rows)
            {
                //filtramos datos por producto
                DataView Dv = new DataView(dtTMP, "ProductoID='" + DRP["ProductoID"].ToString() + "'", "AudCrea ASC", DataViewRowState.CurrentRows);

                foreach (DataRowView Dr in Dv)
                {
                    DataRow DR = DtKardex.NewRow();
                    DR["ProductoID"] = Dr["ProductoID"];
                    DR["Producto"] = Dr["Producto"];
                    DR["UM"] = Dr["UMContabilidad"];
                    DR["Fecha"] = Convert.ToDateTime(Dr["AudCrea"]).ToShortDateString();
                    DR["Tipo"] = Dr["TipoContabilidad"];
                    DR["Serie"] = Dr["Serie"];
                    DR["Numero"] = Dr["Numero"];
                    DR["Operacion"] = Dr["TipoOperacion"];
                    DR["TipoExistencia"] = Dr["TipoExistencia"];
                    

                    Cantidad = Convert.ToDecimal(Dr["Cantidad"]);


                    //validar si es entrada o salida
                    if (Dr["Tipo"].ToString() == "I")
                    {
                        PrecioPonderado = Convert.ToDecimal(Dr["PrecioUnitario"]);//temporal
                        CantidadAcumulada += Cantidad;
                        if (CantidadAcumulada != 0)
                        DR["ECantidad"] = Cantidad;
                        DR["ECostoUnitario"] = PrecioPonderado;
                        DR["ECostoTotal"] = Cantidad * PrecioPonderado;
                        CostoAcumulado += Cantidad * PrecioPonderado;
                        DR["SCantidad"] = DBNull.Value;
                        DR["SCostoUnitario"] = DBNull.Value;
                        DR["SCostoTotal"] = DBNull.Value;
                        DR["FCantidad"] = CantidadAcumulada;
                        if (CantidadAcumulada != 0)
                            PrecioPonderado = CostoAcumulado / CantidadAcumulada;//precio real nuevo
                        DR["FCostoUnitario"] = PrecioPonderado;
                        DR["FCostoTotal"] = CostoAcumulado;
                    }
                    else if (Dr["Tipo"].ToString() == "S" & (Dr["TipoOperacion"].ToString() == "01" | Dr["TipoOperacion"].ToString() == "10"))//salida por venta y por produccion
                    {
                        CantidadAcumulada -= Cantidad;
                        CostoAcumulado = CantidadAcumulada * PrecioPonderado;
                        DR["ECantidad"] = DBNull.Value;
                        DR["ECostoUnitario"] = DBNull.Value;
                        DR["ECostoTotal"] = DBNull.Value;
                        DR["SCantidad"] = Cantidad;
                        DR["SCostoUnitario"] = PrecioPonderado;
                        DR["SCostoTotal"] = Cantidad * PrecioPonderado;
                        DR["FCantidad"] = CantidadAcumulada;
                        if(CantidadAcumulada != 0)
                            PrecioPonderado = CostoAcumulado / CantidadAcumulada;
                        DR["FCostoUnitario"] = PrecioPonderado;
                        DR["FCostoTotal"] = CostoAcumulado;
                    }
                    else if (Dr["Tipo"].ToString() == "S")//otro tipo de salida
                    {
                        PrecioPonderado = Convert.ToDecimal(Dr["PrecioUnitario"]);//temporal
                        CantidadAcumulada -= Cantidad;
                        DR["ECantidad"] = DBNull.Value;
                        DR["ECostoUnitario"] = DBNull.Value;
                        DR["ECostoTotal"] = DBNull.Value;
                        DR["SCantidad"] = Cantidad;
                        DR["SCostoUnitario"] = PrecioPonderado;
                        DR["SCostoTotal"] = Cantidad * PrecioPonderado;
                        DR["FCantidad"] = CantidadAcumulada;
                        CostoAcumulado -= Cantidad * PrecioPonderado;
                        if (CantidadAcumulada != 0)
                            PrecioPonderado = CostoAcumulado / CantidadAcumulada;
                        DR["FCostoUnitario"] = PrecioPonderado;
                        DR["FCostoTotal"] = CostoAcumulado;
                    }
                    else if (Dr["Tipo"].ToString() == "A")//saldo inicial
                    {
                        PrecioPonderado = Convert.ToDecimal(Dr["PrecioUnitario"]);
                        CantidadAcumulada += Cantidad;
                        DR["ECantidad"] = DBNull.Value;
                        DR["ECostoUnitario"] = DBNull.Value;
                        DR["ECostoTotal"] = DBNull.Value;
                        CostoAcumulado += Cantidad * PrecioPonderado;
                        DR["SCantidad"] = DBNull.Value;
                        DR["SCostoUnitario"] = DBNull.Value;
                        DR["SCostoTotal"] = DBNull.Value;
                        DR["FCantidad"] = Cantidad;
                        DR["FCostoUnitario"] = PrecioPonderado;
                        DR["FCostoTotal"] = Cantidad * PrecioPonderado;
                    }
                    DR["KardexID"] = Dr["KardexID"];
                    DR["Tabla"] = Dr["Tabla"];
                    DtKardex.Rows.Add(DR);
                }
                Cantidad = 0; CantidadAcumulada = 0; PrecioPonderado = 0;
            }
            return DtKardex;

        }

        public DataTable getKardex_Producto(string ProductoID, string SedeID)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Kardex.getKardex_Producto(ProductoID, SedeID);
            return dtTMP;

        }


        public DataTable getDTKardex_varios(string ProductoID, string EmpresaID, DateTime FechaInicial, DateTime FechaFinal, string Sede, int Accion)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable("DtKardex");
            dtTMP = ObjCD_Kardex.getDTKardex2(ProductoID, EmpresaID, FechaInicial, FechaFinal, Sede, Accion);
            return dtTMP;

        }
        public void InsertDesperdicio(DataTable dtSalida, string AlmacenID, int TipoMovimiento, int UsuarioID)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);

            dtSalida.TableName = "Movimiento";
            string _xml = new BaseFunctions().GetXML(dtSalida).Replace("NewDataSet", "DocumentElement");
            string xml = _xml.Replace("Table", "Movimiento");

            ObjCD_Kardex.InsertDesperdicio(AlmacenID, TipoMovimiento, UsuarioID, xml);
        }

        public void InsertConsumo(DataTable dtConsumo, int UsuarioID)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);

            dtConsumo.TableName = "Consumo";
            string _xml = new BaseFunctions().GetXML(dtConsumo).Replace("NewDataSet", "DocumentElement");
            string xml = _xml.Replace("Table", "Consumo");

            ObjCD_Kardex.InsertConsumo(UsuarioID, xml);
        }

        public void UpdateXMLKardex(DataTable DTModificar)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);

            DTModificar.TableName = "Modificar";
            string _xml = new BaseFunctions().GetXML(DTModificar).Replace("NewDataSet", "DocumentElement");
            string xml = _xml.Replace("Table", "Modificar");

            ObjCD_Kardex.UpdateXMLKardex(xml);
        }

        public void UpdateXMLCierreMensual(DataTable DTModificar)
        {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);

            DTModificar.TableName = "Modificar";
            string _xml = new BaseFunctions().GetXML(DTModificar).Replace("NewDataSet", "DocumentElement");
            string xml = _xml.Replace("Table", "Modificar");

            ObjCD_Kardex.UpdateXMLCierreMensual(xml);
        }

         public DataTable GetTipoDocumento()
         {
            CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Kardex.GetTipoDocumento();
            return dtTMP;
         }
         public DataTable GetOperacionKardex()
         {
             CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
             DataTable dtTMP = new DataTable();

             dtTMP = ObjCD_Kardex.GetOperacionKardex();
             return dtTMP;
         }

         public DataTable GetMovimiento()
         {
             CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
             DataTable dtTMP = new DataTable();

             dtTMP = ObjCD_Kardex.GetMovimiento();
             return dtTMP;
         }

         public int InsertKardex(E_Kardex ObjE_Kardex,  DataTable DtKardex, string Tipo)
         {
             int KardexID = 0;
             CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
             DataTable dtTMP = new DataTable();

             string XML = "";

             if (Tipo == "M")
             {
                 string _xml = new BaseFunctions().GetXML(DtKardex).Replace("NewDataSet", "DocumentElement");
                 XML = _xml.Replace("Table", "Kardex");
             }

             KardexID = ObjCD_Kardex.InsertKardex(ObjE_Kardex, XML, Tipo);
             return KardexID;
         }

         public bool Existekardex(E_Kardex ObjE_Kardex)
         {
             bool Existe = true;
             CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
             DataTable dtTMP = new DataTable();

             Existe = ObjCD_Kardex.Existekardex(ObjE_Kardex);
             return Existe;
         }
         public int InsertCierreKardex(int Accion,int UsuarioID, string Almacen, string ProductoID, string EmpresaID, string Periodo, int Anno, bool CostoCero,decimal Cantidad2,decimal CostoUnitario)
         {
             int totalAfectados = 0;
             CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
             if (Accion == 1)
             {
                 
                 DataTable dtTMP = new DataTable();
                 if (CostoCero == false)
                 {

                     //aplicar la lógica del cierre en el reporte mensual
                     if (ProductoID == "TODOS")
                         ProductoID = "";


                     DateTime FecInicial, FecFinal;
                     FecInicial = new DateTime(Anno, Convert.ToInt16(Periodo), 1);
                     FecFinal = new DateTime(Anno, Convert.ToInt16(Periodo), 1).AddMonths(1);

                     dtTMP = new CL_Kardex().getDTKardex_varios(ProductoID, EmpresaID, FecInicial, FecFinal, Almacen, 2);

                     //buscar '0' en los valores, no deberia existir el '0'
                     DataView DVCero = new DataView(dtTMP, "PrecioUnitario = 0", "", DataViewRowState.CurrentRows);
                     if (DVCero.Count > 0)
                     {
                         throw new Exception("Hay " + DVCero.Count.ToString() + " costo(s) unitario igual a 0\n\nno se insertara ningun registro");
                     }

                     decimal Cantidad = 0, CantidadAcumulada = 0, PrecioPonderado = 0, CostoAcumulado = 0;

                     //UsuarioID
                     //Creamos tabla para ordenar los datos
                     DataTable DtKardex = new DataTable("GetKardex");
                     DtKardex.Columns.Add("ID", typeof(int)).AutoIncrement = true;
                     DtKardex.Columns.Add("ProductoID", typeof(string));
                     DtKardex.Columns.Add("FCantidad", typeof(decimal));
                     DtKardex.Columns.Add("FCostoUnitario", typeof(decimal));


                     //Seleccionamos disticnt de los productos
                     DataTable DtProductos = new DataTable();
                     DtProductos = dtTMP.DefaultView.ToTable(true, "ProductoID");

                     foreach (DataRow DRP in DtProductos.Rows)
                     {
                         //filtramos datos por producto
                         DataView Dv = new DataView(dtTMP, "ProductoID='" + DRP["ProductoID"].ToString() + "'", "AudCrea ASC", DataViewRowState.CurrentRows);

                         foreach (DataRowView Dr in Dv)
                         {
                             DataRow DR = DtKardex.NewRow();
                             DR["ProductoID"] = Dr["ProductoID"];

                             Cantidad = Convert.ToDecimal(Dr["Cantidad"]);

                             //validar si es entrada o salida
                             if (Dr["Tipo"].ToString() == "I")
                             {
                                 PrecioPonderado = Convert.ToDecimal(Dr["PrecioUnitario"]);//temporal
                                 CantidadAcumulada += Cantidad;
                                 CostoAcumulado += Cantidad * PrecioPonderado;
                                 DR["FCantidad"] = CantidadAcumulada;
                                 PrecioPonderado = CostoAcumulado / CantidadAcumulada;//precio real nuevo
                                 DR["FCostoUnitario"] = PrecioPonderado;
                             }
                             else if (Dr["Tipo"].ToString() == "S" & Dr["TipoOperacion"].ToString() == "01")//salida por venta
                             {
                                 CantidadAcumulada -= Cantidad;
                                 CostoAcumulado = CantidadAcumulada * PrecioPonderado;
                                 DR["FCantidad"] = CantidadAcumulada;
                                 PrecioPonderado = CostoAcumulado / CantidadAcumulada;
                                 DR["FCostoUnitario"] = PrecioPonderado;
                             }
                             else if (Dr["Tipo"].ToString() == "S")//otro tipo de salida
                             {
                                 PrecioPonderado = Convert.ToDecimal(Dr["PrecioUnitario"]);//temporal
                                 CantidadAcumulada -= Cantidad;
                                 DR["FCantidad"] = CantidadAcumulada;
                                 CostoAcumulado -= Cantidad * PrecioPonderado;
                                 PrecioPonderado = CostoAcumulado / CantidadAcumulada;
                                 DR["FCostoUnitario"] = PrecioPonderado;
                             }
                             else if (Dr["Tipo"].ToString() == "A")//saldo inicial
                             {
                                 PrecioPonderado = Convert.ToDecimal(Dr["PrecioUnitario"]);
                                 CantidadAcumulada += Cantidad;

                                 CostoAcumulado += Cantidad * PrecioPonderado;
                                 DR["FCantidad"] = Cantidad;
                                 DR["FCostoUnitario"] = PrecioPonderado;
                             }
                             DtKardex.Rows.Add(DR);
                         }
                         Cantidad = 0; CantidadAcumulada = 0; PrecioPonderado = 0;
                     }

                     //una ves creada la tabla, se debe capturar los totales y ordenarlos en otra tabla
                     //Creamos tabla para ordenar los datos


                     DataTable DTCierre = new DataTable("Cierre");
                     DTCierre.Columns.Add("ProductoID", typeof(string));
                     DTCierre.Columns.Add("Cantidad", typeof(decimal));
                     DTCierre.Columns.Add("CostoUnitario", typeof(decimal));
                     foreach (DataRow DRP in DtProductos.Rows)
                     {

                         //cacturar el ultimo valor agregado, ese sera el costo nuevo
                         DataView DV = new DataView(DtKardex, "ProductoID = '" + DRP["ProductoID"].ToString() + "'", "ID DESC", DataViewRowState.CurrentRows);
                         DataRow DR = DTCierre.NewRow();
                         DR["ProductoID"] = DRP["ProductoID"];
                         DR["Cantidad"] = DV[0]["FCantidad"];
                         DR["CostoUnitario"] = DV[0]["FCostoUnitario"];
                         DTCierre.Rows.Add(DR);
                     }
                     string XML = "";

                     string _xml = new BaseFunctions().GetXML(DTCierre).Replace("NewDataSet", "DocumentElement");
                     XML = _xml.Replace("Table", "Cierre");

                     //insercion masiva del kardex
                     totalAfectados = ObjCD_Kardex.InsertCierreKardex(Accion, XML, UsuarioID, null, null, EmpresaID, Periodo, Anno, false, Cantidad2, CostoUnitario);
                 }
                 else
                 {
                     string XML = "";
                     totalAfectados = ObjCD_Kardex.InsertCierreKardex(Accion, XML, UsuarioID, Almacen, ProductoID, EmpresaID, Periodo, Anno, CostoCero, Cantidad2, CostoUnitario);
                 }
             }
             else if (Accion == 2)
             {
                 //ingreso manual
                 totalAfectados = ObjCD_Kardex.InsertCierreKardex(Accion, "", UsuarioID, Almacen, ProductoID, EmpresaID, Periodo, Anno, CostoCero, Cantidad2, CostoUnitario);
             }
             return totalAfectados;
         }

         public void UpdateMovimiento(E_Movimiento ObjMovimiento, string Tipo)
         {
             CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
             ObjCD_Kardex.UpdateMovimiento(ObjMovimiento, Tipo);
         }

         public void InserMovimiento(E_Movimiento ObjMovimiento)
         {
             CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
             ObjCD_Kardex.InserMovimiento(ObjMovimiento);
         }

         public void UpdateOperacion(E_Operacion ObjOperacion, string Tipo)
         {
             CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
             ObjCD_Kardex.UpdateOperacion(ObjOperacion, Tipo);
         }

         public void InsertOperacion(E_Operacion ObjOperacion)
         {
             CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
             ObjCD_Kardex.InsertOperacion(ObjOperacion);
         }

         public void UpdateTipoDocumento(E_TipoDocumento ObjTipoDocumento, string Tipo)
         {
             CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
             ObjCD_Kardex.UpdateTipoDocumento(ObjTipoDocumento, Tipo);
         }

         public void InsertTipoDocumento(E_TipoDocumento ObjTipoDocumento)
         {
             CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
             ObjCD_Kardex.InsertTipoDocumento(ObjTipoDocumento);
         }
         
         public void DeleteKardex(int KardexID)
         {
             CD_Kardex ObjCD_Kardex = new CD_Kardex(AppSettings.GetConnectionString);
             ObjCD_Kardex.DeleteKardex(KardexID);
         }
    }
}
