using System;
using ThreadLockSample.Abstracts;

namespace ThreadLockSample.Repositories
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
                Console.WriteLine("Task [{0}], Current Balance        : {1, 5}", requester, this._balance);

                return this._balance;
            }
        }

        public decimal DoWithdraw(decimal amount, string requester)
        {
            lock (this._balanceLock) {
                Console.WriteLine("Task [{0}], Balance before Withdraw: {1, 5}", requester, this._balance);
                Console.WriteLine("Task [{0}], Amount to withdraw     : {1, 5}", requester, amount);

                decimal returnAmount = amount;
                if (this._balance >= amount)
                    this._balance = this._balance - amount;
                else
                    returnAmount = 0;

                Console.WriteLine("Task [{0}], Balance after Withdraw : {1, 5}", requester, this._balance);

                return returnAmount;
            }
        }

        public void DoDeposit(decimal amount, string requester)
        {
            lock (this._balanceLock) {
                Console.WriteLine("Task [{0}], Balance before Deposit : {1, 5}", requester, this._balance);
                Console.WriteLine("Task [{0}], Amount to deposit      : {1, 5}", requester, amount);

                this._balance = this._balance + amount;

                Console.WriteLine("Task [{0}], Balance after Deposit  : {1, 5}", requester, this._balance);
            }
        }
    }
}
