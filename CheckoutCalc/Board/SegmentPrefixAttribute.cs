using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutCalc.Board
{
    internal class SegmentPrefixAttribute : Attribute
    {
        public string[] Prefixes { get; set; }

        public SegmentPrefixAttribute(params string[] prefix)
        {
            Prefixes = prefix;
        }
    }
}
