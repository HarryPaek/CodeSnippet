using InterfaceImplementation.Abstracts;

namespace InterfaceImplementation.Impl
{
    public class TestMappable : IMappable, ILinkMappable
    {
        public string resolveName(string firstName)
        {
            return string.Format("Test Mappable [{0}]", firstName);
        }

        string IMappable.resolveName(string firstName)
        {
            return string.Format("IMappable [{0}]", firstName);
        }

        //string ILinkMappable.resolveName(string firstName)
        //{
        //    return string.Format("ILinkMappable [{0}]", firstName);
        //}
    }
}
