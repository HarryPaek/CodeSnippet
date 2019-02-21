using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostedWebApi.Common.Extensions
{
    public static class DataRowExtensions
    {
        #region DataRow 문자값을 안전하게 문자열로 반환

        /// <summary>
        /// DataRow 문자 값을 안전하게 변환
        ///  - NULL인 경우 string.Empty값 리턴
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string SafeGetString(this DataRow row, DataColumn column)
        {
            return (row.Field<string>(column) ?? string.Empty).Trim();
        }

        /// <summary>
        /// DataRow 문자 값을 안전하게 변환
        ///  - NULL인 경우 string.Empty값 리턴
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public static string SafeGetString(this DataRow row, int columnIndex)
        {
            return (row.Field<string>(columnIndex) ?? string.Empty).Trim();
        }

        /// <summary>
        /// DataRow 문자 값을 안전하게 변환
        ///  - NULL인 경우 string.Empty값 리턴
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string SafeGetString(this DataRow row, string columnName)
        {
            return (row.Field<string>(columnName) ?? string.Empty).Trim();
        }

        #endregion

        #region DataRow 임의 형식의 값을 안전하게 문자열로 반환

        /// <summary>
        /// DataRow 임의 형식의 데이터를 문자열로 안전하게 변환
        ///  - NULL인 경우 string.Empty값 리턴
        /// </summary>
        /// <typeparam name="T">struct은 class가 아닌 데이터 형식(int, long, double, float, datatime, bool 등)만 해당됨</typeparam>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string SafeGetString<T>(this DataRow row, DataColumn column) where T : struct
        {
            if (!row.IsNull(column))
                return row.Field<T>(column).ToString();

            return string.Empty;
        }

        /// <summary>
        /// DataRow 임의 형식의 데이터를 문자열로 안전하게 변환
        ///  - NULL인 경우 string.Empty값 리턴
        /// </summary>
        /// <typeparam name="T">struct은 class가 아닌 데이터 형식(int, long, double, float, datatime, bool 등)만 해당됨</typeparam>
        /// <param name="row"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public static string SafeGetString<T>(this DataRow row, int columnIndex) where T : struct
        {
            if (!row.IsNull(columnIndex))
                return row.Field<T>(columnIndex).ToString();

            return string.Empty;
        }

        /// <summary>
        /// DataRow 임의 형식의 데이터를 문자열로 안전하게 변환
        ///  - NULL인 경우 string.Empty값 리턴
        /// </summary>
        /// <typeparam name="T">struct은 class가 아닌 데이터 형식(int, long, double, float, datatime, bool 등)만 해당됨</typeparam>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string SafeGetString<T>(this DataRow row, string columnName) where T : struct
        {
            if (!row.IsNull(columnName))
                return row.Field<T>(columnName).ToString();

            return string.Empty; ;
        }

        #endregion

        #region DataRow 값을 안전하게 지정된 Nullable 형식으로 반환

        /// <summary>
        /// DataRow의 데이터를 지정된 Nullable 형식으로 안전하게 변환하여 리턴
        ///  - NULL인 경우 null값 리턴
        /// </summary>
        /// <typeparam name="T">struct은 class가 아닌 데이터 형식(int, long, double, float, datatime, bool 등)만 해당됨</typeparam>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static T? SafeGetValue<T>(this DataRow row, DataColumn column) where T : struct
        {
            if (!row.IsNull(column))
                return row.Field<T>(column);

            return null;
        }

        /// <summary>
        /// DataRow의 데이터를 지정된 Nullable 형식으로 안전하게 변환하여 리턴
        ///  - NULL인 경우 null값 리턴
        /// </summary>
        /// <typeparam name="T">struct은 class가 아닌 데이터 형식(int, long, double, float, datatime, bool 등)만 해당됨</typeparam>
        /// <param name="row"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public static T? SafeGetValue<T>(this DataRow row, int columnIndex) where T : struct
        {
            if (!row.IsNull(columnIndex))
                return row.Field<T>(columnIndex);

            return null;
        }

        /// <summary>
        /// DataRow의 데이터를 지정된 Nullable 형식으로 안전하게 변환하여 리턴
        ///  - NULL인 경우 null값 리턴
        /// </summary>
        /// <typeparam name="T">struct은 class가 아닌 데이터 형식(int, long, double, float, datatime, bool 등)만 해당됨</typeparam>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static T? SafeGetValue<T>(this DataRow row, string columnName) where T : struct
        {
            if (!row.IsNull(columnName))
                return row.Field<T>(columnName);

            return null;
        }

        #endregion
    }
}
