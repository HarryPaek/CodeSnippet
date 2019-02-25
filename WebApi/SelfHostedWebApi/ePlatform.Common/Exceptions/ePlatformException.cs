using System;

namespace ePlatform.Common.Exceptions
{
    public class ePlatformException : Exception
    {
        public string PopUpHeaderText { get; private set; }

        public ePlatformException(string message) : this(message,"Error", null)
        {
        }

        public ePlatformException(string message, string popupHeaderText) : this(message, popupHeaderText, null)
        {
        }

        public ePlatformException(string message, Exception innerException) : this(message, "Error", innerException)
        {
        }

        public ePlatformException(string message, string popupHeaderText, Exception innerException) : base(message, innerException)
        {
            this.PopUpHeaderText = popupHeaderText;
        }
    }
}
