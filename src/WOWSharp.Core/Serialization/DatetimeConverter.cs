// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WOWSharp.Core.Serialization
{
    /// <summary>
    /// Converts a unix time to date and vice versa
    /// </summary>
    public abstract class DatetimeConverter : JsonConverter
    {
        /// <summary>
        ///   Reference date for Unix time
        /// </summary>
        private static readonly DateTime _unixStartDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


        /// <summary>
        /// Whether the timestamp value is in milliseconds
        /// </summary>
        private bool _isMilliseconds;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="isMilliseconds">Whether the timestamp value is in milliseconds</param>
        public DatetimeConverter(bool isMilliseconds)
        {
            _isMilliseconds = isMilliseconds;
        }

        /// <summary>
        /// Whether the converter can convert a type or not
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(long) || objectType == typeof(DateTime);
        }

        /// <summary>
        /// Read the value from Json reader and converts it to datetime
        /// </summary>
        /// <param name="reader">Json reader</param>
        /// <param name="objectType">object type (should always be datetime)</param>
        /// <param name="existingValue">existing value Ignored. (should always be DateTime.MinValue).</param>
        /// <param name="serializer">serializer object (used to read settings)</param>
        /// <returns>Deserialized object</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == null)
                throw new ArgumentNullException("objectType");
            if (reader == null)
                throw new ArgumentNullException("reader");
            if (objectType == typeof(IList<DateTime>) || objectType == typeof(IList<DateTime?>))
            {
                if (reader.TokenType == JsonToken.Null)
                    return null;
                else if (reader.TokenType == JsonToken.StartArray)
                {
                    var elementType = objectType == typeof(IList<DateTime>) ? typeof(DateTime) : typeof(DateTime?);
                    IList list;
                    if (elementType == typeof(DateTime))
                        list = new List<DateTime>();
                    else
                        list = new List<DateTime?>();
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.EndArray)
                            break;
                        list.Add(ReadDateToken(reader, elementType));
                    }
                    return list;
                }
                else
                {
                    throw new ArgumentException($"Expecting token of type '{JsonToken.StartArray}', and found a token of type {reader.TokenType}.");
                }
            }
            else if (objectType != typeof(DateTime) && objectType != typeof(DateTime?))
            {
                throw new ArgumentException($"Cannot convert type '{objectType.FullName}', can only convert {typeof(DateTime).Name} and and {typeof(DateTime?).Name}.");
            }

            return ReadDateToken(reader, objectType);
        }

        /// <summary>
        /// Reads a date token from a JSON reader
        /// </summary>
        /// <param name="reader">json reader</param>
        /// <param name="objectType">object type</param>
        /// <returns>date object</returns>
        private object ReadDateToken(JsonReader reader, Type objectType)
        {
            if (objectType == typeof(DateTime?) && reader.TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType == JsonToken.Date)
            {
                return reader.ReadAsDateTime();
            }
            if (reader.TokenType != JsonToken.Integer)
            {
                throw new ArgumentException($"Expecting token of type '{JsonToken.Integer}', and found a token of type {reader.TokenType}.");
            }
            var value = Convert.ToInt64(reader.Value, CultureInfo.InvariantCulture);
            if (_isMilliseconds)
            {
                return GetUtcDateFromUnixTimeMilliseconds(value);
            }
            else
            {
                return GetUtcDateFromUnixTimeSeconds(value);
            }
        }

        /// <summary>
        /// Writes a value to json stream
        /// </summary>
        /// <param name="writer">json writer</param>
        /// <param name="value">value to write</param>
        /// <param name="serializer">serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            if (value == null)
                writer.WriteNull();
            else if (value is DateTime)
            {
                var date = (DateTime)value;
                if (_isMilliseconds)
                {
                    writer.WriteValue(GetUnixTimeFromDateMilliseconds(date));
                }
                else
                {
                    writer.WriteValue(GetUnixTimeFromDateSeconds(date));
                }
            }
            else if (value is long)
            {
                writer.WriteValue((long)value);
            }
            else
            {
                var dateTimeList = value as IList<DateTime>;
                if (dateTimeList != null)
                {
                    writer.WriteStartArray();
                    foreach (var date in dateTimeList)
                    {
                        if (_isMilliseconds)
                        {
                            writer.WriteValue(GetUnixTimeFromDateMilliseconds(date));
                        }
                        else
                        {
                            writer.WriteValue(GetUnixTimeFromDateSeconds(date));
                        }
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    var nullableDateTimeList = value as IList<DateTime?>;
                    if (nullableDateTimeList != null)
                    {
                        writer.WriteStartArray();
                        foreach (var date in nullableDateTimeList)
                        {
                            if (!date.HasValue)
                                writer.WriteNull();
                            else if (_isMilliseconds)
                            {
                                writer.WriteValue(GetUnixTimeFromDateMilliseconds(date.GetValueOrDefault()));
                            }
                            else
                            {
                                writer.WriteValue(GetUnixTimeFromDateSeconds(date.GetValueOrDefault()));
                            }
                        }
                        writer.WriteEndArray();
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("value", $"Cannot convert type '{value.GetType().FullName}', can only convert {typeof(DateTime).Name} and and {typeof(DateTime?).Name}.");
                    }
                }
            }
        }

        /// <summary>
        ///   Gets the Utc DateTime object from the Unix time returned by the API
        /// </summary>
        /// <param name="value"> time value returned by API </param>
        /// <returns> Utc time object </returns>
        internal static DateTime GetUtcDateFromUnixTimeMilliseconds(long value)
        {
            return _unixStartDate.AddMilliseconds(value);
        }

        /// <summary>
        ///   Gets the Unit time value from the Date time object
        /// </summary>
        /// <param name="date"> date time object </param>
        /// <returns> Unix time value </returns>
        internal static long GetUnixTimeFromDateMilliseconds(DateTime date)
        {
            return (long)Math.Round((date - _unixStartDate).TotalMilliseconds, 0);
        }

        /// <summary>
        ///   Gets the Utc DateTime object from the Unix time returned by the API
        /// </summary>
        /// <param name="value"> time value returned by API </param>
        /// <returns> Utc time object </returns>
        internal static DateTime GetUtcDateFromUnixTimeSeconds(long value)
        {
            return _unixStartDate.AddSeconds(value);
        }

        /// <summary>
        ///   Gets the Unit time value from the Date time object
        /// </summary>
        /// <param name="date"> date time object </param>
        /// <returns> Unix time value </returns>
        internal static long GetUnixTimeFromDateSeconds(DateTime date)
        {
            return (long)Math.Round((date - _unixStartDate).TotalSeconds, 0);
        }
    }
}
