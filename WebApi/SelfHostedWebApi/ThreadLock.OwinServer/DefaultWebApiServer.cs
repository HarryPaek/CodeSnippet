﻿using ePlatform.WebApi.Abstracts;
using Microsoft.Owin.Hosting;
using System;
using ThreadLock.OwinServer.Abstracts;

namespace ThreadLock.OwinServer
{
    public class DefaultWebApiServer : IWebApiServer
    {
        private IWebApiConfigurationProvider _webApiConfiguration = null;
        private IDisposable _serverInstance = null;

        public DefaultWebApiServer(IWebApiConfigurationProvider webApiConfiguration)
        {
            if (webApiConfiguration == null)
                throw new ArgumentNullException("webApiConfiguration");

            this._webApiConfiguration = webApiConfiguration;
        }

        #region IWebApiServer Implementations

        public void Start()
        {
            Console.WriteLine(" Service is starting at {0}", this._webApiConfiguration.BaseServiceAddress);
            Console.WriteLine(" ..... ..... .....");

            _serverInstance = WebApp.Start<StartUp>(this._webApiConfiguration.BaseServiceAddress);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" Service was  started at {0}", this._webApiConfiguration.BaseServiceAddress);
        }

        public void End()
        {
            if(_serverInstance == null) {
                Console.WriteLine(" ..... ..... .....");
                Console.WriteLine(" Service is not running!");

                return;
            }

            Console.WriteLine(" ..... ..... .....");
            Console.WriteLine(" Service is running at {0} & start shutting down.", this._webApiConfiguration.BaseServiceAddress);

            _serverInstance.Dispose();
            _serverInstance = null;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" Service was shut down successfully.");
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue) {
                if (disposing) {
                    this.End();
                    this._webApiConfiguration = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DefaultWebApiServer() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
