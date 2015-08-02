#if !NOTNULL
using System;

namespace Microsoft.Framework.Internal
{
    [AttributeUsage(AttributeTargets.Parameter)]
    internal class NotNullAttribute : Attribute
    {
    }
}
#endif
