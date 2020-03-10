using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.CapaLogica.Empresa;
using Halley.CapaLogica;
using Halley.Entidad.Almacen;
using Halley.Utilitario;
using Halley.Configuracion;

namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class Despacho : UITemplateAccess
    {
        public static DataTable DetallesRequerimientos = new DataTable();
        private static decimal PesoTotal;
        static DataTable DetallesRequerimientosAcu = new DataTable(); // creado para acumular todos los requerimientos
        private string NumGuiaRemision;
        private string NumGuiaTransportista;
        private string NumHojaDespacho;
        private string NroFactura;
        private string CamionEmpresaID;
        private string NomTransportista;
        private string EmpresaTransporte;
        private string RUCTransporte;
        private string Placa;

        private string SedeId;
        private string DomicilioPartida;
        private int NroDomicilioPartida;
        private int IntDomicilioPartida;
        private string ZonaDomicilioPartida;
        private string DisDomicilioPartida;
        private string ProvDomicilioPartida;
        private string DepDomicilioPartida;

        private DataTable DetalleGuiaRemision;
        private DataTable DetalleHojaDespacho;
        private DataTable DetalleHojaDespacho2;
        private DataTable DetalleGuiaTransporte;
        private DataTable DtFacturas;
        private DataTable DtVehiculos;
        private DataTable DtChoferes;
        private DataTable DtAlmacenes;
        private DataTable DtAlmacenUsuario;

        private DataTable DtEmpresas;
        
        private TextFunctions ObjTextFunctions = new TextFunctions();
        private Point _rowcol = Point.Empty;

        public Despacho()
        {
            InitializeComponent();
        }

        private void BtnRequerimientos_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Requemientos ObjRequerimientos = new Requemientos();
            ErrProvider.Clear();
                        
            if (CboSede.SelectedValue != null)
            {
                SedeId = CboSede.SelectedValue.ToString();
                ObjRequerimientos.DtAlmacenes = DtAlmacenes;
                ObjRequerimientos.EmpresaSede = AppSettings.EmpresaID + CboSede.SelectedValue.ToString();
                ObjRequerimientos.SedeId = SedeId;
                ObjRequerimientos.EmpresaIDUser = AppSettings.EmpresaID;

                if (RBTransferencia.Checked == true)
                    ObjRequerimientos.TipoRequerimiento = "T";
                else if (RbCompras.Checked == true)
                    ObjRequerimientos.TipoRequerimiento = "C";
                /*else if (RbAmbos.Checked == true)
                    ObjRequerimientos.TipoRequerimiento = "A";*/
                ObjRequerimientos.ShowDialog();


                //cargar en el detalle los productos enviados en la guia de remision
                TdgDetalleHojaDespacho.SetDataBinding(DetallesRequerimientos, "", true);
                this.TdgDetalleHojaDespacho.Columns[10].Editor = this.c1NELith;// enlazar con control para que acepte solo numeros
            }
            else
            {
                ErrProvider.SetError(CboSede, "Debe seleccionar primero una sede");
            }
            Cursor = Cursors.Default;
        }

        private void Despacho_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            
            DetallesRequerimientos.Clear(); //limpiar tabla static

            //obtener todas las sedes
            DataTable Dtsedes = new CL_Empresas().GetSedes();
            CboSede.HoldFields();
            CboSede.DataSource = Dtsedes;
            CboSede.DisplayMember = "NomSede";
            CboSede.ValueMember = "SedeID";

            //obtener todos los vehiculos
            DtVehiculos = new CL_Vehiculo().GetVehiculos();
            CboVehiculo.HoldFields();
            CboVehiculo.DataSource = DtVehiculos;
            CboVehiculo.DisplayMember = "Marca";
            CboVehiculo.ValueMember = "Placa";

            //Obtener todos los choferes
            DtChoferes = new CL_Choferes().GetChoferes();
            CboChofer.HoldFields();
            CboChofer.DataSource = DtChoferes;
            CboChofer.DisplayMember = "NomChofer";
            CboChofer.ValueMember = "ChoferID";

            //llenar combo sede destino
            DataTable DtsedesDes = new DataTable();
            DtsedesDes.Merge(Dtsedes);
            CboSedeDestino.HoldFields();
            CboSedeDestino.DataSource = DtsedesDes;
            CboSedeDestino.DisplayMember = "NomSede";
            CboSedeDestino.ValueMember = "SedeID";

            //traer todas las empresas
            DtEmpresas = new DataTable();
            DtEmpresas = new CL_Empresas().GetEmpresas();

                       
            //obtener la sede del usuario
            DtAlmacenUsuario = AppSettings.AlmacenPermisos;

            DomicilioPartida = AppSettings.NomSede;
            if (DtAlmacenUsuario.Rows[0]["Numero"] == DBNull.Value)
                NroDomicilioPartida = 0;
            else
                NroDomicilioPartida = Convert.ToInt16(DtAlmacenUsuario.Rows[0]["Numero"]);

            if (DtAlmacenUsuario.Rows[0]["Interior"] == DBNull.Value)
                IntDomicilioPartida = 0;
            else
                IntDomicilioPartida = Convert.ToInt16(DtAlmacenUsuario.Rows[0]["Interior"]);

            ZonaDomicilioPartida= DtAlmacenUsuario.Rows[0]["Zona"].ToString();
            DisDomicilioPartida= DtAlmacenUsuario.Rows[0]["Distrito"].ToString();
            ProvDomicilioPartida= DtAlmacenUsuario.Rows[0]["Provincia"].ToString();
            DepDomicilioPartida = DtAlmacenUsuario.Rows[0]["Departamento"].ToString();

            //ocultar panel de transporte externo
            PnlExterno.Visible = false;

            //validar opciones según la sede
            /*if (AppSettings.SedeID != "001AL")
            {
                RBTransferencia.Checked = true;
                //RbAmbos.Visible = false;
                RbCompras.Visible = false;
                DeFechaSalida.Value = DateTime.Now;
                DeFechaLlegada.Value = DateTime.Now.AddDays(1);
            }

            else if (AppSettings.SedeID == "001PU")
            {
                RBTransferencia.Checked = true;
                //RbAmbos.Visible = false;
                RbCompras.Visible = true;
                DeFechaSalida.Value = DateTime.Now;
                DeFechaLlegada.Value = DateTime.Now;
            }
            else
            {

            }*/

            DeFechaSalida.Value = DateTime.Now;
            DeFechaLlegada.Value = DateTime.Now.AddDays(1);

            TdgDetalleHoja.Visible = false;

            PnlBuscarHojaDespacho.Visible = false;
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ErrProvider.Clear();
            BtnGrabar.Visible  = false;
            BtnRequerimientos.Visible = false;
            bool HayCero = true;
            string NomProducto = "";

            if (DetallesRequerimientos.Rows.Count > 0) //si no existe detalles de hoja de despacho no guarda nada
            {
                //obtener los datos de la empresa de transporte
                if (ChkExterno.Checked == false & CboChofer.SelectedValue != null & CboVehiculo.SelectedValue != null)
                {
                    CamionEmpresaID = CboVehiculo.Columns["EmpresaID"].Value.ToString();
                    NomTransportista = CboChofer.Columns["NomChofer"].Value.ToString() + " " + CboChofer.Columns["ApeChofer"].Value.ToString();
                    
                    //filtrar para obtener la empresa de transporte
                    DataView Dv = new DataView(DtEmpresas);
                    Dv.RowFilter = "EmpresaID = '" + CamionEmpresaID + "'";
                    EmpresaTransporte = Dv[0]["NomEmpresa"].ToString();
                    RUCTransporte = Dv[0]["RUC"].ToString();
                    Placa = TxtPlaca.Text;
                }
                else
                {
                    CamionEmpresaID = "EX";
                    NomTransportista = TxtChofer.Text;
                    EmpresaTransporte = TxtEmpresaTransporte.Text;
                    Placa = TxtPlaca.Text;
                }
                //validar que el peso no sea iguala 0
                foreach (DataRow Row in DetallesRequerimientos.Rows)
                {
                    
                    if (Convert.ToDecimal(Row["PesoTotal"]) == 0)
                    {
                        HayCero = true;
                        NomProducto = Row["Producto"].ToString();
                        break;
                    }
                    else
                        HayCero = false;
                }


                //validar que tenga los datos del vehiculo para poder crear la hoja de despacho
                if (NomTransportista != "" & EmpresaTransporte != "" & Placa != ""  & CboSedeDestino.SelectedIndex != -1 & HayCero == false)
                {
                    CrearHojaDespacho();
                }
                else
                {
                    if (HayCero == true)
                    {
                        MessageBox.Show("Hay peso '0' en el producto: " + NomProducto + ". el peso no debe ser cero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (ChkExterno.Checked == true)
                    {
                        if (EmpresaTransporte == "") { ErrProvider.SetError(TxtEmpresaTransporte, "Ingrese Empresa de transporte."); }
                        if (NomTransportista == "") { ErrProvider.SetError(TxtChofer, "Ingrese nombre del chofer."); }
                        if (Placa == "") { ErrProvider.SetError(TxtPlaca, "Ingrese placa."); }
                    }
                    else
                    {
                        if (CboVehiculo.SelectedValue == null) { ErrProvider.SetError(CboVehiculo, "Debe seleccionar un vehículo."); }
                        if (CboChofer.SelectedValue == null) { ErrProvider.SetError(CboChofer, "Debe seleccionar un chofer."); }
                        if (Placa == "") { ErrProvider.SetError(TxtPlaca, "Ingrese placa."); }
                    }
                    if (CboSedeDestino.SelectedIndex == -1) { ErrProvider.SetError(CboSedeDestino, "Debe seleccionar una sede de destino."); }
                    BtnGrabar.Visible = true;
                    BtnRequerimientos.Visible = true;
                }
            }
            Cursor = Cursors.Default;
        }

        private void CrearHojaDespacho()
        {
            //obtener el distinct de las facturas para crear guias de remitente y de transportista
            DtFacturas = new DataTable();
            DtFacturas = new BaseFunctions().SelectDistinct(DetallesRequerimientos, "Factura");

            //calcular el total del peso enviado
            for (int i = 0; i < this.TdgDetalleHojaDespacho.Splits[0].Rows.Count; i++)
            {
                if (this.TdgDetalleHojaDespacho.Columns[2].CellValue(i) != DBNull.Value)
                    PesoTotal += Convert.ToInt32(this.TdgDetalleHojaDespacho.Columns[10].CellValue(i));

            }

            #region crear tablas
            //Insertar Hoja de despacho
            E_HojaDespacho ObjHojaDespacho = new E_HojaDespacho();
            ObjHojaDespacho.EmpresaID = AppSettings.EmpresaID;
            ObjHojaDespacho.EmpresaTransporte = EmpresaTransporte;
            ObjHojaDespacho.NombreChofer = NomTransportista;
            ObjHojaDespacho.placa = TxtPlaca.Text;
            ObjHojaDespacho.Carrosa = TxtCarrosa.Text;
            ObjHojaDespacho.FechaLlegada = Convert.ToDateTime(DeFechaLlegada.Value);
            ObjHojaDespacho.FechaSalida = Convert.ToDateTime(DeFechaSalida.Value);
            ObjHojaDespacho.NumJabas = 0;
            ObjHojaDespacho.PesoTotal = PesoTotal;
            ObjHojaDespacho.PesoNeto = 0;
            ObjHojaDespacho.TotalAnimales = 0;
            ObjHojaDespacho.TaraTotal = 0;
            ObjHojaDespacho.UsuarioID = AppSettings.UserID;

            NumHojaDespacho = new CL_HojaDespacho().InsertHojaDespacho(ObjHojaDespacho, AppSettings.SedeID);

            //Tabla para insertar el detalle de la hoja de despacho
            DetalleHojaDespacho = new DataTable();
            DetalleHojaDespacho.TableName = "DetalleHojaDespacho";
            DetalleHojaDespacho.Columns.Add("ProductoID", typeof(string));
            DetalleHojaDespacho.Columns.Add("NumHojaDespacho", typeof(string));
            DetalleHojaDespacho.Columns.Add("NumGuiaRemision", typeof(string));
            DetalleHojaDespacho.Columns.Add("NumRequerimiento", typeof(string));
            DetalleHojaDespacho.Columns.Add("NroFactura", typeof(string));
            DetalleHojaDespacho.Columns.Add("TotalPeso", typeof(decimal));
            DetalleHojaDespacho.Columns.Add("Motivo", typeof(string));
            DetalleHojaDespacho.Columns.Add("NumGuiaTransportista", typeof(string));
            DetalleHojaDespacho.Columns.Add("Bultos", typeof(string));
            DetalleHojaDespacho.Columns.Add("IDProveedor", typeof(int));

            //Tabla para Mostrar Hoja de despacho
            DetalleHojaDespacho2 = new DataTable();
            DetalleHojaDespacho2.TableName = "DetalleHojaDespacho2";
            DetalleHojaDespacho2.Columns.Add("Proveedor", typeof(string));
            DetalleHojaDespacho2.Columns.Add("NroFactura", typeof(string));
            DetalleHojaDespacho2.Columns.Add("NumGuiaRemision", typeof(string));
            DetalleHojaDespacho2.Columns.Add("NumGuiaTransportista", typeof(string));
            DetalleHojaDespacho2.Columns.Add("Producto", typeof(string));
            DetalleHojaDespacho2.Columns.Add("TotalPeso", typeof(decimal));
            DetalleHojaDespacho2.Columns.Add("Bultos", typeof(string));
            #endregion

            foreach (DataRow Row in DtFacturas.Rows)
            {
                NroFactura = Row["Factura"].ToString();

                //filtrar tabla para obtener los datos relacionados a la factura y asi crear las guias de remision
                DataView DvDetallesRequerimientos = new DataView(DetallesRequerimientos);
                DvDetallesRequerimientos.RowFilter = "Factura = '" + NroFactura + "'";
                DataTable DtRequerimientos;
                DtRequerimientos = DvDetallesRequerimientos.ToTable();
                DtRequerimientos.DefaultView.Sort = "Producto";

                
                try
                {
                    #region crear tablas
                    //detalles de guia de remision
                    DetalleGuiaRemision = new DataTable();
                    DetalleGuiaRemision.TableName = "DetalleGuiaRemision";
                    DetalleGuiaRemision.Columns.Add("NumGuiaRemision", typeof(string));
                    DetalleGuiaRemision.Columns.Add("ProductoID", typeof(string));
                    DetalleGuiaRemision.Columns.Add("NumRequerimiento", typeof(string));
                    DetalleGuiaRemision.Columns.Add("PesoNeto", typeof(decimal));
                    DetalleGuiaRemision.Columns.Add("PesoTara", typeof(decimal));
                    DetalleGuiaRemision.Columns.Add("CantidadEnviada", typeof(decimal));
                    DetalleGuiaRemision.Columns.Add("CantidadRecibida", typeof(decimal));
                    DetalleGuiaRemision.Columns.Add("EstadoID", typeof(int));

                    //detalles de guia de transporte
                    DetalleGuiaTransporte = new DataTable();
                    DetalleGuiaTransporte.TableName = "DetalleGuiaTransportista";
                    DetalleGuiaTransporte.Columns.Add("NumGuiaTransportista", typeof(string));
                    DetalleGuiaTransporte.Columns.Add("ProductoID", typeof(string));
                    DetalleGuiaTransporte.Columns.Add("NumRequerimiento", typeof(string));
                    DetalleGuiaTransporte.Columns.Add("PesoNeto", typeof(decimal));
                    DetalleGuiaTransporte.Columns.Add("PesoTara", typeof(decimal));
                    DetalleGuiaTransporte.Columns.Add("CantidadEnviada", typeof(decimal));

                    //tabla para actualizar el estado del requerimiento
                    DataTable DtActuEstadoReq = new DataTable();
                    DtActuEstadoReq.TableName = "DetalleRequerimiento";
                    DtActuEstadoReq.Columns.Add("NumRequerimiento", typeof(string));
                    DtActuEstadoReq.Columns.Add("CantidadTransito", typeof(decimal));
                    DtActuEstadoReq.Columns.Add("ProductoID", typeof(string));
                    DtActuEstadoReq.Columns.Add("EstadoID", typeof(int));
                    #endregion

                    NumGuiaRemision = CrearGuiaRemitente();

                    //se crea guia de transportista si solo si el camion no pertenece a la empresa de destino
                    if ((AppSettings.EmpresaID != CamionEmpresaID) && CamionEmpresaID != "EX")
                    {
                        NumGuiaTransportista = CrearGuiaTransporte();
                    }
                    else
                        NumGuiaTransportista = ""; //no necesita guia de transporte

                    

                    int Cantidad = 0;//contador que indicara si la cantidad de productos no sean mayor de 12 (lo que puede contener la guia)
                    foreach (DataRow Row2 in DtRequerimientos.Rows)
                    {
                        Cantidad++;

                        if (Cantidad > 12)
                        {
                            Cantidad = 1;
                            //se crea guia de transportista si solo si el camion no pertenece a la empresa de destino
                            if ((AppSettings.EmpresaID != CamionEmpresaID) && CamionEmpresaID != "EX")
                            {
                                NumGuiaTransportista = CrearGuiaTransporte();
                            }
                            else
                                NumGuiaTransportista = ""; //no necesita guia de transporte

                            NumGuiaRemision = CrearGuiaRemitente();
                        }

                        if (Row2["Anular"] == DBNull.Value || Row2["Anular"].ToString() == "False")
                        {
                            //analizar el stock y si se logro la actualizacion crear las guias
                            bool Actualizo = false; //'9-' indica que es guia remitente
                            //es para kardex
                            if (Row2["TipoRequerimiento"].ToString() == "C")//en compras baja el stock local y el disponible
                                Actualizo = new CL_Almacen().UpdateStockSustraccion(Row2["AlmacenID"].ToString(), Convert.ToString(Row2["SProductoID"]), Convert.ToDecimal(Row2["CantidadDespachada"]), "D", AppSettings.EmpresaID + CboSedeDestino.SelectedValue.ToString() + Row2["AlmacenID"].ToString().Substring(7), 2, "09", NumGuiaRemision.Substring(2,3), Convert.ToInt32(NumGuiaRemision.Substring(6)), "11", AppSettings.UserID);
                            else if (Row2["TipoRequerimiento"].ToString() == "T")//en transferencia solo baja el stock local
                                Actualizo = new CL_Almacen().UpdateStockSustraccion(Row2["AlmacenID"].ToString(), Convert.ToString(Row2["SProductoID"]), Convert.ToDecimal(Row2["CantidadDespachada"]), "S", AppSettings.EmpresaID + CboSedeDestino.SelectedValue.ToString() + Row2["AlmacenID"].ToString().Substring(7), 2, "09", NumGuiaRemision.Substring(2,3), Convert.ToInt32(NumGuiaRemision.Substring(6)), "11", AppSettings.UserID);

                            if (Actualizo == true)
                            {
                                //para detalle guia remision
                                DataRow RowGR = DetalleGuiaRemision.NewRow();
                                RowGR["NumGuiaRemision"] = NumGuiaRemision;
                                RowGR["ProductoID"] = Row2["SProductoID"];
                                RowGR["NumRequerimiento"] = Row2["NumRequerimiento"];
                                RowGR["PesoNeto"] = Row2["PesoTotal"];
                                RowGR["PesoTara"] = 0;
                                RowGR["CantidadEnviada"] = Row2["CantidadDespachada"];
                                RowGR["CantidadRecibida"] = DBNull.Value;
                                RowGR["EstadoID"] = 2;
                                DetalleGuiaRemision.Rows.Add(RowGR);

                                //para detalle guia transporte
                                if (NumGuiaTransportista != "")
                                {
                                    DataRow RowGT = DetalleGuiaTransporte.NewRow();
                                    RowGT["NumGuiaTransportista"] = NumGuiaTransportista;
                                    RowGT["ProductoID"] = Row2["SProductoID"];
                                    RowGT["NumRequerimiento"] = Row2["NumRequerimiento"];
                                    RowGT["PesoNeto"] = Row2["PesoTotal"];
                                    RowGT["PesoTara"] = 0;
                                    RowGT["CantidadEnviada"] = Row2["CantidadDespachada"];
                                    DetalleGuiaTransporte.Rows.Add(RowGT);
                                }
                                //para estado requerimiento
                                DataRow RowD2 = DtActuEstadoReq.NewRow();
                                RowD2["ProductoID"] = Row2["ProductoID"];
                                RowD2["NumRequerimiento"] = Row2["NumRequerimiento"];
                                
                                //identificar el estado actual del requerimiento
                                if (AppSettings.SedeID == "001PU")
                                {
                                    if (Convert.ToDecimal(Row2["CantidadRecibida"]) + Convert.ToDecimal(Row2["CantidadDespachada"]) == Convert.ToDecimal(Row2["CantidadSolicitada"]))
                                    {
                                        //transito DESTINO total
                                        RowD2["EstadoID"] = 9;
                                    }
                                    else if (Convert.ToDecimal(Row2["CantidadRecibida"]) + Convert.ToDecimal(Row2["CantidadDespachada"]) < Convert.ToDecimal(Row2["CantidadSolicitada"]))
                                    {
                                        //transito DESTINO parcial
                                        RowD2["EstadoID"] = 8;
                                    }
                                    /*siempre va a estar en transito porque la
                                    transferencia es entre almacenes y no pasa por industria*/
                                    if (RBTransferencia.Checked == true) RowD2["CantidadTransito"] = Row2["CantidadDespachada"];

                                    /*en este caso sera "0" porque las compras vienen de lima*/
                                    if (RbCompras.Checked == true) RowD2["CantidadTransito"] = 0;
                                }
                                else
                                {
                                    if (Convert.ToDecimal(Row2["CantidadRecibida"]) + Convert.ToDecimal(Row2["CantidadTransito"]) + Convert.ToDecimal(Row2["CantidadDespachada"]) == Convert.ToDecimal(Row2["CantidadSolicitada"]))
                                    {
                                        //transito total
                                        RowD2["EstadoID"] = 2;
                                    }
                                    else if (Convert.ToDecimal(Row2["CantidadRecibida"]) + Convert.ToDecimal(Row2["CantidadTransito"]) + Convert.ToDecimal(Row2["CantidadDespachada"]) < Convert.ToDecimal(Row2["CantidadSolicitada"]))
                                    {
                                        //transito parcial
                                        RowD2["EstadoID"] = 6;
                                    }
                                    RowD2["CantidadTransito"] = Row2["CantidadDespachada"];
                                }
                                DtActuEstadoReq.Rows.Add(RowD2);

                                //para detalle hoja despacho
                                DataRow RowHD = DetalleHojaDespacho.NewRow();
                                RowHD["ProductoID"] = Row2["SProductoID"];
                                RowHD["NumHojaDespacho"] = NumHojaDespacho;
                                RowHD["NumGuiaRemision"] = NumGuiaRemision;
                                RowHD["NumRequerimiento"] = Row2["NumRequerimiento"];
                                RowHD["NroFactura"] = Row2["Factura"];
                                RowHD["TotalPeso"] = Row2["PesoTotal"];
                                RowHD["Motivo"] = Row2["Motivo"];
                                RowHD["NumGuiaTransportista"] = NumGuiaTransportista;
                                RowHD["Bultos"] = Row2["Bultos"];
                                RowHD["IDProveedor"] = Row2["IDProveedor"];
                                DetalleHojaDespacho.Rows.Add(RowHD);

                                //para detalle hoja despacho para presentar
                                DataRow RowHD2 = DetalleHojaDespacho2.NewRow();
                                RowHD2["Proveedor"] = Row2["Proveedor"];
                                RowHD2["NroFactura"] = Row2["Factura"];
                                RowHD2["NumGuiaRemision"] = NumGuiaRemision;
                                RowHD2["NumGuiaTransportista"] = NumGuiaTransportista;
                                RowHD2["Producto"] = Row2["Producto"];
                                RowHD2["TotalPeso"] = Row2["PesoTotal"];
                                RowHD2["Bultos"] = Row2["Bultos"];
                                DetalleHojaDespacho2.Rows.Add(RowHD2);
                            }
                            else
                                MessageBox.Show("No existe Stock suficiente en el almacen " + Row2["AlmacenID"].ToString() + " del producto \r\n" + Row2["Producto"].ToString() + ".", "Stock Almacen", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                    }
                    #region Actualizar con Xml
                    //insertar detalles guia remision
                    if (DetalleGuiaRemision.Rows.Count > 0)
                    {
                        string xml = new BaseFunctions().GetXML(DetalleGuiaRemision).Replace("NewDataSet", "DocumentElement");
                        bool Valor;
                        Valor = new CL_GuiaRemision().InsertXMLDetalleGuiaRemision(xml);
                        if (Valor == false)
                            MessageBox.Show("Ocurrio un error al intentar guardar el detalle de la Guía de Remisión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    //insertar detalle guia de transporte
                    if (DetalleGuiaTransporte.Rows.Count > 0)
                    {
                        string xml = new BaseFunctions().GetXML(DetalleGuiaTransporte).Replace("NewDataSet", "DocumentElement");
                        bool Valor;
                        Valor = new CL_GuiaTransportista().InsertXMLDetalleGuiaTransporte(xml);
                        if (Valor == false)
                            MessageBox.Show("Ocurrio un error al intentar guardar el detalle de la Guía de Transporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //actualizar estado de los requerimientos
                    if (DtActuEstadoReq.Rows.Count > 0)
                    {
                        string xml = new BaseFunctions().GetXML(DtActuEstadoReq).Replace("NewDataSet", "DocumentElement");
                        bool Valor;
                        Valor = new CL_Requerimientos().UpdateXMLDetalleRequerimientoEstado(xml, "E", AppSettings.UserID, AppSettings.SedeID);
                        if (Valor == false)
                            MessageBox.Show("Ocurrio un error al intentar actualizar el estado de los requerimientos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Se guardo correctamente los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }//fin del foreach de las facturas

            //insertar los detalles de hoja de despacho

            if (DetalleHojaDespacho.Rows.Count > 0)
            {
                string xml = new BaseFunctions().GetXML(DetalleHojaDespacho).Replace("NewDataSet", "DocumentElement");
                bool Valor;
                Valor = new CL_HojaDespacho().InsertXMLDetalleHojaDespacho(xml);
                if (Valor == false)
                    MessageBox.Show("Ocurrio un error al intentar insertar los detalles de la hoja de despacho", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    TdgDetalleHoja.Visible = true;
                    TdgDetalleHoja.SetDataBinding(DetalleHojaDespacho2, "", true);
                }
            }

               
        }

        private string CrearGuiaRemitente()
        {
                    //obtenemos datos guia remision
                    E_GuiaRemision ObjGuiaRemision = new E_GuiaRemision();

                    ObjGuiaRemision.EmpresaID = AppSettings.EmpresaID;
                    ObjGuiaRemision.NroJabas = 0;
                    ObjGuiaRemision.DesAnimal = null;
                    ObjGuiaRemision.NroGalpon = 0;
                    ObjGuiaRemision.DomicilioPartida = DomicilioPartida;
                    ObjGuiaRemision.NroDomicilioPartida = NroDomicilioPartida;
                    ObjGuiaRemision.InteriorDomicilioPartida = IntDomicilioPartida;
                    ObjGuiaRemision.ZonaDomicilioPartida = ZonaDomicilioPartida;
                    ObjGuiaRemision.DistritoDomicilioPartida = DisDomicilioPartida;
                    ObjGuiaRemision.ProvinciaDomicilioPartida = ProvDomicilioPartida;
                    ObjGuiaRemision.DepartamentoDomicilioPartida = DepDomicilioPartida;
                    ObjGuiaRemision.DomicilioLlegada = CboSedeDestino.Columns["NomSede"].Value.ToString();

                    if (CboSedeDestino.Columns["Numero"].Value == DBNull.Value)
                        ObjGuiaRemision.NroDomicilioLlegada = 0;
                    else
                        ObjGuiaRemision.NroDomicilioLlegada = Convert.ToInt16(CboSedeDestino.Columns["Numero"].Value);

                    if (CboSedeDestino.Columns["Interior"].Value == DBNull.Value)
                        ObjGuiaRemision.IntDomicilioLlegada = 0;
                    else
                        ObjGuiaRemision.IntDomicilioLlegada = Convert.ToInt16(CboSedeDestino.Columns["Interior"].Value);

                    ObjGuiaRemision.ZonaDomicilioLlegada = CboSedeDestino.Columns["Zona"].Value.ToString();
                    ObjGuiaRemision.DisDomicilioLlegada = CboSedeDestino.Columns["Distrito"].Value.ToString();
                    ObjGuiaRemision.ProvDomicilioLlegada = CboSedeDestino.Columns["Provincia"].Value.ToString();
                    ObjGuiaRemision.DepDomicilioLlegada = CboSedeDestino.Columns["Departamento"].Value.ToString();
                    ObjGuiaRemision.Destinatario = AppSettings.NomEmpresa;
                    ObjGuiaRemision.RUCDestinatario = AppSettings.RUCEmpresa;
                    ObjGuiaRemision.DireccionDestinatario = CboSedeDestino.Columns["NomSede"].Value.ToString();
                    ObjGuiaRemision.ObservacionDestinatario = null;
                    ObjGuiaRemision.Marca = TxtMarca.Text;
                    ObjGuiaRemision.Placa = TxtPlaca.Text;
                    ObjGuiaRemision.Carrosa = TxtCarrosa.Text;
                    ObjGuiaRemision.NombreChofer = NomTransportista;
                    ObjGuiaRemision.DNIChofer = TxtDNITransportista.Text;
                    ObjGuiaRemision.FechaSalida = Convert.ToDateTime(DeFechaSalida.Value);
                    ObjGuiaRemision.ConfiguracionVehicular = TxtConfVehicular.Text;
                    if (TxtNroConstInscripcion.Text == "")
                    { ObjGuiaRemision.NroConstInscripcion = 0; }
                    else
                    { ObjGuiaRemision.NroConstInscripcion = Convert.ToInt32(TxtNroConstInscripcion.Text); }
                    ObjGuiaRemision.NroLicTransportista = TxtNroLicTransaportista.Text;
                    ObjGuiaRemision.NroFactura = NroFactura;
                    ObjGuiaRemision.EmpresaTransporte = EmpresaTransporte;
                    ObjGuiaRemision.RUCTransporte = RUCTransporte;
                    ObjGuiaRemision.Pesador = "";
                    ObjGuiaRemision.Galponero = "";
                    ObjGuiaRemision.TipoGuia = "I";//es interno
                    ObjGuiaRemision.UsuarioID = AppSettings.UserID;

                    //insertar guia remision y obtener el codigo de registro insertado
                    NumGuiaRemision = new CL_GuiaRemision().InsertGuiaRemitente(ObjGuiaRemision, AppSettings.EmpresaID + AppSettings.SedeID);
                    return NumGuiaRemision;
        }

        private string CrearGuiaTransporte()
        {

            E_GuiaTransporte ObjGuiaTransporte = new E_GuiaTransporte();

            ObjGuiaTransporte.EmpresaID = CamionEmpresaID;
            ObjGuiaTransporte.NumGuiaRemision = NumGuiaRemision;
            ObjGuiaTransporte.DomicilioPartida = DomicilioPartida;
            ObjGuiaTransporte.NroDomicilioPartida = NroDomicilioPartida;
            ObjGuiaTransporte.IntDomicilioPartida = IntDomicilioPartida;
            ObjGuiaTransporte.ZonaDomicilioPartida = ZonaDomicilioPartida;
            ObjGuiaTransporte.DisDomicilioPartida = DisDomicilioPartida;
            ObjGuiaTransporte.ProvDomicilioPartida = ProvDomicilioPartida;
            ObjGuiaTransporte.DepDomicilioPartida = DepDomicilioPartida;
            ObjGuiaTransporte.DomicilioLlegada = CboSedeDestino.Columns["NomSede"].Value.ToString();

            if (CboSedeDestino.Columns["Numero"].Value == DBNull.Value)
                ObjGuiaTransporte.NroDomicilioLlegada = 0;
            else
                ObjGuiaTransporte.NroDomicilioLlegada = Convert.ToInt16(CboSedeDestino.Columns["Numero"].Value);

            if (CboSedeDestino.Columns["Interior"].Value == DBNull.Value)
                ObjGuiaTransporte.IntDomicilioLlegada = 0;  
            else
                ObjGuiaTransporte.IntDomicilioLlegada = Convert.ToInt16(CboSedeDestino.Columns["Interior"].Value);

            ObjGuiaTransporte.ZonaDomicilioLlegada = CboSedeDestino.Columns["Zona"].Value.ToString();
            ObjGuiaTransporte.DisDomicilioLlegada = CboSedeDestino.Columns["Distrito"].Value.ToString();
            ObjGuiaTransporte.ProvDomicilioLlegada = CboSedeDestino.Columns["Provincia"].Value.ToString();
            ObjGuiaTransporte.DepDomicilioLlegada = CboSedeDestino.Columns["Departamento"].Value.ToString();
            ObjGuiaTransporte.Remitente = AppSettings.NomEmpresa;
            ObjGuiaTransporte.RUCRemitente = AppSettings.RUCEmpresa;
            ObjGuiaTransporte.DireccionRemitente = DomicilioPartida;
            ObjGuiaTransporte.ObservacionRemitente = null;
            ObjGuiaTransporte.Destinatario = AppSettings.NomEmpresa;
            ObjGuiaTransporte.RUCDestinatario = AppSettings.RUCEmpresa;
            ObjGuiaTransporte.DireccionDestinatario = CboSedeDestino.Columns["NomSede"].Value.ToString();
            ObjGuiaTransporte.ObservacionDestinatario = null;
            ObjGuiaTransporte.Marca = CboVehiculo.SelectedText;
            ObjGuiaTransporte.Placa = TxtPlaca.Text;
            ObjGuiaTransporte.Carrosa = TxtCarrosa.Text;
            ObjGuiaTransporte.NombreChofer = NomTransportista;
            ObjGuiaTransporte.DNIChofer = TxtDNITransportista.Text;
            ObjGuiaTransporte.FechaSalida = Convert.ToDateTime(DeFechaSalida.Value);
            ObjGuiaTransporte.ConfiguracionVehicular = TxtConfVehicular.Text;
            if (TxtNroConstInscripcion.Text == "")
            { ObjGuiaTransporte.NroConstInscripcion = 0; }
            else
            { ObjGuiaTransporte.NroConstInscripcion = Convert.ToInt32(TxtNroConstInscripcion.Text); }

            ObjGuiaTransporte.NroLicTransportista = TxtNroLicTransaportista.Text;
            ObjGuiaTransporte.TipoGuia = "I";
            ObjGuiaTransporte.UsuarioID = AppSettings.UserID;

            //insertar guia transporte y obtener el codigo de registro insertado
            NumGuiaTransportista = new CL_GuiaTransportista().InsertGuiaTransportista(ObjGuiaTransporte, CamionEmpresaID + AppSettings.SedeID);
            return NumGuiaTransportista;
        }

        private void CboEmpresa_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboSede.SelectedValue != null)
            {
                //obtener los almacenes
                DtAlmacenes = new CL_Empresas().GetAlmacenesEmpresa(CboSede.SelectedValue.ToString(), AppSettings.EmpresaID);
                DataRow Row = DtAlmacenes.NewRow();
                Row["AlmacenID"] = "00000TODOS";
                Row["Descripcion"] = "TODOS";
                Row["Telefono"] = "TODOS";
                
                DtAlmacenes.Rows.Add(Row);
                             
            }
        }

        private void CboVehiculo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboVehiculo.SelectedValue != null)
            {
                TxtMarca.Text =  CboVehiculo.Columns["Marca"].Text;
                TxtPlaca.Text = CboVehiculo.Columns["Placa"].Text;
                TxtConfVehicular.Text = CboVehiculo.Columns["ConfiguracionVehicular"].Text;
                TxtNroConstInscripcion.Text = CboVehiculo.Columns["CertificadoInscripcion"].Text;
                CamionEmpresaID = CboVehiculo.Columns["EmpresaID"].Text;
            }
        }

        private void CboChofer_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboChofer.SelectedValue != null)
            {
                TxtNroLicTransaportista.Text = CboChofer.Columns["Licencia"].Text;
                TxtDNITransportista.Text = CboChofer.Columns["DNI"].Text;
            }
        }

        private void ChkExterno_CheckedChanged(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            if (ChkExterno.Checked == true)
            {
                PnlExterno.Visible = true;
                TxtMarca.Text = "";
                TxtPlaca.Text="";
                TxtConfVehicular.Text = "";
                TxtNroConstInscripcion.Text = "";
                TxtNroLicTransaportista.Text = "";
                TxtDNITransportista.Text = "";
                CboVehiculo.SelectedIndex = -1;
                CboChofer.SelectedIndex = -1;
            }
            else
            {
                PnlExterno.Visible = false;
            }
        }

        private void TxtNroConstInscripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.SoloNumero(sender, e, TxtNroConstInscripcion);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            //limpiar todo
            CboSede.SelectedIndex = -1;
            CboSedeDestino.SelectedIndex = -1;
            CboVehiculo.SelectedIndex = -1;
            CboChofer.SelectedIndex = -1;

            //TxtEmpresaTransporte.Text = "";
            //TxtChofer.Text = "";
            TxtMarca.Text = "";
            TxtCarrosa.Text = "";
            TxtPlaca.Text = "";
            TxtConfVehicular.Text = "";
            TxtNroConstInscripcion.Text = "";
            TxtNroLicTransaportista.Text = "";
            TxtDNITransportista.Text = "";
            PesoTotal = 0;

            //limpiar tabla y cargarla en la grilla
            DetallesRequerimientos.Clear();
            TdgDetalleHojaDespacho.SetDataBinding(DetallesRequerimientos, "", true);

            TdgDetalleHoja.Visible = false;

            //habilitra control de guardar
            BtnGrabar.Visible = true;
            BtnRequerimientos.Visible = true;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            PnlBuscarHojaDespacho.Visible = true;
        }

        private void TdgDetalleHoja_MouseClick(object sender, MouseEventArgs e)
        {
            //para mostrar las guias al hacer click
            Cursor = Cursors.WaitCursor;
            int row, col;
            if (this.TdgDetalleHoja.CellContaining(e.X, e.Y, out row, out col))
            {
                if (col < 7)
                {
                    string Val = this.TdgDetalleHoja[row, col + 1] as string;
                    if (col == 3 && Val != "")
                    {
                        FrmGuiaRemision ObjFrmGuiaRemision = new FrmGuiaRemision();
                        ObjFrmGuiaRemision.NumGuiaRemision = Val;
                        ObjFrmGuiaRemision.ShowDialog();
                    }
                    if (col == 4 && Val + "" != "")
                    {
                        FrmGuiaTransporte ObjFrmGuiaTransporte = new FrmGuiaTransporte();
                        ObjFrmGuiaTransporte.NumGuiaTransportista = Val;
                        ObjFrmGuiaTransporte.ShowDialog();
                    }
                }
            }
            Cursor = Cursors.Default;

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            PnlBuscarHojaDespacho.Visible = false;
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                NumHojaDespacho = TxtBuscar.Text;
                PnlBuscarHojaDespacho.Visible = false;
                DataTable GetDetalleHojaDespacho = new DataTable();
                GetDetalleHojaDespacho = new CL_HojaDespacho().GetDetalleHojaDespacho(TxtBuscar.Text);

                if (GetDetalleHojaDespacho.Rows.Count > 0)
                {
                    TdgDetalleHoja.Visible = true;

                    //Tabla para Mostrar Hoja de despacho
                    DetalleHojaDespacho2 = new DataTable();
                    DetalleHojaDespacho2.TableName = "DetalleHojaDespacho2";
                    DetalleHojaDespacho2.Columns.Add("Proveedor", typeof(string));
                    DetalleHojaDespacho2.Columns.Add("NroFactura", typeof(string));
                    DetalleHojaDespacho2.Columns.Add("NumGuiaRemision", typeof(string));
                    DetalleHojaDespacho2.Columns.Add("NumGuiaTransportista", typeof(string));
                    DetalleHojaDespacho2.Columns.Add("Producto", typeof(string));
                    DetalleHojaDespacho2.Columns.Add("TotalPeso", typeof(decimal));
                    DetalleHojaDespacho2.Columns.Add("Bultos", typeof(string));

                    //para detalle hoja despacho para presentar
                    DataRow RowHD2 = DetalleHojaDespacho2.NewRow();
                    RowHD2["Proveedor"] = "";
                    RowHD2["NroFactura"] = "";
                    RowHD2["NumGuiaRemision"] = GetDetalleHojaDespacho.Rows[0]["NumGuiaRemision"];
                    RowHD2["NumGuiaTransportista"] = GetDetalleHojaDespacho.Rows[0]["NumGuiaTransportista"];
                    RowHD2["Producto"] = GetDetalleHojaDespacho.Rows[0]["NomProducto"];
                    RowHD2["TotalPeso"] = GetDetalleHojaDespacho.Rows[0]["TotalPeso"];
                    RowHD2["Bultos"] = GetDetalleHojaDespacho.Rows[0]["Bultos"];
                    DetalleHojaDespacho2.Rows.Add(RowHD2);

                    TdgDetalleHoja.SetDataBinding(DetalleHojaDespacho2, "", true);
                }
                else
                {
                    MessageBox.Show("No existe Hoja de despacho con ese codigo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PnlBuscarHojaDespacho.Visible = false;
                    TdgDetalleHoja.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnVer_Click(object sender, EventArgs e)
        {
            Reportes.FrmHojaDespacho ObjFrmHojaD = new Reportes.FrmHojaDespacho();
            ObjFrmHojaD.NumHojaDespacho = NumHojaDespacho;
            ObjFrmHojaD.ShowDialog();
        }

    }
}
