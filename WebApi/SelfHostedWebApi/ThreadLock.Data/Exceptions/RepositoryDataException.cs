using ePlatform.Common.Exceptions;
using System;

namespace ThreadLock.Data.Exceptions
{
    public class RepositoryDataException : ePlatformException
    {
        public RepositoryDataException(string message) : this(message, null)
        {
        }

        public RepositoryDataException(string message, Exception innerException) : base(message, "Error", innerException)
        {
        }
    }
}
