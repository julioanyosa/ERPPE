using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.Entidad.Almacen;
using Halley.Configuracion;
using Halley.CapaLogica.Empresa;
using Halley.Utilitario;
using Halley.CapaLogica.Ventas;

namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class FrmGuias : Form
    {
        #region Variables
        private string NumGuiaRemision;
        private string NumGuiaTransportista;
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
        private string DomicilioLlegada;
        private string ZonaDomicilioLlegada;
        private string DisDomicilioLlegada;
        private string ProvDomicilioLlegada;
        private string DepDomicilioLlegada;
        private string DireccionDestinatario;
        private string ObservacionDestinatario;
        private string Pesador;
        private string Galponero;
        private string ObservacionRemitente;

        private DataTable DtEmpresas = new DataTable();
        private DataTable DtAlmacenUsuario = new DataTable();
        private DataTable DtVehiculos = new DataTable();
        private DataTable DtChoferes = new DataTable();

        DataSet DsRemitente = new DataSet();
        DataSet DsTransporte = new DataSet();

        CL_GuiaRemision ObjCL_GuiaRemision = new CL_GuiaRemision();
        CL_GuiaTransportista ObjCL_GuiaTransportista = new CL_GuiaTransportista();
        CL_Venta ObjCL_Venta = new CL_Venta();
        #endregion

        #region propiedades
        //private DataTable _DtDetalleGuiaTransporte;
        private DataTable _DetalleGuiaRemisionVenta;
        private DataTable _DtTipoComprobante;
        private string _Destinatario;
        private string _RUCDestinatario;
        private string _Remitente;
        private string _RUCRemitente;
        private DataTable _DtServicios;

        /*public DataTable DtDetalleGuiaTransporte
        {
            get { return _DtDetalleGuiaTransporte; }
            set { _DtDetalleGuiaTransporte = value; }
        }*/
        public DataTable DtDetalleGuiaRemisionVenta
        {
            get { return _DetalleGuiaRemisionVenta; }
            set { _DetalleGuiaRemisionVenta = value; }
        }
        public DataTable DtTipoComprobante
        {
            get { return _DtTipoComprobante; }
            set { _DtTipoComprobante = value; }
        }
        public string Destinatario
        {
            get { return _Destinatario; }
            set { _Destinatario = value; }
        }
        public string RUCDestinatario
        {
            get { return _RUCDestinatario; }
            set { _RUCDestinatario = value; }
        }
        public string Remitente
        {
            get { return _Remitente; }
            set { _Remitente = value; }
        }
        public string RUCRemitente
        {
            get { return _RUCRemitente; }
            set { _RUCRemitente = value; }
        }
        public DataTable DtServicios
        {
            get { return _DtServicios; }
            set { _DtServicios = value; }
        }

        #endregion
        public FrmGuias()
        {
            InitializeComponent();
        }

        private void FrmGuiascs_Load(object sender, EventArgs e)
        {

            //eliminar los servicios para que no sean mostrados en la guia
            foreach (DataRow DR in DtServicios.Rows)
            {
                //se elimina el registro que contiene el descuento
                DataView Dv = new DataView(DtDetalleGuiaRemisionVenta);
                Dv.RowFilter = "ProductoID = '" + DR["ProductoID"].ToString() + "'";
                if (Dv.Count > 0)
                {
                    DataRow[] customerRow = DtDetalleGuiaRemisionVenta.Select("ProductoID = '" + DR["ProductoID"].ToString() + "'");
                    customerRow[0].Delete();
                }
            }

            DtEmpresas = new CL_Empresas().GetEmpresas();
            DtVehiculos = new CL_Vehiculo().GetVehiculos();
            DtChoferes = new CL_Choferes().GetChoferes();
            c1Combo.FillC1Combo1(CboVehiculo, DtVehiculos, "Marca", "Placa");
            c1Combo.FillC1Combo1(CboChofer, DtChoferes, "NomChofer", "ChoferID");
            if (DtTipoComprobante.Rows.Count > 0)
                c1Combo.FillC1Combo1(cbComprobante, DtTipoComprobante, "NomTipoComprobante", "TipoComprobanteID");
            c1Combo.FillC1Combo(this.c1cboCia, DtEmpresas.Copy(), "NomEmpresa", "EmpresaID");
            //obtener la sede del usuario
            DtAlmacenUsuario = AppSettings.AlmacenPermisos;
            //traer todas las empresas
            
            DeFechaSalida.Value = DateTime.Now.Date;

            if (DtDetalleGuiaRemisionVenta.Rows.Count > 0)
                TdgDetalle.SetDataBinding(DtDetalleGuiaRemisionVenta, "", true);
        }

        #region Metodos
        private DataSet CrearGuiaTransporte()
        {

            E_GuiaTransporte ObjGuiaTransporte = new E_GuiaTransporte();

            ObjGuiaTransporte.EmpresaID = CamionEmpresaID;
            ObjGuiaTransporte.DomicilioPartida = DomicilioPartida;
            ObjGuiaTransporte.NroDomicilioPartida = NroDomicilioPartida;
            ObjGuiaTransporte.IntDomicilioPartida = IntDomicilioPartida;
            ObjGuiaTransporte.ZonaDomicilioPartida = ZonaDomicilioPartida;
            ObjGuiaTransporte.DisDomicilioPartida = DisDomicilioPartida;
            ObjGuiaTransporte.ProvDomicilioPartida = ProvDomicilioPartida;
            ObjGuiaTransporte.DepDomicilioPartida = DepDomicilioPartida;
            ObjGuiaTransporte.DomicilioLlegada = DomicilioLlegada;
            if (txtNumero.Text != "")
                ObjGuiaTransporte.NroDomicilioLlegada = Convert.ToInt32(txtNumero.Text);
            if (txtInterior.Text != "")
                ObjGuiaTransporte.IntDomicilioLlegada = Convert.ToInt32(txtInterior.Text);
            ObjGuiaTransporte.ZonaDomicilioLlegada = ZonaDomicilioLlegada;
            ObjGuiaTransporte.DisDomicilioLlegada = DisDomicilioLlegada;
            ObjGuiaTransporte.ProvDomicilioLlegada = ProvDomicilioLlegada;
            ObjGuiaTransporte.DepDomicilioLlegada = DepDomicilioLlegada;
            ObjGuiaTransporte.Remitente = Remitente;
            ObjGuiaTransporte.RUCRemitente = RUCRemitente;
            ObjGuiaTransporte.DireccionRemitente = DomicilioPartida;
            ObjGuiaTransporte.ObservacionRemitente = ObservacionRemitente;
            ObjGuiaTransporte.Destinatario = Destinatario;
            ObjGuiaTransporte.RUCDestinatario = RUCDestinatario;
            ObjGuiaTransporte.DireccionDestinatario = DireccionDestinatario;
            ObjGuiaTransporte.ObservacionDestinatario = ObservacionDestinatario;
            ObjGuiaTransporte.Marca = CboVehiculo.SelectedText;
            ObjGuiaTransporte.Placa = TxtPlaca.Text;
            ObjGuiaTransporte.Carrosa = TxtCarrosa.Text;
            ObjGuiaTransporte.NombreChofer = NomTransportista;
            ObjGuiaTransporte.DNIChofer = TxtDNITransportista.Text;
            ObjGuiaTransporte.FechaSalida = Convert.ToDateTime(DeFechaSalida.Value);
            ObjGuiaTransporte.ConfiguracionVehicular = TxtConfVehicular.Text;
            if (TxtNroConstInscripcion.Text != "")
                ObjGuiaTransporte.NroConstInscripcion = Convert.ToInt32(TxtNroConstInscripcion.Text);
            ObjGuiaTransporte.NroLicTransportista = TxtNroLicTransaportista.Text;
            ObjGuiaTransporte.TipoGuia = "V";
            ObjGuiaTransporte.UsuarioID = AppSettings.UserID;

            //insertar guia transporte y obtener el codigo de registro insertado
            DataSet DsTransporte = new DataSet();
            DsTransporte = ObjCL_GuiaTransportista.CrearGuiaTransporte(ObjGuiaTransporte, DtDetalleGuiaRemisionVenta, AppSettings.EmpresaID + AppSettings.SedeID);
            return DsTransporte;
        }

        private DataSet CrearGuiaRemitente()
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
            ObjGuiaRemision.DomicilioLlegada = DomicilioLlegada;
            if (txtNumero.Text != "")
                ObjGuiaRemision.NroDomicilioLlegada = Convert.ToInt32(txtNumero.Text);
            if (txtInterior.Text != "")
                ObjGuiaRemision.IntDomicilioLlegada = Convert.ToInt32(txtInterior.Text);
            ObjGuiaRemision.ZonaDomicilioLlegada = ZonaDomicilioLlegada;
            ObjGuiaRemision.DisDomicilioLlegada = DisDomicilioLlegada;
            ObjGuiaRemision.ProvDomicilioLlegada = ProvDomicilioLlegada;
            ObjGuiaRemision.DepDomicilioLlegada = DepDomicilioLlegada;
            ObjGuiaRemision.Destinatario = Destinatario;
            ObjGuiaRemision.RUCDestinatario = RUCDestinatario;
            ObjGuiaRemision.DireccionDestinatario = DireccionDestinatario;
            ObjGuiaRemision.ObservacionDestinatario = ObservacionDestinatario;
            ObjGuiaRemision.Marca = TxtMarca.Text;
            ObjGuiaRemision.Placa = TxtPlaca.Text;
            ObjGuiaRemision.Carrosa = TxtCarrosa.Text;
            ObjGuiaRemision.NombreChofer = NomTransportista;
            ObjGuiaRemision.DNIChofer = TxtDNITransportista.Text;
            ObjGuiaRemision.FechaSalida = Convert.ToDateTime(DeFechaSalida.Value);
            ObjGuiaRemision.ConfiguracionVehicular = TxtConfVehicular.Text;
            if (TxtNroConstInscripcion.Text != "")
                ObjGuiaRemision.NroConstInscripcion = Convert.ToInt32(TxtNroConstInscripcion.Text);
            ObjGuiaRemision.NroLicTransportista = TxtNroLicTransaportista.Text;
            ObjGuiaRemision.NroFactura = NroFactura;
            ObjGuiaRemision.EmpresaTransporte = EmpresaTransporte;
            ObjGuiaRemision.RUCTransporte = RUCTransporte;
            ObjGuiaRemision.Pesador = Pesador;
            ObjGuiaRemision.Galponero = Galponero;
            ObjGuiaRemision.TipoGuia = "V";//tipo venta
            ObjGuiaRemision.UsuarioID = AppSettings.UserID;

            DataSet DsRemitente = new DataSet();
            DsRemitente = ObjCL_GuiaRemision.CrearGuiaRemitente(ObjGuiaRemision, DtDetalleGuiaRemisionVenta, AppSettings.EmpresaID + AppSettings.SedeID);
            return DsRemitente;
        }

        private void ObtenerDatos()
        {
            DomicilioPartida = AppSettings.NomSede;
            if (DtAlmacenUsuario.Rows[0]["Numero"] != DBNull.Value)
               NroDomicilioPartida = Convert.ToInt16(DtAlmacenUsuario.Rows[0]["Numero"]);
            if (DtAlmacenUsuario.Rows[0]["Interior"] != DBNull.Value)
               IntDomicilioPartida = Convert.ToInt16(DtAlmacenUsuario.Rows[0]["Interior"]);
            ZonaDomicilioPartida = DtAlmacenUsuario.Rows[0]["Zona"].ToString();
            DisDomicilioPartida = DtAlmacenUsuario.Rows[0]["Distrito"].ToString();
            ProvDomicilioPartida = DtAlmacenUsuario.Rows[0]["Provincia"].ToString();
            DepDomicilioPartida = DtAlmacenUsuario.Rows[0]["Departamento"].ToString();
            DomicilioLlegada = txtDestino.Text;
            ZonaDomicilioLlegada = txtZona.Text;
            DisDomicilioLlegada = txtDistrito.Text;
            ProvDomicilioLlegada = txtProvincia.Text;
            DepDomicilioLlegada = txtDepartamento.Text;

            DireccionDestinatario = txtDestino.Text;
            ObservacionDestinatario = "";
            Pesador="";
            Galponero="";

            ObservacionRemitente ="";

            if (ChkExterno.Checked == false & CboChofer.SelectedIndex != -1 & CboVehiculo.SelectedIndex != -1)
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
            NroFactura = "";
            SedeId = AppSettings.SedeID;
        }
        #endregion

        #region Eventos
        private void BtnCrearGuias_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            try
            {
                ObtenerDatos();

                //obtener los datos de la empresa de transporte


                //validar que tenga los datos del vehiculo para poder crear las guias
                if (NomTransportista != "" & EmpresaTransporte != "" & Placa != "" & this.txtDestino.Text != "" & txtNumero.Text != "" & txtInterior.Text != "")
                {
                    if (ChkExterno.Checked == true)
                    {
                        DsRemitente = CrearGuiaRemitente();
                        LstRemitente.HoldFields();
                        LstRemitente.DataSource = DsRemitente.Tables["DtCabecera"];
                    }
                    else
                    {
                        DsRemitente = CrearGuiaRemitente();
                        LstRemitente.HoldFields();
                        LstRemitente.DataSource = DsRemitente.Tables["DtCabecera"];
                        DsTransporte = CrearGuiaTransporte();
                        LstTransporte.HoldFields();
                        LstTransporte.DataSource = DsTransporte.Tables["DtCabecera"];
                    }
                    BtnCrearGuias.Visible = false;
                    GbDestino.Enabled = false;
                    GbVehiculo.Enabled = false;
                    DeFechaSalida.Enabled = false;
                    TdgDetalle.Enabled = false;
                    c1cboCia.Enabled = false;
                    cbComprobante.Enabled = false;
                    TxtNumComprobante.Enabled = false;
                    ChkExterno.Enabled = false;
                }
                else
                {
                    if (ChkExterno.Checked)
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
                    if (this.txtDestino.Text == "") { ErrProvider.SetError(txtDestino, "Ingrese el destino."); }
                    if (this.txtNumero.Text == "") { ErrProvider.SetError(txtNumero, "Ingrese el numero."); }
                    if (this.txtInterior.Text == "") { ErrProvider.SetError(txtInterior, "Ingrese el numero del interior."); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ChkExterno_CheckedChanged(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            if (ChkExterno.Checked == true)
            {
                PnlExterno.Visible = true;
                TxtMarca.Text = "";
                TxtPlaca.Text = "";
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

        private void LstRemitente_DoubleClick(object sender, EventArgs e)
        {
            //obtener datos del datase devuelto
            if (LstRemitente.SelectedIndex > -1)
            {
                NumGuiaRemision = LstRemitente.Columns["NumGuiaRemision"].Value.ToString();
                FrmGuiaRemision ObjFrmGuiaRemision = new FrmGuiaRemision();
                ObjFrmGuiaRemision.TipoGuia = "V";
                ObjFrmGuiaRemision.DtCabecera = DsRemitente.Tables["DtCabecera"].Copy();
                ObjFrmGuiaRemision.DtDetalle = DsRemitente.Tables["DetalleGuiaRemisionVenta"].Copy();
                ObjFrmGuiaRemision.ShowDialog();
            }
        }

        private void LstTransporte_DoubleClick(object sender, EventArgs e)
        {
            if (LstTransporte.SelectedIndex > -1)
            {
                NumGuiaTransportista = LstTransporte.Columns["NumGuiaTransportista"].Value.ToString();
                FrmGuiaTransporte ObjFrmGuiaTransporte = new FrmGuiaTransporte();
                ObjFrmGuiaTransporte.TipoGuia = "V";
                ObjFrmGuiaTransporte.NumGuiaTransportista = NumGuiaTransportista;
                ObjFrmGuiaTransporte.DtCabecera = DsTransporte.Tables["DtCabecera"].Copy();
                ObjFrmGuiaTransporte.DtDetalle = DsTransporte.Tables["DetalleGuiaRemisionVenta"].Copy();
                ObjFrmGuiaTransporte.ShowDialog();
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

        private void CboVehiculo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboVehiculo.SelectedValue != null)
            {
                TxtMarca.Text = CboVehiculo.Columns["Marca"].Text;
                TxtPlaca.Text = CboVehiculo.Columns["Placa"].Text;
                TxtConfVehicular.Text = CboVehiculo.Columns["ConfiguracionVehicular"].Text;
                TxtNroConstInscripcion.Text = CboVehiculo.Columns["CertificadoInscripcion"].Text;
                CamionEmpresaID = CboVehiculo.Columns["EmpresaID"].Text;
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            new TextFunctions().SoloNumero(sender, e, txtNumero);
        }

        private void txtInterior_KeyPress(object sender, KeyPressEventArgs e)
        {
            new TextFunctions().SoloNumero(sender, e, txtInterior);
        }
        #endregion

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            //traer todos los datos del comprobante
            if (c1cboCia.SelectedIndex != -1)
            {
                DataTable Dt = new DataTable();
                Dt = ObjCL_Venta.GetDetalleCrearGuias(c1cboCia.SelectedValue.ToString() + TxtNumComprobante.Text, Convert.ToInt32(cbComprobante.SelectedValue));
                Dt.Columns["PesoNeto"].ReadOnly = false;
                DtDetalleGuiaRemisionVenta.Clear();
                DtDetalleGuiaRemisionVenta = Dt;
                DtDetalleGuiaRemisionVenta.TableName = "detallePedido";
                TdgDetalle.SetDataBinding(DtDetalleGuiaRemisionVenta, "", true);

                foreach(DataRow DR in DtServicios.Rows)
                {
                    //se elimina el registro que contiene el descuento
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "ProductoID = '" + DR["ProductoID"].ToString() + "'";
                    if (Dv.Count > 0)
                    {
                        DataRow[] customerRow = Dt.Select("ProductoID = '" + DR["ProductoID"].ToString() + "'");
                        customerRow[0].Delete();
                    }
                }
            }
        }



    }
}
