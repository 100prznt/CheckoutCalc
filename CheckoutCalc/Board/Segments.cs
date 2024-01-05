using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutCalc.Board
{
    public enum Segments
    {
        Undefined = 0,
        [SegmentPrefix("", "S")]
        Single = 1,
        [SegmentPrefix("D")]
        Double = 2,
        [SegmentPrefix("T")]
        Triple = 3
    }
}
