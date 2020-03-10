using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using C1.Win.C1TrueDBGrid;

namespace Halley.Utilitario
{
    public class C1Dropdown
    {
        public static void FillC1Dropdown(C1.Win.C1TrueDBGrid.C1TrueDBDropdown ddown, DataTable dataSource, string displaycolumn, bool SizeOriginal)
        {
            
            ddown.SetDataBinding(dataSource, "", true);

            if (SizeOriginal == false)
            {
                if (displaycolumn != null)
                {
                    foreach (C1DisplayColumn var in ddown.DisplayColumns)
                    {
                        var.Visible = false;
                    }
                    foreach (DataColumn dCol in dataSource.Columns)
                    {
                        if (dCol.ColumnName.ToString().ToUpper() == displaycolumn.ToString().ToUpper())
                        {
                            ddown.DisplayColumns[dCol.ColumnName].Visible = true;
                            ddown.DisplayColumns[dCol.ColumnName].Width = ddown.Width;
                        }
                    }

                    ddown.Tag = "";
                    string firtvalue = "";
                    foreach (DataRow dRow in dataSource.Rows)
                    {
                        if (firtvalue.Trim() == "")
                            firtvalue = dRow[0].ToString();
                        if (Convert.ToString(dRow[displaycolumn]).Trim() == "")
                        {
                            ddown.Tag = dRow[0].ToString();
                        }
                    }
                    if (ddown.Tag.ToString().Trim() == "")
                        ddown.Tag = firtvalue;
                }
            }
        }

        public static void FillC1Dropdown(C1.Win.C1TrueDBGrid.C1TrueDBDropdown ddown, DataTable dataSource, string parameter, string value, string displaycolumn)
        {
           
            ddown.SetDataBinding(dataSource, "", true);

            foreach (C1DisplayColumn var in ddown.DisplayColumns)
            {
                var.Visible = false;
            }
            foreach (DataColumn dCol in dataSource.Columns)
            {
                if (dCol.ColumnName.ToString().ToUpper() == displaycolumn.ToString().ToUpper())
                {
                    ddown.DisplayColumns[dCol.ColumnName].Visible = true;
                    ddown.DisplayColumns[dCol.ColumnName].Width = ddown.Width;
                }
            }

            ddown.Tag = "";
            string firtvalue = "";
            foreach (DataRow dRow in dataSource.Rows)
            {
                if (firtvalue.Trim() == "")
                    firtvalue = dRow[0].ToString();
                if (Convert.ToString(dRow[displaycolumn]).Trim() == "")
                {
                    ddown.Tag = dRow[0].ToString();
                }
            }
            if (ddown.Tag.ToString().Trim() == "")
                ddown.Tag = firtvalue;
        }

        public static void FillC1Dropdown(C1.Win.C1TrueDBGrid.C1TrueDBDropdown ddown, DataTable dataSource, string[] parameters, string[] values, string displaycolumn)
        {
            
            ddown.SetDataBinding(dataSource, "", true);

            foreach (C1DisplayColumn var in ddown.DisplayColumns)
            {
                var.Visible = false;
            }
            foreach (DataColumn dCol in dataSource.Columns)
            {
                if (dCol.ColumnName.ToString().ToUpper() == displaycolumn.ToString().ToUpper())
                {
                    ddown.DisplayColumns[dCol.ColumnName].Visible = true;
                    ddown.DisplayColumns[dCol.ColumnName].Width = ddown.Width;
                }
            }

            ddown.Tag = "";
            string firtvalue = "";
            foreach (DataRow dRow in dataSource.Rows)
            {
                if (firtvalue.Trim() == "")
                    firtvalue = dRow[0].ToString();
                if (Convert.ToString(dRow[displaycolumn]).Trim() == "")
                {
                    ddown.Tag = dRow[0].ToString();
                }
            }
            if (ddown.Tag.ToString().Trim() == "")
                ddown.Tag = firtvalue;
        }
    }
}