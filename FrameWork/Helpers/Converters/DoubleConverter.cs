using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Helpers.Converters {
    public static partial class ConverterHelper {
        public static double ToDouble(this object obj) {
            double res = double.MinValue;
            if(obj != null) {
                return ToDouble(obj.ToString());
            }
            return res;
        }

        public static double ToDouble(this string str) {
            double res = double.MinValue;
            if (!string.IsNullOrEmpty(str)) {
                bool success = double.TryParse(str, out var d);
                if (success)
                    res = d;
            }
            return res;
        }
    }
}
