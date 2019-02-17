using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadLockSample.Abstracts;
using ThreadLockSample.Persistants;

namespace ThreadLockSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = new SimpleValueRepository(1000);
            var account = new Account(repository);
            var tasks   = new Task[100];

            var start = DateTime.Now;

            for (int index = 0; index < tasks.Length; index++)
            {
                string requester = string.Format("Client-{0:D5}", index);
                tasks[index] = Task.Run(() => RandomUpdate(account, requester));
            }

            Task.WaitAll(tasks);

            Console.WriteLine("Tasks were done!!!, Total Time: [{0}]", DateTime.Now - start);
            Console.ReadLine();
        }

        private static void RandomUpdate(Account account, string requester)
        {
            var rnd = new Random();
            for (int index = 0; index < 100; index++)
            {
                var amount = rnd.Next(1, 100);
                double nextDouble = rnd.NextDouble();
                bool doCredit  = nextDouble < 0.35;
                bool doBalance = nextDouble < 0.7;

                if (doCredit)
                    account.Credit(amount, requester);
                else if (doBalance)
                    account.Balance(requester);
                else
                    account.Debit(amount, requester);
            }
        }
    }
}
