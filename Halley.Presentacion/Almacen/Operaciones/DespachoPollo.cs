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
using Halley.Entidad.Almacen;
using Halley.Utilitario;
using Halley.Configuracion;
using System.Reflection;

namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class DespachoPollo : UITemplateAccess
    {
        public static DataTable DetallesRequerimientos = new DataTable();
        private static decimal PesoTotal;
        static DataTable DetallesRequerimientosAcu = new DataTable(); // creado para acumular todos los requerimientos
        private string NumGuiaRemision;
        private string NumGuiaTransportista;
        private string CamionEmpresaID;
        private string NomTransportista;
        private string EmpresaIDUser;
        private string EmpresaTransporte;
        private string Placa;
        private string AlmacenIDLocal;
        private string EmpresaSede;
        private string Galponero;
        private string Pesador;

        private decimal Tara = 0;
        private decimal Neto = 0;
        private decimal Bruto = 0;
        private int NroJabas = 0;

        private decimal TaraTotal = 0;
        private decimal NetoTotal = 0;
        private decimal BrutoTotal = 0;
        private int NroJabasTotal = 0;
        private static Int16 Cantidad = 0;

        private string SedeId;
        private string DomicilioPartida;
        private int NroDomicilioPartida;
        private int IntDomicilioPartida;
        private string ZonaDomicilioPartida;
        private string DisDomicilioPartida;
        private string ProvDomicilioPartida;
        private string DepDomicilioPartida;
        string NumHojaDespacho;

        private DataTable DetalleGuiaRemision;
        private DataTable DetalleGuiaTransporte;
        private DataTable DtRequerimientos;
        private DataTable DtRequerimientosAnt;
        private DataTable DtProductosPeso;
        private DataTable DtVehiculos;
        private DataTable DtChoferes;
        private DataTable DtAlmacenUsuario;
        private DataTable DtTara = new DataTable();
        private DataTable DtPesoBruto = new DataTable();
        private DataTable DtGuias = new DataTable();
        private DataTable DtImportado = new DataTable();

        CL_Requerimientos ObjRequerimientos = new CL_Requerimientos();

        private TextFunctions ObjTextFunctions = new TextFunctions();

        public DespachoPollo()
        {
            InitializeComponent();
        }

        private void DespachoPollo_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            DeFechaSalida.Value = DateTime.Now.Date;
            DeFechaLlegada.Value = DateTime.Now.Date;
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

            EmpresaIDUser = AppSettings.EmpresaID;

            //obtener la sede del usuario
            DtAlmacenUsuario = AppSettings.AlmacenPermisos;
            SedeId = DtAlmacenUsuario.Rows[0]["SedeId"].ToString();
            DomicilioPartida = DtAlmacenUsuario.Rows[0]["NomSede"].ToString();
            if (DtAlmacenUsuario.Rows[0]["Numero"] == DBNull.Value)
                NroDomicilioPartida = 0;
            else
                NroDomicilioPartida = Convert.ToInt16(DtAlmacenUsuario.Rows[0]["Numero"]);

            if (DtAlmacenUsuario.Rows[0]["Interior"] == DBNull.Value)
                IntDomicilioPartida = 0;
            else
                IntDomicilioPartida = Convert.ToInt16(DtAlmacenUsuario.Rows[0]["Interior"]);

            ZonaDomicilioPartida = DtAlmacenUsuario.Rows[0]["Zona"].ToString();
            DisDomicilioPartida = DtAlmacenUsuario.Rows[0]["Distrito"].ToString();
            ProvDomicilioPartida = DtAlmacenUsuario.Rows[0]["Provincia"].ToString();
            DepDomicilioPartida = DtAlmacenUsuario.Rows[0]["Departamento"].ToString();

            //ocultar panel de transporte externo
            PnlExterno.Visible = false;

            //obtener lista de productos que se pésan
            DtProductosPeso = new CL_Producto().GetProductosPeso();
            CboProductoPeso.HoldFields();
            CboProductoPeso.DataSource = DtProductosPeso;
            CboProductoPeso.DisplayMember = "NomProducto";
            CboProductoPeso.ValueMember = "ProductoID";

            //crear tablas para peso y tara
            DtTara = new DataTable();
            DtTara.TableName = "Tara";
            DtTara.Columns.Add("NumGuiaRemision", typeof(string));
            DtTara.Columns.Add("Cantidad", typeof(int));
            DtTara.Columns.Add("Peso", typeof(decimal));
            DtTara.Columns.Add("Tipo", typeof(string));

            DtPesoBruto = new DataTable();
            DtPesoBruto.TableName = "Peso";
            DtPesoBruto.Columns.Add("NumGuiaRemision", typeof(string));
            DtPesoBruto.Columns.Add("Cantidad", typeof(string));
            DtPesoBruto.Columns.Add("Peso", typeof(decimal));
            DtPesoBruto.Columns.Add("Tipo", typeof(string));

            //Para almacenar Las guias creadas
            DtGuias.TableName = "DtGuias";
            DtGuias.Columns.Add("ProductoID", typeof(string));
            DtGuias.Columns.Add("NumHojaDespacho", typeof(string));
            DtGuias.Columns.Add("NumGuiaRemision", typeof(string));
            DtGuias.Columns.Add("NumRequerimiento", typeof(string));
            DtGuias.Columns.Add("NroFactura", typeof(string));
            DtGuias.Columns.Add("TotalPeso", typeof(decimal));
            DtGuias.Columns.Add("Motivo", typeof(string));
            DtGuias.Columns.Add("NumGuiaTransportista", typeof(string));
            DtGuias.Columns.Add("Bultos", typeof(string));
            DtGuias.Columns.Add("IDProveedor", typeof(int));
            DtGuias.Columns.Add("FechaHora", typeof(DateTime));
            DtGuias.Columns.Add("NomSede", typeof(string));
           

            /*//todos los almacenes asignados al usuario
            DtAlmacenUsuario = AppSettings.AlmacenPermisos;
            CboAlmacen.HoldFields();
            CboAlmacen.DataSource = DtAlmacenUsuario;
            CboAlmacen.DisplayMember = "Descripcion";
            CboAlmacen.ValueMember = "AlmacenID";*/

            //tara, neto y bruto
            Tara = 0;
            Neto = 0;
            Bruto = 0;
            NroJabas = 0;

            TxtTara.ReadOnly = false;
            TxtNeto.ReadOnly = false;
            TxtBruto.ReadOnly = false;
            TxtNroJabas.ReadOnly = false;
            TxtTara.Value = Tara;
            TxtNeto.Value = Neto;
            TxtBruto.Value = Bruto;
            TxtTara.ReadOnly = true;
            TxtNeto.ReadOnly = true;
            TxtBruto.ReadOnly = true;
            TxtNroJabas.ReadOnly = true;

            this.c1SuperTooltip1.Show("<table><tr><td><parm><img src='res://Pollos_32x32.gif'></parm></td><td><b><parm>Ingresar Cantidad</parm></b></td></tr></table><parm><hr noshade size=1 style='margin:2' color=Darker></parm><div style='margin:1 12'><parm>Aqui debe ingresar el total<br>de unidades despachadas</parm></div><parm><hr noshade size=1 style='margin:2' color=Darker></parm><table><tr><td><parm><img src='res://pollito32x32.gif'></parm></td><td><b><parm>No debe ser cero</parm></b></td></tr></table>", this.TxtCantidad, 50, 0, 3000);
        }

        private void ChkExterno_CheckedChanged(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            if (ChkExterno.Checked == true)
            {
                PnlExterno.Visible = true;
                TxtMarca.Value = "";
                TxtPlaca.Value = "";
                TxtConfVehicular.Value = "";
                TxtNroConstInscripcion.Value = "";
                TxtNroLicTransaportista.Value = "";
                TxtDNITransportista.Value = "";
                CboVehiculo.SelectedIndex = -1;
                CboChofer.SelectedIndex = -1;
            }
            else
            {
                PnlExterno.Visible = false;
            }
        }


        private void BtnRequerimientos_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ErrProvider.Clear();
            if (CboProductoPeso.SelectedValue != null & CboSede.SelectedValue != null)
            {
                EmpresaSede = EmpresaIDUser + CboSede.SelectedValue.ToString();
                
                DtRequerimientosAnt = new DataTable();
                DtRequerimientosAnt = ObjRequerimientos.GetTransferenciaPeso(CboProductoPeso.SelectedValue.ToString(), EmpresaSede, AppSettings.EmpresaID + AppSettings.SedeID, "0,6,4");


                DtRequerimientos = DtRequerimientosAnt.Clone();

                //bucle para filtrar solo los que faltan productos por enviar
                foreach (DataRow Dr in DtRequerimientosAnt.Rows)
                {
                    if (Convert.ToDecimal(Dr["CantidadRecibida"]) + Convert.ToDecimal(Dr["CantidadTransito"]) < Convert.ToDecimal(Dr["CantidadSolicitada"]))
                        DtRequerimientos.ImportRow(Dr);
                }

                TdgRequerimientos.SetDataBinding(DtRequerimientos, "", true);
                TbDespachoPollo.SelectedIndex = 1;

            }
            else
            {
                if (CboSede.SelectedIndex == -1) { ErrProvider.SetError(CboSede, "Debe seleccionar una sede de destino."); }
                if (CboProductoPeso.SelectedIndex == -1) { ErrProvider.SetError(CboProductoPeso, "Debe seleccionar un producto.."); }
                //if (CboAlmacen.SelectedIndex == -1) { ErrProvider.SetError(CboAlmacen, "Debe seleccionar un almacen de donde sacar el producto."); }
            }
            Cursor = Cursors.Default;
        }

        private void TdgRequerimientos_DoubleClick(object sender, EventArgs e)
        {
            if (TdgRequerimientos.Row > -1)
            {
                ErrProvider.Clear();
                TbDespachoPollo.SelectedIndex = 0;
                ReadOnlyTxt(false);
                TxtAlmacenID.Value = TdgRequerimientos.Columns["RAlmacenID"].Value.ToString();
                TxtRequerimiento.Value = TdgRequerimientos.Columns["NumRequerimiento"].Value.ToString();
                TxtCodigo.Value = TdgRequerimientos.Columns["ProductoID"].Value.ToString();
                TxtProducto.Value = TdgRequerimientos.Columns["NomProducto"].Value.ToString();
                TxtUM.Value = TdgRequerimientos.Columns["UnidadMedidaID"].Value.ToString();
                TxtPrioridad.Value = TdgRequerimientos.Columns["PrioridadID"].Value.ToString();
                TxtObservacion.Value = TdgRequerimientos.Columns["ObservacionD"].Value.ToString();
                TxtIDEstado.Value = TdgRequerimientos.Columns["EstadoIDD"].Value.ToString();
                TxtEstado.Value = TdgRequerimientos.Columns["NomEstado"].Value.ToString();
                TxtStock.Value = TdgRequerimientos.Columns["StockActual"].Value.ToString();
                TxtSolicitado.Value = TdgRequerimientos.Columns["CantidadSolicitada"].Value.ToString();
                TxtRecibido.Value = TdgRequerimientos.Columns["CantidadRecibida"].Value.ToString();
                TxtTransito.Value = TdgRequerimientos.Columns["CantidadTransito"].Value.ToString();
                ReadOnlyTxt(true);
            }

            //obtener almacen local
            AlmacenIDLocal = TdgRequerimientos.Columns["AlmacenID"].Value.ToString();
        }

        private void CboChofer_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboChofer.SelectedValue != null)
            {
                TxtNroLicTransaportista.Value = CboChofer.Columns["Licencia"].Value;
                TxtDNITransportista.Value = CboChofer.Columns["DNI"].Value;
            }
        }

        private void CboVehiculo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboVehiculo.SelectedValue != null)
            {
                TxtMarca.Value = CboVehiculo.Columns["Marca"].Value;
                TxtPlaca.Value = CboVehiculo.Columns["Placa"].Value;
                TxtConfVehicular.Value = CboVehiculo.Columns["ConfiguracionVehicular"].Value;
                TxtNroConstInscripcion.Value = CboVehiculo.Columns["CertificadoInscripcion"].Value;
                CamionEmpresaID = CboVehiculo.Columns["EmpresaID"].Value.ToString();
            }
        }

        private void TdgRequerimientos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Escape))
            {
                TbDespachoPollo.SelectedIndex = 0;
            }
        }

        private void BtnVer_Click(object sender, EventArgs e)
        {
            //mostrar en reporte
            Reportes.FrmHojaDespacho ObjFrmHojaD = new Reportes.FrmHojaDespacho();
            ObjFrmHojaD.NumHojaDespacho = NumHojaDespacho;
            ObjFrmHojaD.ShowDialog();
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            BtnGrabar.Visible = false;
            BtnBalanza.Visible = false;
            //obtener los datos de la empresa de transporte
            ErrProvider.Clear();
            if (ChkExterno.Checked == false & CboChofer.SelectedValue != null & CboVehiculo.SelectedValue != null & TxtCantidad.Text != "")
            {
                CamionEmpresaID = CboVehiculo.Columns["EmpresaID"].Value.ToString();
                NomTransportista = CboChofer.Columns["NomChofer"].Value.ToString() + " " + CboChofer.Columns["ApeChofer"].Value.ToString();
                EmpresaTransporte = AppSettings.NomEmpresa;
                Placa = TxtPlaca.Value.ToString();
            }
            else
            {
                CamionEmpresaID = "EX";
                NomTransportista = TxtChofer.Value.ToString();
                EmpresaTransporte = TxtEmpresaTransporte.Value.ToString();
                Placa = TxtPlaca.Value.ToString();
            }
            //validar que tenga los datos del vehiculo para poder crear la hoja de despacho
            if (NomTransportista != "" & EmpresaTransporte != "" & Placa != "" & CboSedeDestino.SelectedIndex != -1 & DtTara.Rows.Count > 0 & DtPesoBruto.Rows.Count > 0)
            {
                if (Convert.ToDecimal(TxtSolicitado.Text) < Convert.ToDecimal(TxtCantidad.Text) + Convert.ToDecimal(TxtTransito.Text) + Convert.ToDecimal(TxtRecibido.Text)) //lo enviado no debe ser mayor a lo solicitado
                {
                    this.c1SuperTooltip1.Show("<table><tr><td><parm><img src='res://Pollos_32x32.gif'></parm></td><td><b><parm>Ingresar Cantidad</parm></b></td></tr></table><parm><hr noshade size=1 style='margin:2' color=Darker></parm><div style='margin:1 12'><parm>Aqui debe ingresar el total<br>de unidades despachadas</parm></div><parm><hr noshade size=1 style='margin:2' color=Darker></parm><table><tr><td><parm><img src='res://pollito32x32.gif'></parm></td><td><b><parm>lo despachado no<br>debe ser mayor a<br>lo solicitado</parm></b></td></tr></table>", this.TxtCantidad, 50, 0, 4000);
                    TxtCantidad.Text = "";
                    BtnGrabar.Visible = true;
                    BtnBalanza.Visible = true;
                }
                else
                {
                    CrearGuias();

                    #region limpiar
                    ErrProvider.Clear();
                    DtRequerimientos = new DataTable();
                    TdgRequerimientos.SetDataBinding(DtRequerimientos, "", true);

                    ReadOnlyTxt(false);
                    TxtAlmacenID.Value = "";
                    TxtRequerimiento.Value = "";
                    TxtCodigo.Value = "";
                    TxtProducto.Value = "";
                    TxtUM.Value = "";
                    TxtPrioridad.Value = "";
                    TxtObservacion.Value = "";
                    TxtIDEstado.Value = "";
                    TxtEstado.Value = "";
                    TxtStock.Value = "";
                    TxtSolicitado.Value = "";
                    TxtRecibido.Value = "";
                    TxtTransito.Value = "";
                    TxtCantidad.Value = "";
                    TxtNroJabas.Value = "";
                    TxtTara.Value = "";
                    TxtNeto.Value = "";
                    TxtBruto.Value = "";
                    ReadOnlyTxt(true);
                    //limpiar tabla y cargarla en la grilla
                    DetallesRequerimientos.Clear();
                    //habilitra control de guardar
                    BtnGrabar.Visible = true;
                    BtnBalanza.Visible = true;


                    DtTara.Clear();
                    DtPesoBruto.Clear();
                    Neto = 0;
                    Tara = 0;
                    Bruto = 0;
                    NroJabas = 0;
                    TdgTara.SetDataBinding(DtTara,"",true);
                    TdgPesoBruto.SetDataBinding(DtPesoBruto, "", true);
                    #endregion
                    MessageBox.Show("Se guardo correctamente los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
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
                if (TxtCantidad.Text == "") {
                    ErrProvider.SetError(TxtCantidad, "Debe ingresar la cantidad a despachar.");
                    this.c1SuperTooltip1.Show("<table><tr><td><parm><img src='res://Pollos_32x32.gif'></parm></td><td><b><parm>Ingresar Cantidad</parm></b></td></tr></table><parm><hr noshade size=1 style='margin:2' color=Darker></parm><div style='margin:1 12'><parm>Aqui debe ingresar el total<br>de unidades despachadas</parm></div><parm><hr noshade size=1 style='margin:2' color=Darker></parm><table><tr><td><parm><img src='res://pollito32x32.gif'></parm></td><td><b><parm>lo despachado no<br>debe ser mayor a<br>lo solicitado</parm></b></td></tr></table>", this.TxtCantidad, 50, 0, 4000);
                }
                BtnGrabar.Visible = true;
                BtnBalanza.Visible = true;
            }
            
        }

        private void CrearGuias()
        {
            #region Crear guiaremision
            E_GuiaRemision ObjGuiaRemision = new E_GuiaRemision();

            ObjGuiaRemision.EmpresaID = EmpresaIDUser;
            ObjGuiaRemision.NroJabas = Convert.ToInt16(TxtNroJabas.Value);
            ObjGuiaRemision.DesAnimal = TxtProducto.Value.ToString();
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
            ObjGuiaRemision.Marca = TxtMarca.Value.ToString();
            ObjGuiaRemision.Placa = TxtPlaca.Value.ToString();
            ObjGuiaRemision.Carrosa = TxtCarrosa.Text;
            ObjGuiaRemision.NombreChofer = NomTransportista;
            ObjGuiaRemision.DNIChofer = TxtDNITransportista.Value.ToString();
            ObjGuiaRemision.FechaSalida = Convert.ToDateTime(DeFechaSalida.Value.ToString());
            ObjGuiaRemision.ConfiguracionVehicular = TxtConfVehicular.Value.ToString();
            if (TxtNroConstInscripcion.Text == "")
            { ObjGuiaRemision.NroConstInscripcion = 0; }
            else
            { ObjGuiaRemision.NroConstInscripcion = Convert.ToInt32(TxtNroConstInscripcion.Value); }
            ObjGuiaRemision.NroLicTransportista = TxtNroLicTransaportista.Value.ToString();
            ObjGuiaRemision.NroFactura = "";
            ObjGuiaRemision.Pesador = Pesador;
            ObjGuiaRemision.Galponero = Galponero;
            ObjGuiaRemision.UsuarioID = AppSettings.UserID;
            #endregion

            #region Crear GuiaTransportista
            //se crea guia de transportista si solo si el camion no pertenece a la empresa de destino
            E_GuiaTransporte ObjGuiaTransporte = new E_GuiaTransporte();
            if ((EmpresaIDUser != CamionEmpresaID) && CamionEmpresaID != "EX")
            {
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
                ObjGuiaTransporte.Placa = TxtPlaca.Value.ToString();
                ObjGuiaTransporte.Carrosa = TxtCarrosa.Text;
                ObjGuiaTransporte.NombreChofer = NomTransportista;
                ObjGuiaTransporte.DNIChofer = TxtDNITransportista.Value.ToString();
                ObjGuiaTransporte.FechaSalida = Convert.ToDateTime(DeFechaSalida.Value);
                ObjGuiaTransporte.ConfiguracionVehicular = TxtConfVehicular.Value.ToString();
                if (TxtNroConstInscripcion.Value.ToString() == "")
                { ObjGuiaTransporte.NroConstInscripcion = 0; }
                else
                { ObjGuiaTransporte.NroConstInscripcion = Convert.ToInt32(TxtNroConstInscripcion.Value); }

                ObjGuiaTransporte.NroLicTransportista = TxtNroLicTransaportista.Value.ToString();
                ObjGuiaTransporte.UsuarioID = AppSettings.UserID;
            }
            #endregion

            #region Acumular los totales de las guias
            NetoTotal += Neto;
            TaraTotal += Tara;
            BrutoTotal += Bruto;
            NroJabasTotal += NroJabas;
            Cantidad += Cantidad;
            #endregion

            //obtener peso total
            PesoTotal += Convert.ToDecimal(TxtBruto.Text);

            DataSet Ds = new DataSet();
            Ds = new CL_GuiaRemision().CrearGuias(DtPesoBruto, DtTara, Convert.ToDecimal(TxtBruto.Text), ObjGuiaRemision, AppSettings.SedeID, CamionEmpresaID,
                TxtCodigo.Text, TxtRequerimiento.Text, Convert.ToDecimal(TxtNeto.Text), Convert.ToDecimal(TxtTara.Text),
                Convert.ToDecimal(TxtCantidad.Text), Convert.ToDecimal(TxtRecibido.Text), Convert.ToDecimal(TxtSolicitado.Text),
                Convert.ToDecimal(TxtTransito.Text), Convert.ToDecimal(TxtNroJabas.Text), CboSedeDestino.Columns["NomSede"].Value.ToString(),
                AlmacenIDLocal, ObjGuiaTransporte, CboSedeDestino.SelectedValue.ToString(), AppSettings.UserID);

            #region mostrar en grilla
            //extraer los registros de la tabla
            if (Ds.Tables["DtGuias"].Rows.Count > 0)
            {
                foreach (DataRow Row in Ds.Tables["DtGuias"].Rows)
                {
                    DtGuias.ImportRow(Row);
                }
            }


            TbDespachoPollo.SelectedIndex = 2;
            TdgGuias.SetDataBinding(DtGuias, "", true);
            #endregion
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtCantidad);
        }

        private void ReadOnlyTxt(bool Valor)
        {
            //habilitar controles
            TxtAlmacenID.ReadOnly = Valor;
            TxtRequerimiento.ReadOnly = Valor;
            TxtCodigo.ReadOnly = Valor;
            TxtProducto.ReadOnly = Valor;
            TxtUM.ReadOnly = Valor;
            TxtPrioridad.ReadOnly = Valor;
            TxtObservacion.ReadOnly = Valor;
            TxtIDEstado.ReadOnly = Valor;
            TxtEstado.ReadOnly = Valor;
            TxtStock.ReadOnly = Valor;
            TxtSolicitado.ReadOnly = Valor;
            TxtRecibido.ReadOnly = Valor;
            TxtTransito.ReadOnly = Valor;
            TxtNroJabas.ReadOnly = Valor;
            TxtTara.ReadOnly = Valor;
            TxtNeto.ReadOnly = Valor;
            TxtBruto.ReadOnly = Valor;
        }

        private void TdgRequerimientos_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {
            //darle el color a al celda segun su prioridad
            switch (e.Column.DataColumn.DataField)
            {
                case "PrioridadID":
                    if (this.TdgRequerimientos[e.Row, "PrioridadID"].ToString().Trim() == "M")
                    {
                        e.CellStyle.BackColor = Color.Gold;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    }

                    if (this.TdgRequerimientos[e.Row, "PrioridadID"].ToString().Trim() == "B")
                    {
                        e.CellStyle.BackColor = Color.MediumSeaGreen;
                        break;
                    }

                    if (this.TdgRequerimientos[e.Row, "PrioridadID"].ToString().Trim() == "A")
                    {
                        e.CellStyle.BackColor = Color.Crimson;
                        break;
                    }
                    break;
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            //limpiar todo
            ErrProvider.Clear();
            DtRequerimientos = new DataTable();
            TdgRequerimientos.SetDataBinding(DtRequerimientos, "", true);

            ReadOnlyTxt(false);
            TxtAlmacenID.Value = "";
            TxtRequerimiento.Value = "";
            TxtCodigo.Value = "";
            TxtProducto.Value = "";
            TxtUM.Value = "";
            TxtPrioridad.Value = "";
            TxtObservacion.Value = "";
            TxtIDEstado.Value = "";
            TxtEstado.Value = "";
            TxtStock.Value = "";
            TxtSolicitado.Value = "";
            TxtRecibido.Value = "";
            TxtTransito.Value = "";
            TxtCantidad.Value = "";
            TxtNroJabas.Value = "";
            TxtTara.Value="";
            TxtNeto.Value = "";
            TxtBruto.Value="";
            ReadOnlyTxt(true);
            //limpiar tabla y cargarla en la grilla
            DetallesRequerimientos.Clear();
            //habilitra control de guardar
            BtnGrabar.Visible = true;
            BtnBalanza.Visible = true;


            DtTara.Clear();
            DtPesoBruto.Clear();
            Neto = 0;
            Tara = 0;
            Bruto = 0;
            NroJabas = 0;
            TdgTara.SetDataBinding(DtTara, "", true);
            TdgPesoBruto.SetDataBinding(DtPesoBruto, "", true);

            //deshabilitar paraa que no pueda ser modificado
            GbFecha.Enabled = false;
            GbVehiculo.Enabled = false;
            ChkExterno.Enabled = false;
        }



        private void TdgGuias_MouseClick(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //para mostrar las guias al hacer click
            int row, col;
            if (this.TdgGuias.CellContaining(e.X, e.Y, out row, out col)==true && col < 4)
            {
                string Val = this.TdgGuias[row, col + 8] as string;
                if (col == 1 && Val != "")
                {
                    FrmGuiaRemisionPeso ObjFrmGuiaRemisionPeso = new FrmGuiaRemisionPeso();
                    ObjFrmGuiaRemisionPeso.NumGuiaRemision = Val;
                    ObjFrmGuiaRemisionPeso.ShowDialog();
                }
                if (col == 2 && Val + "" != "")
                {
                    FrmGuiaTransporte ObjFrmGuiaTransporte = new FrmGuiaTransporte();
                    ObjFrmGuiaTransporte.NumGuiaTransportista = Val;
                    ObjFrmGuiaTransporte.ShowDialog();
                }
            }
            Cursor = Cursors.Default;
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
            if (RbPeso.Checked == true & ObjBalanza.Peso > 0 & ObjBalanza.Cantidad > 0)
            {
                DataRow Row = DtPesoBruto.NewRow();
                Row["NumGuiaRemision"] = NumGuiaRemision;
                Row["Cantidad"] = ObjBalanza.Cantidad;
                Row["Peso"] = ObjBalanza.Peso;
                Row["Tipo"] = "P";
                DtPesoBruto.Rows.Add(Row);

                Bruto += ObjBalanza.Peso;
                NroJabas += ObjBalanza.Cantidad; //calcular la cantidad de jabas enviadas
            }
            else if (RbTara.Checked == true && ObjBalanza.Peso > 0)
            {
                DataRow Row = DtTara.NewRow();
                Row["NumGuiaRemision"] = NumGuiaRemision;
                Row["Cantidad"] = ObjBalanza.Cantidad;
                Row["Peso"] = ObjBalanza.Peso;
                Row["Tipo"] = "T";
                DtTara.Rows.Add(Row);

                Tara += ObjBalanza.Peso;
            }
            else
                MessageBox.Show("No ingreso la cantidad, no se agregara el peso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Neto = Bruto - Tara;

            TxtTara.ReadOnly = false;
            TxtNeto.ReadOnly = false;
            TxtBruto.ReadOnly = false;
            TxtNroJabas.ReadOnly = false;
            TxtTara.Value = Tara;
            TxtNeto.Value = Neto;
            TxtBruto.Value = Bruto;
            TxtNroJabas.Value = NroJabas;
            TxtTara.ReadOnly = true;
            TxtNeto.ReadOnly = true;
            TxtBruto.ReadOnly = true;
            TxtNroJabas.ReadOnly = true;
        }

        private void BtnGenerarHojaDespacho_Click(object sender, EventArgs e)
        {
            if (DtGuias.Rows.Count > 0)
            {
                BtnGenerarHojaDespacho.Visible = false;
                BtnNuevo.Visible = false;
                BtnGrabar.Visible = false;
                BtnBalanza.Visible = false;
                RbPeso.Visible = false;
                RbTara.Visible = false;
                #region inserta hoja de despacho y se obtiene el codigo

                //Insertar Hoja de despacho
                E_HojaDespacho ObjHojaDespacho = new E_HojaDespacho();
                ObjHojaDespacho.EmpresaID = EmpresaIDUser;
                ObjHojaDespacho.EmpresaTransporte = EmpresaTransporte;
                ObjHojaDespacho.NombreChofer = NomTransportista;
                ObjHojaDespacho.placa = TxtPlaca.Text;
                ObjHojaDespacho.Carrosa = TxtCarrosa.Text;
                ObjHojaDespacho.FechaLlegada = Convert.ToDateTime(DeFechaLlegada.Value);
                ObjHojaDespacho.FechaSalida = Convert.ToDateTime(DeFechaSalida.Value);
                ObjHojaDespacho.NumJabas = NroJabasTotal;
                ObjHojaDespacho.PesoTotal = BrutoTotal;
                ObjHojaDespacho.PesoNeto = NetoTotal;
                ObjHojaDespacho.TotalAnimales = Cantidad;
                ObjHojaDespacho.TaraTotal = TaraTotal;
                ObjHojaDespacho.UsuarioID = AppSettings.UserID;

                NumHojaDespacho = new CL_HojaDespacho().InsertHojaDespacho(ObjHojaDespacho, AppSettings.SedeID);
                #endregion

                #region crear tablas
                //Tabla para insertar el detalle de la hoja de despacho
                DataTable DetalleHojaDespacho = new DataTable();
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
                #endregion

                //para detalle hoja despacho
                foreach (DataRow Row2 in DtGuias.Rows)
                {
                    DataRow RowHD = DetalleHojaDespacho.NewRow();
                    RowHD["ProductoID"] = Row2["ProductoID"];
                    RowHD["NumHojaDespacho"] = NumHojaDespacho;
                    RowHD["NumGuiaRemision"] = Row2["NumGuiaRemision"];
                    RowHD["NumRequerimiento"] = Row2["NumRequerimiento"];
                    RowHD["NroFactura"] = Row2["NroFactura"];
                    RowHD["TotalPeso"] = Row2["TotalPeso"];
                    RowHD["Motivo"] = Row2["Motivo"];
                    RowHD["NumGuiaTransportista"] = Row2["NumGuiaTransportista"];
                    RowHD["Bultos"] = Row2["Bultos"];
                    RowHD["IDProveedor"] = Row2["IDProveedor"];
                    DetalleHojaDespacho.Rows.Add(RowHD);
                }


                if (DetalleHojaDespacho.Rows.Count > 0)
                {
                    string xml = new BaseFunctions().GetXML(DetalleHojaDespacho).Replace("NewDataSet", "DocumentElement");
                    bool Valor;
                    Valor = new CL_HojaDespacho().InsertXMLDetalleHojaDespacho(xml);
                    if (Valor == false)
                        MessageBox.Show("Ocurrio un error al intentar insertar los detalles de la hoja de despacho", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //mostrar en reporte
                Reportes.FrmHojaDespacho ObjFrmHojaD = new Reportes.FrmHojaDespacho();
                ObjFrmHojaD.NumHojaDespacho = NumHojaDespacho;
                ObjFrmHojaD.ShowDialog();
            }
            else
                MessageBox.Show("No se ha creado aún alguna guia.", "Hoja de despacho", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
             o.Filter = "All Archives of Microsoft Office Excel|*.xls;*.xlsx;*.csv";
             if (o.ShowDialog() == DialogResult.OK)
             {

                 Microsoft.Office.Interop.Excel._Application xlApl = new Microsoft.Office.Interop.Excel.Application();
                 Microsoft.Office.Interop.Excel._Workbook xlLibro;
                 Microsoft.Office.Interop.Excel._Worksheet xlHoja;
                 Microsoft.Office.Interop.Excel.Sheets xlHojas;

                 xlLibro = xlApl.Workbooks.Open(o.FileName, Missing.Value, Missing.Value, Missing.Value, "12345", "123456");
                 xlHojas = xlLibro.Sheets;
                 xlHoja = (Microsoft.Office.Interop.Excel._Worksheet)xlHojas[1];

                 DataRow _dRow;
                 int _Row = 2;

                 DtImportado= new DataTable();
                 DtImportado.Columns.Add("Peso", typeof(decimal));
                 DtImportado.Columns.Add("Cantidad", typeof(string));
                 DtImportado.Columns.Add("Tipo", typeof(string));
                 DtImportado.Columns.Add("UsuarioID", typeof(string));
                 DtImportado.Columns.Add("Usuario", typeof(string));
                 DtImportado.Columns.Add("AlmacenID", typeof(string));
                 DtImportado.Columns.Add("Almacen", typeof(string));
                 DtImportado.Columns.Add("Pesador", typeof(string));
                 DtImportado.Columns.Add("Galponero", typeof(string));

                 while (xlHoja.get_Range("A" + _Row, Missing.Value).Text.ToString().Trim() != "")
                 {
                     _dRow = DtImportado.NewRow();
                     _dRow["Peso"] = Convert.ToDecimal(xlHoja.get_Range("A" + _Row, Missing.Value).Text.ToString().Trim());
                     _dRow["Cantidad"] = Convert.ToString(xlHoja.get_Range("B" + _Row, Missing.Value).Text.ToString().Trim());
                     _dRow["Tipo"] = Convert.ToString(xlHoja.get_Range("C" + _Row, Missing.Value).Text.ToString().Trim());
                     _dRow["UsuarioID"] = Convert.ToString(xlHoja.get_Range("D" + _Row, Missing.Value).Text.ToString().Trim());
                     _dRow["Usuario"] = Convert.ToString(xlHoja.get_Range("E" + _Row, Missing.Value).Text.ToString().Trim());
                     _dRow["AlmacenID"] = Convert.ToString(xlHoja.get_Range("F" + _Row, Missing.Value).Text.ToString().Trim());
                     _dRow["Almacen"] = Convert.ToString(xlHoja.get_Range("G" + _Row, Missing.Value).Text.ToString().Trim());
                     _dRow["Pesador"] = Convert.ToString(xlHoja.get_Range("H" + _Row, Missing.Value).Text.ToString().Trim());
                     _dRow["Galponero"] = Convert.ToString(xlHoja.get_Range("I" + _Row, Missing.Value).Text.ToString().Trim());
                     DtImportado.Rows.Add(_dRow);
                     _Row++;
                 }

                 xlLibro.Close(false, Missing.Value, Missing.Value);
                 xlApl.Quit();
                 
                 /*//filtrar por galpones
                 DataTable DtGalpones = new DataTable();
                 DtGalpones = new BaseFunctions().SelectDistinct(DtImportado, "AlmacenID", "Almacen");
                 TdgGalpones.SetDataBinding(DtGalpones, "", true);*/

                 //ocultar botones
                 BtnBalanza.Visible = false;
                 RbPeso.Visible = false;
                 RbTara.Visible = false;

                 if (DtImportado.Rows.Count > 0)//Si contiene registros
                 {
                     string AlmacenIDGalpon = "";
                     Tara = 0;
                     Neto = 0;
                     Bruto = 0;
                     NroJabas = 0;
                     AlmacenIDGalpon = DtImportado.Rows[0]["AlmacenID"].ToString();
                     //Nombre del galpon
                     TxtDesGalpon.ReadOnly = false;
                     TxtDesGalpon.Text = "";
                     TxtDesGalpon.Text = DtImportado.Rows[0]["Almacen"].ToString();
                     TxtDesGalpon.ReadOnly = true;
                     DataView dvT = new DataView(DtImportado);
                     DataView dvP = new DataView(DtImportado);
                     dvT.RowFilter = "AlmacenID = '" + AlmacenIDGalpon + "' and Tipo = 'T'";
                     dvP.RowFilter = "AlmacenID = '" + AlmacenIDGalpon + "' and Tipo = 'P'";
                     DtTara.Rows.Clear();
                     DtPesoBruto.Rows.Clear();

                     //calcular totales
                     foreach (DataRowView drv in dvT)
                     {
                         Tara += Convert.ToDecimal(drv["Peso"]);

                         DataRow Row = DtTara.NewRow();
                         Row["NumGuiaRemision"] = NumGuiaRemision;
                         Row["Cantidad"] = 0;
                         Row["Peso"] = Convert.ToDecimal(drv["Peso"]);
                         Row["Tipo"] = "T";
                         DtTara.Rows.Add(Row);
                     }

                     foreach (DataRowView drv in dvP)
                     {
                         Bruto += Convert.ToDecimal(drv["Peso"]);
                         NroJabas += Convert.ToInt32(drv["Cantidad"]);

                         DataRow Row = DtPesoBruto.NewRow();
                         Row["NumGuiaRemision"] = NumGuiaRemision;
                         Row["Cantidad"] = Convert.ToInt32(drv["Cantidad"]);
                         Row["Peso"] = Convert.ToDecimal(drv["Peso"]);
                         Row["Tipo"] = "P";
                         DtPesoBruto.Rows.Add(Row);

                         //obtener el galponero y el pesador
                         Pesador = drv["Pesador"].ToString();
                         Galponero = drv["Galponero"].ToString();
                     }

                     Neto = Bruto - Tara;

                     TxtTara.ReadOnly = false;
                     TxtNeto.ReadOnly = false;
                     TxtBruto.ReadOnly = false;
                     TxtNroJabas.ReadOnly = false;
                     TxtTara.Value = Tara;
                     TxtNeto.Value = Neto;
                     TxtBruto.Value = Bruto;
                     TxtNroJabas.Value = NroJabas;
                     TxtTara.ReadOnly = true;
                     TxtNeto.ReadOnly = true;
                     TxtBruto.ReadOnly = true;
                     TxtNroJabas.ReadOnly = true;

                     //mostrar en grilla
                     TdgTara.SetDataBinding(DtTara, "", true);
                     TdgPesoBruto.SetDataBinding(DtPesoBruto, "", true);
                 }
             }
             
        }

    }
    
}
