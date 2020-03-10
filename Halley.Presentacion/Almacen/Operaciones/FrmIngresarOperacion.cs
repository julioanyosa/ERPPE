using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Empresa;
using Halley.CapaLogica.Almacen;
using Halley.Utilitario;
using Halley.Configuracion;
using Halley.Entidad.Almacen;
using Halley.Presentacion.Almacen.Reportes;
using Halley.Presentacion.Almacen.Contabilidad;

namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class FrmIngresarOperacion : Form
    {
        DataTable DtProductos;
        DataTable DtKardex;

        TextFunctions ObjTextFunctions = new TextFunctions();

        #region propiedades
        string _EmpresaID;

        public string EmpresaID
        {
            get { return _EmpresaID; }
            set { _EmpresaID = value; }
        }
        string _ProductoID;

        public string ProductoID
        {
            get { return _ProductoID; }
            set { _ProductoID = value; }
        }

        DataTable _DTOperacion;

        public DataTable DTOperacion
        {
            get { return _DTOperacion; }
            set { _DTOperacion = value; }
        }

        DataTable _DtTipoDocumento;

        public DataTable DtTipoDocumento
        {
            get { return _DtTipoDocumento; }
            set { _DtTipoDocumento = value; }
        }

        DataTable _DTMovimiento;

        public DataTable DTMovimiento
        {
            get { return _DTMovimiento; }
            set { _DTMovimiento = value; }
        }
        #endregion

        public FrmIngresarOperacion()
        {
            InitializeComponent();
        }

        private void FrmIngresarOperacion_Load(object sender, EventArgs e)
        {

            //Crear tabla apra el kardex
            DtKardex = new DataTable("Kardex");
            DtKardex.Columns.Add("AlmacenID", typeof(string));
            DtKardex.Columns.Add("ProductoID", typeof(string));
            DtKardex.Columns.Add("Producto", typeof(string));
            DtKardex.Columns.Add("Cantidad", typeof(decimal));
            DtKardex.Columns.Add("CostoUnitario", typeof(decimal));
            DtKardex.Columns.Add("Almacen", typeof(string));
            TdgProductos.SetDataBinding(DtKardex, "", true);

            //obtener todas las sedes
            DataTable Dtsedes = new CL_Empresas().GetSedes();
            CboSede.HoldFields();
            CboSede.DataSource = Dtsedes;
            CboSede.DisplayMember = "NomSede";
            CboSede.ValueMember = "SedeID";
            CboSede.SelectedIndex = 0;

            //obtener lista de productos
            DtProductos = new CL_Producto().GetProductos();
            CboProducto.HoldFields();
            CboProducto.DataSource = DtProductos;
            CboProducto.DisplayMember = "Alias";
            CboProducto.ValueMember = "ProductoID";
            if (ProductoID != null && ProductoID != "")
            {
                //seleccionar producto
                CboProducto.SelectedValue = ProductoID;
            }

            //traer los almacenes 
            DataTable DtAlmacenUsuario = new DataTable();
            DtAlmacenUsuario = new CL_Almacen().ObtenerAlmacen2(EmpresaID, CboSede.SelectedValue.ToString());
            CboAlmacen.HoldFields();
            CboAlmacen.DataSource = DtAlmacenUsuario;
            CboAlmacen.DisplayMember = "Descripcion";
            CboAlmacen.ValueMember = "AlmacenID";

            //Obtener Movimiento
            //CL_Kardex ObjCL_Kardex = new CL_Kardex();
            //DTMovimiento = new DataTable();
            //DTMovimiento = ObjCL_Kardex.GetMovimiento();
            CboMovimiento.HoldFields();
            CboMovimiento.DataSource = DTMovimiento;
            CboMovimiento.DisplayMember = "NomMovimiento";
            CboMovimiento.ValueMember = "MovimientoID";

            //obtener tipo documento
            //DtTipoDocumento = new DataTable();
            //DtTipoDocumento = ObjCL_Kardex.GetTipoDocumento();
            CboTipoDocumento.HoldFields();
            CboTipoDocumento.DataSource = DtTipoDocumento;
            CboTipoDocumento.DisplayMember = "Descripcion";
            CboTipoDocumento.ValueMember = "TipoContabilidad";

            //obtener operacion
            //DTOperacion = new DataTable();
            //DTOperacion = ObjCL_Kardex.GetOperacionKardex();
            CboOperacion.HoldFields();
            CboOperacion.DataSource = DTOperacion;
            CboOperacion.DisplayMember = "Descripcion";
            CboOperacion.ValueMember = "OperacionID";
        }

        private void TxtCostoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtCostoUnitario);
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtCantidad);
        }

        private void TxtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtNumero);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            //ingresar movimiento del producto
            try
            {
                Errp.Clear();
                //validar
                if (CboAlmacen.SelectedIndex != -1 & CboMovimiento.SelectedIndex != -1 & CboOperacion.SelectedIndex != -1 &
                    CboProducto.SelectedIndex != -1 & CboSede.SelectedIndex != -1 & CboTipoDocumento.SelectedIndex != -1 &
                    TxtCantidad.Text != "" & TxtCostoUnitario.Text != "" & TxtNumero.Text != "" & TxtSerie.Text != "" &
                    TxtSerie.Text.Length == 3 & DtKardex.Rows.Count > 0)
                {
                    //2da validacion
                    if (Convert.ToDecimal(TxtCantidad.Text) != 0 & Convert.ToInt32(TxtNumero.Text) != 0)
                    {
                        int KardexID = 0;
                        CL_Kardex ObjCL_Kardex = new CL_Kardex();
                        E_Kardex ObjE_Kardex = new E_Kardex();
                        ObjE_Kardex.AlmacenID = DtKardex.Rows[0]["AlmacenID"].ToString();
                        ObjE_Kardex.ProductoID = DtKardex.Rows[0]["ProductoID"].ToString();
                        ObjE_Kardex.MovimientoID =  Convert.ToInt32(CboMovimiento.SelectedValue);
                        ObjE_Kardex.TipoComprobante =  CboTipoDocumento.SelectedValue.ToString();
                        ObjE_Kardex.Cantidad = Convert.ToDecimal(DtKardex.Rows[0]["Cantidad"]);
                        ObjE_Kardex.Serie = TxtSerie.Text;
                        ObjE_Kardex.Numero = Convert.ToInt32(TxtNumero.Text);
                        ObjE_Kardex.TipoOperacion = CboOperacion.SelectedValue.ToString();
                        ObjE_Kardex.CostoUnitario = Convert.ToDecimal(DtKardex.Rows[0]["CostoUnitario"]);
                        ObjE_Kardex.Ingreso = "M";
                        ObjE_Kardex.UsuarioID = AppSettings.UserID;
                        ObjE_Kardex.AudCrea = Convert.ToDateTime(DtFecha.Value.ToShortDateString());
                        //verificar si existe el movimiento, si no existe se ingresa, en caso de existir pregunta al usuario
                        bool existe = true;
                        existe = ObjCL_Kardex.Existekardex(ObjE_Kardex);
                        if (existe == false)
                        {
                            if(DtKardex.Rows.Count == 1)
                                KardexID = ObjCL_Kardex.InsertKardex(ObjE_Kardex,null,"U");
                            else
                                KardexID = ObjCL_Kardex.InsertKardex(ObjE_Kardex, DtKardex, "M");
                        }
                        else
                        {
                            if (MessageBox.Show("El movimiento ya existe.\n\n¿Desea ingresarlo de todos modos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (DtKardex.Rows.Count == 1)
                                    KardexID = ObjCL_Kardex.InsertKardex(ObjE_Kardex, null, "U");
                                else
                                    KardexID = ObjCL_Kardex.InsertKardex(ObjE_Kardex, DtKardex, "M");
                                existe = false;
                            }
                            else
                            {
                                return;
                            }
                        }
                        ObjE_Kardex.KardexID = KardexID;
                        if (DtKardex.Rows.Count == 1)
                        {
                            #region Agregar a la tabla temp del formulario Re_Kardex
                            if (Rep_Kardex.DtTemp.Rows.Count > 0 & existe == false)
                            {
                                DataRow DR = Rep_Kardex.DtTemp.NewRow();
                                DR["KardexID"] = ObjE_Kardex.KardexID;
                                DR["Tabla"] = "K";
                                DR["AudCrea"] = ObjE_Kardex.AudCrea;
                                DR["ProductoID"] = ObjE_Kardex.ProductoID;
                                DR["Producto"] = CboProducto.Columns["Alias"].Value.ToString();
                                DR["UMContabilidad"] = "";
                                DR["UnidadMedidaID"] = CboProducto.Columns["UnidadMedidaID"].Value.ToString();
                                DR["Cantidad"] = ObjE_Kardex.Cantidad;
                                DR["CantidadReal"] = ObjE_Kardex.Cantidad;
                                DR["TipoContabilidad"] = ObjE_Kardex.TipoComprobante;
                                DR["Serie"] = ObjE_Kardex.Serie;
                                DR["Numero"] = ObjE_Kardex.Numero;
                                DR["TipoOperacion"] = ObjE_Kardex.TipoOperacion;
                                DR["Tipo"] = CboMovimiento.Columns["Tipo"].Value.ToString();
                                DR["PrecioUnitario"] = ObjE_Kardex.CostoUnitario;
                                DR["NomMovimiento"] = CboMovimiento.Columns["NomMovimiento"].Value.ToString();
                                DR["TipoExistencia"] = "ACTUALIZAR PARA VISUALIZAR";
                                DR["FactorConversion"] = 0;
                                DR["Unidades"] = 0;
                                DR["MovimientoID"] = ObjE_Kardex.MovimientoID;
                                DR["UnidadMedidaIDReal"] = CboProducto.Columns["UnidadMedidaID"].Value;
                                DR["PresentacionReal"] = "ACTUALIZAR PARA VISUALIZAR";
                                Rep_Kardex.DtTemp.Rows.Add(DR);
                            }
                            #endregion
                            MessageBox.Show("Se almaceno correctamente el movimiento.\r\nEl ID generado es: " + KardexID.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Se almaceno correctamente el movimiento.\r\nEl ID generado es: " + KardexID.ToString() + ".\r\nEn este caso por ser insercion masiva debe\nvolver a consultra los datos para\npoder ver la actualización.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
                        DtKardex.Rows.Clear();
                    }
                    else
                    {
                        if (Convert.ToDecimal(TxtCantidad.Text) == 0) Errp.SetError(TxtCantidad, "Ingrese una cantidad valida diferente de cero.");
                        //if (Convert.ToDecimal(TxtCostoUnitario.Text) == 0) Errp.SetError(TxtCostoUnitario, "Ingrese un costo valido diferente de cero.");
                        if (Convert.ToInt32(TxtNumero.Text) == 0) Errp.SetError(TxtNumero, "Ingrese un número valido diferente de cero.");
                    }
                }
                else
                {
                    if(CboAlmacen.SelectedIndex == -1)Errp.SetError(CboAlmacen,"Seleccione un almacen.");
                    if(CboMovimiento.SelectedIndex == -1)Errp.SetError(CboMovimiento,"Seleccione un movimiento.");
                    if(CboOperacion.SelectedIndex == -1) Errp.SetError(CboOperacion,"Seleccione una operacion.");
                    if(CboProducto.SelectedIndex == -1) Errp.SetError(CboProducto,"Seleccione una producto.");
                    if(CboSede.SelectedIndex == -1) Errp.SetError(CboSede,"Seleccione una Sede.");
                    if(CboTipoDocumento.SelectedIndex == -1) Errp.SetError(CboTipoDocumento,"Seleccione un tipo de documento.");
                    if(TxtCantidad.Text == "") Errp.SetError(TxtCantidad,"Ingrese una cantidad valida.");
                    if(TxtCostoUnitario.Text == "") Errp.SetError(TxtCostoUnitario,"Ingrese un costo valido.");
                    if(TxtNumero.Text == "") Errp.SetError(TxtNumero,"Ingrese un número valido.");
                    if(TxtSerie.Text == "" | TxtSerie.Text.Length != 3) Errp.SetError(TxtSerie, "Ingrese una serie valida.");
                    if(DtKardex.Rows.Count == 0) Errp.SetError(TdgProductos,"No ha ingresado ningún producto a la grilla.");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Metodo Ingresar\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmIngresarOperacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Rep_Kardex.DtTemp != null & Rep_Kardex.DtTemp.Rows.Count > 0)
            {
                //ordenar el datatable
                Rep_Kardex.DtTemp.DefaultView.Sort = "AudCrea ASC";
            }
        }

        private void CboProducto_SelectedValueChanged(object sender, EventArgs e)
        {
            //seleccionar almacen
            if (CboProducto.SelectedIndex != -1)
                CboAlmacen.SelectedValue = EmpresaID + CboSede.SelectedValue.ToString() + CboProducto.Columns["Almacen"].Value.ToString();
            else
                CboAlmacen.SelectedIndex = -1;
        }

        private void CboSede_SelectedValueChanged(object sender, EventArgs e)
        {
            if(CboSede.SelectedIndex != -1)
            {
                DataTable DtAlmacenUsuario = new DataTable();
                DtAlmacenUsuario = new CL_Almacen().ObtenerAlmacen2(EmpresaID, CboSede.SelectedValue.ToString());
                CboAlmacen.HoldFields();
                CboAlmacen.DataSource = DtAlmacenUsuario;
                CboAlmacen.DisplayMember = "Descripcion";
                CboAlmacen.ValueMember = "AlmacenID";

                CboAlmacen.Text="";
                CboProducto_SelectedValueChanged(null, null);//actualizar el almacen

                DtKardex.Rows.Clear();
            }
        }

        private void BtnMovimiento_Click(object sender, EventArgs e)
        {
            FrmMovimiento ObjFrmMovimiento = new FrmMovimiento();
            ObjFrmMovimiento.ShowDialog();
        }

        private void BtnOperacion_Click(object sender, EventArgs e)
        {
            FrmOperacion ObjFrmOperacion = new FrmOperacion();
            ObjFrmOperacion.ShowDialog();
        }

        private void BtnTipoDocumento_Click(object sender, EventArgs e)
        {
            FrmTipoDocumento ObjFrmTipoDocumento = new FrmTipoDocumento();
            ObjFrmTipoDocumento.ShowDialog();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Errp.Clear();
            //validar
            if (CboAlmacen.SelectedIndex != -1 & CboProducto.SelectedIndex != -1 & TxtCantidad.Text != "" & TxtCostoUnitario.Text != "")
            {
                //agregar registro a la tabla del kardex
                DataRow DR = DtKardex.NewRow();
                DR["AlmacenID"] = CboAlmacen.Columns["AlmacenID"].Value.ToString();
                DR["ProductoID"] = CboProducto.SelectedValue.ToString();
                DR["Producto"] = CboProducto.Columns["Alias"].Value.ToString();
                DR["Cantidad"] = Convert.ToDecimal(TxtCantidad.Text);
                DR["CostoUnitario"] = Convert.ToDecimal(TxtCostoUnitario.Text);
                DR["Almacen"] = CboAlmacen.Columns["Descripcion"].Value.ToString();
                DtKardex.Rows.Add(DR);
            }
            else
            {
                if (CboAlmacen.SelectedIndex == -1) Errp.SetError(CboAlmacen, "Seleccione un almacen.");
                if (CboProducto.SelectedIndex == -1) Errp.SetError(CboProducto, "Seleccione una producto.");
                if (TxtCantidad.Text == "") Errp.SetError(TxtCantidad, "Ingrese una cantidad valida.");
                if (TxtCostoUnitario.Text == "") Errp.SetError(TxtCostoUnitario, "Ingrese un costo valido.");
                
            }

        }

        private void CboOperacion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboOperacion.SelectedIndex != -1)
            {
                if (CboOperacion.Columns["OperacionID"].Value.ToString() == "10")//Salida a produccion
                {
                    TxtSerie.Text = "PRO";
                    TxtNumero.Text = "9999999";
                    TxtSerie.Enabled = false;
                    TxtNumero.Enabled = false;
                }
                else
                {
                    TxtSerie.Enabled = true;
                    TxtNumero.Enabled = true;
                    TxtSerie.Text = "";
                    TxtNumero.Text = "";
                }
            }
        }

    }
}
