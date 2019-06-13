using ePlatform.Data.Abstracts;
using ThreadLock.Data.Models;

namespace ThreadLock.Data.Abstracts
{
    public interface IOpcUaServiceRepository : IRepository<string, OpcUaServiceRequest>
    {
    }
}
