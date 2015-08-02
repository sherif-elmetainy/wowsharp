using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOWSharp.Core.Serialization
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumMemberAttribute : Attribute
    {
        public string Value { get; set; }
    }
}
