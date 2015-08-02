using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WOWSharp.Core.Serialization
{
    public static class EnumHelper
    {
        private static readonly Dictionary<Type, Dictionary<string, object>> _stringDict = new Dictionary<Type, Dictionary<string, object>>();
        private static readonly Dictionary<Type, Dictionary<object, string>> _enumDict = new Dictionary<Type, Dictionary<object, string>>();

        

        /// <summary>
        ///   Initializes String -> EnumValue cache
        /// </summary>
        /// <returns> String -> EnumValue cache </returns>
        private static Dictionary<string, object> InitializeStringDict(Type enumType)
        {
            var dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            var fields = enumType.GetEnumFields();
            foreach (var field in fields)
            {
                var attr = field.GetEnumMemberAttribute();
                dict.Add(attr.Value, Enum.Parse(enumType, field.Name, true));
            }
            return dict;
        }

        /// <summary>
        ///   Initializes EnumValue -> String cache
        /// </summary>
        /// <returns> EnumValue -> String cache </returns>
        private static Dictionary<object, string> InitializeEnumDict(Type enumType)
        {
            var dict = new Dictionary<object, string>();
            var fields = enumType.GetEnumFields();
            foreach (var field in fields)
            {
                var attr = field.GetEnumMemberAttribute();
                dict.Add(Enum.Parse(enumType, field.Name, true), attr.Value);
            }
            return dict;
        }

        

        private static Dictionary<string, object> GetStringDict(Type enumType)
        {
            lock(_stringDict)
            {
                Dictionary<string, object> dict;
                if (!_stringDict.TryGetValue(enumType, out dict))
                {
                    dict = InitializeStringDict(enumType);
                    _stringDict.Add(enumType, dict);
                }
                return dict;
            }
        }

        private static Dictionary<object, string> GetEnumDict(Type enumType)
        {
            lock (_enumDict)
            {
                Dictionary<object, string> dict;
                if (!_enumDict.TryGetValue(enumType, out dict))
                {
                    dict = InitializeEnumDict(enumType);
                    _enumDict.Add(enumType, dict);
                }
                return dict;
            }
        }

        public static string EnumToString(object value)
        {
            if (value == null)
                return null;
            var type = value.GetType();
            if (!type.IsEnumeration())
                throw new ArgumentException($"Argument {value} is of type {type.FullName} which is not an enum type.", nameof(value));
            var dict = GetEnumDict(type);
            string result;
            if (!dict.TryGetValue(value, out result))
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Cannot find a string value for enum value {value} of type {type.FullName}.");
            }
            return result;
        }

        public static object StringToEnum(Type enumType, string stringValue)
        {
            if (enumType == null)
                throw new ArgumentNullException(nameof(enumType));
            if (!enumType.IsEnumeration())
                throw new ArgumentException($"The type {enumType.FullName} which is not an enum type.", nameof(enumType));
            if (string.IsNullOrEmpty(stringValue))
                return null;
            var dict = GetStringDict(enumType);
            object result;
            if (!dict.TryGetValue(stringValue, out result))
            {
                throw new ArgumentOutOfRangeException(nameof(stringValue), $"Cannot find a enum value for string value {stringValue} of type {enumType.FullName}.");
            }
            return result;
        }
    }
}
