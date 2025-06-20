using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SafeExtensions.DataAccess
{
    public static class Utility
    {
        public static short ToShortSafe(this Object dbValue, short defaultValue = 0)
        {
            return dbValue == DBNull.Value || dbValue == null ? defaultValue : Convert.ToInt16(dbValue, CultureInfo.InvariantCulture);
        }
        public static int ToIntSafe(this object dbValue, int defaultValue = 0)
        {
            return dbValue == DBNull.Value || dbValue == null ? defaultValue : Convert.ToInt32(dbValue, CultureInfo.InvariantCulture);
        }
        public static long ToLongSafe(this object dbValue, int defaultValue = 0)
        {
            return dbValue == DBNull.Value || dbValue == null ? defaultValue : Convert.ToInt64(dbValue, CultureInfo.InvariantCulture);
        }
        public static double ToDoubleSafe(this object dbValue, double defaultValue = 0.00)
        {
            return dbValue == DBNull.Value || dbValue == null ? defaultValue : Convert.ToDouble(dbValue, CultureInfo.InvariantCulture);
        }
        public static string ToStringSafe(this object dbValue, string defaultValue = "")
        {
            return dbValue == DBNull.Value || dbValue == null ? defaultValue : Convert.ToString(dbValue, CultureInfo.InvariantCulture);
        }
        public static DateTime? ToDateTimeSafe(this object dbValue)
        {
            DateTime defaultDatetime = DateTime.Parse("1000-01-01");
            if (dbValue == DBNull.Value || dbValue == null)
                return defaultDatetime;
            return Convert.ToDateTime(dbValue, CultureInfo.InvariantCulture);
        }
        public static bool? ToBoolSafe(this object dbValue)
        {
            bool defaultValue = false;
            if (dbValue == DBNull.Value || dbValue == null)
                return defaultValue;
            return Convert.ToBoolean(dbValue, CultureInfo.InvariantCulture);
        }
    }
}