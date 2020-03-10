using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.CapaLogica;
using Halley.Entidad.Almacen;
using Halley.Utilitario;
using Halley.Configuracion;
using Halley.CapaLogica.Compras;
using Halley.Entidad.Compras;

namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class DespachoMaiz : UITemplateAccess
    {
        public static DataTable DetallesRequerimientos = new DataTable();
        static DataTable DetallesRequerimientosAcu = new DataTable(); // creado para acumular todos los requerimientos
        CL_Proveedor ObjCL_Proveedor = new CL_Proveedor();
        
        private static decimal Neto;
        private static int Cantidad;
        private static int NroPesadas;
        private static int MaximoPesadas = 1;//maximo de pesadas
        private string NumHojaLiquidacion = "";

        private DataTable DtProductosPeso;
        private DataTable DtAlmacenUsuario;
        private DataTable DtSacos;
        private DataTable DtTipoDocumento = new DataTable();
        private DataTable DtProveedores = new DataTable();
        private DataTable DtProveedores2 = new DataTable();
        
        private TextFunctions ObjTextFunctions = new TextFunctions();

        public DespachoMaiz()
        {
            InitializeComponent();
        }

        private void DespachoPollo_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();

            //agregar opcion de sacos
            DtSacos = new DataTable();
            DtSacos.Columns.Add("ID", typeof(int));
            DtSacos.Columns.Add("Descripcion", typeof(string));
            DataRow DR = DtSacos.NewRow();
            DR["ID"] = 1;
            DR["Descripcion"] = "Con Todo";
            DtSacos.Rows.Add(DR);
            DataRow DR1 = DtSacos.NewRow();
            DR1["ID"] = 2;
            DR1["Descripcion"] = "Sin sacos";
            DtSacos.Rows.Add(DR1);
            CboSacos.HoldFields();
            CboSacos.DataSource = DtSacos;
            CboSacos.DisplayMember = "Descripcion";
            CboSacos.ValueMember = "ID";

            //obtener lista de productos que se pésan
            DtProductosPeso = new CL_Producto().GetProductosPeso();
            CboProductoPeso.HoldFields();
            CboProductoPeso.DataSource = DtProductosPeso;
            CboProductoPeso.DisplayMember = "NomProducto";
            CboProductoPeso.ValueMember = "ProductoID";
            CboProductoPeso.SelectedValue = "00121000099.7";

            //todos los almacenes asignados al usuario
            DtAlmacenUsuario = AppSettings.AlmacenPermisos;
            CboAlmacen.HoldFields();
            CboAlmacen.DataSource = DtAlmacenUsuario;
            CboAlmacen.DisplayMember = "Descripcion";
            CboAlmacen.ValueMember = "AlmacenID";
            CboAlmacen.SelectedValue = AppSettings.EmpresaID + AppSettings.SedeID + "MAI";

            //neto
            Neto = 0;

            //traer tipo de documento
            DtTipoDocumento =  ObjCL_Proveedor.GetTipoDocumento();
            CboTipoDocumento.HoldFields();
            CboTipoDocumento.DataSource = DtTipoDocumento;
            CboTipoDocumento.DisplayMember = "TipoDocumento";
            CboTipoDocumento.ValueMember = "IDTipoDocumento";

            //traer los proveedores
            GetProveedoresTipoDocumento();

            BtnInsertar.Visible = false;
            BtnCancelar.Visible = false;

            //limpiar tabla de pesos
            DetallesRequerimientos.Clear();
        }


        private void BtnVer_Click(object sender, EventArgs e)
        {
            Reportes.FrmGuiaCompraMaiz ObjFrmGuiaC = new Reportes.FrmGuiaCompraMaiz();
            ObjFrmGuiaC.NumHojaLiquidacion = NumHojaLiquidacion;
            ObjFrmGuiaC.ShowDialog();
        }

        private void GetProveedoresTipoDocumento()
        {
            DtProveedores = ObjCL_Proveedor.GetProveedoresTipoDocumento(2);
            DtProveedores2.Merge(DtProveedores);//almacenar en otro tabla todos los vendedores
            CboProveedor.HoldFields();
            CboProveedor.DataSource = DtProveedores;
            CboProveedor.DisplayMember = "RazonSocial";
            CboProveedor.ValueMember = "IDProveedor";
        }

        private void ReadOnlyTxt(bool Valor)
        {
            //habilitar controles
            CboSacos.ReadOnly = Valor;
            TxtPrecioUnitario.ReadOnly = Valor;
            TxtTotalKilos.ReadOnly = Valor;
            TxtTotalSacos.ReadOnly = Valor;
        }

   
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            //limpiar todo
            ErrProvider.Clear();
            CboProveedor.SelectedIndex = -1;
            //CboAlmacen.SelectedIndex = -1;
            //CboProductoPeso.SelectedIndex = -1;
            CboTipoDocumento.SelectedIndex = -1;
            NroPesadas = 0;
            ReadOnlyTxt(false);
            TxtDireccion.Value = "";
            TxtDocumento.ReadOnly = false;
            TxtDocumento.Value = "";
            TxtDocumento.ReadOnly = true;
            TxtTelefono.ReadOnly = false;
            TxtTelefono.Value = "";
            TxtTelefono.ReadOnly = true;
            CboSacos.SelectedIndex = -1;
            TxtPrecioUnitario.Value = "";
            TxtTotalKilos.Value = "";
            TxtTotalSacos.Value = "";
            Neto = 0;
            Cantidad = 0;
            BtnGrabar.Visible = true;
            BtnBalanza.Visible = true;
            TxtProcedencia.Text = "";
            TxtComentario.Text = "";
            TxtPorcDesc.Text = "";

            #region borrar los list
            foreach (Control ctrl in this.Controls)
            {

                if (ctrl is GroupBox)
                {
                    foreach (Control c in ctrl.Controls)
                    {
                        if (c is ListBox)
                        {
                            ListBox d = c as ListBox;
                            d.Items.Clear();
                        }
                    }
                }
            }
            #endregion

         }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            //validar datos
            Cursor = Cursors.WaitCursor;
            ErrProvider.Clear();
           if (CboProductoPeso.SelectedValue != null & CboAlmacen.SelectedValue != null & CboProveedor.SelectedValue != null  & CboSacos.Text != "" & TxtPrecioUnitario.Text != "" & TxtTotalKilos.Text != "" & TxtTotalSacos.Text != "" & CboSacos.SelectedIndex != -1 & TxtProcedencia.Text != "" & TxtDireccion.Text != "")
            {
                BtnGrabar.Visible = false;
                BtnBalanza.Visible = false;
                CrearCompraMaiz();
                BtnVer_Click(null, null);
            }
            else
            {
            if (CboProductoPeso.SelectedValue == null) {ErrProvider.SetError(CboProductoPeso, "Seleccione el producto.");}
            if (CboAlmacen.SelectedValue == null) { ErrProvider.SetError(CboAlmacen, "Seleccione el almacen donde se almacenara."); }
            if (CboProveedor.SelectedValue == null) { ErrProvider.SetError(CboProveedor, "Seleccione el Proveedor."); }
            if (TxtProcedencia.Text == "") { ErrProvider.SetError(TxtProcedencia, "Ingrese la procedencia."); }
            if (CboSacos.Text == "") { ErrProvider.SetError(CboSacos, "Ingrese los sacos."); }
            if (TxtDocumento.Text == "") { ErrProvider.SetError(TxtDocumento, "Ingrese DNI."); }
            if (TxtPrecioUnitario.Text == "") { ErrProvider.SetError(TxtPrecioUnitario, "Ingrese el precio unitario (costo por kilos)"); }
            if (TxtTotalKilos.Text == "") { ErrProvider.SetError(TxtTotalKilos, "No ha pesado nada"); }
            if (TxtTotalSacos.Text == "") { ErrProvider.SetError(TxtTotalSacos, "No ha pesado nada"); }
            if (CboSacos.SelectedIndex == -1) { ErrProvider.SetError(CboSacos, "No ha seleccionado opción de sacos"); }
            if (TxtDireccion.Text == "") { ErrProvider.SetError(TxtDireccion, "Debe tener direccion establecida"); }
            BtnGrabar.Visible = true;
            BtnBalanza.Visible = true;
            }

            Cursor = Cursors.Default;
        }

        private void CrearCompraMaiz()
        {
            try 
	        {
                //calcular peso
                decimal PesoTotal = 0;
                decimal DescPorc = 0;
                decimal DescSac = 0;

                if(TxtPorcDesc.Text != "" & TxtPorcDesc.Text != "0")
                    DescPorc = Convert.ToDecimal(TxtPorcDesc.Text)/100 * Convert.ToDecimal(TxtTotalKilos.Text);
                if(Convert.ToInt16(CboSacos.SelectedValue) == 2)
                    DescSac = Convert.ToInt16(TxtTotalSacos.Text);

                PesoTotal = Convert.ToDecimal(TxtTotalKilos.Text) - DescPorc - DescSac;

		        //insertar la guia y que retorne el nro de guia
                CL_GuiaCompraMaiz ObjCL_GuiaCompraMaiz = new CL_GuiaCompraMaiz();
                E_GuiaCompraMaiz ObjE_GuiaCompraMaiz = new E_GuiaCompraMaiz();
                ObjE_GuiaCompraMaiz.IDProveedor = Convert.ToInt16(CboProveedor.SelectedValue);
                ObjE_GuiaCompraMaiz.NombreProveedor = CboProveedor.SelectedText;
                ObjE_GuiaCompraMaiz.Procedencia = TxtProcedencia.Text;
                ObjE_GuiaCompraMaiz.Sacos = CboSacos.Text;
                ObjE_GuiaCompraMaiz.DNI = TxtDocumento.Text;
                ObjE_GuiaCompraMaiz.PrecioUnitario = Convert.ToDecimal(TxtPrecioUnitario.Text.ToString());
                ObjE_GuiaCompraMaiz.ProductoID = CboProductoPeso.SelectedValue.ToString();
                ObjE_GuiaCompraMaiz.TotalPeso = PesoTotal;
                ObjE_GuiaCompraMaiz.TotalSaco = Convert.ToInt16(TxtTotalSacos.Text);
                ObjE_GuiaCompraMaiz.Comentario = TxtComentario.Text;
                ObjE_GuiaCompraMaiz.UsuarioID = AppSettings.UserID;
                ObjE_GuiaCompraMaiz.Pagado = 0; //monto pagado


                //insertar detalles de la guia
                DataTable DtPesos = new DataTable();//tabla apra almacenar los pesos
                DtPesos.TableName = "HojaLiquidacion";
                DtPesos.Columns.Add("Kilo", typeof(decimal));
                DtPesos.Columns.Add("Saco", typeof(int));

                #region Llenar tabla pesos
                for (int x = 0; x < LstKilo1.Items.Count; x++)
                {
                    DataRow Rw1 = DtPesos.NewRow();
                    Rw1["Kilo"] = Convert.ToDecimal(LstKilo1.Items[x]);
                    Rw1["Saco"] = Convert.ToInt16(LstSaco1.Items[x]);
                    DtPesos.Rows.Add(Rw1);
                }
                for (int x = 0; x < LstKilo2.Items.Count; x++)
                {
                    DataRow Rw1 = DtPesos.NewRow();
                    Rw1["Kilo"] = Convert.ToDecimal(LstKilo2.Items[x]);
                    Rw1["Saco"] = Convert.ToInt16(LstSaco2.Items[x]);
                    DtPesos.Rows.Add(Rw1);
                }
                for (int x = 0; x < LstKilo3.Items.Count; x++)
                {
                    DataRow Rw1 = DtPesos.NewRow();
                    Rw1["Kilo"] = Convert.ToDecimal(LstKilo3.Items[x]);
                    Rw1["Saco"] = Convert.ToInt16(LstSaco3.Items[x]);
                    DtPesos.Rows.Add(Rw1);
                }
                for (int x = 0; x < LstKilo4.Items.Count; x++)
                {
                    DataRow Rw1 = DtPesos.NewRow();
                    Rw1["Kilo"] = Convert.ToDecimal(LstKilo4.Items[x]);
                    Rw1["Saco"] = Convert.ToInt16(LstSaco4.Items[x]);
                    DtPesos.Rows.Add(Rw1);
                }
                for (int x = 0; x < LstKilo5.Items.Count; x++)
                {
                    DataRow Rw1 = DtPesos.NewRow();
                    Rw1["Kilo"] = Convert.ToDecimal(LstKilo5.Items[x]);
                    Rw1["Saco"] = Convert.ToInt16(LstSaco5.Items[x]);
                    DtPesos.Rows.Add(Rw1);
                }

                //hacer descuento según la opcion de los sacos
                if(Convert.ToInt16(CboSacos.SelectedValue) == 2)
                {
                    DataRow Rw1 = DtPesos.NewRow();
                    Rw1["Kilo"] = Convert.ToDecimal(TxtTotalSacos.Text) * -1;
                    Rw1["Saco"] = 0;
                    DtPesos.Rows.Add(Rw1);
                }

                //hacer descuento según la calidad del maiz
                if (TxtPorcDesc.Text != "" && TxtPorcDesc.Text != "0")
                {
                    DataRow Rw1 = DtPesos.NewRow();
                    Rw1["Kilo"] = Convert.ToDecimal(TxtTotalKilos.Text) * Convert.ToDecimal(TxtPorcDesc.Text)/100 * -1;
                    Rw1["Saco"] = 0;
                    DtPesos.Rows.Add(Rw1);
                }
                #endregion

                string xml = new BaseFunctions().GetXML(DtPesos).Replace("NewDataSet", "DocumentElement");
                NumHojaLiquidacion = ObjCL_GuiaCompraMaiz.InsertHojaLiquidacion(ObjE_GuiaCompraMaiz, AppSettings.EmpresaID, AppSettings.SedeID, xml, CboAlmacen.SelectedValue.ToString(), null, "02");
                MessageBox.Show("Se grabo correctamente la compra", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
	        catch (Exception ex)
	        {
                MessageBox.Show(ex.Message + ".\t\nmetodo CrearCompraMaiz()", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	        }


        }

        private void TxtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtPrecioUnitario);
        }

        private void BtnBalanza_Click(object sender, EventArgs e)
        {
            if (MaximoPesadas < 51)
            {
                Operaciones.Balanza ObjBalanza = new Operaciones.Balanza();
                ObjBalanza.Titulo = "Peso Neto";
                ObjBalanza.VerCantidad = true;
                ObjBalanza.ShowDialog();
                NroPesadas++;

                if (ObjBalanza.Peso > 0 && ObjBalanza.Cantidad > 0)
                {
                    #region Llenar Listas
                    MaximoPesadas++;
                    switch (NroPesadas) //validar la cantidad de pesadas, según eso repartir a los list
                    {
                        case 1:
                            LstKilo1.Items.Add(ObjBalanza.Peso);
                            LstSaco1.Items.Add(ObjBalanza.Cantidad);
                            break;
                        case 2:
                            LstKilo2.Items.Add(ObjBalanza.Peso);
                            LstSaco2.Items.Add(ObjBalanza.Cantidad);
                            break;
                        case 3:
                            LstKilo3.Items.Add(ObjBalanza.Peso);
                            LstSaco3.Items.Add(ObjBalanza.Cantidad);
                            break;
                        case 4:
                            LstKilo4.Items.Add(ObjBalanza.Peso);
                            LstSaco4.Items.Add(ObjBalanza.Cantidad);
                            break;
                        case 5:
                            LstKilo5.Items.Add(ObjBalanza.Peso);
                            LstSaco5.Items.Add(ObjBalanza.Cantidad);
                            NroPesadas = 0;
                            break;
                    }

                    #endregion
                }
                else
                {
                    MessageBox.Show("No ingreso la cantidad de sacos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    NroPesadas--;
                    ObjBalanza.Peso = 0;
                    ObjBalanza.Cantidad = 0;
                }
                #region mostrar datos
                Neto += ObjBalanza.Peso;
                Cantidad += ObjBalanza.Cantidad;

                TxtTotalKilos.Value = Neto;
                TxtTotalSacos.Value = Cantidad;
                #endregion
            }
            else
                 MessageBox.Show("No puede pesar mas de 50 veces. tendría que crear otra guía", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                //agregar el proveedor nuevo
                E_Proveedor ObjProveedor = new E_Proveedor();
                ObjProveedor.RazonSocial = CboProveedor.Text;
                ObjProveedor.IDTipoDocumento = Convert.ToInt32(CboTipoDocumento.SelectedValue);
                ObjProveedor.NroDocumento = TxtDocumento.Text;
                ObjProveedor.Telefono = TxtTelefono.Text;
                ObjProveedor.Pais = "Peru";
                ObjProveedor.Region = "";
                ObjProveedor.Direccion = TxtDireccion.Text;
                ObjProveedor.Contacto = CboProveedor.Text;
                ObjProveedor.CargoContacto = "Vendedor";
                ObjProveedor.Email = "";
                ObjProveedor.UsuarioID = AppSettings.UserID;

                Int32 IDProveedor = ObjCL_Proveedor.InsertProveedor(ObjProveedor);

                //agregar al datatable proveedor
                DataRow Dr = DtProveedores2.NewRow();
                Dr["IDProveedor"] = IDProveedor;
                Dr["RazonSocial"] = ObjProveedor.RazonSocial;
                Dr["IDTipoDocumento"] = ObjProveedor.IDTipoDocumento;
                Dr["NroDocumento"] = ObjProveedor.NroDocumento;
                Dr["Telefono"] = ObjProveedor.Telefono;
                Dr["Pais"] = ObjProveedor.Pais;
                Dr["Region"] = ObjProveedor.Region;
                Dr["Direccion"] = ObjProveedor.Direccion;
                Dr["Contacto"] = ObjProveedor.Contacto;
                Dr["CargoContacto"] = ObjProveedor.CargoContacto;
                Dr["Email"] = ObjProveedor.Email;
                DtProveedores2.Rows.Add(Dr);
                MessageBox.Show("Se inserto correctamente el registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + ". Metodo BtnInsertar_Click().", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            DtProveedores.Merge(DtProveedores2);//recuperamos todos los proveedores denuevo
            BtnInsertar.Visible = false;
            BtnCancelar.Visible = false;
            BtnNuevoProveedor.Visible = true;
        }

        private void CboProveedor_SelectedValueChanged(object sender, EventArgs e)
        {
            ReadonlyObj(false);
            TxtDocumento.Value = CboProveedor.Columns["NroDocumento"].Value;
            TxtTelefono.Value = CboProveedor.Columns["Telefono"].Value;
            TxtDireccion.Value = CboProveedor.Columns["Direccion"].Value;
            CboTipoDocumento.SelectedValue = CboProveedor.Columns["IDTipoDocumento"].Value;
            ReadonlyObj(true);

        }
        
        private void ReadonlyObj(bool Valor)
        {
            TxtDocumento.ReadOnly = Valor;
            TxtTelefono.ReadOnly = Valor;
            CboTipoDocumento.ReadOnly = Valor;
        }

        private void BtnNuevoProveedor_Click(object sender, EventArgs e)
        {
            DtProveedores.Clear(); //borramos temporalmente todos los vendedores
            BtnNuevoProveedor.Visible = false;
            BtnCancelar.Visible = true;
            BtnInsertar.Visible = true;
            ReadonlyObj(false);
            TxtDireccion.Value = "";
            TxtTelefono.Value = "";
            TxtDocumento.Value = "";
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            BtnNuevoProveedor.Visible = true;
            BtnCancelar.Visible = false;
            BtnInsertar.Visible = false;
            ReadonlyObj(true);
            DtProveedores.Merge(DtProveedores2);//recuperamos todos los vendedores
        }


    }
    
}
