using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using C1.Win.C1List;
using C1.Win.C1TrueDBGrid;
using C1.Win;

namespace Halley.Utilitario
{
    public class c1Combo
    {
        public static void FillC1Combo(C1Combo objC1Combo, DataTable dataSource, string displayMember, string valueMember)
        {
            objC1Combo.DataMode = DataModeEnum.Normal;
            objC1Combo.ResetText();
            objC1Combo.AutoCompletion = true;
            objC1Combo.MatchCol = MatchColEnum.CurrentMousePos;
            objC1Combo.MatchEntry = MatchEntryEnum.Standard;
            
            objC1Combo.HoldFields();
            objC1Combo.ColumnHeaders = false;            
            objC1Combo.DataSource = dataSource;
            objC1Combo.DisplayMember = displayMember;
            objC1Combo.ValueMember = valueMember;
            objC1Combo.MaxDropDownItems = 20;

            if (dataSource.Rows.Count != 0)
                objC1Combo.SelectedIndex = 0;
        }

        public static void FillC1Combo1(C1Combo objC1Combo, DataTable dataSource, string displayMember, string valueMember)
        {
            objC1Combo.DataMode = DataModeEnum.Normal;
            objC1Combo.ResetText();
            objC1Combo.AutoCompletion = true;
            objC1Combo.MatchCol = MatchColEnum.CurrentMousePos;
            objC1Combo.MatchEntry = MatchEntryEnum.Standard;

            objC1Combo.HoldFields();
            objC1Combo.ColumnHeaders = false;
            objC1Combo.Text = "[Seleccionar]";
            objC1Combo.DataSource = dataSource;
            objC1Combo.DisplayMember = displayMember;
            objC1Combo.ValueMember = valueMember;
            objC1Combo.MaxDropDownItems = 20;

            if (dataSource.Rows.Count != 0)
                objC1Combo.SelectedIndex = -1;
        }

        public static void FillC1Combo(C1TrueDBDropdown objC1Combo, DataTable dataSource, string displayMember, string valueMember)
        {
            objC1Combo.ColumnHeaders = false;
            objC1Combo.ExtendRightColumn = true;
            
            objC1Combo.DataSource = dataSource;
            foreach (C1DropDisplayColumn dc in objC1Combo.DisplayColumns)
            {
                if (dc.Name != displayMember)
                { dc.Visible = false; }
            }

            //objC1Combo.DisplayColumns[valueMember].Visible = false;
            objC1Combo.DisplayMember = displayMember;
            objC1Combo.ValueMember = valueMember;
            objC1Combo.ValueTranslate = true;

            
        }

        //Valida que los combos de component one tenga un dato por defecto descartando valores nulos
        //que puedan dar errores

        public static object Validate(C1Combo objC1Combo, object defaultValue)
        {
            object _objTmp=null;
            object _objValue=null;


            _objTmp = objC1Combo.SelectedValue;
            if (_objTmp == null)
            { _objValue = defaultValue; }
            else
            {
                _objValue = objC1Combo.SelectedValue;
            }


            return _objValue;
        }


        public static DataTable DtPuertos()
        {
            DataTable DtPuertos = new DataTable("Puertos");
            DtPuertos.Columns.Add("Puerto", typeof(string));
            DataRow Dr = DtPuertos.NewRow();
            Dr["Puerto"] = "COM1";
            DtPuertos.Rows.Add(Dr);
            DataRow Dr1 = DtPuertos.NewRow();
            Dr1["Puerto"] = "COM2";
            DtPuertos.Rows.Add(Dr1);
            DataRow Dr2 = DtPuertos.NewRow();
            Dr2["Puerto"] = "COM3";
            DtPuertos.Rows.Add(Dr2);
            DataRow Dr3 = DtPuertos.NewRow();
            Dr3["Puerto"] = "COM4";
            DtPuertos.Rows.Add(Dr3);
            DataRow Dr4 = DtPuertos.NewRow();
            Dr4["Puerto"] = "COM5";
            DtPuertos.Rows.Add(Dr4);

            return DtPuertos;
        }

        public static DataTable DtMinutos()
        {
            DataTable DtPuertos = new DataTable("Minutos");
            DtPuertos.Columns.Add("Minuto", typeof(Int16));
            DataRow Dr0 = DtPuertos.NewRow();
            Dr0["Minuto"] = "5";
            DtPuertos.Rows.Add(Dr0);
            DataRow Dr = DtPuertos.NewRow();
            Dr["Minuto"] = "10";
            DtPuertos.Rows.Add(Dr);
            DataRow Dr1 = DtPuertos.NewRow();
            Dr1["Minuto"] = "20";
            DtPuertos.Rows.Add(Dr1);
            DataRow Dr2 = DtPuertos.NewRow();
            Dr2["Minuto"] = "30";
            DtPuertos.Rows.Add(Dr2);
            DataRow Dr3 = DtPuertos.NewRow();
            Dr3["Minuto"] = "40";
            DtPuertos.Rows.Add(Dr3);
            DataRow Dr4 = DtPuertos.NewRow();
            Dr4["Minuto"] = "50";
            DtPuertos.Rows.Add(Dr4);
            DataRow Dr5 = DtPuertos.NewRow();
            Dr5["Minuto"] = "60";
            DtPuertos.Rows.Add(Dr5);

            return DtPuertos;
        }

        public static DataTable DtPeriodos()
        {
            DataTable DtPeriodo = new DataTable("Periodo");
            DtPeriodo.Columns.Add("Codigo", typeof(string));
            DtPeriodo.Columns.Add("Descripcion", typeof(string));
            DataRow Dr1 = DtPeriodo.NewRow();
            Dr1["Codigo"] = "01";
            Dr1["Descripcion"] = "Enero";
            DtPeriodo.Rows.Add(Dr1);
            DataRow Dr2 = DtPeriodo.NewRow();
            Dr2["Codigo"] = "02";
            Dr2["Descripcion"] = "Febrero";
            DtPeriodo.Rows.Add(Dr2);
            DataRow Dr3 = DtPeriodo.NewRow();
            Dr3["Codigo"] = "03";
            Dr3["Descripcion"] = "Marzo";
            DtPeriodo.Rows.Add(Dr3);
            DataRow Dr4 = DtPeriodo.NewRow();
            Dr4["Codigo"] = "04";
            Dr4["Descripcion"] = "Abril";
            DtPeriodo.Rows.Add(Dr4);
            DataRow Dr5 = DtPeriodo.NewRow();
            Dr5["Codigo"] = "05";
            Dr5["Descripcion"] = "Mayo";
            DtPeriodo.Rows.Add(Dr5);
            DataRow Dr6 = DtPeriodo.NewRow();
            Dr6["Codigo"] = "06";
            Dr6["Descripcion"] = "Junio";
            DtPeriodo.Rows.Add(Dr6);
            DataRow Dr7 = DtPeriodo.NewRow();
            Dr7["Codigo"] = "07";
            Dr7["Descripcion"] = "Julio";
            DtPeriodo.Rows.Add(Dr7);
            DataRow Dr8 = DtPeriodo.NewRow();
            Dr8["Codigo"] = "08";
            Dr8["Descripcion"] = "Agosto";
            DtPeriodo.Rows.Add(Dr8);
            DataRow Dr9 = DtPeriodo.NewRow();
            Dr9["Codigo"] = "09";
            Dr9["Descripcion"] = "Septiembre";
            DtPeriodo.Rows.Add(Dr9);
            DataRow Dr10 = DtPeriodo.NewRow();
            Dr10["Codigo"] = "10";
            Dr10["Descripcion"] = "Octubre";
            DtPeriodo.Rows.Add(Dr10);
            DataRow Dr11 = DtPeriodo.NewRow();
            Dr11["Codigo"] = "11";
            Dr11["Descripcion"] = "Noviembre";
            DtPeriodo.Rows.Add(Dr11);
            DataRow Dr12 = DtPeriodo.NewRow();
            Dr12["Codigo"] = "12";
            Dr12["Descripcion"] = "Diciembre";
            DtPeriodo.Rows.Add(Dr12);

            return DtPeriodo;
        }

        public static DataTable Annos()
        {
            DataTable DtAnno = new DataTable("Periodo");
            DtAnno.Columns.Add("Anno", typeof(string));
            int AnnoBase = DateTime.Now.Year + 1;
            for (int X = AnnoBase - 8; X <= AnnoBase;  X++)
            {
                DataRow Dr1 = DtAnno.NewRow();
                Dr1["Anno"] = X;
                DtAnno.Rows.Add(Dr1);
            }
           
            return DtAnno;
        }

        public static DataTable DtTiposMovimientos()
        {
            DataTable DtTiposMovimiento = new DataTable("TiposMovimiento");
            DtTiposMovimiento.Columns.Add("Codigo", typeof(string));
            DtTiposMovimiento.Columns.Add("Descripcion", typeof(string));
            DataRow Dr0 = DtTiposMovimiento.NewRow();
            Dr0["Codigo"] = "I";
            Dr0["Descripcion"] = "Ingreso";
            DtTiposMovimiento.Rows.Add(Dr0);
            DataRow Dr = DtTiposMovimiento.NewRow();
            Dr["Codigo"] = "S";
            Dr["Descripcion"] = "Salida";
            DtTiposMovimiento.Rows.Add(Dr);
            DataRow Dr1 = DtTiposMovimiento.NewRow();
            Dr1["Codigo"] = "A";
            Dr1["Descripcion"] = "Anterior";
            DtTiposMovimiento.Rows.Add(Dr1);
            return DtTiposMovimiento;
        }
       
    }
}
