using log4net.Config;
using Microsoft.Practices.Unity.Configuration;
using System;
using Unity;

namespace ePlatform.Common.DI
{
    public static class IoC
    {
        private static readonly IUnityContainer _container;

        static IoC()
        {
            _container = new UnityContainer();
            _container.AddNewExtension<Log4NetExtension>();

            try
            {
                //Initialize log4net
                InitLog4NetConfiguration();

                _container.LoadConfiguration();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IUnityContainer DependencyResolver
        {
            get { return _container; }
        }

        /// <summary>
        /// Resolve an instance of T
        /// </summary>
        public static T Resolve<T>()
        {
            try
            {
                return _container.Resolve<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Resolve an instance of T
        /// </summary>
        public static T Resolve<T>(string key)
        {
            try
            {
                return _container.Resolve<T>(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Private Methods

        private static void InitLog4NetConfiguration()
        {
            XmlConfigurator.Configure();
        }

        #endregion
    }
}
