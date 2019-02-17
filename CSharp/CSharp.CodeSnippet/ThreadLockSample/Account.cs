using System;
using ThreadLockSample.Abstracts;

namespace ThreadLockSample
{
    public class Account
    {
        private readonly IRepository _repository;

        public Account(IRepository repository)
        {
            this._repository = repository;
        }

        public decimal Debit(decimal amount, string requester)
        {
            return this._repository.DoWithdraw(amount, requester);
        }

        public void Credit(decimal amount, string requester)
        {
            this._repository.DoDeposit(amount, requester);
        }

        public decimal Balance(string requester)
        {
            return this._repository.GetBalance(requester);
        }
    }
}
