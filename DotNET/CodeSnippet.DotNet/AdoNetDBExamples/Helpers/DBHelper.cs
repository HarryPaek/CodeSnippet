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
                return (T)reader.GetValue(colIndex);

            return null;
        }
    }
}
