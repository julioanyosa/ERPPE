using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Configuracion;
using Halley.CapaLogica.Ventas;
using Halley.Utilitario;

namespace Halley.Presentacion.Ventas
{
    public partial class FrmCierre : Form
    {
        #region variables
        string EmpresaID = "";
        CL_Venta ObjCL_Venta = new CL_Venta();
        string ImpresoraBoletaPeruanaEnvase = AppSettings.ImpresoraBoletaPeruanaEnvase;

        string ImpresoraFacturaPeruanaEnvase = AppSettings.ImpresoraFacturaPeruanaEnvase;

        string ImpresoraTicketPeruanaEnvase = AppSettings.ImpresoraTicketPeruanaEnvase;

        #endregion

        #region propiedades
        private DataTable _DtEmpresas;

        public DataTable DtEmpresas
        {
            get { return _DtEmpresas; }
            set { _DtEmpresas = value; }
        }
        private int _NumCaja;

        public int NumCaja
        {
            get { return _NumCaja; }
            set { _NumCaja = value; }
        }
        #endregion

        public FrmCierre()
        {
            InitializeComponent();
        }

        private void BtnCierre_Click(object sender, EventArgs e)
        {
            if (c1cboCia.SelectedIndex != -1)
            {
                switch (c1cboCia.SelectedValue.ToString())
                {
                    case "PE":

                        if (MessageBox.Show("¿Esta seguro que desea imprimir el total de la caja por día de peruana de envases?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Cursor = Cursors.WaitCursor;
                         
                            //ahora se gauradara en una tabla Configuracion.Configuracion

                            DataView DV = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo ='" + "IMP_PE_TI" + "'", "", DataViewRowState.CurrentRows);

                            if (DV.Count > 0)
                            {
                                printDocument1.PrinterSettings.PrinterName = DV[0]["Data"].ToString();
                            }
                            else
                                printDocument1.PrinterSettings.PrinterName = "";

                            if (printDocument1.PrinterSettings.PrinterName == "")
                            {
                                MessageBox.Show("Al parecer no se ha seleccionado la impresora. No se imprimira el comprobante.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Cursor = Cursors.Default;
                                return;
                            }
                            EmpresaID = "PE";
                            printDocument1.Print();//manda a imprimnir
                            Cursor = Cursors.Default;
                        }

                        break;


                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                #region Total Eticketera
                //obtener datos de la empresa
                DataView DV = new DataView(DtEmpresas);
                //string EmpresaID = "IH";
                DV.RowFilter = "EmpresaID = '" + EmpresaID + "'";
                string NomEmpresa = DV[0]["NomEmpresa"].ToString();
                string RUC = DV[0]["RUC"].ToString();

                string FormatoTotalesTicket = ObjCL_Venta.FormatoTotalesTicket(NomEmpresa, AppSettings.NomSede, RUC, DtpFechaCierre.Value.Date, DtpFechaCierre.Value.Date.AddDays(1), NumCaja, EmpresaID, AppSettings.SedeID, AppSettings.UserID);
                e.Graphics.DrawString(FormatoTotalesTicket, TxtFormatoticketera.Font, Brushes.Black, 0, 0); //total pagar en letras
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();

        }

        private void FrmCierre_Load(object sender, EventArgs e)
        {
            //agregar empresa
            c1Combo.FillC1Combo(this.c1cboCia, DtEmpresas, "NomEmpresa", "EmpresaID");
            c1cboCia.SelectedValue = AppSettings.EmpresaID;
        }
    }
}


