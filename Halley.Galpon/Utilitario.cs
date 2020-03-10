using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1List;
using System.Data;

namespace Halley.Galpon
{
    public class Utilitario
    {

        public  void FillC1Combo(C1Combo objC1Combo, DataTable dataSource, string displayMember, string valueMember)
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

        public void ValidaNumero(object sender, KeyPressEventArgs e, TextBox textBox1)
        {
            if (textBox1.Text.Contains("."))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }
    }
}
