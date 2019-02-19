using System;
using System.Collections.Generic;
using System.Transactions;
using ThreadLockSample.Abstracts;
using ThreadLockSample.Models;

namespace ThreadLockSample.Repositories
{
    public class DatabaseRepository : IRepository
    {
        private const string ACCOUNT_ID = "Harry";
        private readonly object _balanceLock = new object();
        private readonly IDBAccessor _db;

        public DatabaseRepository(IDBAccessor dbAccessor)
        {
            if (dbAccessor == null)
                throw new ArgumentNullException("dbAccessor");

            this._db = dbAccessor;
        }

        #region IRepository Implementations

        public decimal GetBalance(string requester)
        {
            AccountDTO dto = null;

            lock (this._balanceLock) {
                try
                {
                    dto = GetBalanceInternal(ACCOUNT_ID, requester);

                    RecordAccountHistory(new AccountHistoryDTO { AccountSequence = dto.Sequence, TransactionType = "GetBalance", Amount = 0, Balance = dto.Balance, AccessedBy = requester });
                    Console.WriteLine("Task [{0}], Current Balance        : {1, 5}", requester, dto.Balance);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return dto.Balance;
        }

        public decimal DoWithdraw(decimal amount, string requester)
        {
            decimal returnAmount = amount;

            lock (this._balanceLock) {
                try
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        AccountDTO dto = GetBalanceInternal(ACCOUNT_ID, requester);

                        Console.WriteLine("Task [{0}], Balance before Withdraw: {1, 5}", requester, dto.Balance);
                        Console.WriteLine("Task [{0}], Amount to withdraw     : {1, 5}", requester, amount);

                        if (dto.Balance >= amount) {
                            RecordAccountHistory(new AccountHistoryDTO { AccountSequence = dto.Sequence, TransactionType = "DoWithdraw", Amount = amount, Balance = dto.Balance, AccessedBy = requester });
                            DoWithdrawInternal(dto, amount, requester);
                        }
                        else
                            returnAmount = 0;

                        dto = GetBalanceInternal(dto.Id, requester);
                        Console.WriteLine("Task [{0}], Balance after Withdraw : {1, 5}", requester, dto.Balance);

                        transactionScope.Complete();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return returnAmount;
        }

        public void DoDeposit(decimal amount, string requester)
        {
            lock (this._balanceLock) {
                try
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        AccountDTO dto = GetBalanceInternal(ACCOUNT_ID, requester);

                        Console.WriteLine("Task [{0}], Balance before Deposit : {1, 5}", requester, dto.Balance);
                        Console.WriteLine("Task [{0}], Amount to deposit      : {1, 5}", requester, amount);

                        RecordAccountHistory(new AccountHistoryDTO { AccountSequence = dto.Sequence, TransactionType = "DoDeposit", Amount = amount, Balance = dto.Balance, AccessedBy = requester });
                        DoDepositInternal(dto, amount, requester);

                        dto = GetBalanceInternal(dto.Id, requester);
                        Console.WriteLine("Task [{0}], Balance after Deposit  : {1, 5}", requester, dto.Balance);

                        transactionScope.Complete();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #endregion

        #region Private Methods

        public AccountDTO GetBalanceInternal(string accountId, string requester)
        {
            try
            {
                string commandText = @"SELECT *
                                         FROM ACCOUNT
                                        WHERE ACCOUNT_ID   = :AccountId";

                Dictionary<string, object> parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                parameters.Add(":AccountId", accountId);

                return AccountDTO.ConvertFromDataTable(this._db.ExecuteSelect(commandText, parameters));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void DoWithdrawInternal(AccountDTO dto, decimal amount, string requester)
        {
            try
            {
                string commandText = @"UPDATE ACCOUNT
                                          SET BALANCE         = :Balance - :Amount,
                                              LAST_UPDATED    = SYSDATE,
                                              LAST_UPDATED_BY = :LastUpdatedBy
                                        WHERE SEQ             = :Sequence";

                Dictionary<string, object> parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                parameters.Add(":Balance", dto.Balance);
                parameters.Add(":Amount", amount);
                parameters.Add(":LastUpdatedBy", requester);
                parameters.Add(":Sequence", dto.Sequence);

                int count = _db.ExecuteNonQuery(commandText, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void DoDepositInternal(AccountDTO dto, decimal amount, string requester)
        {
            try
            {
                string commandText = @"UPDATE ACCOUNT
                                          SET BALANCE         = :Balance + :Amount,
                                              LAST_UPDATED    = SYSDATE,
                                              LAST_UPDATED_BY = :LastUpdatedBy
                                        WHERE SEQ             = :Sequence";

                Dictionary<string, object> parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                parameters.Add(":Balance", dto.Balance);
                parameters.Add(":Amount", amount);
                parameters.Add(":LastUpdatedBy", requester);
                parameters.Add(":Sequence", dto.Sequence);

                int count = _db.ExecuteNonQuery(commandText, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void RecordAccountHistory(AccountHistoryDTO history)
        {
            try
            {
                string commandText = @"INSERT INTO ACCOUNT_HISTORY(SEQ, ACCOUNT_SEQ, TRANSACTION_TYPE, AMOUNT, BALANCE, ACCESSED, ACCESSED_BY)
                                       VALUES (ACCOUNT_HISTORY_SEQ.NEXTVAL, :Sequence, :TransactionType, :Amount, :Balance, SYSDATE, :AccessedBy)";

                Dictionary<string, object> parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                parameters.Add(":Sequence", history.AccountSequence);
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
