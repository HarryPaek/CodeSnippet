using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDefaultValue
{
    public class EplanRepresentationType
    {
        public static EplanRepresentationType MultiLine = new EplanRepresentationType { Id = 1, Name = "AAA", Description = "아아아" };
        public static EplanRepresentationType SingleLine = new EplanRepresentationType { Id = 2, Name = "BBB", Description = "비비비" };

        public EplanRepresentationType()
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this))
            {
                DefaultValueAttribute myAttribute = (DefaultValueAttribute)property.Attributes[typeof(DefaultValueAttribute)];

                if (myAttribute != null)
                    property.SetValue(this, myAttribute.Value);
            }
        }

        #region Public Properties

        [DefaultValue(1)]
        public int Id { get; private set; }

        [DefaultValue("AAA")]
        public string Name { get; private set; }

        [DefaultValue("아아아")]
        public string Description { get; private set; }

        #endregion

        #region Public Methods

        public string ToEECOneText()
        {
            return string.Format("{0} <{1}>", this.Name, this.Id);
        }

        public override string ToString()
        {
            return string.Format("{0} <{1}>", this.Description, this.Id);
        }

        #endregion
    }
}
