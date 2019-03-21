using System.Collections.Generic;

namespace EplanService.SimpleClient.Models
{
    public class EplanServiceRequest
    {
        #region Public Properties

        public string Action { get; set; }
        public string ProjectName { get; set; }
        public List<KeyValuePair<string, string>> Parameters { get; set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("Action=[{0}], ProjectName=[{1}], Parameters=[{2}]", this.Action, this.ProjectName, Parameters);
        }

        #endregion
    }
}
