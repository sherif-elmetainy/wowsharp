﻿#region LICENSE
// Copyright (C) 2015 by Sherif Elmetainy (Grendiser@Kazzak-EU)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;

namespace WOWSharp.Core.Serialization
{
    public static class EnumHelper
    {
        private static readonly Dictionary<Type, Dictionary<string, object>> StringToEnumDictionaryDict = new Dictionary<Type, Dictionary<string, object>>();
        private static readonly Dictionary<Type, Dictionary<object, string>> EnumToStringDictionary = new Dictionary<Type, Dictionary<object, string>>();

        

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
            lock(StringToEnumDictionaryDict)
            {
                Dictionary<string, object> dict;
                if (!StringToEnumDictionaryDict.TryGetValue(enumType, out dict))
                {
                    dict = InitializeStringDict(enumType);
                    StringToEnumDictionaryDict.Add(enumType, dict);
                }
                return dict;
            }
        }

        private static Dictionary<object, string> GetEnumDict(Type enumType)
        {
            lock (EnumToStringDictionary)
            {
                Dictionary<object, string> dict;
                if (!EnumToStringDictionary.TryGetValue(enumType, out dict))
                {
                    dict = InitializeEnumDict(enumType);
                    EnumToStringDictionary.Add(enumType, dict);
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
