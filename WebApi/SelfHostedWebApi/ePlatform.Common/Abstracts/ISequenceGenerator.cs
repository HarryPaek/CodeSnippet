
namespace ePlatform.Common.Abstracts
{
    public interface ISequenceGenerator
    {
        void Reset();
        void Reset(string key);

        int GetNext(string key);
        int GetCurrent(string key);

        int GetNext(params string[] keys);
        int GetCurrent(params string[] keys);
    }
}
