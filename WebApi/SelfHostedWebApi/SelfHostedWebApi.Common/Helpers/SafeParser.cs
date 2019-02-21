using System;
using System.ComponentModel;
using System.Configuration;

namespace SelfHostedWebApi.Common.Helpers
{
    public static class SafeParser
    {
        public static T Get<T>(string txtValue) where T : struct
        {
            return Get<T>(txtValue, default(T));
        }

        public static T Get<T>(string txtValue, T defaultValue) where T : struct
        {
            if (string.IsNullOrWhiteSpace(txtValue))
                return defaultValue;

            var converter = TypeDescriptor.GetConverter(typeof(T));

            try
            {
                return (T)(converter.ConvertFromInvariantString(txtValue));
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static T Get<T>(KeyValueConfigurationElement configurationElement, T defaultValue) where T : struct
        {
            if (configurationElement == null || string.IsNullOrWhiteSpace(configurationElement.Value))
                return defaultValue;

            return Get(configurationElement.Value, defaultValue);
        }

        public static string Get(KeyValueConfigurationElement configurationElement, string defaultValue)
        {
            if (configurationElement == null || string.IsNullOrWhiteSpace(configurationElement.Value))
                return defaultValue;

            return configurationElement.Value;
        }

        public static bool GetFromYN(string txtValue)
        {
            return GetFromYN(txtValue, false);
        }

        public static bool GetFromYN(string txtValue, bool defaultValue)
        {
            if (string.IsNullOrWhiteSpace(txtValue))
                return defaultValue;

            if (txtValue.Equals("Y", StringComparison.OrdinalIgnoreCase) || txtValue.Equals("YES", StringComparison.OrdinalIgnoreCase))
                return true;

            if (txtValue.Equals("N", StringComparison.OrdinalIgnoreCase) || txtValue.Equals("NO", StringComparison.OrdinalIgnoreCase))
                return false;

            return defaultValue;
        }
    }
}
