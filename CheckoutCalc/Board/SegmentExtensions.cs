using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutCalc.Board
{
    public static class SegmentExtension
    {
        public static string[] GetPrefixes(this Segments segment)
        {
            var fi = segment.GetType().GetField(segment.ToString());

            foreach (var attr in fi.GetCustomAttributes(false))
                if (attr is SegmentPrefixAttribute selectedAttr)
                    return selectedAttr.Prefixes;

            return new string[0];
        }

        public static string GetPrefix(this Segments segment)
        {
            var prefixes = GetPrefixes(segment);

            if (prefixes != null && prefixes.Length > 0)
                return prefixes[0];
            else
                return string.Empty;
        }
    }
}
