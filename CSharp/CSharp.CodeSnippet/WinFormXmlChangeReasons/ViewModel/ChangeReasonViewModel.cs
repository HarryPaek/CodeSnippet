using log4net;
using System;
using System.Globalization;
using System.Threading;
using WinFormXmlChangeReasons.Models;

namespace WinFormXmlChangeReasons.ViewModel
{
    public sealed class ChangeReasonViewModel
    {
        private readonly ILog _logger = null;
        private readonly ChangeReason _model = null;
        private readonly CultureInfo  _locale = null;

        public ChangeReasonViewModel(ChangeReason changeReason): this(changeReason, Thread.CurrentThread.CurrentUICulture)
        {
        }

        public ChangeReasonViewModel(ChangeReason changeReason, CultureInfo cultureInfo)
        {
            #region Validation

            if (changeReason == null)
                throw new ArgumentNullException(nameof(changeReason));

            if (cultureInfo == null)
                throw new ArgumentNullException(nameof(cultureInfo));

            #endregion

            this._logger = LogManager.GetLogger(this.GetType());
            this._model = changeReason;
            this._locale = cultureInfo;
        }

        public override string ToString()
        {
            return string.Format("{0} <{1}>", this._model.GetDisplayText(this._locale), this._model.Key);
        }
    }
}
