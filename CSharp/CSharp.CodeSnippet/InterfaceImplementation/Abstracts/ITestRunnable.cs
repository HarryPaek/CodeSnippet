
namespace InterfaceImplementation.Abstracts
{
    public interface ITestRunnable
    {
        void RunIMappable(IMappable mappable, string firstName);
        void RunILinkMappable(ILinkMappable linkMappable, string firstName);
    }
}
