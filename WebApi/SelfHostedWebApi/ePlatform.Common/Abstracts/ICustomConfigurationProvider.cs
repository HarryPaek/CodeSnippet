using System.Collections.Generic;

namespace ePlatform.Common.Abstracts
{
    public interface ICustomConfigurationProvider<TKey, TValue>
    {
        IDictionary<TKey, TValue> Configurations { get; }
    }
}
