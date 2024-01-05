using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutCalc
{
    public class Checkout
    {
        FieldRates m_Ranks;

        public int Score { get; set; }

        public List<Throw> PossibleThrows { get; set; } = new List<Throw>();

        public Checkout(FieldRates ranks)
        {
            m_Ranks = ranks;
        }
    }
}
