using ePlatform.Common.Abstracts;

namespace ePlatform.WebApi.Abstracts
{
    public interface IWebApiConfigurationProvider : ICustomConfigurationProvider<string, string>
    {
        string BaseServiceAddress { get; }
    }
}
