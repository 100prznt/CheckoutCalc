using CheckoutCalc.Board;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutCalc
{
    /// <summary>
    /// Specifies a throw, wich contains three darts thrown in a series.
    /// </summary>
    [DebuggerDisplay("{Score} (AVG = {Average} RATE = {Rate})")]
    public class Throw : IComparable<Throw>
    {
        /// <summary>
        /// Calcualted score
        /// </summary>
        public int Score => Hits.Sum(x => x.Score);

        /// <summary>
        /// Calculated average
        /// </summary>
        public double Average => Hits.Count() > 0 ? Hits.Average(x => x.Score) : 0;

        /// <summary>
        /// Calculated rate sum
        /// </summary>
        public double Rate => Hits.Sum(x => x.HitRate);

        /// <summary>
        /// Hit fields
        /// </summary>
        public List<Field> Hits = new List<Field>();

        public int CompareTo(Throw other)
        {
            return this.Score.CompareTo(other.Score);
        }
    }
}
