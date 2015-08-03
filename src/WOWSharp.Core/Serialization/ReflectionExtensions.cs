#region LICENSE
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
using System.Reflection;
using System.Linq;

namespace WOWSharp.Core.Serialization
{
    public static class ReflectionExtensions
    {
        public static bool IsEnumeration(this Type type)
        {
#if DOTNET || DNXCORE50
            return type.GetTypeInfo().IsEnum;
#else
            return type.IsEnum;
            
#endif
        }

        public static bool IsGeneric(this Type type)
        {
#if DOTNET || DNXCORE50
            return type.GetTypeInfo().IsGenericType;
#else
            return type.IsGenericType;
            
#endif
        }

        public static bool IsNullable(this Type type)
        {
            return type.IsGeneric() && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        internal static IEnumerable<FieldInfo> GetEnumFields(this Type enumType)
        {
#if DOTNET
            return enumType.GetTypeInfo().DeclaredFields.Where(f => f.IsLiteral);
#else
            return enumType.GetFields().Where(f => f.IsLiteral);
#endif

        }

        internal static EnumMemberAttribute GetEnumMemberAttribute(this FieldInfo fieldInfo)
        {
            var attrs = fieldInfo.GetCustomAttributes(true);
            if (attrs == null)
                return null;
            return attrs.OfType<EnumMemberAttribute>().FirstOrDefault();
        }

#if DOTNET
        internal static bool IsAssignableFrom(this Type type, Type other)
        {
            return type.GetTypeInfo().IsAssignableFrom(other.GetTypeInfo());
        }
#endif
    }
}
