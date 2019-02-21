
namespace SelfHostedWebApi.Common.Abstracts
{
    public interface IWebApiConfigurationProvider : ICustomConfigurationProvider<string, string>
    {
        string BaseServiceAddress { get; }
    }
}
