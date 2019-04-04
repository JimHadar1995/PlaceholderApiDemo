using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FrameWork.Enums.ClassEnums {
    public abstract class EnumBaseType<T> where T : EnumBaseType<T> {
        protected static List<T> enumValues = new List<T>();
        public int Id { get; }
        public string Value { get; }
        public string Name { get; }
        public EnumBaseType(int key, string value, string name) {
            Id = key;
            Value = value;
            Name = !string.IsNullOrEmpty(name) ? name : value;
            if (key > 0) {
                if (GetBaseByKey(key) == null) {
                    T searchByValue = GetBaseByValue(value);
                    if (searchByValue == null) {
                        enumValues.Add((T)this);
                    }
                    else {
                        enumValues.Remove(searchByValue);
                        enumValues.Add((T)this); // замена, если надо изменить например key или name
                                                 //throw new Exception("Дубликаты названий! (" + typeof (T).Name + ")");
                    }
                }
                else {
                    throw new Exception("Дубликаты идентификаторов! (" + typeof(T).Name + ")");
                }
            }
            else {
                T searchByValue = GetBaseByValue(value);
                if (searchByValue != null) {
                    enumValues.Remove(searchByValue); // удаление, если надо удалить из списка
                }
            }
        }

        protected static ReadOnlyCollection<T> GetBaseValues() {
            return enumValues.AsReadOnly();
        }
        protected static T GetBaseByKey(int key) {
            foreach (T t in enumValues) {
                if (t.Id == key) return t;
            }
            return null;
        }
        protected static T GetBaseByValue(string value) {
            foreach (T t in enumValues) {
                if (t.Value == value) return t;
            }
            return null;
        }
        public override string ToString() {
            return Value;
        }

        #region implicit operators
        public static implicit operator int(EnumBaseType<T> cType) {
            return cType.Id;
        }
        public static implicit operator EnumBaseType<T>(int id) {
            return GetBaseByKey(id);
        }
        public static implicit operator EnumBaseType<T>(string value) {
            return GetBaseByValue(value);
        }
        #endregion
    }
}
