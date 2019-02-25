using System.Collections.Generic;
using System.Data;

namespace ThreadLock.Data.Models
{
    public class AccountList: List<Account>
    {
        #region Static Methods

        public static List<Account> ConvertFromDataTable(DataTable accountTable)
        {
            var list = new List<Account>();

            if (accountTable == null || accountTable.Rows == null || accountTable.Rows.Count == 0)
                return list;

            foreach (DataRow accountRow in accountTable.Rows)
            {
                list.Add(Account.ConvertFromDataRow(accountRow));
            }

            return list;
        }

        #endregion
    }
}
