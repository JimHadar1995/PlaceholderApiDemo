using FrameWork.Constants;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FrameWork.Helpers.Converters {
    public static partial class ConverterHelper {
        #region конвертирование из даты в строковое представление
        /// <summary>
        /// конвертирование даты dd.MM.yyyy
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string DateToString(this DateTime? date) {
            string res = string.Empty;
            try {
                if (date.HasValue) {
                    res = date.Value.DateToString();
                }
            }
            catch (Exception e) {
#if DEBUG
                Debug.WriteLine(e.Message);
#endif
            }
            return res;
        }
        /// <summary>
        /// конвертирование даты в формате dd.MM.yyyy
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string DateToString(this DateTime date) {
            return date.ToString(FormatConstants.DateFormat);
        }
        /// <summary>
        /// конвертирование даты в формат HH:mm
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string TimeToString(this DateTime? date) {
            string res = string.Empty;
            try {
                if (date.HasValue) {
                    res = date.Value.TimeToString();
                }
            }
            catch (Exception e) {
#if DEBUG
                Debug.WriteLine(e.Message);
#endif
            }
            return res;
        }
        /// <summary>
        /// конвертирование даты в формат HH:mm
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string TimeToString(this DateTime date) {
            return date.ToString(FormatConstants.TimeFormat);
        }
        /// <summary>
        /// конвертирование даты в формат dd.MM.yyyy HH:mm
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string DateTimeToString(this DateTime? date) {
            string res = string.Empty;
            try {
                if (date.HasValue) {
                    res = date.Value.DateTimeToString();
                }
            }
            catch (Exception e) {
#if DEBUG
                Debug.WriteLine(e.Message);
#endif
            }
            return res;
        }
        /// <summary>
        /// конвертирование даты dd.MM.yyyy HH:mm
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string DateTimeToString(this DateTime date) {
            return date.ToString(FormatConstants.DateTimeFormat);
        }
        #endregion

        #region конвертация в представление даты
        /// <summary>
        /// конвертирование строки в дату
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str) {
            var res = DateTime.MinValue;
            if (string.IsNullOrEmpty(str)) {
                res = Convert.ToDateTime(str);
            }
            return res;
        }
        /// <summary>
        /// конвертирование объекта в дату
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object obj) {
            var res = DateTime.MinValue;
            if(obj != null) {
                res = Convert.ToDateTime(obj);
            }
            return res;
        }
        #endregion
    }
}
