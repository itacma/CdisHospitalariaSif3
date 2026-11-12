using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio.Helpers
{
    public static class SifUtils
    {

        public static int DaysBetweenDates(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts = dt2 - dt1;

            return Convert.ToInt32(Math.Truncate(ts.TotalDays)) + 1;
        }

    }
}
