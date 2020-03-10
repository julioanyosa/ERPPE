using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Halley.CapaDatos.Empresa;
using Halley.Configuracion;
using Halley.Entidad.Empresa;
using System.Data;

namespace Halley.CapaLogica.Empresa
{
    public class CL_Vehiculo
    {
        public DataTable GetVehiculos()
        {
            CD_Vehiculo objCD_Vehiculo = new CD_Vehiculo(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Vehiculo.GetVehiculos();
            return dtTMP;
        }

        public DataTable GetVehiculosPlaca(string Placa)
        {
            CD_Vehiculo objCD_Vehiculo = new CD_Vehiculo(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Vehiculo.GetVehiculosPlaca(Placa);
            return dtTMP;
        }

        public void UpdateVehiculos(E_Vehiculo ObjVehiculo, string Tipo)
        {
            CD_Vehiculo objCD_Vehiculo = new CD_Vehiculo(AppSettings.GetConnectionString);
            objCD_Vehiculo.UpdateVehiculos(ObjVehiculo, Tipo);
        }

        public void InsertVehiculos(E_Vehiculo ObjVehiculo)
        {
            CD_Vehiculo objCD_Vehiculo = new CD_Vehiculo(AppSettings.GetConnectionString);
            objCD_Vehiculo.InsertVehiculos(ObjVehiculo);
        }
    }
}
