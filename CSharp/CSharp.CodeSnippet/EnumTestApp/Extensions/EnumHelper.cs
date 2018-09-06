using System;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace EnumTestApp.Extensions
{
    public static class EnumHelper
    {
        public static string GetLocalizedDescription(this Enum currentEnum)
        {
            string description = currentEnum.ToString();

            FieldInfo fieldInfo = currentEnum.GetType().GetField(currentEnum.ToString());
            LocalizedDescriptionAttribute localizedDescriptionAttribute = (LocalizedDescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(LocalizedDescriptionAttribute));

            if (localizedDescriptionAttribute != null)
            {
                ResourceManager rm = new ResourceManager(Type.GetType(localizedDescriptionAttribute.ResourceName));
                string localizedDescription = rm.GetString(localizedDescriptionAttribute.ResourceId, Thread.CurrentThread.CurrentCulture);

                if (!string.IsNullOrWhiteSpace(localizedDescription))
                    return localizedDescription;
            }

            return description;
        }

        public static string GetDescription(this Enum currentEnum)
        {
            string description = currentEnum.ToString();
            DescriptionAttribute descriptionAttribute;

            FieldInfo fieldInfo = currentEnum.GetType().GetField(currentEnum.ToString());
            descriptionAttribute = (DescriptionAttribute)System.Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

            if (descriptionAttribute != null)
                description = descriptionAttribute.Description;

            return description;
        }

        public static object ParseEnumFromDescription(string desc, Type enumType, object defaultValue, bool includeEnumName)
        {
            FieldInfo[] fis = enumType.GetFields();

            foreach (FieldInfo fi in fis)
            {
                DescriptionAttribute da = System.Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (da != null)
                {
                    object enumValue = fi.GetValue(fi);

                    if (da.Description.Equals(desc, StringComparison.OrdinalIgnoreCase) ||
                        (includeEnumName && enumValue.ToString().Equals(desc, StringComparison.OrdinalIgnoreCase)))
                    {
                        return enumValue;
                    }
                }
            }

            throw new Exception(string.Format("Could not parse the value [{0}]. No matching value found in Enum [{1}]. ", desc, enumType.Name));
        }

        public static T GetEnumValue<T>(int enumValue, T defaultEnumValue) where T : struct, IConvertible
        {
            return GetEnumValue(enumValue.ToString(), defaultEnumValue);
        }

        public static T GetEnumValue<T>(string enumText, T defaultEnumValue) where T : struct, IConvertible
        {
            Type enumType = typeof(T);

            if (!enumType.IsEnum)
                throw new Exception("T must be an Enumeration type.");

            T enumValue;

            if (Enum.TryParse(enumText, true, out enumValue)) {
                if (Enum.IsDefined(typeof(T), enumValue) | enumValue.ToString().Contains(","))
                    return enumValue;
            }

            return defaultEnumValue;
        }
    }
}
