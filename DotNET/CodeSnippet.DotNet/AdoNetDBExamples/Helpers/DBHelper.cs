using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDBExamples.Helpers
{
    public static class DBHelper
    {
        public static T? SafeGetValue<T>(this DbDataReader reader, int colIndex) where T : struct
        {
            if (!reader.IsDBNull(colIndex))
            {
                var value = reader.GetValue(colIndex);

                if (value is T)
                    return (T)value;
                else
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                }
            }

            return null;
        }

        public static string SafeGetString(this DbDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);

            return null;
        }
    }
}
