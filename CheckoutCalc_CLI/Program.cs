using CheckoutCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutCalc_CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fu = new DartRanks();

            for (int i = 1; i <= 20;  i++)
            {
                fu.Add(new SingleDart(Segments.Single, i, 50));
                fu.Add(new SingleDart(Segments.Double, i, 25));
                fu.Add(new SingleDart(Segments.Triple, i, 15));
            }
            fu.Add(new SingleDart(Segments.Single, 25, 5));
            fu.Add(new SingleDart(Segments.Double, 25, 0));


            fu.ToJson("out.json");
        }
    }
}
