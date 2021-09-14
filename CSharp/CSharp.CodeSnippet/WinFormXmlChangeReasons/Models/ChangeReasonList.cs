using log4net;
using System;
using System.Globalization;
using System.Linq;

namespace WinFormXmlChangeReasons.Models
{

    public partial class ChangeReasonList
    {
        public int Count()
        {
            if (this.Items == null)
                return 0;

            return this.Items.Length;
        }
    }

    public partial class ChangeReason
    {
        private readonly ILog _logger = null;

        public ChangeReason()
        {
            this._logger = LogManager.GetLogger(this.GetType());
        }

        public string GetDisplayText(CultureInfo locale)
        {
            if (this._logger.IsDebugEnabled)
                this._logger.DebugFormat("locale=[{0}]", locale == null ? "<NULL>" : locale.ToString());

            if (locale == null)
                throw new ArgumentNullException(nameof(locale));

            if (this.DisplayTexts == null || this.DisplayTexts.Length == 0)
                return this.Description;

            ChangeReasonText reasonText = this.DisplayTexts.FirstOrDefault(dt => locale.Name.Equals(dt.LocaleText, StringComparison.OrdinalIgnoreCase));

            if(reasonText == null)
                reasonText = this.DisplayTexts.FirstOrDefault(dt => locale.Name.StartsWith(dt.LocaleText, StringComparison.OrdinalIgnoreCase) ||
                                                                    dt.LocaleText.StartsWith(locale.Name, StringComparison.OrdinalIgnoreCase));

            return reasonText?.DisplayText ?? this.Description;
        }

        public override string ToString()
        {
            return string.Format("{0} <{1}>", this.Description, this.Key);
        }
    }

    public partial class ChangeReasonText
    {
        public override string ToString()
        {
            return string.Format("{0} <{1}>", this.DisplayText, this.LocaleText);
        }
    }
}
