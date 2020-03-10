using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Halley.CapaDatos.Empresa;
using Halley.Configuracion;
using Halley.Entidad.Empresa;

namespace Halley.CapaLogica.Empresa
{
    public class CL_Empresas
    {
        public DataTable GetEmpresas()
        {
            CD_Empresas objCD_Empresas = new CD_Empresas(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Empresas.GetEmpresas();
            return dtTMP;
        }

        public DataTable GetSedes()
        {
            CD_Empresas objCD_Empresas = new CD_Empresas(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Empresas.GetSedes();
            return dtTMP;
        }

        public DataTable GetAlmacenesEmpresa(string SedeID, string EmpresaID)
        {
            CD_Empresas objCD_Empresas = new CD_Empresas(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Empresas.GetAlmacenesEmpresa(SedeID, EmpresaID);
            return dtTMP;
        }

        public void InsertSede(E_Sede ObjSede)
        {
            CD_Empresas objCD_Empresas = new CD_Empresas(AppSettings.GetConnectionString);
            objCD_Empresas.InsertSede(ObjSede);
        }

        public void UpdateSede(E_Sede ObjSede, string Tipo)
        {
            CD_Empresas objCD_Empresas = new CD_Empresas(AppSettings.GetConnectionString);
            objCD_Empresas.UpdateSede(ObjSede, Tipo);
        }

        public DataTable GetAlmacenHalley()
        {
            CD_Empresas objCD_Empresas = new CD_Empresas(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Empresas.GetAlmacenHalley();
            return dtTMP;
        }

        public void InsertAlmacen(string AlmacenID, string Descripcion, string SedeID, string EmpresaID, string Telefono, string Tipo, int UsuarioID)
        {
            CD_Empresas objCD_Empresas = new CD_Empresas(AppSettings.GetConnectionString);
            objCD_Empresas.InsertAlmacen(AlmacenID, Descripcion, SedeID, EmpresaID, Telefono, Tipo, UsuarioID);
        }

        public void UpdateEmpresa(E_Empresa ObjEmpresa, string Tipo)
        {
            CD_Empresas ObjCD_Empresas = new CD_Empresas(AppSettings.GetConnectionString);
            ObjCD_Empresas.UpdateEmpresa(ObjEmpresa, Tipo);
        }

        public string InsertEmpresa(E_Empresa ObjEmpresa)
        {
            string EmpresaID = "";
            CD_Empresas ObjCD_Empresas = new CD_Empresas(AppSettings.GetConnectionString);
            EmpresaID = ObjCD_Empresas.InsertEmpresa(ObjEmpresa);
            return EmpresaID;
        }

        public DataTable GetEmpresasMantenimiento()
        {
            CD_Empresas objCD_Empresas = new CD_Empresas(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Empresas.GetEmpresasMantenimiento();
            return dtTMP;
        }
    }
}
