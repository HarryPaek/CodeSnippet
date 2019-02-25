using ePlatform.Data.Abstracts;
using System;

namespace ThreadLock.Data.Models
{
    public class AccountHistory : IBaseEntity<long>
    {
        #region IBaseEntity Implementations

        public long Id { get; private set; }

        #endregion

        #region Public Properties

        public long AccountSequence { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime? Accessed { get; set; }
        public string AccessedBy { get; set; }

        #endregion
    }
}
