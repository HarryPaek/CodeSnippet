using System;

namespace ThreadLock.Data.Exceptions
{
    public class RepositoryDataNotFoundException : RepositoryDataException
    {
        public RepositoryDataNotFoundException(string id) : this(id, null)
        {
        }

        public RepositoryDataNotFoundException(string id, Exception innerException) : base(string.Format("Data Id = [{id}] Not Found.", id), innerException)
        {
        }
    }
}
