using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace AdoNetDBExamples.Interfaces
{
    public interface IDBAccessor
    {
        DbDataReader ExecuteReader(string sql, List<DbParameter> parameters = null);

        int ExecuteNonQuery(string sql, List<DbParameter> parameters = null);

        DataTable ExecuteSelect(string sql, List<DbParameter> parameters = null);

        object ExecuteScalar(string sql, List<DbParameter> parameters = null);
    }
}
