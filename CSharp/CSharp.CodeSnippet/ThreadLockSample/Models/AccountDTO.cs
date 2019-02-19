using System;
using System.Data;
using ThreadLockSample.Extensions;
using ThreadLockSample.Helpers;

namespace ThreadLockSample.Models
{
    public class AccountDTO
    {
        #region Public Properties

        public long Sequence { get; private set; }
        public string Id { get; private set; }
        public decimal Balance { get; private set; }

        public DateTime? Created { get; private set; }
        public string CreatedBy { get; private set; }

        public DateTime? LastUpdated { get; private set; }
        public string LastUpdatedBy { get; private set; }

        #endregion

        #region Static Methods

        public static AccountDTO ConvertFromDataTable(DataTable accountTable)
        {
            if(accountTable == null || accountTable.Rows == null || accountTable.Rows.Count == 0)
                return Empty;

            return ConvertFromDataRow(accountTable.Rows[0]);
        }

        public static AccountDTO Empty
        {
            get { return _empty; }
        }

        #region Private Static Methods

        private static AccountDTO ConvertFromDataRow(DataRow accountRow)
        {
            if (accountRow == null)
                return Empty;

            AccountDTO dto = new AccountDTO
            {
                Sequence = accountRow.Field<long>("SEQ"),
                Id = accountRow.SafeGetString("ACCOUNT_ID"),
                Balance = SafeParser.Get<decimal>(accountRow.SafeGetString<decimal>("BALANCE"), 0m),
                Created = accountRow.SafeGetValue<DateTime>("CREATED"),
                CreatedBy = accountRow.SafeGetString("CREATED_BY"),
                LastUpdated = accountRow.SafeGetValue<DateTime>("LAST_UPDATED"),
                LastUpdatedBy = accountRow.SafeGetString("LAST_UPDATED_BY")
            };

            return dto;
        }

        private static AccountDTO _empty = new AccountDTO
        {
            Sequence = -1,
            Id = string.Empty,
            Balance = 0,
            Created = null,
            CreatedBy = string.Empty,
            LastUpdated = null,
            LastUpdatedBy = string.Empty
        };

        #endregion

        #endregion
    }
}
