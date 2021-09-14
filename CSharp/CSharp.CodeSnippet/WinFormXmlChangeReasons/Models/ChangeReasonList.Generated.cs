
namespace WinFormXmlChangeReasons.Models
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("ChangeReasons", Namespace = "", IsNullable = false)]
    public partial class ChangeReasonList
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChangeReason")]
        public ChangeReason[] Items
        {
            get;
            set;
        }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ChangeReason
    {
        [System.Xml.Serialization.XmlAttributeAttribute("key")]
        public string Key
        {
            get;
            set;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("name")]
        public string Name
        {
            get;
            set;
        }

        private string _description = string.Empty;

        [System.Xml.Serialization.XmlAttributeAttribute("desc")]
        public string Description
        {
            get { return string.IsNullOrWhiteSpace(this._description) ? this.Name : this._description; }
            set { this._description = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DisplayText")]
        public ChangeReasonText[] DisplayTexts
        {
            get;
            set;
        }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ChangeReasonText
    {
        [System.Xml.Serialization.XmlAttributeAttribute("locale")]
        public string LocaleText
        {
            get;
            set;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("text")]
        public string DisplayText
        {
            get;
            set;
        }
    }
}
