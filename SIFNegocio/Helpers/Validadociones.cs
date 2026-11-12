using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace SIFNegocio.Helpers
{
    public static class Validadociones
    {
        private static bool invalid = false;
        public static bool IsValidEmail(string strIn)
        {
            invalid = false;

            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            strIn = Regex.Replace(strIn, @"(@)(.+)$", DomainMapper);
            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn,
                   @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                   RegexOptions.IgnoreCase);
        }

        private static string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        public static bool ValidarRFC(string cadena)
        {
            int i = 0;
            bool confirmacion = true;
            if (cadena.Length > 11 && cadena.Length < 14)
            {
                if (cadena.Length == 12)
                {
                    cadena = "-" + cadena;
                    i = 1;
                }
                for (int j = i; j <= 3; j++)
                {
                    if (!char.IsLetter(cadena[j]))
                        confirmacion = false;
                }
                for (int j = 4; j <= 9; j++)
                {
                    if (!char.IsDigit(cadena[j]))
                        confirmacion = false;
                }
                for (int j = 9; j < 13; j++)
                {
                    if (!char.IsLetterOrDigit(cadena[j]))
                        confirmacion = false;
                }
                if (!confirmacion)
                {
                   MessageBox.Show("El formato del RFC no es valido.", "RFC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
               MessageBox.Show("La longitud del RFC no es valida.", "RFC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (confirmacion)
                return true;
            else
                return false;
        }

        public static bool IsNumeric(string p)
        {
            try
            {
                int.Parse(p);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
