using System.Collections.Generic;

namespace SelfHostedWebApi.Common.Abstracts
{
    public interface ICustomConfigurationProvider<TKey, TValue>
    {
        IDictionary<TKey, TValue> Configurations { get; }
    }
}
