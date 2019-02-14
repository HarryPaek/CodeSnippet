using ThreadLockSample.Abstracts;

namespace ThreadLockSample.Persistants
{
    public class SimpleValueRepository : IRepository
    {
        private readonly object _balanceLock = new object();
        private decimal _balance;
 
        public SimpleValueRepository(decimal initialBalance)
        {
            this._balance = initialBalance;
        }

        public decimal GetBalance(string requester)
        {
            lock (this._balanceLock) {
                return this._balance;
            }
        }

        public decimal DoWithdraw(decimal amount, string requester)
        {
            lock (this._balanceLock) {
                if (this._balance >= amount) {
                    this._balance = this._balance - amount;

                    return amount;
                }
                else
                    return 0;
            }

        }

        public void DoDeposit(decimal amount, string requester)
        {
            lock (this._balanceLock) {
                this._balance = this._balance + amount;
            }
        }
    }
}
