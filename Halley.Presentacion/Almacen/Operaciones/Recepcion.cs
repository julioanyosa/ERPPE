using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.CapaLogica.Compras;
using Halley.Configuracion;
using Halley.Utilitario;
using Halley.CapaLogica.Users;

namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class Recepcion : UITemplateAccess
    {
        #region Variables
        CL_HojaDespacho ObjCL_HojaDEspacho = new CL_HojaDespacho();
        CL_Almacen ObjCL_Almacen = new CL_Almacen();
        CL_GuiaRemision ObjCL_GuiaRemision = new CL_GuiaRemision();
        string NumHojaDespacho;
        DataTable DtRecepcionHojaDespacho;
        DataTable DTGuiaRemisionPeso;
        DataTable DtCabeceraOrdenCompra;
        DataTable DtDetalleOrdenCompra;
        bool TieneFactura = false;

        decimal Tara;
        decimal Neto;
        decimal Bruto;
        string NumGuiaRemision;
        string AlmacenExterno;

        decimal Bruto2 = 0;
        decimal Tara2 = 0;
        decimal Neto2 = 0;
        int NroJabas = 0;

        decimal Bruto3 = 0;
        decimal Tara3 = 0;
        decimal Neto3 = 0;

        string SedeId;
        string EmpresaID;
        string TipoR; //estado requrimi
        string TipoC; //estado OC
        string TipoF;//se usa para calcular el estado del requerimiento cuando la sede q recepciona la compra es la que hizo el requerimiento
        string NumOrdenCompra = "";
        private TextFunctions ObjTextFunctions = new TextFunctions();
        #endregion

        public Recepcion()
        {
            InitializeComponent();
        }

        private void Recepcion_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            //Obtener datos del usuario logueado
            SedeId = AppSettings.SedeID;
            EmpresaID = AppSettings.EmpresaID;
            BtnGrabarRecepcionPollo.Visible = false;
            BtnGrabarHojaDespacho.Visible = false;
        }


        private void TabRecepcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabRecepcion.SelectedIndex == 1)
            {
                //limpiar todo
                LblEmpresaProveedora.Text = "";
                LblEstado.Text = "";
                LblFechaEmision.Text = "";
                LblNomSede.Text = "";
                LblCondicionPago.Text = "";
                TxtFactura.ReadOnly = false;
                TxtSerie.ReadOnly = false;
                TxtFactura.Text = "";
                TxtSerie.Text = "";
                TxtFactura.ReadOnly = true;
                TxtSerie.ReadOnly = true;
                DataTable DtDetalleOrdenCompra = new DataTable();
                TdgDetalleOCReq.SetDataBinding(DtDetalleOrdenCompra, "", true);
                TdgCabeceraOC.SetDataBinding(DtDetalleOrdenCompra, "", true);
                BtnGrabarOrdenCompra.Visible = false;

            }
            if (TabRecepcion.SelectedIndex == 2)
            {
                this.c1SuperTooltip1.Show("<table><tr><td><parm><img src='res://Pollos_32x32.gif'></parm></td><td><b><parm>Ingresar Cantidad</parm></b></td></tr></table><parm><hr noshade size=1 style='margin:2' color=Darker></parm><div style='margin:1 12'><parm>  Aqui debe ingresar la cantidad<br>recibida de la guia de remisión.</parm></div><parm><hr noshade size=1 style='margin:2' color=Darker></parm><table><tr><td><parm><img src='res://pollito32x32.gif'></parm></td><td><b><parm>No debe ser cero</parm></b></td></tr></table>", this.TxtRecibiendo, 50, 0, 3000);
                BtnGrabarOrdenCompra.Visible = false;
            }
        }


        #region Recepcion Hoja de despacho
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TxtBuscar.Text != "" && (AppSettings.EmpresaID == TxtBuscar.Text.Substring(0, 2)))
            {
                Cursor = Cursors.WaitCursor;
                DtRecepcionHojaDespacho = new DataTable();
                DtRecepcionHojaDespacho = ObjCL_HojaDEspacho.GetRecepcionHojaDespacho(TxtBuscar.Text);
                NumHojaDespacho = TxtBuscar.Text;
                DtRecepcionHojaDespacho.Columns["Recibiendo"].ReadOnly = false;
                TdgRecepcionHojaDespacho.SetDataBinding(DtRecepcionHojaDespacho, "", true);
                this.TdgRecepcionHojaDespacho.Columns[8].Editor = this.c1NELith;// enlazar con control para que acepte solo numeros
                Cursor = Cursors.Default;
                if (DtRecepcionHojaDespacho.Rows.Count > 0)
                    BtnGrabarHojaDespacho.Visible = true;
                else
                    BtnGrabarHojaDespacho.Visible = false;
            }
        }

        private void BtnGrabarHojaDespacho_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            BtnGrabarHojaDespacho.Visible = false;
            #region Crear Tablas
            //tabla para actualizar el nuevo stock (agregar productos recepcionados)
            DataTable DtActuStockLocal = new DataTable();
            DtActuStockLocal.TableName = "StockAlmacen";
            DtActuStockLocal.Columns.Add("AlmacenID", typeof(string));
            DtActuStockLocal.Columns.Add("AlmacenExterno", typeof(string));
            DtActuStockLocal.Columns.Add("ProductoID", typeof(string));
            DtActuStockLocal.Columns.Add("Adicion", typeof(decimal));
            DtActuStockLocal.Columns.Add("NroDocumento", typeof(string));

            //tabla para Actualizar estado de la guia de remision
            DataTable DTActuEstaGR = new DataTable();
            DTActuEstaGR.TableName = "DetalleGuiaRemision";
            DTActuEstaGR.Columns.Add("NumGuiaRemision", typeof(string));
            DTActuEstaGR.Columns.Add("ProductoID", typeof(string));
            DTActuEstaGR.Columns.Add("NumRequerimiento", typeof(string));
            DTActuEstaGR.Columns.Add("CantidadRecibida", typeof(decimal));
            DTActuEstaGR.Columns.Add("EstadoID", typeof(int));

            //tabla para Actualizar estado del requerimiento
            DataTable DtActuEstadoReq = new DataTable();
            DtActuEstadoReq.TableName = "DetalleRequerimiento";
            DtActuEstadoReq.Columns.Add("NumRequerimiento", typeof(string));
            DtActuEstadoReq.Columns.Add("ProductoID", typeof(string));
            DtActuEstadoReq.Columns.Add("CantidadTransito", typeof(decimal));
            DtActuEstadoReq.Columns.Add("CantidadRecibida", typeof(decimal));
            DtActuEstadoReq.Columns.Add("EstadoID", typeof(int));
            #endregion

            foreach (DataRow Row in DtRecepcionHojaDespacho.Rows)//crear tabla para actualizar
            {
                if (Convert.ToDecimal(Row["Recibiendo"].ToString()) > 0)//si se altero la cantidad
                {
                    #region actualiza el stock local

                    DataRow DrR = DtActuStockLocal.NewRow();
                    /*validar que la sede que lo solicito es el mismo que lo va a recepcionar
                     y si no es lo recepcionara en el almacen por defecto*/
                    if (Row["AlmacenID"].ToString().Substring(2, 5) == AppSettings.SedeID)//el que requirio lo esta recepcionando
                        DrR["AlmacenID"] = Row["AlmacenID"];
                    else
                        DrR["AlmacenID"] = EmpresaID + SedeId + Row["Almacen"].ToString();

                    DrR["AlmacenExterno"] = Row["AlmacenID"];
                    DrR["ProductoID"] = Row["ProductoID"];
                    DrR["Adicion"] = Row["Recibiendo"];
                    DrR["NroDocumento"] = Row["NumGuiaRemision"];
                    DtActuStockLocal.Rows.Add(DrR);
                    #endregion

                    #region actualiza estado Guia Remision
                    DataRow DrGR = DTActuEstaGR.NewRow();
                    DrGR["NumGuiaRemision"] = Row["NumGuiaRemision"];
                    DrGR["ProductoID"] = Row["ProductoID"];
                    DrGR["NumRequerimiento"] = Row["NumRequerimiento"];
                    DrGR["CantidadRecibida"] = Row["Recibiendo"];
                    //obtener estado de la guia de remision
                    if (Convert.ToDecimal(Row["CantidadEnviada"].ToString()) == Convert.ToDecimal(Row["Recibiendo"].ToString()) + Convert.ToDecimal(TdgRecepcionHojaDespacho.Columns["CantidadRecibidaGR"].Value))
                        //DrGR["EstadoID"] = 5; //llego completo (RECEPCION COMPLETA)
                        DrGR["EstadoID"] = 11; // (cerrado)
                    else if (Convert.ToDecimal(Row["CantidadEnviada"].ToString()) > Convert.ToDecimal(Row["Recibiendo"].ToString()) + Convert.ToDecimal(TdgRecepcionHojaDespacho.Columns["CantidadRecibidaGR"].Value))
                        //DrGR["EstadoID"] = 4; //falta, algo ocurre aqui (RECEPCION PARCIAL)
                        DrGR["EstadoID"] = 11; //cerrado
                    DTActuEstaGR.Rows.Add(DrGR);
                    #endregion

                    #region actualiza estado Requerimiento

                    DataRow DrER = DtActuEstadoReq.NewRow();
                    DrER["NumRequerimiento"] = Row["NumRequerimiento"];
                    DrER["ProductoID"] = Row["ProductoID"];

                    //obtener estado del requerimiento
                    TipoR = "R";//es recepcion
                    if (AppSettings.SedeID == "001PU" && Row["AlmacenID"].ToString().Substring(2, 5) != AppSettings.SedeID) //si lo recepciono industria, LUEGO LLEGARA A SU DESTINO VERDADERO
                    {
                        if (Convert.ToDecimal(Row["CantidadSolicitada"].ToString()) == Convert.ToDecimal(Row["CantidadRecibida"].ToString()) + Convert.ToDecimal(Row["Recibiendo"].ToString()))
                            DrER["EstadoID"] = 7; //llego completo (RECEPCION COMPLETA INDUSTRIA)
                        else if (Convert.ToDecimal(Row["CantidadSolicitada"].ToString()) > Convert.ToDecimal(Row["CantidadRecibida"].ToString()) + Convert.ToDecimal(Row["Recibiendo"].ToString()))
                            DrER["EstadoID"] = 3; //falta,  (RECEPCION PARCIAL INDUSTRIA)
                        DrER["CantidadRecibida"] = 0;
                        DrER["CantidadTransito"] = 0;

                    }
                    else if (AppSettings.SedeID == "001PU" && Row["AlmacenID"].ToString().Substring(2, 5) == AppSettings.SedeID) //si lo recepciono industria pero lo solicito tambien industria
                    {
                        if (Convert.ToDecimal(Row["CantidadSolicitada"].ToString()) == Convert.ToDecimal(Row["CantidadRecibida"].ToString()) + Convert.ToDecimal(Row["Recibiendo"].ToString()))
                            DrER["EstadoID"] = 5; //llego completo (RECEPCION COMPLETA)
                        else if (Convert.ToDecimal(Row["CantidadSolicitada"].ToString()) > Convert.ToDecimal(Row["CantidadRecibida"].ToString()) + Convert.ToDecimal(Row["Recibiendo"].ToString()))
                            DrER["EstadoID"] = 4; //falta,  (RECEPCION PARCIAL)
                        DrER["CantidadRecibida"] = Row["Recibiendo"];
                        DrER["CantidadTransito"] = Row["CantidadTransito"];
                    }
                    else if (AppSettings.SedeID != "001PU" && Row["AlmacenID"].ToString().Substring(2, 5) == AppSettings.SedeID) //no lo solicito industria (Llego a su destino final)
                    {
                        if (Convert.ToDecimal(Row["CantidadSolicitada"].ToString()) == Convert.ToDecimal(Row["CantidadRecibida"].ToString()) + Convert.ToDecimal(Row["Recibiendo"].ToString()))
                            DrER["EstadoID"] = 5; //llego completo (RECEPCION COMPLETA)
                        else if (Convert.ToDecimal(Row["CantidadSolicitada"].ToString()) > Convert.ToDecimal(Row["CantidadRecibida"].ToString()) + Convert.ToDecimal(Row["Recibiendo"].ToString()))
                            DrER["EstadoID"] = 4; //falta, (RECEPCION PARCIAL)
                        DrER["CantidadRecibida"] = Row["Recibiendo"];
                        DrER["CantidadTransito"] = Row["CantidadTransito"];
                    }
                    DtActuEstadoReq.Rows.Add(DrER);
                    #endregion
                }//fin de si se altero la cantidad
            }

            #region agrupar para actualizar el stock local
            //Agrupar los productos apra almacenarlos
            DataTable DtProducto = new DataTable();
            DataTable DtActuStockLocal2 = new DataTable();
            DtActuStockLocal2.TableName = "StockAlmacen";
            DtActuStockLocal2.Columns.Add("AlmacenID", typeof(string));
            DtActuStockLocal2.Columns.Add("AlmacenExterno", typeof(string));
            DtActuStockLocal2.Columns.Add("ProductoID", typeof(string));
            DtActuStockLocal2.Columns.Add("Adicion", typeof(decimal));
            DtActuStockLocal2.Columns.Add("TipoComprobante", typeof(string));
            DtActuStockLocal2.Columns.Add("Serie", typeof(string));
            DtActuStockLocal2.Columns.Add("Numero", typeof(int));
            DtActuStockLocal2.Columns.Add("TipoOperacion", typeof(string));
            DtActuStockLocal2.Columns.Add("NroDocumento", typeof(string));
            DtProducto = new BaseFunctions().SelectDistinct(DtActuStockLocal, "ProductoID", "AlmacenID");
            foreach (DataRow RowP in DtProducto.Rows)
            {
                DataView Dv = new DataView(DtActuStockLocal);
                Dv.RowFilter = "ProductoID = '" + RowP["ProductoID"] + "' and AlmacenID = '" + RowP["AlmacenID"] + "'";
                decimal Suma = 0;
                foreach (DataRowView Drv in Dv) //sumar las cantidades por producto
                {
                    Suma += Convert.ToDecimal(Drv["Adicion"]);
                }
                DataRow DrR = DtActuStockLocal2.NewRow();
                DrR["AlmacenID"] = RowP["AlmacenID"];
                DrR["AlmacenExterno"] = Dv[0]["AlmacenExterno"];
                DrR["ProductoID"] = RowP["ProductoID"];
                DrR["Adicion"] = Suma;
                DrR["Serie"] = Dv[0]["NroDocumento"].ToString().Substring(2,3);
                DrR["Numero"] = Convert.ToInt32(Dv[0]["NroDocumento"].ToString().Substring(6));
                DrR["TipoOperacion"] = "11";
                DrR["NroDocumento"] = "09";
                DtActuStockLocal2.Rows.Add(DrR);
            }

            #endregion

            #region actualizar con XML
            if (DtActuStockLocal2.Rows.Count > 0 & DTActuEstaGR.Rows.Count > 0 & DtActuEstadoReq.Rows.Count > 0)
            {
                bool Valor;
                string xml1 = new BaseFunctions().GetXML(DtActuStockLocal2).Replace("NewDataSet", "DocumentElement");
                Valor = new CL_Almacen().UpdateXMLStockAlmacen(xml1, 4, AppSettings.UserID);
                string xml2 = new BaseFunctions().GetXML(DTActuEstaGR).Replace("NewDataSet", "DocumentElement");
                Valor = new CL_GuiaRemision().UpdateXMLDetalleGuiaRemision(xml2, "G");
                string xml3 = new BaseFunctions().GetXML(DtActuEstadoReq).Replace("NewDataSet", "DocumentElement");
                Valor = new CL_Requerimientos().UpdateXMLDetalleRequerimientoEstado(xml3, TipoR, AppSettings.UserID, AppSettings.SedeID);
                MessageBox.Show("Se guardo correctamente los datos", "Recepción", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion

            DtRecepcionHojaDespacho.Rows.Clear();//borrar datos de la hoja de despacho
            Cursor = Cursors.Default;
        }

        private void TdgRecepcionHojaDespacho_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
        {
            //validar que no se ingresa mas de lo enviado en la guia remision
            if (this.TdgRecepcionHojaDespacho.RowCount > 0)
            {
                decimal Val;
                Val = Convert.ToDecimal(TdgRecepcionHojaDespacho.Columns["CantidadEnviada"].Value) - Convert.ToDecimal(TdgRecepcionHojaDespacho.Columns["CantidadRecibidaGR"].Value);
                if (Convert.ToDecimal(TdgRecepcionHojaDespacho.Columns["Recibiendo"].Value) > Val)
                {
                    MessageBox.Show("Lo recibido no puede ser mayor a lo enviado, lo restante por recibir de la guia '" + TdgRecepcionHojaDespacho.Columns["NumGuiaRemision"].Value.ToString() + "' es : " + Val.ToString(), "aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    TdgRecepcionHojaDespacho.Columns["Recibiendo"].Value = 0;
                    e.Cancel = false;
                    return;
                }
            }
        }

        private void TdgRecepcionHojaDespacho_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {
            //habilitar si se puede modificar la columna de recibido
            switch (e.Column.DataColumn.DataField)
            {
                case "Recibiendo":
                    if (this.TdgRecepcionHojaDespacho[e.Row, "EstadoID"].ToString().Trim() == "9" | this.TdgRecepcionHojaDespacho[e.Row, "EstadoID"].ToString().Trim() == "5" | this.TdgRecepcionHojaDespacho[e.Row, "EstadoID"].ToString().Trim() == "11")
                    {
                        e.CellStyle.Locked = true;
                        break;
                    }
                    break;
            }
        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                BtnBuscar_Click(null, null);
            }
        }
        #endregion

        #region Recepcion Orden de compra
        private void BtnBuscarOrdenCompra_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //limpiar todo
            LblEmpresaProveedora.Text = "";
            LblEstado.Text = "";
            LblFechaEmision.Text = "";
            LblNomSede.Text = "";
            LblCondicionPago.Text = "";
            TxtFactura.ReadOnly = false;
            TxtSerie.ReadOnly = false;
            TxtSerie.Text = "";
            TxtFactura.Text = "";
            TxtFactura.ReadOnly = true;
            TxtSerie.ReadOnly = true;
            DtCabeceraOrdenCompra = new DataTable();
            DtDetalleOrdenCompra = new DataTable();
            TieneFactura = false;

            TdgCabeceraOC.SetDataBinding(DtDetalleOrdenCompra, "", true);
            TdgDetalleOCReq.SetDataBinding(DtDetalleOrdenCompra, "", true);

            if (TxtOrdenCompra.Text != "")
            {
                CL_OrdenCompra ObjCL_OrdenCompra = new CL_OrdenCompra();

                NumOrdenCompra = TxtOrdenCompra.Text;

                //traer datos de la cabecera
                DtCabeceraOrdenCompra = ObjCL_OrdenCompra.GetCabeceraRecepcionOrdenCompra(TxtOrdenCompra.Text);

                if (DtCabeceraOrdenCompra.Rows.Count > 0)
                {
                    BtnGrabarOrdenCompra.Visible = true;
                    LblEmpresaProveedora.Text = DtCabeceraOrdenCompra.Rows[0]["RazonSocial"].ToString();
                    LblEstado.Text = DtCabeceraOrdenCompra.Rows[0]["NomEstado"].ToString();
                    LblFechaEmision.Text = DtCabeceraOrdenCompra.Rows[0]["FechaEmision"].ToString();
                    LblNomSede.Text = DtCabeceraOrdenCompra.Rows[0]["NomSede"].ToString();
                    LblCondicionPago.Text = DtCabeceraOrdenCompra.Rows[0]["CondicionPago"].ToString();
                    TxtFactura.ReadOnly = false;
                    TxtSerie.ReadOnly = false;
                    if (DtCabeceraOrdenCompra.Rows[0]["FacturaProveedor"].ToString().Length == 11)
                    {
                        TxtFactura.Text = DtCabeceraOrdenCompra.Rows[0]["FacturaProveedor"].ToString().Substring(4);
                        TxtSerie.Text = DtCabeceraOrdenCompra.Rows[0]["FacturaProveedor"].ToString().Substring(0, 3);
                    }
                    if (TxtFactura.Text != "")
                    {
                        TxtFactura.ReadOnly = true;
                        TxtSerie.ReadOnly = true;
                        TieneFactura = true;
                    }
                    //traer detalles
                    DtDetalleOrdenCompra = ObjCL_OrdenCompra.GetRecepcionOrdenCompra(TxtOrdenCompra.Text, AppSettings.EmpresaID + AppSettings.SedeID);
                    DtDetalleOrdenCompra.Columns["Descripcion"].ReadOnly = false;
                    DtDetalleOrdenCompra.Columns["AlmacenID"].ReadOnly = false;
                    DtDetalleOrdenCompra.Columns["Recibiendo"].ReadOnly = false;

                    //extraer las cabeceras
                    DataTable DtCabeceraOC = new DataTable();
                    DtCabeceraOC = new BaseFunctions().SelectDistinct(DtDetalleOrdenCompra, "ProductoID", "NomProducto", "UnidadMedidaID", "CantidadOrdenada", "CantidadRecibida", "CantidadPendiente", "FechaRequerida", "FechaVencimiento", "Comentario", "EstadoID", "NomEstado");
                    TdgCabeceraOC.SetDataBinding(DtCabeceraOC,"",true);
                    
                    this.TdgDetalleOCReq.Columns[1].Editor = this.c1NELith;// enlazar con control para que acepte solo numeros
                }
                else
                    MessageBox.Show("El requerimiento Nro: " + TxtOrdenCompra.Text + " no existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            Cursor = Cursors.Default;
        }

        private void BtnGrabarOrdenCompra_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (DtDetalleOrdenCompra.Rows.Count > 0 & TxtFactura.Text != "" & TxtSerie.Text.Length == 3 & TxtSerie.Text != "")
            {
                
                BtnGrabarOrdenCompra.Visible = false;
                #region Crear Tablas
                //tabla para actualizar el nuevo stock (agregar productos recepcionados)
                DataTable DtActuStockLocal = new DataTable();
                DtActuStockLocal.TableName = "StockAlmacen";
                DtActuStockLocal.Columns.Add("AlmacenID", typeof(string));
                DtActuStockLocal.Columns.Add("ProductoID", typeof(string));
                DtActuStockLocal.Columns.Add("Adicion", typeof(decimal));


                //tabla para Actualizar estado de la orden de compra
                DataTable DtActuEstadoDOCSinUnificar = new DataTable();
                DtActuEstadoDOCSinUnificar.TableName = "DetalleOrdenCompraSU";
                DtActuEstadoDOCSinUnificar.Columns.Add("NumOrdenCompra", typeof(string));
                DtActuEstadoDOCSinUnificar.Columns.Add("ProductoID", typeof(string));
                DtActuEstadoDOCSinUnificar.Columns.Add("CantidadRecibidaR", typeof(decimal));
                DtActuEstadoDOCSinUnificar.Columns.Add("CantidadOrdenada", typeof(decimal));
                DtActuEstadoDOCSinUnificar.Columns.Add("CantidadRecibida", typeof(decimal));

                //tabla para Actualizar estado de la orden de compra
                DataTable DtActuEstadoDOC = new DataTable();
                DtActuEstadoDOC.TableName = "DetalleOrdenCompra";
                DtActuEstadoDOC.Columns.Add("NumOrdenCompra", typeof(string));
                DtActuEstadoDOC.Columns.Add("ProductoID", typeof(string));
                DtActuEstadoDOC.Columns.Add("CantidadRecibida", typeof(decimal));
                DtActuEstadoDOC.Columns.Add("EstadoID", typeof(int));


                //tabla para Actualizar estado del requerimiento
                DataTable DtActuEstadoReq = new DataTable();
                DtActuEstadoReq.TableName = "DetalleRequerimiento";
                DtActuEstadoReq.Columns.Add("NumRequerimiento", typeof(string));
                DtActuEstadoReq.Columns.Add("ProductoID", typeof(string));
                DtActuEstadoReq.Columns.Add("CantidadTransito", typeof(decimal));
                DtActuEstadoReq.Columns.Add("CantidadRecibida", typeof(decimal));
                DtActuEstadoReq.Columns.Add("EstadoID", typeof(int));
                #endregion

                foreach (DataRow Row in DtDetalleOrdenCompra.Rows)//crear tabla para actualizar
                {
                    if (Convert.ToDecimal(Row["Recibiendo"].ToString()) > 0)//si se altero la cantidad
                    {
                        #region actualiza el stock local

                        DataRow DrR = DtActuStockLocal.NewRow();
                        if (Row["AlmacenID"].ToString().Substring(2, 5) == AppSettings.SedeID) //si la empresa que hizo el requerimiento de compra, es la misma que recepciona la compra
                            DrR["AlmacenID"] = Row["AlmacenID"];
                        else
                            DrR["AlmacenID"] = AppSettings.EmpresaID + AppSettings.SedeID + Row["Almacen"].ToString();

                        DrR["ProductoID"] = Row["ProductoID"];
                        DrR["Adicion"] = Row["Recibiendo"];
                        DtActuStockLocal.Rows.Add(DrR);
                        #endregion

                        #region actualiza estado Requerimiento (en caso de que el receptor de la OC es el mismo que hizo el req)
                        //obtener estado del requerimiento
                        TipoC = "E";//es recepcion
                        if (Row["AlmacenID"].ToString().Substring(2, 5) == AppSettings.SedeID) //si la empresa que hizo el requerimiento de compra, es la misma que recepciona la compra
                        {
                            DataRow DrER = DtActuEstadoReq.NewRow();
                            DrER["NumRequerimiento"] = Row["NumRequerimiento"];
                            DrER["ProductoID"] = Row["ProductoID"];
                            if (Convert.ToDecimal(Row["CantidadSolicitadaR"].ToString()) == Convert.ToDecimal(Row["CantidadRecibidaR"].ToString()) + Convert.ToDecimal(Row["Recibiendo"].ToString()))
                                DrER["EstadoID"] = 5; //llego completo (RECEPCION COMPLETA)
                            else if (Convert.ToDecimal(Row["CantidadSolicitadaR"].ToString()) > Convert.ToDecimal(Row["CantidadRecibidaR"].ToString()) + Convert.ToDecimal(Row["Recibiendo"].ToString()))
                                DrER["EstadoID"] = 4; //falta, (RECEPCION PARCIAL)
                            DrER["CantidadRecibida"] = Row["Recibiendo"];
                            DrER["CantidadTransito"] = Row["CantidadTransitoR"];
                            DtActuEstadoReq.Rows.Add(DrER);
                        }
                        
                        #endregion


                        #region acumular estado Detalle OC

                        DataRow DrEOCS = DtActuEstadoDOCSinUnificar.NewRow();
                        DrEOCS["NumOrdenCompra"] = NumOrdenCompra;
                        DrEOCS["ProductoID"] = Row["ProductoID"];
                        DrEOCS["CantidadRecibidaR"] = Row["Recibiendo"];
                        DrEOCS["CantidadOrdenada"] = Row["CantidadOrdenada"];
                        DrEOCS["CantidadRecibida"] = Row["CantidadRecibida"];
                        DtActuEstadoDOCSinUnificar.Rows.Add(DrEOCS);
                        #endregion
                        

                    }//fin de si se altero la cantidad
                }


                #region actualiza estado Detalle OC
                //agrupar los detalles de las OC para calcular estado OC
                DataTable DtAgrupadoDOC = new DataTable();
                DtAgrupadoDOC = new BaseFunctions().SelectDistinct(DtActuEstadoDOCSinUnificar, "NumOrdenCompra", "ProductoID", "CantidadOrdenada", "CantidadRecibida");

                foreach (DataRow DrA in DtAgrupadoDOC.Rows)
                {
                    TipoF = "F";
                    Decimal Recibiendo = 0;
                    DataRow DrEOC = DtActuEstadoDOC.NewRow();
                    DrEOC["NumOrdenCompra"] = NumOrdenCompra;
                    DrEOC["ProductoID"] = DrA["ProductoID"];

                    //agrupar las cantidades
                    DataView Dv = new DataView(DtActuEstadoDOCSinUnificar);
                    Dv.RowFilter = "NumOrdenCompra = '" + NumOrdenCompra + "' and ProductoID = '" + DrA["ProductoID"] + "'";
                    foreach (DataRowView Drv in Dv)
                    {
                        Recibiendo += Convert.ToDecimal(Drv["CantidadRecibidaR"]);
                    }

                    //obtener estado del detalle de la orden de compra
                    if (Convert.ToDecimal(DrA["CantidadOrdenada"].ToString()) == Convert.ToDecimal(DrA["CantidadRecibida"].ToString()) + Recibiendo)
                        DrEOC["EstadoID"] = 5; //llego completo (RECEPCION COMPLETA)
                    else if (Convert.ToDecimal(DrA["CantidadOrdenada"].ToString()) > Convert.ToDecimal(DrA["CantidadRecibida"].ToString()) + Recibiendo)
                        DrEOC["EstadoID"] = 4; //falta, (RECEPCION PARCIAL)
                    DrEOC["CantidadRecibida"] = Recibiendo;

                    DtActuEstadoDOC.Rows.Add(DrEOC);
                }



                #endregion

                #region agrupar para actualizar el stock local
                //Agrupar los productos apra almacenarlos
                DataTable DtProducto = new DataTable();
                DataTable DtActuStockLocal2 = new DataTable();
                DtActuStockLocal2.TableName = "StockAlmacen";
                DtActuStockLocal2.Columns.Add("AlmacenID", typeof(string));
                DtActuStockLocal2.Columns.Add("AlmacenExterno", typeof(string));
                DtActuStockLocal2.Columns.Add("ProductoID", typeof(string));
                DtActuStockLocal2.Columns.Add("Adicion", typeof(decimal));
                DtActuStockLocal2.Columns.Add("TipoComprobante", typeof(string));
                DtActuStockLocal2.Columns.Add("Serie", typeof(string));
                DtActuStockLocal2.Columns.Add("Numero", typeof(int));
                DtActuStockLocal2.Columns.Add("TipoOperacion", typeof(string));
                DtProducto = new BaseFunctions().SelectDistinct(DtActuStockLocal, "ProductoID", "AlmacenID");
                foreach (DataRow RowP in DtProducto.Rows)
                {
                    DataView Dv = new DataView(DtActuStockLocal);
                    Dv.RowFilter = "ProductoID = '" + RowP["ProductoID"] + "' and AlmacenID = '" + RowP["AlmacenID"] + "'";
                    decimal Suma = 0;
                    foreach (DataRowView Drv in Dv) //sumar las cantidades por producto
                    {
                        Suma += Convert.ToDecimal(Drv["Adicion"]);
                    }
                    DataRow DrR = DtActuStockLocal2.NewRow();
                    DrR["AlmacenID"] = RowP["AlmacenID"];
                    DrR["AlmacenExterno"] = DBNull.Value;
                    DrR["ProductoID"] = RowP["ProductoID"];
                    DrR["Adicion"] = Suma;
                    DrR["TipoComprobante"] = "01";
                    DrR["Serie"] = TxtSerie.Text;
                    DrR["Numero"] = Convert.ToInt32(TxtFactura.Text);
                    DrR["TipoOperacion"] = "02";
                    DtActuStockLocal2.Rows.Add(DrR);
                }

                #endregion

                #region actualizar con XML
                if (DtActuStockLocal2.Rows.Count > 0 & DtActuEstadoDOC.Rows.Count > 0)
                {
                    bool Valor;
                    string xml = new BaseFunctions().GetXML(DtActuStockLocal2).Replace("NewDataSet", "DocumentElement");
                    Valor = new CL_Almacen().UpdateXMLStockAlmacen(xml, 3, AppSettings.UserID);
                    string xml2 = new BaseFunctions().GetXML(DtActuEstadoDOC).Replace("NewDataSet", "DocumentElement");
                    Valor = new CL_OrdenCompra().UpdateXMLDetalleOCEstado(xml2, TipoC);
                    string xml3 = new BaseFunctions().GetXML(DtActuEstadoReq).Replace("NewDataSet", "DocumentElement");
                    Valor = new CL_Requerimientos().UpdateXMLDetalleRequerimientoEstado(xml3, TipoF, AppSettings.UserID, AppSettings.SedeID);
                    #region Actualizar factura
                    if (TieneFactura == false)
                    {
                        bool v;
                        v = new CL_OrdenCompra().UpdateFacturaOC(NumOrdenCompra, TxtSerie.Text + "-" + Convert.ToInt32(TxtFactura.Text).ToString("0000000"), AppSettings.UserID, AppSettings.SedeID);
                        if (v == false)
                            MessageBox.Show("Ocurrio un error al intentar actualizar el numero de factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion
                    MessageBox.Show("Se almacenó correctamente los datos", "Recepción OC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                #endregion
                Cursor = Cursors.Default;
            }
            else
            {
                if (TxtFactura.Text == "")
                    this.c1SuperTooltip1.Show("<table><tr><td><parm><img src='res://Generate_32x32.gif'></parm></td><td><b><parm>Ingresar numero</parm></b></td></tr></table><parm><hr noshade size=1 style='margin:2' color=Darker></parm><div style='margin:1 12'><parm>Debe ingresar el número <br>de factura para que sea<br>almacenado</parm></div><parm><hr noshade size=1 style='margin:2' color=Darker></parm><table><tr><td><parm><img src='res://pollito32x32.gif'></parm></td><td><b><parm>No debe estar vacio</parm></b></td></tr></table>", this.TxtFactura, 50, 0, 3000);
                if (TxtSerie.Text == "")
                    this.c1SuperTooltip1.Show("<table><tr><td><parm><img src='res://Generate_32x32.gif'></parm></td><td><b><parm>Ingresar serie</parm></b></td></tr></table><parm><hr noshade size=1 style='margin:2' color=Darker></parm><div style='margin:1 12'><parm>Debe ingresar serie <br>de factura para que sea<br>almacenado</parm></div><parm><hr noshade size=1 style='margin:2' color=Darker></parm><table><tr><td><parm><img src='res://pollito32x32.gif'></parm></td><td><b><parm>No debe estar vacio</parm></b></td></tr></table>", this.TxtSerie, 50, 0, 3000);
                Cursor = Cursors.Default;
            }
        }

        private void TxtOrdenCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                BtnBuscarOrdenCompra_Click(null, null);
            }
        }

        #endregion

        #region Recepcion Peso
        private void BtnBuscarPeso_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            LimpiarREmisionPeso();
            if (TxtGuiaRemision.Text != "")
            {
                Tara2 = 0;
                Neto2 = 0;
                Bruto2 = 0;
                NroJabas = 0;
                DTGuiaRemisionPeso = new DataTable();
                DTGuiaRemisionPeso = ObjCL_GuiaRemision.GetRecepcionGuiaRemisionPeso(AppSettings.EmpresaID + TxtGuiaRemision.Text);
                if (DTGuiaRemisionPeso.Rows.Count > 0)
                {
                    ReadOnlyTxt(false);
                    NumGuiaRemision = DTGuiaRemisionPeso.Rows[0]["NumGuiaRemision"].ToString();
                    TxtAlmacenID.Text = DTGuiaRemisionPeso.Rows[0]["AlmacenID"].ToString();
                    TxtRequerimiento.Text = DTGuiaRemisionPeso.Rows[0]["NumRequerimiento"].ToString();
                    TxtCodigo.Text = DTGuiaRemisionPeso.Rows[0]["ProductoID"].ToString();
                    TxtProducto.Text = DTGuiaRemisionPeso.Rows[0]["NomProducto"].ToString();
                    TxtUM.Text = DTGuiaRemisionPeso.Rows[0]["UnidadMedidaID"].ToString();
                    TxtEstado.Text = DTGuiaRemisionPeso.Rows[0]["NomEstado"].ToString();
                    TxtSolicitado.Text = DTGuiaRemisionPeso.Rows[0]["CantidadSolicitada"].ToString();
                    TxtTransito.Text = DTGuiaRemisionPeso.Rows[0]["CantidadTransito"].ToString();
                    TxtRecibido.Text = DTGuiaRemisionPeso.Rows[0]["CantidadRecibida"].ToString();
                    TxtCantidadRecibidaGR.Text = DTGuiaRemisionPeso.Rows[0]["CantidadRecibidaGR"].ToString();
                    Neto = Convert.ToDecimal(DTGuiaRemisionPeso.Rows[0]["PesoNeto"].ToString());
                    Tara = Convert.ToDecimal(DTGuiaRemisionPeso.Rows[0]["PesoTara"].ToString());
                    Tara3 = Convert.ToDecimal(DTGuiaRemisionPeso.Rows[0]["PesoTaraRecibido"].ToString());
                    Neto3 = Convert.ToDecimal(DTGuiaRemisionPeso.Rows[0]["PesoNetoRecibido"].ToString());
                    TxtTara3.Value = Tara - Tara3;
                    TxtNeto3.Value = Neto - Neto3;
                    TxtCantidadEnviada.Text = DTGuiaRemisionPeso.Rows[0]["CantidadEnviada"].ToString();
                    TxtNroJabas.Text = DTGuiaRemisionPeso.Rows[0]["NroJabas"].ToString();
                    AlmacenExterno = DTGuiaRemisionPeso.Rows[0]["AlmacenOrigen"].ToString();
                    TxtNroJabas2.Value = NroJabas;
                    TxtTara.Text = Tara.ToString();
                    TxtNeto.Text = Neto.ToString();
                    Bruto = Neto + Tara;
                    TxtBruto.Text = Bruto.ToString();
                    TxtRecibiendo.Value = "";
                    TxtBruto3.Value = Convert.ToDecimal(TxtTara3.Value) + Convert.ToDecimal(TxtNeto3.Value);
                    ReadOnlyTxt(true);

                    //ocultar el boton "grabar" segun el estado
                    int Val;
                    Val = Convert.ToInt16(DTGuiaRemisionPeso.Rows[0]["EstadoID"]);//estado de la guia
                    if (Val == 4 | Val == 2)
                    {
                        BtnGrabarRecepcionPollo.Visible = true;
                        TxtRecibiendo.Visible = true;
                        BtnBalanza.Visible = true;
                        RbPeso.Visible = true;
                        RbTara.Visible = true;
                    }
                    else
                    {
                        BtnGrabarRecepcionPollo.Visible = false;
                        TxtRecibiendo.Visible = false;
                        BtnBalanza.Visible = false;
                        RbPeso.Visible = false;
                        RbTara.Visible = false;
                    }
                }
                else
                {
                    LimpiarREmisionPeso();
                }
            }
            Cursor = Cursors.Default;
        }
        private void LimpiarREmisionPeso()
        {
            ReadOnlyTxt(false);
            TxtAlmacenID.Text = "";
            TxtRequerimiento.Text = "";
            TxtCodigo.Text = "";
            TxtProducto.Text = "";
            TxtUM.Text = "";
            TxtEstado.Text = "";
            TxtSolicitado.Text = "";
            TxtTransito.Text = "";
            TxtRecibido.Text = "";
            TxtCantidadRecibidaGR.Text = "";
            Neto = 0;
            Tara = 0;
            Neto2 = 0;
            Tara2 = 0;
            Neto3 = 0;
            Tara3 = 0;
            TxtCantidadEnviada.Text = "";
            TxtTara.Text = Tara.ToString();
            TxtNeto.Text = Neto.ToString();
            Bruto = Neto + Tara;
            TxtBruto.Text = Neto.ToString();
            TxtTara2.Value = Tara2;
            TxtNeto2.Value = Neto2;
            TxtTara3.Value = Tara3;
            TxtNeto3.Value = Neto3;
            Bruto2 = Tara2 + Neto2;
            Bruto3 = Tara3 + Neto3;
            TxtBruto2.Value = Bruto2;
            TxtBruto3.Value = Bruto3;
            ReadOnlyTxt(true);

            BtnGrabarRecepcionPollo.Visible = false;
            TxtRecibiendo.Visible = false;
            BtnBalanza.Visible = false;
        }

        private void BtnGrabarRecepcionPollo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //validaR
            if (TxtRecibiendo.Text != "" & TxtTara2.Text != "" & TxtNeto2.Text != "" & TxtBruto2.Text != "" & TxtNroJabas2.Text != "")
            {
                BtnGrabarRecepcionPollo.Visible = false;
                BtnBalanza.Visible = false;
                RbTara.Visible = false;
                RbPeso.Visible = false;

                decimal Val;
                Val = Convert.ToDecimal(TxtCantidadEnviada.Text) - Convert.ToDecimal(TxtCantidadRecibidaGR.Text);
                if (Convert.ToDecimal(TxtRecibiendo.Text) <= Val)
                {
                    #region Crear Tablas
                    //tabla para actualizar el nuevo stock (agregar productos recepcionados)
                    DataTable DtActuStockLocal = new DataTable();
                    DtActuStockLocal.TableName = "StockAlmacen";
                    DtActuStockLocal.Columns.Add("AlmacenID", typeof(string));
                    DtActuStockLocal.Columns.Add("ProductoID", typeof(string));
                    DtActuStockLocal.Columns.Add("Adicion", typeof(decimal));

                    //tabla para Actualizar estado de la guia de remision
                    DataTable DTActuEstaGR = new DataTable();
                    DTActuEstaGR.TableName = "DetalleGuiaRemision";
                    DTActuEstaGR.Columns.Add("NumGuiaRemision", typeof(string));
                    DTActuEstaGR.Columns.Add("ProductoID", typeof(string));
                    DTActuEstaGR.Columns.Add("NumRequerimiento", typeof(string));
                    DTActuEstaGR.Columns.Add("PesoNetoRecibido", typeof(decimal));
                    DTActuEstaGR.Columns.Add("PesoTaraRecibido", typeof(decimal));
                    DTActuEstaGR.Columns.Add("CantidadRecibida", typeof(decimal));
                    DTActuEstaGR.Columns.Add("EstadoID", typeof(int));

                    //tabla para Actualizar estado del requerimiento
                    DataTable DtActuEstadoReq = new DataTable();
                    DtActuEstadoReq.TableName = "DetalleRequerimiento";
                    DtActuEstadoReq.Columns.Add("NumRequerimiento", typeof(string));
                    DtActuEstadoReq.Columns.Add("ProductoID", typeof(string));
                    DtActuEstadoReq.Columns.Add("CantidadTransito", typeof(decimal));
                    DtActuEstadoReq.Columns.Add("CantidadRecibida", typeof(decimal));
                    DtActuEstadoReq.Columns.Add("EstadoID", typeof(int));
                    #endregion

                    #region actualiza el stock local

                    DataRow DrR = DtActuStockLocal.NewRow();
                    DrR["AlmacenID"] = EmpresaID + SedeId + TxtAlmacenID.Text.Substring(7, 3);
                    DrR["ProductoID"] = TxtCodigo.Text;
                    DrR["Adicion"] = Convert.ToDecimal(TxtRecibiendo.Text);
                    DtActuStockLocal.Rows.Add(DrR);
                    #endregion

                    #region actualiza estado Guia Remision
                    DataRow DrGR = DTActuEstaGR.NewRow();
                    DrGR["NumGuiaRemision"] = NumGuiaRemision;
                    DrGR["ProductoID"] = TxtCodigo.Text;
                    DrGR["NumRequerimiento"] = TxtRequerimiento.Text;
                    DrGR["CantidadRecibida"] = Convert.ToDecimal(TxtRecibiendo.Text);
                    DrGR["PesoNetoRecibido"] = Convert.ToDecimal(TxtNeto2.Text);
                    DrGR["PesoTaraRecibido"] = Convert.ToDecimal(TxtTara2.Text);
                    //obtener estado de la guia de remision
                    if (Convert.ToDecimal(TxtCantidadEnviada.Text) == Convert.ToDecimal(TxtRecibiendo.Text) + Convert.ToDecimal(TxtCantidadRecibidaGR.Text))
                        DrGR["EstadoID"] = 5; //llego completo (RECEPCION COMPLETA)
                    else if (Convert.ToDecimal(TxtCantidadEnviada.Text) > Convert.ToDecimal(TxtRecibiendo.Text) + Convert.ToDecimal(TxtCantidadRecibidaGR.Text))
                        DrGR["EstadoID"] = 4; //falta, algo ocurre aqui (RECEPCION PARCIAL)
                    DTActuEstaGR.Rows.Add(DrGR);
                    #endregion

                    #region actualiza estado Requerimiento

                    DataRow DrER = DtActuEstadoReq.NewRow();
                    DrER["NumRequerimiento"] = TxtRequerimiento.Text;
                    DrER["ProductoID"] = TxtCodigo.Text;

                    //obtener estado del requerimiento
                    TipoR = "R";//es peso

                    if (Convert.ToDecimal(TxtSolicitado.Text) == Convert.ToDecimal(TxtRecibido.Text) + Convert.ToDecimal(TxtRecibiendo.Text))
                        DrER["EstadoID"] = 5; //llego completo (RECEPCION COMPLETA)
                    else if (Convert.ToDecimal(Convert.ToDecimal(TxtSolicitado.Text)) > Convert.ToDecimal(TxtRecibido.Text) + Convert.ToDecimal(TxtRecibiendo.Text))
                        DrER["EstadoID"] = 4; //falta, (RECEPCION PARCIAL)
                    DrER["CantidadRecibida"] = Convert.ToDecimal(TxtRecibiendo.Text);
                    DrER["CantidadTransito"] = Convert.ToDecimal(TxtTransito.Text); //no es usado al momento de actualizar

                    DtActuEstadoReq.Rows.Add(DrER);
                    #endregion

                    #region agrupar para actualizar el stock local
                    //Agrupar los productos apra almacenarlos
                    DataTable DtProducto = new DataTable();
                    DataTable DtActuStockLocal2 = new DataTable();
                    DtActuStockLocal2.TableName = "StockAlmacen";
                    DtActuStockLocal2.Columns.Add("AlmacenID", typeof(string));
                    DtActuStockLocal2.Columns.Add("AlmacenExterno", typeof(string));
                    DtActuStockLocal2.Columns.Add("ProductoID", typeof(string));
                    DtActuStockLocal2.Columns.Add("Adicion", typeof(decimal));
                    DtActuStockLocal2.Columns.Add("TipoComprobante", typeof(string));
                    DtActuStockLocal2.Columns.Add("Serie", typeof(string));
                    DtActuStockLocal2.Columns.Add("Numero", typeof(int));
                    DtActuStockLocal2.Columns.Add("TipoOperacion", typeof(string));
                    DtProducto = new BaseFunctions().SelectDistinct(DtActuStockLocal, "ProductoID", "AlmacenID");
                    foreach (DataRow RowP in DtProducto.Rows)
                    {
                        DataView Dv = new DataView(DtActuStockLocal);
                        Dv.RowFilter = "ProductoID = '" + RowP["ProductoID"] + "' and AlmacenID = '" + RowP["AlmacenID"] + "'";
                        decimal Suma = 0;
                        foreach (DataRowView Drv in Dv) //sumar las cantidades por producto
                        {
                            Suma += Convert.ToDecimal(Drv["Adicion"]);
                        }
                        DataRow DrS = DtActuStockLocal2.NewRow();
                        DrS["AlmacenID"] = RowP["AlmacenID"];
                        DrS["AlmacenExterno"] = AlmacenExterno;
                        DrS["ProductoID"] = RowP["ProductoID"];
                        DrS["Adicion"] = Suma;
                        DrR["TipoComprobante"] = "09";
                        DrR["Serie"] = NumGuiaRemision.ToString().Substring(2, 3);
                        DrR["Numero"] = Convert.ToInt32(NumGuiaRemision.ToString().Substring(6));
                        DrR["TipoOperacion"] = "11";
                        DtActuStockLocal2.Rows.Add(DrS);
                    }

                    #endregion

                    #region actualizar con XML
                    if (DtActuStockLocal2.Rows.Count > 0 & DTActuEstaGR.Rows.Count > 0 & DtActuEstadoReq.Rows.Count > 0)
                    {
                        bool Valor;
                        string xml = new BaseFunctions().GetXML(DtActuStockLocal2).Replace("NewDataSet", "DocumentElement");
                        Valor = new CL_Almacen().UpdateXMLStockAlmacen(xml, 4, AppSettings.UserID);
                        string xml1 = new BaseFunctions().GetXML(DTActuEstaGR).Replace("NewDataSet", "DocumentElement");
                        Valor = new CL_GuiaRemision().UpdateXMLDetalleGuiaRemision(xml1, "P");
                        string xml2 = new BaseFunctions().GetXML(DtActuEstadoReq).Replace("NewDataSet", "DocumentElement");
                        Valor = new CL_Requerimientos().UpdateXMLDetalleRequerimientoEstado(xml2, TipoR, AppSettings.UserID, AppSettings.SedeID);
                        MessageBox.Show("Se guardo correctamente los datos", "Recepción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    #endregion
                }
                else
                    MessageBox.Show("Lo recibido no puede ser mayor a lo enviado, lo restante por recibir de la guia '" + TdgRecepcionHojaDespacho.Columns["NumGuiaRemision"].Value.ToString() + "' es : " + Val.ToString(), "aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("debe ingresar la cantidad recibida y haber pesado la recepción. ", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Cursor = Cursors.Default;
        }

        private void BtnBalanza_Click(object sender, EventArgs e)
        {
            Operaciones.Balanza ObjBalanza = new Operaciones.Balanza();
            if (RbPeso.Checked == true)
            {
                ObjBalanza.Titulo = "Peso bruto";
                ObjBalanza.VerCantidad = true;
            }
            else if (RbTara.Checked == true)
            {
                ObjBalanza.Titulo = "Peso Tara";
                ObjBalanza.VerCantidad = false;
            }

            ObjBalanza.ShowDialog();

            //agregar Peso segun el tipo
            if (RbPeso.Checked == true && ObjBalanza.Peso > 0 & ObjBalanza.Cantidad > 0)
            {
                Bruto2 += ObjBalanza.Peso;
                NroJabas += ObjBalanza.Cantidad; //calcular la cantidad de jabas enviadas
            }
            else if (RbTara.Checked == true && ObjBalanza.Peso > 0)
            {
                Tara2 += ObjBalanza.Peso;
            }
            else
                MessageBox.Show("No ingreso la cantidad, no se agregara el peso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Neto2 = Bruto2 - Tara2;

            TxtTara2.ReadOnly = false;
            TxtNeto2.ReadOnly = false;
            TxtBruto2.ReadOnly = false;
            TxtNroJabas2.ReadOnly = false;
            TxtNroJabas2.Value = NroJabas;
            TxtTara2.Value = Tara2;
            TxtNeto2.Value = Neto2;
            TxtBruto2.Value = Bruto2;
            TxtTara2.ReadOnly = true;
            TxtNeto2.ReadOnly = true;
            TxtBruto2.ReadOnly = true;
            TxtNroJabas2.ReadOnly = true;
        }

        private void RbTara_CheckedChanged(object sender, EventArgs e)
        {
            if (RbTara.Checked == true)
            {
                RbTara.BackColor = Color.Black;
                RbPeso.BackColor = Color.White;
            }
            if (RbPeso.Checked == true)
            {
                RbPeso.BackColor = Color.Black;
                RbTara.BackColor = Color.White;
            }
        }

        private void ReadOnlyTxt(bool Valor)
        {
            //habilitar controles
            TxtAlmacenID.ReadOnly = Valor;
            TxtRequerimiento.ReadOnly = Valor;
            TxtCodigo.ReadOnly = Valor;
            TxtProducto.ReadOnly = Valor;
            TxtUM.ReadOnly = Valor;
            TxtEstado.ReadOnly = Valor;
            TxtSolicitado.ReadOnly = Valor;
            TxtRecibido.ReadOnly = Valor;
            TxtTransito.ReadOnly = Valor;
            TxtRecibido.ReadOnly = Valor;
            TxtTara.ReadOnly = Valor;
            TxtNeto.ReadOnly = Valor;
            TxtBruto.ReadOnly = Valor;
            TxtCantidadRecibidaGR.ReadOnly = Valor;
            TxtCantidadEnviada.ReadOnly = Valor;
            TxtNroJabas.ReadOnly = Valor;
        }

        private void TxtGuiaRemision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                BtnBuscarPeso_Click(null, null);
            }
        }
        #endregion

        private void TxtRecibiendo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtRecibiendo);
        }

        private void TdgCabeceraOC_RowColChange(object sender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs e)
        {
            //obtener los detalles de la OC enlazados con el detalle del requrimiento
            DataView Dv = new DataView(DtDetalleOrdenCompra);
            Dv.RowFilter = "ProductoID = '" + TdgCabeceraOC.Columns["ProductoID"].Value.ToString() + "'";
            TdgDetalleOCReq.SetDataBinding(Dv, "", true);
        }

        private void TdgDetalleOCReq_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
        {
            //validar que no se ingresa mas de lo enviado en la orden de compra
            if (this.TdgDetalleOCReq.RowCount > 0)
            {
                decimal Val;
                //Val = Convert.ToDecimal(TdgOrdenCompra.Columns["CantidadOrdenadaR"].Value) - Convert.ToDecimal(TdgOrdenCompra.Columns["CantidadRecibida"].Value);
                Val = Convert.ToDecimal(TdgDetalleOCReq.Columns["CantidadSolicitadaR"].Value) + Convert.ToDecimal(TdgDetalleOCReq.Columns["CantidadTransitoR"].Value) + Convert.ToDecimal(TdgDetalleOCReq.Columns["CantidadRecibidaR"].Value);
                if (Val < Convert.ToDecimal(TdgDetalleOCReq.Columns["Recibiendo"].Value))
                {
                    MessageBox.Show("No se puede recepcionar mas de lo que se pidio en el requerimiento '" + TdgDetalleOCReq.Columns["NumRequerimiento"].Value.ToString() + "' es : " + Val.ToString(), "aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    TdgDetalleOCReq.Columns["Recibiendo"].Value = 0;
                    e.Cancel = false;
                    return;
                }
            }
        }

        private void TdgDetalleOCReq_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {
            //habilitar si se puede modificar la columna de recibido
            switch (e.Column.DataColumn.DataField)
            {
                case "Recibiendo":
                    if (this.TdgDetalleOCReq[e.Row, "EstadoID"].ToString().Trim() == "9" | this.TdgDetalleOCReq[e.Row, "EstadoID"].ToString().Trim() == "5" | this.TdgDetalleOCReq[e.Row, "EstadoIDR"].ToString().Trim() == "5" | this.TdgDetalleOCReq[e.Row, "EstadoIDR"].ToString().Trim() == "9")
                    {
                        e.CellStyle.Locked = true;
                        break;
                    }
                    break;
            }
        }

        private void TxtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtFactura);
        }

        private void BtnBuscadorOC_Click(object sender, EventArgs e)
        {
            FrmBuscarOC ObjFrmBuscarOC = new FrmBuscarOC();
            ObjFrmBuscarOC.ShowDialog();
            if (ObjFrmBuscarOC.NumOrdenCompra != "")
            {
                TxtOrdenCompra.Text = ObjFrmBuscarOC.NumOrdenCompra;
                BtnBuscarOrdenCompra_Click(null, null);
            }
            ObjFrmBuscarOC.Dispose();
        }

        /*private void TdgDetalleOCReq_AfterColUpdate(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            //actualizar los datos de la grilla principal de detalñles de la OC con Requerimientos
            decimal CantidadrecibidaOC = 0;
            CantidadrecibidaOC = Convert.ToDecimal(TdgDetalleOCReq.Columns["Recibiendo"].Value);
            DataRow[] customerRow = DtDetalleOrdenCompra.Select("NumOrdenCompra = '" + TdgCabeceraOC.Columns["NumOrdenCompra"].Value.ToString() + "' and ProductoID = '" + TdgCabeceraOC.Columns["ProductoID"].Value.ToString() + "' and AlmacenID = '" + TdgDetalleOCReq.Columns["AlmacenID"].Value.ToString() + "' and NumRequerimiento = '" + TdgDetalleOCReq.Columns["NumRequerimiento"].Value.ToString() + "'");
            customerRow[0]["Recibiendo"] = CantidadrecibidaOC;
        }*/


    }
}