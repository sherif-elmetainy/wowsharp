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
using System.Globalization;
using System.Linq;

namespace WOWSharp.Core.Serialization
{
    /// <summary>
    ///   Helper class to allow custom parsing of enumeration
    /// </summary>
    /// <typeparam name="T"> The enumeration type </typeparam>
    public static class EnumHelper<T> where T : struct
    {
        /// <summary>
        ///   Caches String -> EnumValue data
        /// </summary>
        private static readonly Dictionary<string, T> StringToEnumDictionary = InitializeStringDict();

        /// <summary>
        ///   Caches EnumValue -> String data
        /// </summary>
        private static readonly Dictionary<T, string> EnumToStringDictionaryDict = InitializeEnumDict();

        /// <summary>
        ///   Initializes String -> EnumValue cache
        /// </summary>
        /// <returns> String -> EnumValue cache </returns>
        private static Dictionary<string, T> InitializeStringDict()
        {
            var dict = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
            var enumType = typeof(T);
            var fields = enumType.GetEnumFields();
            foreach (var field in fields)
            {
                var attr = field.GetEnumMemberAttribute();
                dict.Add(attr.Value, (T)Enum.Parse(enumType, field.Name, true));
            }
            return dict;
        }

        /// <summary>
        ///   Initializes EnumValue -> String cache
        /// </summary>
        /// <returns> EnumValue -> String cache </returns>
        private static Dictionary<T, string> InitializeEnumDict()
        {
            var dict = new Dictionary<T, string>();
            Type enumType = typeof(T);
            var fields = enumType.GetEnumFields();
            foreach (var field in fields)
            {
                var attr = field.GetEnumMemberAttribute();
                dict.Add((T)Enum.Parse(enumType, field.Name, true), attr.Value);
            }
            return dict;
        }

        /// <summary>
        ///   Returns EnumValue from String representation
        /// </summary>
        /// <param name="value"> string value </param>
        /// <returns> Enum value </returns>
        public static T ParseEnum(string value)
        {
            int intVal;
            if (int.TryParse(value, out intVal))
                return EnumToStringDictionaryDict.Keys.FirstOrDefault(k => Convert.ToInt32(k, CultureInfo.InvariantCulture) == intVal);
            T enumValue;
            if (StringToEnumDictionary.TryGetValue(value, out enumValue))
                return enumValue;
            throw new ArgumentOutOfRangeException(nameof(value), $"Enum value '{value}' is invalid for enum type '{typeof(T).Name}'");
        }

        /// <summary>
        ///   Returns string value from Enum value
        /// </summary>
        /// <param name="value"> string value </param>
        /// <returns> String value </returns>
        public static string EnumToString(T value)
        {
            return EnumToStringDictionaryDict[value];
        }

        /// <summary>
        ///   Gets all the names in an enumeration type
        /// </summary>
        /// <returns> </returns>
        /// <remarks>
        ///   Implemented for Silverlight support
        /// </remarks>
        public static string[] GetNames()
        {
            Type enumType = typeof(T);
            var fields = enumType.GetEnumFields();
            return fields.Select(field => field.Name).ToArray();
        }

        /// <summary>
        ///   Gets all the values in an enumeration type
        /// </summary>
        /// <returns> </returns>
        /// <remarks>
        ///   Implemented for Silverlight support
        /// </remarks>
        public static IEnumerable<T> GetValues()
        {
            return GetNames().Select(n => (T)Enum.Parse(typeof(T), n, true));
        }
    }
}