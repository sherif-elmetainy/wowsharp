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
#if !DOTNET
            return type.IsEnum;
#else
            return type.GetTypeInfo().IsEnum;
#endif
        }

        public static bool IsGeneric(this Type type)
        {
#if !DOTNET
            return type.IsGenericType;
#else
            return type.GetTypeInfo().IsGenericType;
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
    }
}
