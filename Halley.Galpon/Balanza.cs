using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace Halley.Galpon
{
    public partial class Balanza : Form
    {        
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

        public string SerialPortBalanza
        {
            get { return _SerialPortBalanza; }
            set { _SerialPortBalanza = value; }
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
                Cantidad = int.Parse(TxtCantidad.Text);
                DialogResult = DialogResult.OK;
        }

        private void Balanza_Load(object sender, EventArgs e)
        {
            try
            {
                if (VerCantidad == false)
                {
                    TxtCantidad.Visible = false;
                    LblCantidad.Visible = false;
                }
                LblPeso.Text = Titulo;
                SpBalanza.PortName = SerialPortBalanza;
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
         new Utilitario().ValidaNumero(sender, e, TxtCantidad);           
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
            new Utilitario().ValidaNumero(sender, e, TxtPeso);         
        }

        private void TxtPeso_TextChanged(object sender, EventArgs e)
        {
            if (TxtPeso.Text.Equals(""))
                TxtPeso.Text = "0";
        }

        private void TxtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (TxtCantidad.Text.Equals(""))
                TxtCantidad.Text = "0";
        }

    }
}
