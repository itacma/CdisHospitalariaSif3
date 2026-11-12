using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIF
{
    public static class IsType
    {
        public static bool IsInteger(this string value)
        {
            int i;
            return int.TryParse(value.ToString(), out i);
        }

        public static bool IsIntegerPositive(this string value)
        {
            int i;
            bool isInt = int.TryParse(value.ToString(), out i);

            if (isInt)
            {
                return i >= 0;
            }
            return false;
        }

        public static bool IsFloat(this string value)
        {
            float f;
            bool valor = float.TryParse(value.ToString(), out f);
            return valor;
        }

        public static bool IsFloatPositive(this string value)
        {
            float i;
            bool isFloat = float.TryParse(value.ToString(), out i);
            if (isFloat)
            {
                return i >= 0;
            }

            return false;
        }

        public static bool IsDatetime(this string value)
        {
            DateTime i;
            return DateTime.TryParse(value.ToString(), out i);
        }
    }
}
