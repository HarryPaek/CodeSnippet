using ePlatform.Common.Extensions;
using ePlatform.Common.Helpers;
using ePlatform.Data.Abstracts;
using System;
using System.Data;

namespace ThreadLock.Data.Models
{
    public class Account : IBaseEntity<string>
    {
        private Account()
        {
        }

        public Account(string id, decimal balance, string accessedBy)
        {
            this.Id = id;
            this.Balance = balance;
            this.CreatedBy = accessedBy;
            this.LastUpdatedBy = accessedBy;
        }

        #region IBaseEntity Implementations

        public string Id { get; private set; }

        #endregion

        #region Public Properties

        public long Sequence { get; private set; }
        public decimal Balance { get; private set; }

        public DateTime? Created { get; private set; }
        public string CreatedBy { get; private set; }

        public DateTime? LastUpdated { get; private set; }
        public string LastUpdatedBy { get; private set; }

        #endregion

        #region Public Methods

        public Account UpdateBalance(decimal amount, string requester)
        {
            return new Account
            {
                Id = this.Id,
                Sequence = this.Sequence,
                Balance = this.Balance + amount,
                LastUpdatedBy = requester
            };
        }

        public override string ToString()
        {
            return string.Format("Id=[{0}], Balance=[{1}], Updated=[{2}/{3}]", this.Id, this.Balance, this.LastUpdated, this.LastUpdatedBy);
        }

        #endregion

        #region Static Methods

        public static Account ConvertFromDataRow(DataRow accountRow)
        {
            if (accountRow == null)
                return Empty;

            Account dto = new Account
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

        public static Account Empty
        {
            get { return _empty; }
        }

        #region Private Static Methods

        private static Account _empty = new Account
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
