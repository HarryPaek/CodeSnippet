using System;
using System.Threading.Tasks;

namespace ThreadLockSample
{
    public class Account
    {
        private readonly object _balanceLock = new object();
        private decimal _balance;

        public Account(decimal initialBalance)
        {
            this._balance = initialBalance;
        }

        public decimal Debit(decimal amount, int index)
        {
            lock (this._balanceLock) {
                if (this._balance >= amount) {
                    Console.WriteLine("Task [{0, 10}], Balance before debit: {1, 5}", index, this._balance);
                    Console.WriteLine("Task [{0, 10}], Amount to remove    : {1, 5}", index, amount);
                    this._balance = this._balance - amount;
                    Console.WriteLine("Task [{0, 10}], Balance after debit : {1, 5}", index, this._balance);

                    return amount;
                }
                else {
                    return 0;
                }
            }
        }

        public void Credit(decimal amount, int index)
        {
            lock (this._balanceLock) {
                Console.WriteLine("Task [{0, 10}], Balance before credit: {1, 5}", index, this._balance);
                Console.WriteLine("Task [{0, 10}], Amount to add        : {1, 5}", index, amount);
                this._balance = this._balance + amount;
                Console.WriteLine("Task [{0, 10}], Balance after credit : {1, 5}", index, this._balance);
            }
        }

        public decimal Balance(int index)
        {
            lock (this._balanceLock) {
                Console.WriteLine("Task [{0, 10}], Current Balance      : {1, 5}", index, this._balance);
                return this._balance;
            }
        }
    }
}
