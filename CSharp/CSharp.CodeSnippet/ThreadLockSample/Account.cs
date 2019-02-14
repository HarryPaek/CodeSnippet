using System;
using ThreadLockSample.Abstracts;

namespace ThreadLockSample
{
    public class Account
    {
        private readonly object _balanceLock = new object();
        private readonly IRepository _repository;

        public Account(IRepository repository)
        {
            this._repository = repository;
        }

        public decimal Debit(decimal amount, string requester)
        {
            lock (this._balanceLock) {
                decimal balance = this._repository.GetBalance(requester);

                Console.WriteLine("Task [{0}], Balance before debit: {1, 5}", requester, balance);
                Console.WriteLine("Task [{0}], Amount to remove    : {1, 5}", requester, amount);

                decimal returnAmount = this._repository.DoWithdraw(amount, requester);
                balance = this._repository.GetBalance(requester);

                Console.WriteLine("Task [{0}], Balance after debit : {1, 5}", requester, balance);

                return returnAmount;
            }
        }

        public void Credit(decimal amount, string requester)
        {
            lock (this._balanceLock) {
                decimal balance = this._repository.GetBalance(requester);

                Console.WriteLine("Task [{0}], Balance before credit: {1, 5}", requester, balance);
                Console.WriteLine("Task [{0}], Amount to add        : {1, 5}", requester, amount);

                this._repository.DoDeposit(amount, requester);
                balance = this._repository.GetBalance(requester);

                Console.WriteLine("Task [{0}], Balance after credit : {1, 5}", requester, balance);
            }
        }

        public decimal Balance(string requester)
        {
            lock (this._balanceLock) {
                decimal balance = this._repository.GetBalance(requester);
                Console.WriteLine("Task [{0}], Current Balance      : {1, 5}", requester, balance);

                return balance;
            }
        }
    }
}
