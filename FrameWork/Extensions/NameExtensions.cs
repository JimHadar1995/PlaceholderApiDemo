using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FrameWork.Extensions {
    public static class NameExtensions {
        #region Get DisplayNameAttibute
        public static string GetDisplayName(this object obj, string propertyName) {
            return GetDisplayName(obj.GetType(), propertyName);
        }
        public static string GetDisplayName(this Type type, string propertyName) {
            var property = type.GetProperty(propertyName);
            return GetAttributeDisplayName(property);
        }
        
        public static string GetDisplayName(this object obj) {
            string res = string.Empty;
            if (obj is null)
                return res;
            res = obj.GetType().Name;
            try {
                var attr = obj.GetType().GetCustomAttribute<DisplayNameAttribute>(true);
                return attr.DisplayName;
            }
            catch (Exception e) { }
            return res;
        }

        public static string GetAttributeDisplayName(PropertyInfo property) {
            try {
                var atts = property.GetCustomAttributes(
                    typeof(DisplayNameAttribute), true);
                if (atts.Length == 0)
                    return property.Name;
                return (atts[0] as DisplayNameAttribute).DisplayName;
            }
            catch(Exception e) {

            }
            return property.Name;
        }
        #endregion

        #region Get Name of object
        public static string GetName(this object obj) {
            string res = string.Empty;
            try {
                res = obj.GetType().Name;
            }
            catch { }
            return res;
        }
        public static string GetName(this Type type) {
            string res = string.Empty;
            try {
                res = type.Name;
            }
            catch { }
            return res;
        }
        #endregion
    }
}
