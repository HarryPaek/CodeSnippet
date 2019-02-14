
namespace ThreadLockSample.Abstracts
{
    public interface IRepository
    {
        decimal GetBalance(string requester);
        decimal DoWithdraw(decimal amount, string requester);
        void DoDeposit(decimal amount, string requester);
    }
}
