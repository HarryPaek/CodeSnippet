using ePlatform.Common.Extensions;
using ePlatform.Data.Abstracts;
using System.Collections.Generic;

namespace ThreadLock.Data.Models
{
    public class EplanServiceRequest: IBaseEntity<string>
    {
        #region IBaseEntity Implementations

        public string Id
        {
            get { return Action; }
        }

        #endregion

        #region Public Properties

        public string Action { get; set; }
        public string ProjectName { get; set; }
        public List<KeyValuePair<string, string>> Parameters { get; set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("Action=[{0}], ProjectName=[{1}], Parameters=[{2}]", this.Action, this.ProjectName, Parameters.AsText());
        }

        #endregion
    }
}
