using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Helpers.Converters {
    public static partial class ConverterHelper {
        /// <summary>
        /// преобразование из объекта в тип int.
        /// Если пустая строка или ошибка, то возвращается минимальное значение
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt(this object obj) {
            int res = int.MinValue;
            if (obj != null) {
                res = ToInt(obj.ToString());
            }
            return res;
        }
        /// <summary>
        /// преобразование из строки в int. 
        /// Если пустая строка или ошибка, то возвращается минимальное значение
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str) {
            int res = int.MinValue;
            if (!string.IsNullOrEmpty(str)) {
                bool successParse = int.TryParse(str, out var i);
                if (successParse)
                    res = i;
            }
            return res;
        }
    }
}
