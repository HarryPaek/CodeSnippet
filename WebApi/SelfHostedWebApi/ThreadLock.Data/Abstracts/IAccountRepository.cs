using ePlatform.Data.Abstracts;
using ThreadLock.Data.Models;

namespace ThreadLock.Data.Abstracts
{
    public interface IAccountRepository: IRepository<string, Account>
    {
        decimal GetBalance(string id, string requester);

        bool DoDeposit(string id, decimal amount, string requester);

        decimal DoWithdraw(string id, decimal amount, string requester);
    }
}
