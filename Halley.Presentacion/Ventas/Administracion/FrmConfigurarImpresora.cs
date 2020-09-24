using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Empresa;
using Halley.Utilitario;
using Halley.Configuracion;
using Halley.CapaLogica.Ventas;
using System.Configuration;
using System.Net;

namespace Halley.Presentacion.Ventas.Pagos
{
    public partial class FrmConfigurarImpresora : Form
    {

        string ImpresoraBoletaPeruanaEnvase = "";
        string ImpresoraFacturaPeruanaEnvase = "";
        string ImpresoraTicketPeruanaEnvase = "";
        string ImpresoraPago = "";
        string ImpresoraCB = "";
        CapaLogica.Users.CL_Usuario ObjUsuario = new CapaLogica.Users.CL_Usuario();

        string NuevaIP = "";

        public FrmConfigurarImpresora()
        {
            InitializeComponent();
        }

        private void FrmConfigurarImpresora_Load(object sender, EventArgs e)
        {
            //agregar empresa
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            c1Combo.FillC1Combo1(CboTipoComprobante, new CL_Comprobante().getTipoComprobante(), "NomTipoComprobante", "TipoComprobanteID");



            #region nueva ip
            String NombreHost;
            String DireccionIP;
            NombreHost = Dns.GetHostName();
            DireccionIP = System.Net.Dns.GetHostByName(NombreHost).AddressList[0] + "";
            //MessageBox.Show(DireccionIP);
            //dar formato a la direccion IP
            string ACU = "";
            NuevaIP = "";
            for (int X = 0; X < DireccionIP.Length; X++)
            {
                string Valor = DireccionIP.Substring(X, 1);
                if (Valor != ".")
                    ACU += Valor;
                else
                {
                    NuevaIP += ACU.PadLeft(3, '0') + ".";
                    ACU = "";
                }
            }
            NuevaIP += ACU.PadLeft(3, '0');
            #endregion

            //ahora se gauradara en una tabla Configuracion.Configuracion

            UTI_Datatables.Dt_Configuracion = ObjUsuario.USP_M_CONFIGURACION(2, 0, "", "", "", "", 0, NuevaIP);

            DataView dv = new DataView();

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_PE_BO'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblBoletaGranja.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_PE_FA'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblFacturaGranja.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_PE_TI'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblTicketGranja.Text = dv[0]["Data"].ToString();
            }


            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_PA'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblTicketPago.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_CB'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblImpresoraCB.Text = dv[0]["Data"].ToString();
            }

        }

        private void BtnImpresora_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {

                string EMPRESA_ID = c1cboCia.SelectedValue.ToString();
                if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 1 & EMPRESA_ID == "PE")//es boleta
                {
                    ImpresoraBoletaPeruanaEnvase = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraBoletaPeruanaEnvase != AppSettings.ImpresoraBoletaPeruanaEnvase & ImpresoraBoletaPeruanaEnvase != "")
                    {
                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_PE_BO", "IMPRESORA BOLETA DE PERUANA DE ENVASES", ImpresoraBoletaPeruanaEnvase, AppSettings.UserID, NuevaIP);
                        LblBoletaGranja.Text = ImpresoraBoletaPeruanaEnvase;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_PE_BO", ImpresoraBoletaPeruanaEnvase, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        //AppSettingsSection appSettings = config.AppSettings;

                        //KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraBoletaGranja"];
                        //setting.Value = ImpresoraBoletaGranja;
                        //config.Save(ConfigurationSaveMode.Modified);
                        //ConfigurationManager.RefreshSection("appSettings");
                        //LblBoletaGranja.Text = ImpresoraBoletaGranja;



                    }
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 2 & EMPRESA_ID == "PE")// es factura
                {
                    ImpresoraFacturaPeruanaEnvase = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraFacturaPeruanaEnvase != AppSettings.ImpresoraFacturaPeruanaEnvase & ImpresoraFacturaPeruanaEnvase != "")
                    {
                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_PE_FA", "IMPRESORA FACTURA DE GRANJA", ImpresoraFacturaPeruanaEnvase, AppSettings.UserID, NuevaIP);
                        LblFacturaGranja.Text = ImpresoraFacturaPeruanaEnvase;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_PE_FA", ImpresoraFacturaPeruanaEnvase, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        //AppSettingsSection appSettings = config.AppSettings;

                        //KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraFacturaGranja"];
                        //setting.Value = ImpresoraFacturaGranja;
                        //config.Save(ConfigurationSaveMode.Modified);
                        //ConfigurationManager.RefreshSection("appSettings");
                        //LblFacturaGranja.Text = ImpresoraFacturaGranja;
                        //MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 3 & c1cboCia.SelectedValue.ToString() == "PE")// es ticket
                {
                    ImpresoraTicketPeruanaEnvase = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraTicketPeruanaEnvase != AppSettings.ImpresoraTicketPeruanaEnvase & ImpresoraTicketPeruanaEnvase != "")
                    {

                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_PE_TI", "IMPRESORA TICKET DE GRANJA", ImpresoraTicketPeruanaEnvase, AppSettings.UserID, NuevaIP);
                        LblTicketGranja.Text = ImpresoraTicketPeruanaEnvase;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_PE_TI", ImpresoraTicketPeruanaEnvase, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        //AppSettingsSection appSettings = config.AppSettings;

                        //KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraTicketPeruanaEnvase"];
                        //setting.Value = ImpresoraTicketPeruanaEnvase;
                        //config.Save(ConfigurationSaveMode.Modified);
                        //ConfigurationManager.RefreshSection("appSettings");
                        //LblTicketGranja.Text = ImpresoraTicketPeruanaEnvase;
                        //MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
        }

        private void BtnImpresoraPago_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                //configurar impresora de pago
                ImpresoraPago = printDialog1.PrinterSettings.PrinterName;
                //*****************guardar la configuracion de la impresora en el appconfig**************
                if (ImpresoraPago != AppSettings.ImpresoraPago & ImpresoraPago != "")
                {
                    string EMPRESA_ID = c1cboCia.SelectedValue.ToString();
                    //ahora se gauradara en una tabla Configuracion.Configuracion
                    DataTable DtImpresora = new DataTable();
                    DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_PA", "IMPRESORA PAGO DE " + EMPRESA_ID, ImpresoraPago, AppSettings.UserID, NuevaIP);

                    ActualizarConfiguracion(EMPRESA_ID, "IMP_PA", ImpresoraPago, NuevaIP);

                    LblTicketPago.Text = ImpresoraPago;
                    MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    //AppSettingsSection appSettings = config.AppSettings;

                    //KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraPago"];
                    //setting.Value = ImpresoraPago;
                    //config.Save(ConfigurationSaveMode.Modified);
                    //ConfigurationManager.RefreshSection("appSettings");
                    //LblTicketPago.Text = ImpresoraPago;
                    //MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActualizarConfiguracion(string EMPRESA_ID, string CODIGO, string Impresora, string direccionip)
        {
            //buscamos para actualizar
            DataView DV = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo ='" + CODIGO + "'", "", DataViewRowState.CurrentRows);
            //si encuantr actualiza
            if (DV.Count > 0)
            {
                //actualizar
                DataRow[] customerRow = UTI_Datatables.Dt_Configuracion.Select("Codigo ='" + CODIGO + "'");
                customerRow[0]["Data"] = Impresora;
            }
            else
            {
                //sino agrega
                DataRow Dr = UTI_Datatables.Dt_Configuracion.NewRow();
                Dr["ConfiguracionID"] = 0;//no interesa
                Dr["EmpresaID"] = EMPRESA_ID;
                Dr["Codigo"] = CODIGO;
                Dr["Descripcion"] = "no interesa";
                Dr["Data"] = Impresora;
                Dr["UsuarioID"] = AppSettings.UserID;
                Dr["DireccionIP"] = direccionip;
                UTI_Datatables.Dt_Configuracion.Rows.Add(Dr);

            }
            UTI_Datatables.Dt_Configuracion.AcceptChanges();

        }

        private void BtnImpresoraCB_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                //configurar impresora de pago
                ImpresoraCB = printDialog1.PrinterSettings.PrinterName;
                //*****************guardar la configuracion de la impresora en el appconfig**************
                if (ImpresoraCB != AppSettings.ImpresoraPago & ImpresoraCB != "")
                {
                    string EMPRESA_ID = c1cboCia.SelectedValue.ToString();
                    //ahora se gauradara en una tabla Configuracion.Configuracion
                    DataTable DtImpresora = new DataTable();
                    DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_CB", "IMPRESORA CB DE " + EMPRESA_ID, ImpresoraCB, AppSettings.UserID, NuevaIP);

                    ActualizarConfiguracion(EMPRESA_ID, "IMP_CB", ImpresoraCB, NuevaIP);

                    LblImpresoraCB.Text = ImpresoraCB;
                    MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    //AppSettingsSection appSettings = config.AppSettings;

                    //KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraPago"];
                    //setting.Value = ImpresoraPago;
                    //config.Save(ConfigurationSaveMode.Modified);
                    //ConfigurationManager.RefreshSection("appSettings");
                    //LblTicketPago.Text = ImpresoraPago;
                    //MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}


