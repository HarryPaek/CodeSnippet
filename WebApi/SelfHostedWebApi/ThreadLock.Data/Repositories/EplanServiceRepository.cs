using log4net;
using System;
using ThreadLock.Data.Abstracts;
using ThreadLock.Data.Models;

namespace ThreadLock.Data.Repositories
{
    public class EplanServiceRepository : IEplanServiceRepository
    {
        private readonly ILog _logger = null;

        public EplanServiceRepository(ILog logger)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");

            this._logger = logger;
        }

        #region IEplanServiceRepository Implementations

        public void ExceuteEplanAction(EplanServiceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (this._logger.IsDebugEnabled)
                this._logger.DebugFormat("[{0}] Called with EplanServiceRequest = [{1}]", "ExceuteEplanAction()", request);
        }

        public void StartEplan()
        {
            if (this._logger.IsDebugEnabled)
                this._logger.DebugFormat("[{0}] Called...", "StartEplan()");
        }

        #endregion
    }
}
