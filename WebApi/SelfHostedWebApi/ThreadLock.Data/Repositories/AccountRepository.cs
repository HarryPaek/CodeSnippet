using ePlatform.Common.Extensions;
using ePlatform.Data.Abstracts;
using ePlatform.Data.Repositories;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using ThreadLock.Data.Abstracts;
using ThreadLock.Data.Exceptions;
using ThreadLock.Data.Models;

namespace ThreadLock.Data.Repositories
{
    public class AccountRepository : AbstractRepositoryBase<string, Account>, IAccountRepository
    {
        private readonly ILog _logger = null;
        private readonly object _accountLock = new object();
        private readonly IDBAccessor _db;

        public AccountRepository(IDBAccessor dbAccessor, ILog logger): base(logger)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");

            if (dbAccessor == null)
                throw new ArgumentNullException("dbAccessor");

            this._logger = logger;
            this._db = dbAccessor;
        }

        #region AbstractRepositoryBase Implementations

        public decimal GetBalance(string id, string requester)
        {
            Account dto = null;

            lock (this._accountLock)
            {
                try
                {
                    dto = GetInternal(id);

                    if (dto == null)
                        throw new RepositoryDataNotFoundException(id);

                    RecordAccountHistory(new AccountHistory { AccountSequence = dto.Sequence, TransactionType = "GetBalance", Amount = 0, Balance = dto.Balance, AccessedBy = requester });
                    Console.WriteLine("Task [{0}], Current Balance        : {1, 5}", requester, dto.Balance);
                }
                catch (RepositoryDataNotFoundException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new RepositoryDataException(string.Format("Error while executing GetBalance() for Account [{0}]", id), ex);
                }
            }

            return dto.Balance;
        }

        public bool DoDeposit(string id, decimal amount, string requester)
        {
            bool affected = false;

            lock (this._accountLock)
            {
                try
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        Account dto = GetInternal(id);

                        if (dto == null)
                            throw new RepositoryDataNotFoundException(id);

                        Console.WriteLine("Task [{0}], Balance before Deposit : {1, 5}", requester, dto.Balance);
                        Console.WriteLine("Task [{0}], Amount to deposit      : {1, 5}", requester, amount);

                        RecordAccountHistory(new AccountHistory { AccountSequence = dto.Sequence, TransactionType = "DoDeposit", Amount = amount, Balance = dto.Balance, AccessedBy = requester });
                        affected = UpdateInternal(id, dto.UpdateBalance(amount, requester));

                        dto = GetInternal(dto.Id);

                        if (dto == null)
                            throw new RepositoryDataNotFoundException(id);

                        Console.WriteLine("Task [{0}], Balance after Deposit  : {1, 5}", requester, dto.Balance);

                        transactionScope.Complete();
                    }
                }
                catch (RepositoryDataNotFoundException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new RepositoryDataException(string.Format("Error while executing DoDeposit() for Account [{0}]", id), ex);
                }
            }

            return affected;
        }

        public decimal DoWithdraw(string id, decimal amount, string requester)
        {
            decimal returnAmount = amount;

            lock (this._accountLock)
            {
                try
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        bool affected = false;
                        Account dto = GetInternal(id);

                        if (dto == null)
                            throw new RepositoryDataNotFoundException(id);

                        Console.WriteLine("Task [{0}], Balance before Withdraw: {1, 5}", requester, dto.Balance);
                        Console.WriteLine("Task [{0}], Amount to withdraw     : {1, 5}", requester, amount);

                        if (dto.Balance >= amount) {
                            RecordAccountHistory(new AccountHistory { AccountSequence = dto.Sequence, TransactionType = "DoWithdraw", Amount = amount, Balance = dto.Balance, AccessedBy = requester });
                            affected = UpdateInternal(id, dto.UpdateBalance(-amount, requester));
                        }

                        if(!affected)
                            returnAmount = 0;

                        dto = GetInternal(dto.Id);

                        if (dto == null)
                            throw new RepositoryDataNotFoundException(id);

                        Console.WriteLine("Task [{0}], Balance after Withdraw : {1, 5}", requester, dto.Balance);

                        transactionScope.Complete();
                    }
                }
                catch (RepositoryDataNotFoundException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new RepositoryDataException(string.Format("Error while executing DoWithdraw() for Account [{0}]", id), ex);
                }
            }

            return returnAmount;
        }

        #endregion

        #region AbstractRepositoryBase Implementations

        protected override object LockObject
        {
            get { return _accountLock; }
        }

        protected override IEnumerable<Account> GetAllInternal()
        {
            try
            {
                string commandText = @"SELECT *
                                         FROM ACCOUNT_WEBAPI";

                if (this._logger.IsDebugEnabled)
                    this._logger.DebugFormat("GetAllInternal(), commandText = [{0}]", commandText);

                var accountList = AccountList.ConvertFromDataTable(this._db.ExecuteSelect(commandText));

                if (this._logger.IsDebugEnabled)
                    this._logger.DebugFormat("GetAllInternal(), accountList = [{0}]", accountList.AsText());

                return accountList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override Account GetInternal(string id)
        {
            if (this._logger.IsDebugEnabled)
                this._logger.DebugFormat("GetInternal(), id = [{0}]", id);

            try
            {
                string commandText = @"SELECT *
                                         FROM ACCOUNT_WEBAPI
                                        WHERE ACCOUNT_ID   = :AccountId";

                Dictionary<string, object> parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                parameters.Add(":AccountId", id);

                if (this._logger.IsDebugEnabled)
                    this._logger.DebugFormat("GetInternal(), commandText = [{0}], parameters = [{1}]", commandText, parameters.AsText());

                var accountList = AccountList.ConvertFromDataTable(this._db.ExecuteSelect(commandText, parameters));

                if (this._logger.IsDebugEnabled)
                    this._logger.DebugFormat("GetInternal(), accountList = [{0}]", accountList.AsText());

                return accountList.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override string AddInternal(Account item)
        {
            if (this._logger.IsDebugEnabled)
                this._logger.DebugFormat("AddInternal(), item = [{0}]", item);

            try
            {
                long accountSequence = GetNextAccountSequence();
                string commandText = @"INSERT INTO ACCOUNT_WEBAPI(SEQ, ACCOUNT_ID, BALANCE, CREATED, CREATED_BY, LAST_UPDATED, LAST_UPDATED_BY)
                                       VALUES (:AccountSequence, :AccountId, :Balance, SYSDATE, :CreatedBy, SYSDATE, :LastUpdatedBy)";

                Dictionary<string, object> parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                parameters.Add(":AccountSequence", accountSequence);
                parameters.Add(":AccountId", item.Id);
                parameters.Add(":Balance", item.Balance);
                parameters.Add(":CreatedBy", item.CreatedBy);
                parameters.Add(":LastUpdatedBy", item.CreatedBy);

                if (this._logger.IsDebugEnabled)
                    this._logger.DebugFormat("AddInternal(), commandText = [{0}], parameters = [{1}]", commandText, parameters.AsText());

                int affectedRowCount = this._db.ExecuteNonQuery(commandText, parameters);

                if (this._logger.IsDebugEnabled)
                    this._logger.DebugFormat("AddInternal(), affectedRowCount = [{0}], item.Id = [{0}]", affectedRowCount, item.Id);

                return item.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override bool UpdateInternal(string id, Account item)
        {
            if (this._logger.IsDebugEnabled)
                this._logger.DebugFormat("UpdateInternal(), id = [{0}], item = [{1}]", id, item);

            try
            {
                string commandText = @"UPDATE ACCOUNT_WEBAPI
                                          SET BALANCE            = :Balance,
                                              LAST_UPDATED       = SYSDATE,
                                              LAST_UPDATED_BY    = :LastUpdatedBy
                                        WHERE ACCOUNT_ID         = :AccountId";

                Dictionary<string, object> parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                parameters.Add(":AccountId", id);
                parameters.Add(":Balance", item.Balance);
                parameters.Add(":LastUpdatedBy", item.LastUpdatedBy);

                if (this._logger.IsDebugEnabled)
                    this._logger.DebugFormat("UpdateInternal(), commandText = [{0}], parameters = [{1}]", commandText, parameters.AsText());

                int updated = this._db.ExecuteNonQuery(commandText, parameters);

                if (this._logger.IsDebugEnabled)
                    this._logger.DebugFormat("UpdateInternal(), updated = [{0}]", updated);

                return updated > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override bool DeleteInternal(string id)
        {
            if (this._logger.IsDebugEnabled)
                this._logger.DebugFormat("DeleteInternal(), id = [{0}]", id);

            try
            {
                string commandText = @"DELETE ACCOUNT_WEBAPI
                                        WHERE ACCOUNT_ID         = :AccountId";

                Dictionary<string, object> parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                parameters.Add(":AccountId", id);

                if (this._logger.IsDebugEnabled)
                    this._logger.DebugFormat("DeleteInternal(), commandText = [{0}], parameters = [{1}]", commandText, parameters.AsText());

                int deleted = this._db.ExecuteNonQuery(commandText, parameters);

                if (this._logger.IsDebugEnabled)
                    this._logger.DebugFormat("DeleteInternal(), deleted = [{0}]", deleted);

                return deleted > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private Methods

        private long GetNextAccountSequence()
        {
            try
            {
                string commandText = @"SELECT ACCOUNT_WEBAPI_SEQ.NextVal
                                         FROM DUAL";

                object returnValue = this._db.ExecuteScalar(commandText);

                return Convert.ToInt64(returnValue);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void RecordAccountHistory(AccountHistory history)
        {
            try
            {
                string commandText = @"INSERT INTO ACCOUNT_WEBAPI_HISTORY(SEQ, ACCOUNT_SEQ, TRANSACTION_TYPE, AMOUNT, BALANCE, ACCESSED, ACCESSED_BY)
                                       VALUES (ACCOUNT_WEBAPI_HISTORY_SEQ.NEXTVAL, :AccountSequence, :TransactionType, :Amount, :Balance, SYSDATE, :AccessedBy)";

                Dictionary<string, object> parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                parameters.Add(":AccountSequence", history.AccountSequence);
                parameters.Add(":TransactionType", history.TransactionType);
                parameters.Add(":Amount", history.Amount);
                parameters.Add(":Balance", history.Balance);
                parameters.Add(":AccessedBy", history.AccessedBy);

                int count = _db.ExecuteNonQuery(commandText, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
