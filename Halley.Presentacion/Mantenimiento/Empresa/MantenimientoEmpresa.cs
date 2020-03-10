using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Empresa;
using Halley.Entidad.Empresa;
using Halley.Configuracion;
using System.IO;
using Halley.Utilitario;

namespace Halley.Presentacion.Mantenimiento.Empresa
{
    public partial class MantenimientoEmpresa : UITemplateAccess
    {

        string TipoGuardar = "";
        string EmpresaID = "";
        E_Empresa ObjEmpresa = new E_Empresa();
        CL_Empresas ObjCL_Empresas = new CL_Empresas();
        DataTable DTEmpresas = new DataTable();

        public MantenimientoEmpresa()
        {
            InitializeComponent();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            TipoGuardar = "Nuevo";
            OcultarBotones(false, false, true, false, true, false);
            ReadOnly(false);
            LimpiarTextos();
            BtnCargar.Enabled = true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            //desahcer
            OcultarBotones(true, true, false, false, false, false);
            ReadOnly(false);
            LimpiarTextos();
            ReadOnly(true);
            BtnCargar.Enabled = false;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            TipoGuardar = "Actualizar";
            OcultarBotones(false, false, true, false, true, false);
            ReadOnly(false);
            BtnCargar.Enabled = true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarBotones(true, true, false, false, false, false);
                validarControles();

                if (validarControles() == false)
                {
                    OcultarBotones(false, false, true, false, true, false);
                    return;
                }
                ErrProvider.Clear();
                ObtenerDatosControles();
                if (TipoGuardar == "Nuevo")
                {
                    //agregar
                    EmpresaID = ObjCL_Empresas.InsertEmpresa(ObjEmpresa);
                    DataRow Dr = DTEmpresas.NewRow();
                    Dr["EmpresaID"] = EmpresaID;
                    Dr["NomEmpresa"] = ObjEmpresa.NomEmpresa;
                    Dr["RUC"] = ObjEmpresa.RUC;
                    Dr["DomicilioFiscal"] = ObjEmpresa.DomicilioFiscal;
                    Dr["Telefono"] = ObjEmpresa.Telefono;
                    Dr["Logo"] = ObjEmpresa.Logo;
                    DTEmpresas.Rows.Add(Dr);

                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Empresas.UpdateEmpresa(ObjEmpresa, "A");

                    //actualizar
                    DataRow[] customerRow = DTEmpresas.Select("EmpresaID = '" + ObjEmpresa.EmpresaID + "'");
                    customerRow[0]["NomEmpresa"] = ObjEmpresa.NomEmpresa;
                    customerRow[0]["RUC"] = ObjEmpresa.RUC;
                    customerRow[0]["DomicilioFiscal"] = ObjEmpresa.DomicilioFiscal;
                    customerRow[0]["Telefono"] = ObjEmpresa.Telefono;
                    customerRow[0]["Logo"] = ObjEmpresa.Logo;

                    lblEstado.Text = "Se actualizó correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                TipoGuardar = "";
                BtnCargar.Enabled = false;

                //actualizar tambien la tabal estatica de empresas
                UTI_Datatables.DtEmpresas = DTEmpresas.Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReadOnly(false);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarBotones(true, true, false, false, false, false);

                if (MessageBox.Show("¿Está seguro que desea eliminar la UM?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Empresas.UpdateEmpresa(ObjEmpresa, "E");

                    //Eliminar
                    DataRow[] customerRow = DTEmpresas.Select("EmpresaID = '" + ObjEmpresa.EmpresaID + "'");
                    customerRow[0].Delete();

                    lblEstado.Text = "Se eliminó la empresa:  " + TxtEmpresaID.Text + ".";
                    lblEstado.ForeColor = Color.Red;
                }
                else
                    OcultarBotones(true, true, false, false, false, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MantenimientoEmpresa_Load(object sender, EventArgs e)
        {
            DTEmpresas = ObjCL_Empresas.GetEmpresasMantenimiento();
            TdgEmpresa.SetDataBinding(DTEmpresas, "", true);
            lblEstado.Text = "";
            OcultarBotones(false, true, false, false, false, false);
            ReadOnly(true);
            ocultarToolStrip();
        }

        private void ReadOnly(bool Valor)
        {
            TxtEmpresaID.ReadOnly = Valor;
            TxtNomEmpresa.ReadOnly = Valor;
            TxtRUC.ReadOnly = Valor;
            TxtDomicilioFiscal.ReadOnly = Valor;
            TxtTelefono.ReadOnly = Valor;
            
        }

        private bool validarControles()
        {
            if (TxtEmpresaID.Text == "") { ErrProvider.SetError(TxtEmpresaID, "Debe Ingresar el ID de la emrpresa"); return false; }
            if (TxtNomEmpresa.Text == "") { ErrProvider.SetError(TxtNomEmpresa, "Debe Ingresar el nombre de la empresa."); return false; }
            if (TxtRUC.Text == "") { ErrProvider.SetError(TxtRUC, "Debe Ingresar el RUC de la empresa."); return false; }
            if (TxtDomicilioFiscal.Text == "") { ErrProvider.SetError(TxtDomicilioFiscal, "Debe Ingresar el domicilio de la empresa."); return false; }
            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjEmpresa = new E_Empresa();
            ObjEmpresa.EmpresaID = TxtEmpresaID.Text;
            ObjEmpresa.NomEmpresa = TxtNomEmpresa.Text;
            ObjEmpresa.RUC = TxtRUC.Text;
            ObjEmpresa.DomicilioFiscal = TxtDomicilioFiscal.Text;
            ObjEmpresa.Telefono = TxtTelefono.Text;
            if (PbLogo.Image != null)
            {
                Bitmap res = new Bitmap(PbLogo.Image);
                MemoryStream stream = new MemoryStream();
                MemoryStream salida = new MemoryStream();
                res.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Seek(0, SeekOrigin.Begin);
                stream.WriteTo(salida);
                res.Dispose();
                byte[] pic = salida.ToArray();
                ObjEmpresa.Logo = pic;
            }
            ObjEmpresa.UsuarioID = AppSettings.UserID;
        }

        private void LimpiarTextos()
        {
            TxtEmpresaID.Text = "";
            TxtNomEmpresa.Text = "";
            TxtRUC.Text = "";
            TxtDomicilioFiscal.Text = "";
            TxtTelefono.Text = "";
            PbLogo.Image = null;
        }

        private void OcultarBotones(bool Buscar, bool Nuevo, bool Cancelar, bool Editar, bool Guardar, bool Eliminar)
        {
            BtnNuevo.Visible = Nuevo;
            BtnCancelar.Visible = Cancelar;
            BtnEditar.Visible = Editar;
            BtnGuardar.Visible = Guardar;
            BtnEliminar.Visible = Eliminar;
        }

        private void TdgEmpresa_DoubleClick(object sender, EventArgs e)
        {
            ReadOnly(false);
            TxtEmpresaID.Text = TdgEmpresa.Columns["EmpresaID"].Value.ToString();
            TxtNomEmpresa.Text = TdgEmpresa.Columns["NomEmpresa"].Value.ToString();
            TxtRUC.Text = TdgEmpresa.Columns["RUC"].Value.ToString();
            TxtDomicilioFiscal.Text = TdgEmpresa.Columns["DomicilioFiscal"].Value.ToString();
            TxtTelefono.Text = TdgEmpresa.Columns["Telefono"].Value.ToString();

            // El campo productImage primero se almacena en un buffer
            DataRow[] customerRow = DTEmpresas.Select("EmpresaID = '" + TxtEmpresaID.Text + "'");
            if (customerRow[0]["Logo"] != DBNull.Value)
            {
                byte[] imageBuffer = (byte[])customerRow[0]["Logo"];
                // Se crea un MemoryStream a partir de ese buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                // Se utiliza el MemoryStream para extraer la imagen
                PbLogo.Image = Image.FromStream(ms);
            }
            else
                PbLogo.Image = null;

            ReadOnly(true);
            OcultarBotones(true, true, false, true, false, true);
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            System.IO.Stream MiStream = null;//null porque no tienesw nada para cargar aun
            OpenFileDialog openFileDialog1 = new OpenFileDialog();//instancias el boton
            //despues ahi mismo en el boton
            openFileDialog1.InitialDirectory = "C:\\";//ruta donde inicias a buscar 
            openFileDialog1.Filter = "JPG(*.jpg)|*.jpg|PNG(*.png)|*.png|GIF(*… *.Png, *.Gif, *.Tiff, *.Jpeg, *.Bmp)|*.Jpg; *.Png; *.Gif; *.Tiff; *.Jpeg; *.Bmp"; //formatos soportados
            openFileDialog1.FilterIndex = 4;//4 si te das cuenta arribita dice todos 4 es el indice que sera el predeterminado
            openFileDialog1.RestoreDirectory = true;//cuando hagas otra busqueda se regrese a donde mismo

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((MiStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (MiStream)
                        {
                            PbLogo.Image = System.Drawing.Bitmap.FromStream(MiStream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se puede carga la imagen " + ex.Message);
                }
            }
        }

        private void TdgEmpresa_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {
            switch (e.Col)
            {
                case 5:
                    if (this.TdgEmpresa[e.Row, 5] != DBNull.Value)
                    {
                        //e.CellStyle.BackgroundImage = (Image)this.TdgEmpresa[e.Row, 5];
                        
                        // El campo productImage primero se almacena en un buffer
                        DataRow[] customerRow = DTEmpresas.Select("EmpresaID = '" + this.TdgEmpresa[e.Row, 0] + "'");
                        if (customerRow[0]["Logo"] != DBNull.Value)
                        {
                            byte[] imageBuffer = (byte[])customerRow[0]["Logo"];
                            // Se crea un MemoryStream a partir de ese buffer
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                            // Se utiliza el MemoryStream para extraer la imagen
                            e.CellStyle.BackgroundImage = Image.FromStream(ms);
                        }
                    }
                    break;
            }
        }

        private void TxtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextFunctions ObjTextFunctions = new TextFunctions();
            ObjTextFunctions.SoloNumero(sender, e, TxtRUC);
        }

    }
}
