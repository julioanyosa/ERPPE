using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace Halley.Presentacion.Almacen.Reportes
{
    public partial class FrmHojaDespachocs : Form
    {
        public FrmHojaDespachocs()
        {
            InitializeComponent();
        }

        private void FrmPruebacs_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewer1.LocalReport;
            localReport.ReportPath = @"D:\Presentations\SQL Server\SSRS RDLC\SSRS_RDLC\Report2.rdlc";
        }
    }
}
