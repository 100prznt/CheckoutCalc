using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutCalc
{
    public class Checkout
    {
        public int Score { get; set; }

        public List<Throw> PossibleThrows { get; set; } = new List<Throw>();
    }
}
