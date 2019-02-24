using ePlatform.Data.Abstracts;
using ThreadLock.Data.Models;

namespace ThreadLock.Data.Abstracts
{
    public interface IAccountRepository: IRepository<string, AccountDTO>
    {
        decimal GetBalance(string id, AccountDTO dto);

        bool DoWithdraw(string id, AccountDTO dto);

        bool DoDeposit(string id, AccountDTO dto);
    }
}
