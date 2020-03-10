using System;
using System.Collections.Generic;
using System.Text;

namespace Halley.Entidad.Users
{
    public class E_Usuario
    {
        int _UserID;
        int _PerfilID;
        int _EmpresaID;
        int _UnidadNegocioID;
        int _PersonalID;
        string _Usuario;
        string _Descripcion;
        string _Password;
        string _Correo;
        bool _FlgMaster;
        bool _FlgEst;
        int _UsuarioID;

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public int PerfilID
        {
            get { return _PerfilID; }
            set { _PerfilID = value; }
        }
        public int EmpresaID
        {
            get { return _EmpresaID; }
            set { _EmpresaID = value; }
        }
        public int UnidadNegocioID
        {
            get { return _UnidadNegocioID; }
            set { _UnidadNegocioID = value; }
        }
        public int PersonalID
        {
            get { return _PersonalID; }
            set { _PersonalID = value; }
        }
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }
        public bool FlgMaster
        {
            get { return _FlgMaster; }
            set { _FlgMaster = value; }
        }
        public bool FlgEst
        {
            get { return _FlgEst; }
            set { _FlgEst = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}
