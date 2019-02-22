using SelfHostedWebApi.Client.Abstracts;
using SelfHostedWebApi.Common.DI;
using SelfHostedWebApi.Data.Models;
using SelfHostedWebApi.TestClient.Abstracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SelfHostedWebApi.TestClient.Tests
{
    public class MultiThreadTest : AbstractProductTest
    {
        private ITestConfigurationProvider _testConfiguration = null;

        public MultiThreadTest(ITestConfigurationProvider testConfiguration)
        {
            if (testConfiguration == null)
                throw new ArgumentNullException("testConfiguration");

            this._testConfiguration = testConfiguration;
        }

        #region ITest Implementations

        public override void Run()
        {
            var tasks = new Task[this._testConfiguration.NumberOfTasks];

            var start = DateTime.Now;

            for (int index = 0; index < tasks.Length; index++)
            {
                string requester = string.Format("Client-{0:D5}", index);
                tasks[index] = Task.Run(() => RunRandomTest(requester, this._testConfiguration.NumberOfRequestsPerTask, this._testConfiguration.SpeepBetweenWebRequests));
                Thread.Sleep(this._testConfiguration.ThreadSpeepBetweenTasks);
            }

            Task.WaitAll(tasks);
			
			Console.WriteLine("Tasks were done!!!, Total Time: [{0}]", DateTime.Now - start);
        }

        #endregion

        #region ITest Implementations

        protected override IWebApiClient<Product> Client
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region overrided Methods

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (this._testConfiguration != null)
                    this._testConfiguration = null;
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Private Methods

        private void RunRandomTest(string requester, int numberOfRequests, int speepBetweenWebRequests)
        {
            for (int index = 0; index < numberOfRequests; index++)
            {
                Console.Out.WriteLine("----- ----- ----- ----- ----- Start Test For [{0}/{1:D5}] ----- ----- ----- ----- -----", requester, index);
                using (ITest test = IoC.Resolve<ITest>("singleThread"))
                {
                    test.Run();
                }
                Console.Out.WriteLine("***** ***** ***** ***** ***** End Test For [{0}/{1:D5}] ***** ***** ***** ***** *****", requester, index);
                Thread.Sleep(speepBetweenWebRequests);
            }
        }

        #endregion
    }
}
