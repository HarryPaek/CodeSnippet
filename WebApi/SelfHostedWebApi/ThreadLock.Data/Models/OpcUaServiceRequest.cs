using System;
using ePlatform.Data.Abstracts;

namespace ThreadLock.Data.Models
{
    public class OpcUaServiceRequest : IBaseEntity<string>
    {
        /*
        KeyValuePair<string, double> _internalEntity;

        public OpcUaServiceRequest(string key, double value)
        {
            this._internalEntity = new KeyValuePair<string, double>(key, value);
        }
        */

        #region IBaseEntity Implementations

        string IBaseEntity<string>.Id
        {
            get { return Key; }
        }

        #endregion

        #region Public Properties

        public string Key { get; set; }
        public double Value { get; set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("Key = [{0}], Value = [{1}]", this.Key, this.Value);
        }

        #endregion
    }
}
