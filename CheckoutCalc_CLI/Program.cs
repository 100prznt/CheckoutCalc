using CheckoutCalc;
using CheckoutCalc.Board;
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
            var rates = new FieldRates();

            for (int i = 1; i <= 20; i++)
            {
                rates.Add(new Field(Segments.Single, i, 70));
                rates.Add(new Field(Segments.Double, i, 30));
                rates.Add(new Field(Segments.Triple, i, 20));
            }
            rates.Add(new Field(Segments.Single, 25, 10));
            rates.Add(new Field(Segments.Double, 25, 5));


            rates.ToJson("../../../personal_rates.json");

            var fu = FieldRates.FromJson("../../../personal_rates.json");

            var co = new Checkout(fu);

            co.CalculateAllThrows();
        }
    }
}
