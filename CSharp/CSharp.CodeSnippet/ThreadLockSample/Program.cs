using System;
using System.Threading;
using System.Threading.Tasks;
using ThreadLockSample.Abstracts;
using ThreadLockSample.DataAccess;
using ThreadLockSample.Providers;
using ThreadLockSample.Repositories;

namespace ThreadLockSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // var repository = GetSimpleValueRepository();
            var repository = GetDatabaseRepository();

            Account account = new Account(repository);
            var tasks   = new Task[100];

            var start = DateTime.Now;

            for (int index = 0; index < tasks.Length; index++)
            {
                string requester = string.Format("Client-{0:D5}", index);
                tasks[index] = Task.Run(() => RandomUpdate(account, requester));
                Thread.Sleep(100);
            }

            Task.WaitAll(tasks);

            Console.WriteLine("Tasks were done!!!, Total Time: [{0}]", DateTime.Now - start);
            Console.ReadLine();
        }

        private static IRepository GetSimpleValueRepository()
        {
            return new SimpleValueRepository(1000);
        }

        private static IRepository GetDatabaseRepository()
        {
            IConfigurationProvider configuration = new DefaultConfigurationProvider();
            IDBAccessor oracleDb = new OracleDBAccessor(configuration);

            return new DatabaseRepository(oracleDb);
        }

        private static void RandomUpdate(Account account, string requester)
        {
            var rnd = new Random();
            for (int index = 0; index < 10; index++)
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
