using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Presentacion.Almacen.Operaciones;
using Halley.Configuracion;
using Halley.Utilitario;

namespace Halley.Presentacion.Ventas
{
    public partial class FrmPesos : Form
    {
        private decimal _PesoNeto;

        public decimal PesoNeto
        {
            get { return _PesoNeto; }
            set { _PesoNeto = value; }
        }

        DataTable DtPesoBruto = new DataTable();
        private decimal Tara = 0;
        private decimal Neto = 0;
        private decimal Bruto = 0;
        private TextFunctions ObjTextFunctions = new TextFunctions();

        public FrmPesos()
        {
            InitializeComponent();
        }


        private void BtnBalanza_Click(object sender, EventArgs e)
        {
            Balanza ObjBalanza = new Balanza();
            ObjBalanza.Titulo = "Peso bruto";
            ObjBalanza.VerCantidad = false;
            ObjBalanza.ShowDialog();

            //agregar Peso segun el tipo
            if (ObjBalanza.Peso > 0)
            {
                DataRow Row = DtPesoBruto.NewRow();
                Row["Peso"] = ObjBalanza.Peso;
                DtPesoBruto.Rows.Add(Row);

                Bruto += ObjBalanza.Peso;
            }
            else
                MessageBox.Show("No ingreso la cantidad, no se agregara el peso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Neto = Bruto - Tara;

            //Pasando valoresa las listas
            LstPesoBruto.DataSource = DtPesoBruto;
            LstPesoBruto.DisplayMember = "Peso";
            LstPesoBruto.ValueMember = "Peso";
                        
            TxtTara.Value = Tara;
            LblNeto.Text = Neto.ToString();
            LblBruto.Text = Bruto.ToString();

        }

        private void FrmPesos_Load(object sender, EventArgs e)
        {
            //crear tablas para peso y tara

            DtPesoBruto = new DataTable();
            DtPesoBruto.TableName = "Peso";
            DtPesoBruto.Columns.Add("Peso", typeof(decimal));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Si realiza esta acción se borraran todo lo pesado anteriormente.\r¿Seguro que desea realizar esta acción?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Tara = 0;
                Neto = 0;
                Bruto = 0;
                //borrar los datos de las tablas
                DtPesoBruto.Rows.Clear();

                TxtTara.Value = Tara;
                LblNeto.Text = Neto.ToString();
                LblBruto.Text = Bruto.ToString();

            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            PesoNeto = Neto;
            this.Close();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            PesoNeto = 0;
            this.Close();
        }

        private void TxtTara_TextChanged(object sender, EventArgs e)
        {
            if (TxtTara.Text != "")
            {
                Tara = Convert.ToDecimal(TxtTara.Text);
                Neto = Bruto - Tara;
                LblBruto.Text = Bruto.ToString();
                LblNeto.Text = Neto.ToString();
            }
        }

        private void TxtTara_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtTara);
        }


    }
}
