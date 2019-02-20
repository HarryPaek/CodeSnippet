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
        static IConfigurationProvider _configuration = null;

        static void Main(string[] args)
        {
            ThreadLockConfigurationProvider customConfiguration = GetCustomConfiguration();
            Account account = new Account(GetRepository());
            var tasks = new Task[customConfiguration.NumberOfTasks];

            var start = DateTime.Now;

            for (int index = 0; index < tasks.Length; index++)
            {
                string requester = string.Format("Client-{0:D5}", index);
                tasks[index] = Task.Run(() => RandomUpdate(account, requester, customConfiguration.NumberOfRequestsPerTask));
                Thread.Sleep(customConfiguration.ThreadSpeepBetweenTasks);
            }

            Task.WaitAll(tasks);

            Console.WriteLine("Tasks were done!!!, Total Time: [{0}]", DateTime.Now - start);
            Console.ReadLine();
        }

        private static IRepository GetRepository()
        {
            // return GetSimpleValueRepository();
            return GetDatabaseRepository();
        }

        #region Support Methods

        private static void RandomUpdate(Account account, string requester, int numberOfRequests = 10)
        {
            var rnd = new Random();
            for (int index = 0; index < numberOfRequests; index++)
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

        private static IRepository GetSimpleValueRepository()
        {
            return new SimpleValueRepository(1000);
        }

        private static IRepository GetDatabaseRepository()
        {
            IDBAccessor oracleDb = new OracleDBAccessor(GetConfiguration());

            return new DatabaseRepository(oracleDb);
        }

        private static IConfigurationProvider GetConfiguration()
        {
            if (_configuration == null)
                _configuration = new DefaultConfigurationProvider();

            return _configuration;
        }

        private static ThreadLockConfigurationProvider GetCustomConfiguration()
        {
            return new ThreadLockConfigurationProvider(GetConfiguration());
        }

        #endregion
    }
}
