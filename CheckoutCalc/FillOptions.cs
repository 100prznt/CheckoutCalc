using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutCalc
{
    public enum FillOptions
    {
        /// <summary>
        /// Disable autofill
        /// </summary>
        Disable = 0,
        /// <summary>
        /// Fill missing fields with lowest rate (1)
        /// </summary>
        LowestRate,
        /// <summary>
        /// Fill missing fields with highest rate (100)
        /// </summary>
        HighestRate,
        /// <summary>
        /// Fill missing fields with average rate of presetted fields
        /// </summary>
        AvarageRate
    }
}
