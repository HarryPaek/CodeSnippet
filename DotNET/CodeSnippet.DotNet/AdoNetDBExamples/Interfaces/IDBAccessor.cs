using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace AdoNetDBExamples.Interfaces
{
    public interface IDBAccessor
    {
        DbDataReader ExecuteReader(string sql);
        DbDataReader ExecuteReader(string sql, List<DbParameter> parameters);

        int ExecuteNonQuery(string sql);
        int ExecuteNonQuery(string sql, List<DbParameter> parameters);

        DataTable ExecuteSelect(string sql);
        DataTable ExecuteSelect(string sql, List<DbParameter> parameters);

        object ExecuteScalar(string sql);
        object ExecuteScalar(string sql, List<DbParameter> parameters);
    }
}
