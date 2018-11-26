using System;

namespace EnumTestApp.Extensions
{
    [AttributeUsage(AttributeTargets.Field)]
    public class LocalizedDescriptionAttribute : Attribute
    {
        public string ResourceName { get; set; }
        public string ResourceId { get; set; }

        public LocalizedDescriptionAttribute()
        {
        }
    }
}
