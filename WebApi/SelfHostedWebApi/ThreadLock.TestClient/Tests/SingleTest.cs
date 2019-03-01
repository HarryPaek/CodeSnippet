using ePlatform.Common.Abstracts;
using ePlatform.Common.Extensions;
using ePlatform.WebApi.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using ThreadLock.Data.Models;
using ThreadLock.TestClient.Abstracts;

namespace ThreadLock.TestClient.Tests
{
    public class SingleTest : ITest
    {
        private readonly string        _accountIdPrefix = string.Empty;
        private IWebApiClient<Account> _client = null;
        private ISequenceGenerator     _sequencerGenerator = null;

        public SingleTest(IWebApiClient<Account> client, ISequenceGenerator sequencerGenerator)
        {
            if (client == null)
                throw new ArgumentNullException("client");

            if (sequencerGenerator == null)
                throw new ArgumentNullException("sequencerGenerator");

            this._accountIdPrefix    = DateTime.Now.ToLongDataTimeMillSecondRadixString();
            this._client             = client;
            this._sequencerGenerator = sequencerGenerator;
        }

        #region ITest Implementations

        private string _requester = string.Empty;

        public virtual string Requester
        {
            get { return string.IsNullOrWhiteSpace(this._requester) ? "SingleTest" : this._requester; }
            set { this._requester = value ?? string.Empty; }
        }

        public virtual bool RandomTest { get; set; }

        public virtual void Run()
        {
            this._client.DefaultRequestHeaders.Add("Requester", this.Requester);

            if (this.RandomTest)
                RunRandomTest();
            else
                RunFullTest();
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue) {
                if (disposing) {
                    if (this._client != null) {
                        this._client.Dispose();
                        this._client = null;
                    }

                    this._sequencerGenerator = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SingleTest() {
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

        private void RunRandomTest()
        {
            GetBalance();
            DoDeposit();
            DoWithdraw();
        }

        private void RunFullTest()
        {
            GetAllAccounts();
            GetAccount();
            AddAccount();
            EditAccount();
            DeleteAccount();
        }

        #region All Test Case Methods

        private void GetAllAccounts()
        {
            HttpResponseMessage response = this._client.Get("api/account");

            if (!response.IsSuccessStatusCode) {
                Console.WriteLine(string.Format("GetAllAccounts(), Error with [{0}]", response.ReasonPhrase));

                return;
            }

            var accounts = response.Content.ReadAsAsync<IEnumerable<Account>>().Result
                                                                               .OrderBy(p => p.Id)
                                                                               .ToList();

            if (accounts.Any()) {
                Console.WriteLine("GetAllAccounts(), Displaying all the accounts...");
                accounts.ForEach(a => Console.WriteLine(a));
                Console.WriteLine();
            }
        }

        private void GetAccount()
        {
            string accountId = GetRandomAccountId();
            HttpResponseMessage response = QueryAccount(accountId);

            if (!response.IsSuccessStatusCode) {
                Console.WriteLine(string.Format("GetAccount({0}), Error with [{1}]", accountId, response.ReasonPhrase));

                return;
            }

            var account = response.Content.ReadAsAsync<Account>().Result;
            Console.WriteLine("Displaying account having [{0}]", account);
        }

        private void AddAccount()
        {
            HttpResponseMessage response = this._client.Post("api/account", GetNewAccountItem());

            if (!response.IsSuccessStatusCode) {
                Console.WriteLine(string.Format("AddAccount(), Error with [{0}]", response.ReasonPhrase));

                return;
            }

            string accountId = response.Content.ReadAsAsync<string>().Result;
            Console.WriteLine("New Account Id=[{0}] added successfully.", accountId);
        }

        private void EditAccount()
        {
            string accountId = GetRandomAccountId();
            HttpResponseMessage response = QueryAccount(accountId);

            if (!response.IsSuccessStatusCode) {
                Console.WriteLine(string.Format("EditAccount(), QueryAccount({0}) error with [{1}]", accountId, response.ReasonPhrase));

                return;
            }

            var account = response.Content.ReadAsAsync<Account>().Result;
            response = this._client.Put(string.Format("api/product/{0}", account.Id), GetEditAccountItem(account));

            if (!response.IsSuccessStatusCode) {
                Console.WriteLine(string.Format("EditAccount({0}), Error with [{1}]", account.Id, response.ReasonPhrase));

                return;
            }

            Console.WriteLine("Account Id=[{0}] updated successfully.", account.Id);
        }

        private void DeleteAccount()
        {
            string deleteAccountId = GetRandomAccountId();

            Console.WriteLine("DeleteAccount(), deleteAccountId=[{0}], this._sequencerGenerator.GetCurrent()=[{1}]", deleteAccountId, this._sequencerGenerator.GetCurrent(this.Requester));
            HttpResponseMessage response = this._client.Delete(string.Format("api/product/{0}", deleteAccountId));

            if (!response.IsSuccessStatusCode) {
                Console.WriteLine(string.Format("DeleteAccount({0}), Error with [{1}]", deleteAccountId, response.ReasonPhrase));

                return;
            }

            Console.WriteLine("Account Id=[{0}] deleted successfully.", deleteAccountId);
        }

        #endregion

        #region Random Test Case Methods

        private void GetBalance()
        {
            string accountId = "Harry";
            HttpResponseMessage response = this._client.Get(string.Format("api/account/{0}/balance", accountId));

            if (!response.IsSuccessStatusCode) {
                Console.WriteLine(string.Format("GetBalance({0}), Error with [{1}]", accountId, response.ReasonPhrase));

                return;
            }

            var balance = response.Content.ReadAsAsync<decimal>().Result;
            Console.WriteLine("GetBalance(), account balance having [{0}]", balance);
        }

        private void DoDeposit()
        {
            string accountId = "Harry";
            HttpResponseMessage response = this._client.Get(string.Format("api/account/{0}/deposit/{1}", accountId, GetRandomAmount()));

            if (!response.IsSuccessStatusCode) {
                Console.WriteLine(string.Format("DoDeposit({0}), Error with [{1}]", accountId, response.ReasonPhrase));

                return;
            }

            var result = response.Content.ReadAsAsync<bool>().Result;
            Console.WriteLine("DoDeposit(), result = [{0}]", result);
        }

        private void DoWithdraw()
        {
            string accountId = "Harry";
            HttpResponseMessage response = this._client.Get(string.Format("api/account/{0}/withdraw/{1}", accountId, GetRandomAmount()));

            if (!response.IsSuccessStatusCode) {
                Console.WriteLine(string.Format("DoWithdraw({0}), Error with [{1}]", accountId, response.ReasonPhrase));

                return;
            }

            var resultAmount = response.Content.ReadAsAsync<decimal>().Result;
            Console.WriteLine("DoWithdraw(), resultAmount = [{0}]", resultAmount);
        }

        #endregion

        #region Utility Methods

        private HttpResponseMessage QueryAccount(string accountId)
        {
            return this._client.Get(string.Format("api/account/{0}", accountId));
        }

        /// <summary>
        /// 임의의 Account 데이터를 억세스하기 위한 값을 구함
        /// </summary>
        /// <returns></returns>
        private string GetRandomAccountId()
        {
            return string.Format("{0}-{1}", this._accountIdPrefix, new Random().Next(0, this._sequencerGenerator.GetCurrent(this.Requester)+1));
        }

        private Account GetNewAccountItem()
        {
            string id = string.Format("{0}-{1}", this._accountIdPrefix, this._sequencerGenerator.GetNext(this.Requester));
            decimal balance = new Random().Next(1, 10) * 250m;

            return new Account(id, balance, this.Requester);
        }

        private Account GetEditAccountItem(Account account)
        {
            return account.UpdateBalance(GetRandomAmount(), this.Requester);
        }

        private decimal GetRandomAmount()
        {
            return new Random().Next(1, 10) * 15m;
        }

        #endregion

        #endregion
    }
}
