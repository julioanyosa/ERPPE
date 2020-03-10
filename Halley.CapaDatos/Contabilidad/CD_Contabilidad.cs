
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;


namespace Halley.CapaDatos.Contabilidad
{
    public class CD_Contabilidad
    {

        string connectionString;
        public CD_Contabilidad(string ConnectionString)
		{
			connectionString = ConnectionString;
		}


        public DataSet GetDatosCuenta()
        {
            DataSet dsPedido = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Contabilidad].[Usp_GetDatosCuenta]");

            dsPedido.Load(SqlClient.ExecuteReader(SqlCommand), LoadOption.PreserveChanges, "EntidadBancaria", "TipoPago", "CuentaCorriente", "Moneda");
            return dsPedido;
        }
    }
}
