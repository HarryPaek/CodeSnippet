using ThreadLock.Data.Models;

namespace ThreadLock.Data.Abstracts
{
    public interface IEplanServiceRepository
    {
        void StartEplan();

        void ExceuteEplanAction(EplanServiceRequest request);
    }
}
