using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadLockSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account(1000);
            var tasks   = new Task[100];

            var start = DateTime.Now;

            for (int index = 0; index < tasks.Length; index++)
            {
                int taskIndex = index;
                tasks[index] = Task.Run(() => RandomUpdate(account, taskIndex));
            }

            Task.WaitAll(tasks);

            Console.WriteLine("Tasks were done!!!, Total Time: [{0}]", DateTime.Now - start);
            Console.ReadLine();
        }

        private static void RandomUpdate(Account account, int index)
        {
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                var amount = rnd.Next(1, 100);
                double nextDouble = rnd.NextDouble();
                bool doCredit  = nextDouble < 0.35;
                bool doBalance = nextDouble < 0.7;

                if (doCredit)
                    account.Credit(amount, index);
                else if (doBalance)
                    account.Balance(index);
                else
                    account.Debit(amount, index);
            }
        }
    }
}
