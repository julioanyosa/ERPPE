using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;
using System.IO.Ports;
using Halley.Configuracion;

namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class Balanza : Form
    {
        private TextFunctions _TextFunctions = new TextFunctions();
        string indata;

        private decimal _Peso;
        private int _Cantidad;
        private string _Titulo;
        private bool _VerCantidad;
        private string _SerialPortBalanza;

        public decimal Peso
        {
            get { return _Peso; }
            set { _Peso = value; }
        }
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        public string Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }
        public bool VerCantidad
        {
            get { return _VerCantidad; }
            set { _VerCantidad = value; }
        }

        public Balanza()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Peso = 0;
            Cantidad = 0;
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            Peso = Convert.ToDecimal(TxtPeso.Text);
            Cantidad = Convert.ToInt16(TxtCantidad.Text);
            this.Close();
        }

        private void Balanza_Load(object sender, EventArgs e)
        {
            try
            {
                //Llenar combo de puertos (se llena de esta forma paraq no sleccione el 1ero de la lista)
                CboPuertos.HoldFields();
                CboPuertos.DataSource = c1Combo.DtPuertos();
                CboPuertos.DisplayMember = "Puerto";
                CboPuertos.ValueMember = "Puerto";
                CboPuertos.SelectedValue = AppSettings.SerialPortBalanza;

                if (VerCantidad == false)
                {
                    TxtCantidad.Visible = false;
                    LblCantidad.Visible = false;
                }
                LblPeso.Text = Titulo;
                SpBalanza.PortName = CboPuertos.SelectedValue.ToString();
                SpBalanza.Open();//abro el puerto
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error abriendo");
            }
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            _TextFunctions.ValidaNumero(sender, e, TxtCantidad);
        }

        private void Balanza_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            if (SpBalanza.IsOpen)
            {
                SpBalanza.Close();//cuando se cierra el formulario se cierra el puerto

            }
        }

        private void SpBalanza_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            indata = SpBalanza.ReadExisting();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (indata != null && indata != "\r\n")
                {
                    //extraer el numero de indata
                    int pos1 = 0;
                    int pos2 = 0;
                    indata = indata.Trim();
                    pos1 = indata.IndexOf("S");
                    pos2 = indata.IndexOf("KG");
                    if (pos1 != 0 & pos2 > 0 & indata.Length > 2)
                        TxtPeso.Text = indata.Substring(pos1 + 1, pos2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n\r\n" + "Metodo Tick del timer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TxtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            _TextFunctions.ValidaNumero(sender, e, TxtPeso);
        }

        private void CboPuertos_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CboPuertos.SelectedValue.ToString() != AppSettings.SerialPortBalanza)
                {
                    UpdateConfiguration ObjUpdateConfiguration = new UpdateConfiguration();
                    ObjUpdateConfiguration.AppSettingsSectionModify("SerialPortBalanza", CboPuertos.SelectedValue.ToString());

                    if (SpBalanza.IsOpen == true)
                    {
                        SpBalanza.Close();
                    }
                    SpBalanza.PortName = CboPuertos.SelectedValue.ToString();
                    SpBalanza.Open();//abro el puerto
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\rMetodo SelectedValueChanged().", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
