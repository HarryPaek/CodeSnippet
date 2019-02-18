using System;

namespace ThreadLockSample.Models
{
    public class AccountHistoryDTO
    {
        public long Sequence { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime? Accessed { get; set; }
        public string AccessedBy { get; set; }
    }
}
