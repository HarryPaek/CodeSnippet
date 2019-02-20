using System.Collections.Generic;

namespace ThreadLockSample.Abstracts
{
    public interface ICustomConfigurationProvider<TKey, TValue>
    {
        IDictionary<TKey, TValue> Configurations { get; }
    }
}
