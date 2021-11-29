using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionHandling.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 주어진 객체가 해당 타입인지 검사
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsA<T>(this object obj)
        {
            return obj is T;
        }

        public static string ToNullString(this object obj)
        {
            if (obj == null) return "<NULL>";

            if (obj.IsA<Exception>()) return string.Format("Exception.Message=[{0}]", (obj as Exception).Message);

            if (obj.IsA<Array>()) return string.Format("Array.Length=[{0}]", (obj as Array).Length);

            if (obj.IsA<ICollection>()) return string.Format("ICollection.Count=[{0}]", (obj as ICollection).Count);

            if (obj.IsA<IEnumerable<object>>()) return string.Format("IEnumerable<object>.Count()=[{0}]",  (obj as IEnumerable<object>).Count());

            return obj.ToString();
        }
    }
}
