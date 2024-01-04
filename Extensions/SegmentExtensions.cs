using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutCalc.Extensions
{
    public static class SegmentExtension
    {
        public static string[] GetPrefixes(this Segments segment)
        {
            return GetAttribute<SegmentPrefixAttribute>(segment).Prefixes;
        }

        public static string GetPrefix(this Segments segment)
        {
            var prefixes = GetAttribute<SegmentPrefixAttribute>(segment).Prefixes;

            if (prefixes != null && prefixes.Length > 0)
                return prefixes[0];
            else
                return string.Empty;

        }

        internal static T GetAttribute<T>(Segments unit) where T : Attribute
        {
            var fi = unit.GetType().GetField(unit.ToString());

            foreach (var attr in fi.GetCustomAttributes(false))
                if (attr is T selectedAttr)
                    return selectedAttr;

            return null;
        }
    }
}
