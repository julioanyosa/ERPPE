using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using Halley.Entidad.Ventas;
using Halley.Utilitario;
using System.IO;
using System.Data.SQLite;

namespace Halley.CapaDatos.Ventas
{
    public class CD_Comprobante
    {
        string connectionString;

        public CD_Comprobante(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        public DataTable getTipoComprobante()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_TipoComprobante");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable getTipoPago()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_TipoPago");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable getFormaPago()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_FormaPago");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public int getIGV()
        {
            int IGV;
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_IGV");

            IGV = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommand));
            return IGV;
        }



        public void InsertarIGV(int IGV, int UsuarioID)
        {

            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("VENTAS.proc_InsertarIGV");
            SqlClient.AddInParameter(SqlCommand, "@IGV", SqlDbType.SmallInt, IGV);
            SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
            SqlClient.ExecuteNonQuery(SqlCommand);

        }

        public DataTable GetSerieComprobantes(string EmpresaSede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("ventas.Usp_GetSerieGuias");
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }
        public DataTable GetSerieGuiasT(string Sede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("ventas.Usp_GetSerieGuiasT");
            SqlClient.AddInParameter(SqlCommand, "@Sede", SqlDbType.Char, Sede);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetCajasSede(string EmpresaSede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[usp_GetCajasSede]");
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetCajasSedeT(string DireccionIP)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[usp_GetCajasSedeT]");
            SqlClient.AddInParameter(SqlCommand, "@DireccionIP", SqlDbType.Char, DireccionIP);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable InsertComprobante(E_Comprobante ObjComprobante, string XMLDetalle, int NumPedido, string Tipo, DataTable DTValesConsumo, DataTable DtBoucher, DataTable DtNotaIngreso)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            string NumComprobante = null;

            try
            {

                DbCommand SqlCommandComprobante = SqlClient.GetStoredProcCommand("Ventas.Usp_Insert_Comprobante2");
                SqlClient.AddInParameter(SqlCommandComprobante, "@EmpresaID", SqlDbType.Char, ObjComprobante.EmpresaID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@SedeID", SqlDbType.Char, ObjComprobante.SedeID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@TipoComprobanteID", SqlDbType.TinyInt, ObjComprobante.TipoComprobanteID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@ClienteID", SqlDbType.Int, ObjComprobante.ClienteID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Direccion", SqlDbType.VarChar, ObjComprobante.Direccion);
                SqlClient.AddInParameter(SqlCommandComprobante, "@TipoVentaID", SqlDbType.TinyInt, ObjComprobante.TipoVentaID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@TipoPagoID", SqlDbType.TinyInt, ObjComprobante.TipoPagoId);
                SqlClient.AddInParameter(SqlCommandComprobante, "@FormaPagoID", SqlDbType.TinyInt, ObjComprobante.FormaPagoID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@NumCaja", SqlDbType.Int, ObjComprobante.NumCaja);
                SqlClient.AddInParameter(SqlCommandComprobante, "@NroGuia", SqlDbType.VarChar, ObjComprobante.NumGuia);
                SqlClient.AddInParameter(SqlCommandComprobante, "@IGV", SqlDbType.Decimal, ObjComprobante.IGV);
                SqlClient.AddInParameter(SqlCommandComprobante, "@SubTotal", SqlDbType.Decimal, ObjComprobante.SubTotal);
                SqlClient.AddInParameter(SqlCommandComprobante, "@TotalIGV", SqlDbType.Decimal, ObjComprobante.TotIgv);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Vendedor", SqlDbType.Int, ObjComprobante.Vendedor);
                SqlClient.AddInParameter(SqlCommandComprobante, "@CreditoID", SqlDbType.Int, ObjComprobante.CreditoID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Cajero", SqlDbType.Int, ObjComprobante.Cajero);
                SqlClient.AddInParameter(SqlCommandComprobante, "@EstadoID", SqlDbType.Int, ObjComprobante.EstadoID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Externa", SqlDbType.Bit, ObjComprobante.Externa);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Vale", SqlDbType.Bit, ObjComprobante.Vale);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Serie", SqlDbType.Char, ObjComprobante.Serie);
                SqlClient.AddInParameter(SqlCommandComprobante, "@NumVale", SqlDbType.Int, ObjComprobante.NumVale);
                SqlClient.AddInParameter(SqlCommandComprobante, "@XMLDetalle", SqlDbType.Xml, XMLDetalle);
                SqlClient.AddInParameter(SqlCommandComprobante, "@NumPedido", SqlDbType.Int, NumPedido);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Tipo", SqlDbType.Char, Tipo);
                SqlClient.AddInParameter(SqlCommandComprobante, "@TipoTicket", SqlDbType.Char, ObjComprobante.TipoTicket);
                SqlClient.AddInParameter(SqlCommandComprobante, "@TotalICBPER", SqlDbType.Decimal, ObjComprobante.TotalICBPER);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Descuento", SqlDbType.Decimal, ObjComprobante.Descuento);
                SqlClient.AddInParameter(SqlCommandComprobante, "@MontoTotal", SqlDbType.Decimal, ObjComprobante.MontoTotal);

                DataTable DT = new DataTable();
                DT.Load(SqlClient.ExecuteReader(SqlCommandComprobante, tran));
                NumComprobante = DT.Rows[0]["NumComprobante"].ToString();

                //insertar pago
                decimal TotalValeConsumo = 0;
                if (ObjComprobante.FormaPagoID == 5 & ObjComprobante.TipoPagoId == 2)//es vale de consumo y contado
                {
                    foreach (DataRow DRV in DTValesConsumo.Rows)
                    {
                        Int32 PagoID = 0;

                        DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_Insert_PagoNavideño");
                        SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
                        SqlClient.AddInParameter(SqlCommand, "@TipoComprobante", SqlDbType.TinyInt, ObjComprobante.TipoComprobanteID);
                        SqlClient.AddInParameter(SqlCommand, "@Importe", SqlDbType.Decimal, Convert.ToDecimal(DRV["Monto"]));
                        SqlClient.AddInParameter(SqlCommand, "@FormaPago", SqlDbType.Int, ObjComprobante.FormaPagoID);
                        SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjComprobante.Cajero);

                        PagoID = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommand, tran));

                        //insertar el vale de consumo
                        DbCommand SqlCommandComprobante2 = SqlClient.GetStoredProcCommand("Ventas.Usp_InsertValeConsumo");
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@Numvale", SqlDbType.VarChar, DRV["Numvale"].ToString());
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@PagoID", SqlDbType.Int, PagoID);
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@FechaEmision", SqlDbType.SmallDateTime, DRV["FechaEmision"]);
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@Monto", SqlDbType.Decimal, Convert.ToDecimal(DRV["Monto"]));
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@UsuarioID", SqlDbType.Int, ObjComprobante.Cajero);
                        SqlClient.ExecuteNonQuery(SqlCommandComprobante2, tran);

                        SqlCommandComprobante2.Dispose();

                        TotalValeConsumo += Convert.ToDecimal(DRV["Monto"]);
                    }
                }

                else if (ObjComprobante.FormaPagoID == 3 & ObjComprobante.TipoPagoId == 2)//es boucher y contado
                {
                    foreach (DataRow DRV in DtBoucher.Rows)
                    {
                        Int32 PagoID = 0;

                        DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_Insert_PagoNavideño");
                        SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
                        SqlClient.AddInParameter(SqlCommand, "@TipoComprobante", SqlDbType.TinyInt, ObjComprobante.TipoComprobanteID);
                        SqlClient.AddInParameter(SqlCommand, "@Importe", SqlDbType.Decimal, Convert.ToDecimal(DRV["Monto"]));
                        SqlClient.AddInParameter(SqlCommand, "@FormaPago", SqlDbType.Int, ObjComprobante.FormaPagoID);
                        SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjComprobante.Cajero);

                        PagoID = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommand, tran));

                        //insertar el vale de consumo
                        DbCommand SqlCommandComprobante2 = SqlClient.GetStoredProcCommand("Ventas.Usp_InsertBoucher");
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@NroBoucher", SqlDbType.VarChar, DRV["NroBoucher"].ToString());
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@PagoID", SqlDbType.Int, PagoID);
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@Banco", SqlDbType.VarChar, DRV["Banco"]);
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@Monto", SqlDbType.Decimal, Convert.ToDecimal(DRV["Monto"]));
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@UsuarioID", SqlDbType.Int, ObjComprobante.Cajero);
                        SqlClient.ExecuteNonQuery(SqlCommandComprobante2, tran);

                        SqlCommandComprobante2.Dispose();

                        TotalValeConsumo += Convert.ToDecimal(DRV["Monto"]);
                    }
                }

                if (DtNotaIngreso.Rows.Count > 0)
                {
                    //cambiar los estados de los ingresos
                    string XML;
                    DtNotaIngreso.TableName = "NotaIngreso";
                    XML = new BaseFunctions().GetXML(DtNotaIngreso).Replace("NewDataSet", "DocumentElement");
                    XML.Replace("Table", "NotaIngreso");

                    DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[Usp_UpdateXMLEstadoNotaIngreso]");
                    SqlClient.AddInParameter(SqlCommand, "@XML", SqlDbType.Xml, XML);
                    SqlClient.AddInParameter(SqlCommand, "@EstadoID", SqlDbType.TinyInt, 11);//estado CERRADO
                    SqlClient.ExecuteNonQuery(SqlCommand, tran);
                    SqlCommand.Dispose();

                    TotalValeConsumo += Convert.ToDecimal(DtNotaIngreso.Compute("sum(Importe)", ""));
                }

                if ((ObjComprobante.SubTotal + ObjComprobante.TotIgv) > TotalValeConsumo & ObjComprobante.TipoPagoId == 2)
                {
                    //insertar el pago que falta
                    DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_Insert_PagoNavideño");
                    SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
                    SqlClient.AddInParameter(SqlCommand, "@TipoComprobante", SqlDbType.TinyInt, ObjComprobante.TipoComprobanteID);
                    SqlClient.AddInParameter(SqlCommand, "@Importe", SqlDbType.Decimal, ObjComprobante.MontoPagado - TotalValeConsumo);
                    SqlClient.AddInParameter(SqlCommand, "@FormaPago", SqlDbType.Int, 1);// seria al contado
                    SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjComprobante.Cajero);

                    SqlClient.ExecuteNonQuery(SqlCommand, tran);
                    SqlCommand.Dispose();
                }

                SqlCommandComprobante.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();

                return DT;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void InsertComprobanteManual(string NumComprobante, E_Comprobante ObjComprobante, string XMLDetalle, int NumPedido, string Tipo, DataTable DTValesConsumo, DateTime AudCrea, DataTable DtBoucher)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommandComprobante = SqlClient.GetStoredProcCommand("Ventas.Usp_Insert_ComprobanteManual");
                SqlClient.AddInParameter(SqlCommandComprobante, "@NumComprobante", SqlDbType.Char, NumComprobante);
                SqlClient.AddInParameter(SqlCommandComprobante, "@EmpresaID", SqlDbType.Char, ObjComprobante.EmpresaID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@SedeID", SqlDbType.Char, ObjComprobante.SedeID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@TipoComprobanteID", SqlDbType.TinyInt, ObjComprobante.TipoComprobanteID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@ClienteID", SqlDbType.Int, ObjComprobante.ClienteID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Direccion", SqlDbType.VarChar, ObjComprobante.Direccion);
                SqlClient.AddInParameter(SqlCommandComprobante, "@TipoVentaID", SqlDbType.TinyInt, ObjComprobante.TipoVentaID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@TipoPagoID", SqlDbType.TinyInt, ObjComprobante.TipoPagoId);
                SqlClient.AddInParameter(SqlCommandComprobante, "@FormaPagoID", SqlDbType.TinyInt, ObjComprobante.FormaPagoID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@NumCaja", SqlDbType.Int, ObjComprobante.NumCaja);
                SqlClient.AddInParameter(SqlCommandComprobante, "@NroGuia", SqlDbType.VarChar, ObjComprobante.NumGuia);
                SqlClient.AddInParameter(SqlCommandComprobante, "@IGV", SqlDbType.Decimal, ObjComprobante.IGV);
                SqlClient.AddInParameter(SqlCommandComprobante, "@SubTotal", SqlDbType.Decimal, ObjComprobante.SubTotal);
                SqlClient.AddInParameter(SqlCommandComprobante, "@TotalIGV", SqlDbType.Decimal, ObjComprobante.TotIgv);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Vendedor", SqlDbType.Int, ObjComprobante.Vendedor);
                SqlClient.AddInParameter(SqlCommandComprobante, "@CreditoID", SqlDbType.Int, ObjComprobante.CreditoID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Cajero", SqlDbType.Int, ObjComprobante.Cajero);
                SqlClient.AddInParameter(SqlCommandComprobante, "@EstadoID", SqlDbType.Int, ObjComprobante.EstadoID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Externa", SqlDbType.Bit, ObjComprobante.Externa);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Vale", SqlDbType.Bit, ObjComprobante.Vale);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Serie", SqlDbType.Char, ObjComprobante.Serie);
                SqlClient.AddInParameter(SqlCommandComprobante, "@NumVale", SqlDbType.Int, ObjComprobante.NumVale);
                SqlClient.AddInParameter(SqlCommandComprobante, "@XMLDetalle", SqlDbType.Xml, XMLDetalle);
                SqlClient.AddInParameter(SqlCommandComprobante, "@NumPedido", SqlDbType.Int, NumPedido);
                SqlClient.AddInParameter(SqlCommandComprobante, "@Tipo", SqlDbType.Char, Tipo);
                SqlClient.AddInParameter(SqlCommandComprobante, "@AudCrea", SqlDbType.SmallDateTime, AudCrea);

                SqlClient.ExecuteNonQuery(SqlCommandComprobante, tran);

                //insertar pago
                decimal TotalValeConsumo = 0;
                if (ObjComprobante.FormaPagoID == 5 & ObjComprobante.TipoPagoId == 2)//es vale de consumo y contado
                {
                    foreach (DataRow DRV in DTValesConsumo.Rows)
                    {
                        Int32 PagoID = 0;

                        DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_Insert_PagoManual");
                        SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
                        SqlClient.AddInParameter(SqlCommand, "@TipoComprobante", SqlDbType.TinyInt, ObjComprobante.TipoComprobanteID);
                        SqlClient.AddInParameter(SqlCommand, "@Importe", SqlDbType.Decimal, Convert.ToDecimal(DRV["Monto"]));
                        SqlClient.AddInParameter(SqlCommand, "@FormaPago", SqlDbType.Int, ObjComprobante.FormaPagoID);
                        SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjComprobante.Cajero);
                        SqlClient.AddInParameter(SqlCommand, "@AudCrea", SqlDbType.SmallDateTime, AudCrea);

                        PagoID = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommand, tran));

                        //insertar el vale de consumo
                        DbCommand SqlCommandComprobante2 = SqlClient.GetStoredProcCommand("Ventas.Usp_InsertValeConsumo");
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@Numvale", SqlDbType.VarChar, DRV["Numvale"].ToString());
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@PagoID", SqlDbType.Int, PagoID);
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@FechaEmision", SqlDbType.SmallDateTime, DRV["FechaEmision"]);
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@Monto", SqlDbType.Decimal, Convert.ToDecimal(DRV["Monto"]));
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@UsuarioID", SqlDbType.Int, ObjComprobante.Cajero);
                        SqlClient.ExecuteNonQuery(SqlCommandComprobante2, tran);

                        SqlCommandComprobante2.Dispose();

                        TotalValeConsumo += Convert.ToDecimal(DRV["Monto"]);
                    }
                }

                if (ObjComprobante.FormaPagoID == 3 & ObjComprobante.TipoPagoId == 2)//es boucher y contado
                {
                    foreach (DataRow DRV in DtBoucher.Rows)
                    {
                        Int32 PagoID = 0;

                        DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_Insert_PagoManual");
                        SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
                        SqlClient.AddInParameter(SqlCommand, "@TipoComprobante", SqlDbType.TinyInt, ObjComprobante.TipoComprobanteID);
                        SqlClient.AddInParameter(SqlCommand, "@Importe", SqlDbType.Decimal, Convert.ToDecimal(DRV["Monto"]));
                        SqlClient.AddInParameter(SqlCommand, "@FormaPago", SqlDbType.Int, ObjComprobante.FormaPagoID);
                        SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjComprobante.Cajero);
                        SqlClient.AddInParameter(SqlCommand, "@AudCrea", SqlDbType.SmallDateTime, AudCrea);

                        PagoID = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommand, tran));

                        //insertar el vale de consumo
                        DbCommand SqlCommandComprobante2 = SqlClient.GetStoredProcCommand("Ventas.Usp_InsertBoucher");
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@NroBoucher", SqlDbType.VarChar, DRV["NroBoucher"].ToString());
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@PagoID", SqlDbType.Int, PagoID);
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@Banco", SqlDbType.VarChar, DRV["Banco"]);
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@Monto", SqlDbType.Decimal, Convert.ToDecimal(DRV["Monto"]));
                        SqlClient.AddInParameter(SqlCommandComprobante2, "@UsuarioID", SqlDbType.Int, ObjComprobante.Cajero);
                        SqlClient.ExecuteNonQuery(SqlCommandComprobante2, tran);

                        SqlCommandComprobante2.Dispose();

                        TotalValeConsumo += Convert.ToDecimal(DRV["Monto"]);
                    }
                }

                if ((ObjComprobante.SubTotal + ObjComprobante.TotIgv) > TotalValeConsumo & ObjComprobante.TipoPagoId == 2)
                {
                    //insertar el pago que falta
                    DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_Insert_PagoManual");
                    SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
                    SqlClient.AddInParameter(SqlCommand, "@TipoComprobante", SqlDbType.TinyInt, ObjComprobante.TipoComprobanteID);
                    SqlClient.AddInParameter(SqlCommand, "@Importe", SqlDbType.Decimal, (ObjComprobante.SubTotal + ObjComprobante.TotIgv) - TotalValeConsumo);
                    SqlClient.AddInParameter(SqlCommand, "@FormaPago", SqlDbType.Int, 1);// seria al contado
                    SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjComprobante.Cajero);
                    SqlClient.AddInParameter(SqlCommand, "@AudCrea", SqlDbType.SmallDateTime, AudCrea);

                    SqlClient.ExecuteNonQuery(SqlCommand, tran);
                    SqlCommand.Dispose();
                }

                SqlCommandComprobante.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void AnularComprobante(string NumComprobante, int TipoComprobanteID, int UsuarioID, string SedeIDE)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();


            try
            {
                DbCommand SqlCommandComprobante = SqlClient.GetStoredProcCommand("Ventas.usp_AnularComprobante");
                SqlClient.AddInParameter(SqlCommandComprobante, "@NumComprobante", SqlDbType.Char, NumComprobante);
                SqlClient.AddInParameter(SqlCommandComprobante, "@TipoComprobanteID", SqlDbType.TinyInt, TipoComprobanteID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommandComprobante, "@SedeIDE", SqlDbType.Char, SedeIDE);

                SqlClient.ExecuteNonQuery(SqlCommandComprobante, tran);
                SqlCommandComprobante.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void InsertSerieComprobante(string EmpresaSede, int TipoDocumento, string Serie, Int32 Numero, int UsuarioID, string NroAutorizacion, string SerieEticketera)
        {
            try
            {
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("ventas.Usp_InsertSerieComprobante");
                SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                SqlClient.AddInParameter(SqlCommand, "@TipoDocumento", SqlDbType.Int, TipoDocumento);
                SqlClient.AddInParameter(SqlCommand, "@Serie", SqlDbType.Char, Serie);
                SqlClient.AddInParameter(SqlCommand, "@Numero", SqlDbType.Int, Numero);
                SqlClient.AddInParameter(SqlCommand, "@NroAutorizacion", SqlDbType.VarChar, NroAutorizacion);
                SqlClient.AddInParameter(SqlCommand, "@SerieEticketera", SqlDbType.VarChar, SerieEticketera);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);

                SqlCommand.CommandTimeout = 180;
                SqlClient.ExecuteNonQuery(SqlCommand);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void UpdateSerieComprobante(string EmpresaSede, int TipoDocumento, string Serie, Int32 Numero, int UsuarioID, string NroAutorizacion, string SerieEticketera)
        {
            try
            {
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("ventas.Usp_UpdateSerieComprobante");
                SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                SqlClient.AddInParameter(SqlCommand, "@TipoDocumento", SqlDbType.Int, TipoDocumento);
                SqlClient.AddInParameter(SqlCommand, "@Serie", SqlDbType.Char, Serie);
                SqlClient.AddInParameter(SqlCommand, "@Numero", SqlDbType.Int, Numero);
                SqlClient.AddInParameter(SqlCommand, "@NroAutorizacion", SqlDbType.VarChar, NroAutorizacion);
                SqlClient.AddInParameter(SqlCommand, "@SerieEticketera", SqlDbType.VarChar, SerieEticketera);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);

                SqlCommand.CommandTimeout = 180;
                SqlClient.ExecuteNonQuery(SqlCommand);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void ELIMINAR_COMPROBANTES(string EmpresaID, string Serie, Int32 NumeroIni, Int32 numeroFin, int UsuarioID, int TipoComprobanteId)
        {
            try
            {
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[USP_ELIMINAR_COMPROBANTES]");
                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@Serie", SqlDbType.Char, Serie);
                SqlClient.AddInParameter(SqlCommand, "@NumeroIni", SqlDbType.Int, NumeroIni);
                SqlClient.AddInParameter(SqlCommand, "@numeroFin", SqlDbType.Int, numeroFin);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteId", SqlDbType.Int, TipoComprobanteId);

                SqlCommand.CommandTimeout = 180;
                SqlClient.ExecuteNonQuery(SqlCommand);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void ActualizarNotaCredito(Int32 NotaID, Int64 TicketSunat, string MensajeSunat, string EnviadoSunat, Int64 ComprobanteId)
        {
            try
            {
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ActualizarNotaCredito");
                SqlClient.AddInParameter(SqlCommand, "@NotaID", SqlDbType.Int, NotaID);
                SqlClient.AddInParameter(SqlCommand, "@TicketSunat", SqlDbType.BigInt, TicketSunat);
                SqlClient.AddInParameter(SqlCommand, "@MensajeSunat", SqlDbType.VarChar, MensajeSunat);
                SqlClient.AddInParameter(SqlCommand, "@EnviadoSunat", SqlDbType.Char, EnviadoSunat);
                SqlClient.AddInParameter(SqlCommand, "@ComprobanteId", SqlDbType.BigInt, ComprobanteId);

                SqlCommand.CommandTimeout = 180;
                SqlClient.ExecuteNonQuery(SqlCommand);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ActualizarComprobanteSunat(int ComprobanteId, string EnviadoSunat)
        {

            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ActualizarComprobanteSunat");
            SqlClient.AddInParameter(SqlCommand, "@ComprobanteId", SqlDbType.BigInt, ComprobanteId);
            SqlClient.AddInParameter(SqlCommand, "@EnviadoSunat", SqlDbType.Char, EnviadoSunat);

            DataTable DT = new DataTable();
            DT.Load(SqlClient.ExecuteReader(SqlCommand));
            return DT;

        }

        public DataTable InsertarNotaCreditoFE(string Tipo, string EmpresaID, string SerieRelacionado, Int32 NumeroRelacionado, int TipoComprobanteID,
decimal Importe, string Concepto, decimal Descuento, int ClienteID, int UsuarioID, string SedeID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.InsertarNotaCreditoFE");
            SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, Tipo);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@SerieRelacionado", SqlDbType.Char, SerieRelacionado);
            SqlClient.AddInParameter(SqlCommand, "@NumeroRelacionado", SqlDbType.Int, NumeroRelacionado);
            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.TinyInt, TipoComprobanteID);
            SqlClient.AddInParameter(SqlCommand, "@Importe", SqlDbType.Decimal, Importe);
            SqlClient.AddInParameter(SqlCommand, "@Concepto", SqlDbType.VarChar, Concepto);
            SqlClient.AddInParameter(SqlCommand, "@Descuento", SqlDbType.Decimal, Descuento);
            SqlClient.AddInParameter(SqlCommand, "@ClienteID", SqlDbType.Int, ClienteID);
            SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            SqlCommand.CommandTimeout = 150;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable ObtenerFacturadorComprobantes()
        {

            SQLiteConnection connection;

            String SQLInsert = "INSERT INTO User(Name, Surname) VALUES(?, ?)";
            String SQLUpdate = "UPDATE User SET Name = ?, Surname = ? where UserId = ?";
            string FEC_CARG = "substr(FEC_CARG, 7, 4)||\"-\"||substr(FEC_CARG, 1,2)||\"-\"||substr(FEC_CARG, 4,2) as FEC_CARG,";
            string FEC_GENE = "substr(FEC_GENE, 7, 4)||\"-\"||substr(FEC_GENE, 4,2) ||\"-\"||substr(FEC_GENE, 1,2)||\" \"||substr(FEC_GENE, 12,2) ||\":\"||substr(FEC_GENE, 15,2)||\":\"||substr(FEC_GENE, 18,2) as FEC_GENE,";
            string FEC_ENVI = "substr(FEC_ENVI, 7, 4)||\"-\"||substr(FEC_ENVI, 4,2) ||\"-\"||substr(FEC_ENVI, 1,2)||\" \"||substr(FEC_ENVI, 12,2) ||\":\"||substr(FEC_ENVI, 15,2)||\":\"||substr(FEC_ENVI, 18,2) as FEC_ENVI,";
            String SQLSelect = "SELECT TIP_DOCU, NUM_DOCU, " + FEC_CARG + FEC_GENE + FEC_ENVI + " DES_OBSE, NOM_ARCH, IND_SITU, TIP_ARCH  FROM DOCUMENTO";
            String SQLDelete = "DELETE FROM DOCUMENTO WHERE UserId = ?";

            connection = new SQLiteConnection(connectionString, true);

            // Abrimos la conexión
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLSelect;

            // Creamos un nuevo DataTable y un DataAdapter a partir de la SELECT.
            // A continuación, rellenamos la tabla con el DataAdapter
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);

            // Asignamos el DataTable al DataGrid y cerramos la conexión

            connection.Close();

            return dt;
        }

        public void EliminarFacturadorComprobantes(string nombrearchivo)
        {
            try
            {

                SQLiteConnection connection;

                String SQLDelete = "DELETE FROM DOCUMENTO WHERE NOM_ARCH = ?";

                connection = new SQLiteConnection(connectionString, true);

                // Abrimos la conexión
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Creamos un SQLiteCommand y le asignamos la cadena de consulta
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = SQLDelete;
                command.Parameters.AddWithValue("NOM_ARCH", nombrearchivo);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

   

        public DataSet ListarFacturadorSunat(string EmpresaID, DateTime FechaIni, DateTime FechaFin, int TipoComprobanteId,
            string EstadoSunat, int pagenum, int pagesize, int tipo)
        {
            DataSet Ds = new DataSet();

            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ListarFacturadorSunat");

            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.Date, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.Date, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteId", SqlDbType.Int, TipoComprobanteId);
            SqlClient.AddInParameter(SqlCommand, "@EstadoSunat", SqlDbType.VarChar, EstadoSunat);
            SqlClient.AddInParameter(SqlCommand, "@pagenum", SqlDbType.Int, pagenum);
            SqlClient.AddInParameter(SqlCommand, "@pagesize", SqlDbType.Int, pagesize);
            SqlClient.AddInParameter(SqlCommand, "@tipo", SqlDbType.Int, tipo);
            SqlCommand.CommandTimeout = 180;
            Ds.Load(SqlClient.ExecuteReader(SqlCommand), LoadOption.PreserveChanges, "Comprobante", "Usuario");
            return Ds;
        }



        public DataTable ObtenerDatosFacturdorSunat(string EmpresaID)
        {

            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ObtenerDatosFacturdorSunat");
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);

            DataTable DT = new DataTable();
            DT.Load(SqlClient.ExecuteReader(SqlCommand));
            return DT;

        }

        public void EditarDatosFacturadorSunat(string EmpresaID, string RutaArchivosSunat, string RutaBDSunat)
        {
            try
            {
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.EditarDatosFacturadorSunat");
                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@RutaArchivosSunat", SqlDbType.VarChar, RutaArchivosSunat);
                SqlClient.AddInParameter(SqlCommand, "@RutaBDSunat", SqlDbType.VarChar, RutaBDSunat);

                SqlCommand.CommandTimeout = 180;
                SqlClient.ExecuteNonQuery(SqlCommand);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable GenerarTxtFacturadorSunatVarios(string EmpresaID, int TipoComprobanteID, DateTime FechaIni, DateTime FechaFin, string Ruta)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ObtenerComprobantesGenerar");
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.Int, TipoComprobanteID);
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.Date, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.Date, FechaFin);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));

            foreach (DataRow DR in dtTmp.Rows)
            {
                GenerarTxtFacturadorSunat(Convert.ToInt64(DR["ComprobanteId"]), Ruta);

            }
            return dtTmp;
        }

        public string GenerarTxtFacturadorSunatResumenDiario(DateTime fecha, string EmpresaID, string Ruta, bool FlgEst, int TipoComprobanteID)
        {
            DataSet ds = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.GenerarTxtFacturadorSunatResumenDiario");

            SqlClient.AddInParameter(SqlCommand, "@fecha", SqlDbType.Date, fecha);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.Int, TipoComprobanteID);
            SqlClient.AddInParameter(SqlCommand, "@FlgEst", SqlDbType.Bit, FlgEst);

            ds = SqlClient.ExecuteDataSet(SqlCommand);

            GenerarTxtFacturadorSunat2(ds, Ruta);
            return "OK";
        }

        public string GenerarTxtFacturadorSunatComunicacionBaja(string EmpresaID, string NumComprobante, string MotivoBaja, string Ruta)
        {
            DataSet ds = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.GenerarTxtFacturadorSunatComunicacionBaja");

            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
            SqlClient.AddInParameter(SqlCommand, "@MotivoBaja", SqlDbType.VarChar, MotivoBaja);
            ds = SqlClient.ExecuteDataSet(SqlCommand);

            GenerarTxtFacturadorSunat2(ds, Ruta);
            return "OK";
        }


        public void GenerarTxtFacturadorSunat2(DataSet DS, string Ruta)
        {

            foreach (DataRow DR in DS.Tables[1].Rows)
            {
                string rutaCompleta = Ruta + "\\" + DR["TEXTO"].ToString();

                System.IO.File.Delete(rutaCompleta);
                DataView DV = new DataView(DS.Tables[2], "ID=" + DR["ID"].ToString(), "", DataViewRowState.CurrentRows);
                using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                {
                    foreach (DataRow DRDET in DV.ToTable().Rows)
                    {
                        mylogs.WriteLine(DRDET["TEXTO"].ToString());
                    }
                    mylogs.Close();

                }

            }

        }

        public DataSet GenerarTxtFacturadorSunat(Int64 ID, string Ruta)
        {
            DataSet ds = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ObtenerTxtFacturadorSunat");

            SqlClient.AddInParameter(SqlCommand, "@ID", SqlDbType.BigInt, ID);
            ds = SqlClient.ExecuteDataSet(SqlCommand);

            GenerarTxtFacturadorSunat2(ds, Ruta);

            ////CABECERA
            //string rutaCompleta = Ruta + "\\" + ds.Tables[1].Rows[0]["NOMBREARCHIVOCAB"].ToString();
            //string texto = ds.Tables[2].Rows[0]["COL1"].ToString();

            //System.IO.File.Delete(rutaCompleta);
            //using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            //{
            //    mylogs.WriteLine(texto);
            //    mylogs.Close();
            //}

            ////DETALLE
            //rutaCompleta = Ruta + "\\" + ds.Tables[3].Rows[0]["NOMBREARCHIVODET"].ToString();
            //System.IO.File.Delete(rutaCompleta);
            //using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            //{
            //    foreach (DataRow DR in ds.Tables[4].Rows)
            //    {
            //        texto = DR["COL1"].ToString();
            //        mylogs.WriteLine(texto);

            //    }
            //    mylogs.Close();
            //}

            ////tributo
            //rutaCompleta = Ruta + "\\" + ds.Tables[5].Rows[0]["NOMBREARCHIVOTRI"].ToString();
            //System.IO.File.Delete(rutaCompleta);
            //using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            //{
            //    foreach (DataRow DR in ds.Tables[6].Rows)
            //    {
            //        texto = DR["COL1"].ToString();
            //        mylogs.WriteLine(texto);
            //    }
            //    mylogs.Close();
            //}

            ////leyenda
            //rutaCompleta = Ruta + "\\" + ds.Tables[7].Rows[0]["NOMBREARCHIVOLEY"].ToString();
            //System.IO.File.Delete(rutaCompleta);
            //using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            //{
            //    foreach (DataRow DR in ds.Tables[8].Rows)
            //    {
            //        texto = DR["COL1"].ToString();
            //        mylogs.WriteLine(texto);
            //    }
            //    mylogs.Close();

            //}

            return ds;
        }

        public DataTable ObtenerEstadosSunat()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ObtenerEstadosSunat");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));

            return dtTmp;
        }

        public DataTable ObtenerReportesParaSunat(string EmpresaID, DateTime FechaIni, DateTime FechaFin, Int16 Tipo)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Contabilidad.ObtenerReportesParaSunat");
            SqlCommand.CommandTimeout = 600;
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.Date, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.Date, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.TinyInt, Tipo);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));

            return dtTmp;
        }


        public void InsertarPuntos(int ClienteID, int Puntos, string Concepto, int Usuario)
        {
         SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.InsertarPuntos");
            SqlClient.AddInParameter(SqlCommand, "@ClienteID", SqlDbType.Int, ClienteID);
            SqlClient.AddInParameter(SqlCommand, "@Puntos", SqlDbType.Int, Puntos);
            SqlClient.AddInParameter(SqlCommand, "@Concepto", SqlDbType.VarChar, Concepto);
            SqlClient.AddInParameter(SqlCommand, "@Usuario", SqlDbType.Int, Usuario);
            SqlClient.ExecuteNonQuery(SqlCommand);

        }

        public DataTable ObtenerPuntosCliente(int ClienteID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ObtenerPuntosCliente");
            SqlClient.AddInParameter(SqlCommand, "@ClienteID", SqlDbType.Int, ClienteID);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));

            return dtTmp;
        }

        public DataTable ActualizarTicketBaja(int id, string mensaje)
        {
            try
            {

                DataTable dtTmp = new DataTable();
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ActualizarTicketBaja");
                SqlClient.AddInParameter(SqlCommand, "@id", SqlDbType.Int, id);
                SqlClient.AddInParameter(SqlCommand, "@mensaje", SqlDbType.VarChar, mensaje);
                SqlCommand.CommandTimeout = 240;
                dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));

                return dtTmp;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void ActualizarDesdeFacturadorSunat(string EmpresaID, string NumComprobante, int TipoComprobanteID, DateTime? fechaenvio,
        string mensaje, string EstadoSunat, string NroTicket)
        {
            try
            {
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ActualizarDesdeFacturadorSunat");
                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
                SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.Int, TipoComprobanteID);
                SqlClient.AddInParameter(SqlCommand, "@fechaenvio", SqlDbType.DateTime, fechaenvio);
                SqlClient.AddInParameter(SqlCommand, "@mensaje", SqlDbType.VarChar, mensaje);
                SqlClient.AddInParameter(SqlCommand, "@EstadoSunat", SqlDbType.VarChar, EstadoSunat);
                SqlClient.AddInParameter(SqlCommand, "@NroTicket", SqlDbType.VarChar, NroTicket);

                SqlCommand.CommandTimeout = 180;
                SqlClient.ExecuteNonQuery(SqlCommand);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataSet ListarEnvioOSE(string EmpresaID, DateTime Fecha)
        {
            DataSet Ds = new DataSet();

            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ListarEnvioOSE");

            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@Fecha", SqlDbType.Date, Fecha);
            SqlCommand.CommandTimeout = 180;
            Ds.Load(SqlClient.ExecuteReader(SqlCommand), LoadOption.PreserveChanges, "Comprobante");
            return Ds;
        }

        public DataTable ObtenerComprobantesResumen(int id)
        {
            try
            {

                DataTable dtTmp = new DataTable();
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ObtenerComprobantesResumen");
                SqlClient.AddInParameter(SqlCommand, "@id", SqlDbType.Int, id); 
                SqlCommand.CommandTimeout = 240;
                dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));

                return dtTmp;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
