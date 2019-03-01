using ePlatform.Common.DI;
using System;
using System.Threading;
using System.Threading.Tasks;
using ThreadLock.TestClient.Abstracts;

namespace ThreadLock.TestClient.Tests
{
    public class MultiThreadTest : ITest
    {
        private ITestConfigurationProvider _testConfiguration = null;

        public MultiThreadTest(ITestConfigurationProvider testConfiguration)
        {
            if (testConfiguration == null)
                throw new ArgumentNullException("testConfiguration");

            this._testConfiguration = testConfiguration;
        }

        #region ITest Implementations

        private string _requester = string.Empty;

        public virtual string Requester
        {
            get { return string.IsNullOrWhiteSpace(this._requester) ? "MultiThreadTest" : this._requester; }
            set { this._requester = value ?? string.Empty; }
        }

        public virtual bool RandomTest { get; set; }

        public virtual void Run()
        {
            var tasks = new Task[this._testConfiguration.NumberOfTasks];

            var start = DateTime.Now;

            for (int index = 0; index < tasks.Length; index++)
            {
                string requester = string.Format("Client-{0:D5}", index);
                tasks[index] = Task.Run(() => RunTest(requester, this._testConfiguration.NumberOfRequestsPerTask, this._testConfiguration.SpeepBetweenWebRequests));
                Thread.Sleep(this._testConfiguration.ThreadSpeepBetweenTasks);
            }

            Task.WaitAll(tasks);

            Console.WriteLine("Tasks were done!!!, Total Time: [{0}]", DateTime.Now - start);
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue) {
                if (disposing) {
                    this._testConfiguration = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MultiThreadTest() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion

        #region Private Methods

        private void RunTest(string requester, int numberOfRequests, int speepBetweenWebRequests)
        {
            for (int index = 0; index < numberOfRequests; index++)
            {
                using (ITest test = IoC.Resolve<ITest>("singleThread"))
                {
                    test.Requester = requester;
                    test.RandomTest = this.RandomTest;
                    test.Run();
                }
                Thread.Sleep(speepBetweenWebRequests);
            }
        }

        #endregion
    }
}
