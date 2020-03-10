using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;
using System.Xml;
using System.IO;

namespace Halley.Utilitario
{
    public class TextFunctions
    {
        public bool IsNumeric(char Character)
        {
            bool value;
            if (char.IsNumber(Character) == true)
            {
                value = true;

            }
            else
            {
                string Letter;
                Letter = char.ConvertFromUtf32(Character);

                if ((Letter == "\b") | (Letter == "\r"))
                {
                    value = true;
                }
                else
                {
                    value = false;
                }
            }
            return value;
        }

        public void SoloNumero(object sender, KeyPressEventArgs e, TextBox textBox1)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }
      

        public bool DecimalPoint(string text)
        {
            bool value;
            if (text.Contains(".") == true)
            {
                value = true;
            }
            else
            {
                value = false;
            }

            return value;
        }

        public bool IsDecimal(char Character, string text, int decimals)
        {
            bool value = false;
            string Letter;
            Letter = char.ConvertFromUtf32(Character);
            if (GetDigitDecimal(text, decimals, Character) > decimals)
            {
                value = false;
            }
            else
            {
                if (char.IsNumber(Character) == true)
                {
                    value = true;
                }
                else
                {

                    switch (Letter)
                    {
                        case "\b":
                            value = true;
                            break;

                        case "\r":
                            value = true;
                            break;

                        case ".":
                            if (DecimalPoint(text) == true)
                            { value = false; }
                            else { value = true; }
                            break;
                    }

                }
            }
            return value;
        }

        public bool IsCurrency(char Character, string text)
        {
            bool value = false;
            string Letter;
            Letter = char.ConvertFromUtf32(Character);
            if (GetDigitDecimal(text, 2, Character) > 2)
            {
                value = false;
            }
            else
            {
                if (char.IsNumber(Character) == true)
                {
                    value = true;
                }
                else
                {

                    switch (Letter)
                    {
                        case "\b":
                            value = true;
                            break;

                        case "\r":
                            value = true;
                            break;

                        case ".":
                            if (DecimalPoint(text) == true)
                            { value = false; }
                            else { value = true; }
                            break;
                    }

                }
            }
            return value;
        }

        private int GetDigitDecimal(string text, int decimals, char Character)
        {
            string Letter;
            Letter = char.ConvertFromUtf32(Character);
            int _c = 0;
            string _tmp = "";
            int value = 0;
            int _tmpCant = 0;

            if (Letter == "\b" || Letter == "\r")
            {
                value = 0;
            }
            else
            {
                _c = text.IndexOf(".");
                if (_c > 0)
                {

                    _tmpCant = _c + (decimals);
                    if (text.Length == _tmpCant)
                    {
                        _tmp = text.Substring(_c, decimals);
                        value = _tmp.Length;
                    }
                    else
                    {
                        if (text.Length >= _tmpCant)
                        {
                            value = decimals + 1;
                        }
                        else
                        {
                            value = 0;
                        }

                    }
                }
            }

            return value;

        }

        public bool IsLetter(Char key, bool Spaces)
        {
            bool value = false;

            if (Spaces == true)
            {
                if (((key >= 32) & (key <= 47)) | ((key >= 58) & (key <= 255)) | ((key == 8) | (key == 13)))
                {
                    value = true;
                }
                else
                {
                    value = false;
                }
            }
            else
            {
                if (((key >= 33) & (key <= 47)) | ((key >= 58) & (key <= 255)) | ((key == 8) | (key == 13)))
                {
                    value = true;
                }
                else
                {
                    value = false;
                }
            }


            return value;
        }

        public bool IsLetterOrDigits(Char key, bool Spaces)
        {
            bool value = false;

            if (Spaces == true)
            {
                if (((key >= 32) & (key <= 255)) | ((key == 8) | (key == 13)))
                {
                    value = true;
                }
                else
                {
                    value = false;
                }
            }
            else
            {
                if (((key >= 33) & (key <= 255)) | ((key == 8) | (key == 13)))
                {
                    value = true;
                }
                else
                {
                    value = false;
                }
            }

            return value;
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

        public double Redondear(double numero)
        {
            int cifras = (int)Math.Pow(10, 4);
            return Math.Round(numero * cifras) / cifras;
        }
        public Boolean ValidarEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //aca comienza


       public string enletras(string num)
       {
           string res, dec = "";
           Int64 entero;
           int decimales;
           double nro;
           try
           {
               nro = Convert.ToDouble(num);
           }
           catch
           {
               return "";
           }

           entero = Convert.ToInt64(Math.Truncate(nro));
           decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));

           if (decimales > 0)
           {
               dec = " Y " + decimales.ToString() + "/100";
           }
           res = toText(Convert.ToDouble(entero)) + dec;
           return res;
       }

       private string toText(double value)
       {
           string Num2Text = "";
           value = Math.Truncate(value);
           if (value == 0) Num2Text = "CERO";
           else if (value == 1) Num2Text = "UNO";
           else if (value == 2) Num2Text = "DOS";
           else if (value == 3) Num2Text = "TRES";
           else if (value == 4) Num2Text = "CUATRO";
           else if (value == 5) Num2Text = "CINCO";
           else if (value == 6) Num2Text = "SEIS";
           else if (value == 7) Num2Text = "SIETE";
           else if (value == 8) Num2Text = "OCHO";
           else if (value == 9) Num2Text = "NUEVE";
           else if (value == 10) Num2Text = "DIEZ";
           else if (value == 11) Num2Text = "ONCE";
           else if (value == 12) Num2Text = "DOCE";
           else if (value == 13) Num2Text = "TRECE";
           else if (value == 14) Num2Text = "CATORCE";
           else if (value == 15) Num2Text = "QUINCE";
           else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
           else if (value == 20) Num2Text = "VEINTE";
           else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
           else if (value == 30) Num2Text = "TREINTA";
           else if (value == 40) Num2Text = "CUARENTA";
           else if (value == 50) Num2Text = "CINCUENTA";
           else if (value == 60) Num2Text = "SESENTA";
           else if (value == 70) Num2Text = "SETENTA";
           else if (value == 80) Num2Text = "OCHENTA";
           else if (value == 90) Num2Text = "NOVENTA";
           else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
           else if (value == 100) Num2Text = "CIEN";
           else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
           else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
           else if (value == 500) Num2Text = "QUINIENTOS";
           else if (value == 700) Num2Text = "SETECIENTOS";
           else if (value == 900) Num2Text = "NOVECIENTOS";
           else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
           else if (value == 1000) Num2Text = "MIL";
           else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
           else if (value < 1000000)
           {
               Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
               if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
           }

           else if (value == 1000000) Num2Text = "UN MILLON";
           else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
           else if (value < 1000000000000)

           {
               Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
               if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
           }

          else if (value == 1000000000000) Num2Text = "UN BILLON";
          else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
          else
           {
              Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
              if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
           }
           return Num2Text;
       }

    }
}
