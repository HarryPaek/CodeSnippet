using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ePlatform.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static int FindIndex<T>(this IEnumerable<T> source, Predicate<T> match)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (match == null) throw new ArgumentNullException("match");

            return source.ToList().FindIndex(match);
        }

        public static int FindLastIndex<T>(this IEnumerable<T> source, Predicate<T> match)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (match == null) throw new ArgumentNullException("match");

            return source.ToList().FindLastIndex(match);
        }

        public static string AsText<T>(this IEnumerable<T> source)
        {
            if (source == null)
                return string.Empty;

            return string.Join(", ", source);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyElements"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string BuildKey(this IEnumerable<string> keyElements, string separator = "@")
        {
            if (keyElements == null || keyElements.Count() == 0)
                throw new ArgumentNullException("keyElements");

            StringBuilder keyBuilder = new StringBuilder();

            foreach (var keyElement in keyElements)
            {
                keyBuilder.Append(separator);
                keyBuilder.Append(keyElement);
            }

            return keyBuilder.ToString();
        }

        /// <summary>
        /// 현재 Collection에 주어진 리스트를  추가함
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">현재 리스트</param>
        /// <param name="items">추가할 리스트</param>
        public static void AddRange<T>(this ICollection<T> list, IEnumerable<T> items)
        {
            if (list == null) throw new ArgumentNullException("list");
            if (items == null) throw new ArgumentNullException("items");

            foreach (var item in items)
            {
                list.Add(item);
            }
        }

        /// <summary>
        /// 현재 Collection 전체를 신규 리스트로 교체함
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">교체 대상 리스트</param>
        /// <param name="items">신규 리스트</param>
        public static void ReplaceAllRange<T>(this ICollection<T> list, IEnumerable<T> items)
        {
            if (list == null) throw new ArgumentNullException("list");
            if (items == null) throw new ArgumentNullException("items");

            list.Clear();
            list.AddRange(items);
        }
    }
}
