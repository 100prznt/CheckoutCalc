using CheckoutCalc.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutCalc
{
    public class Checkout
    {
        FieldRates m_Rates;
        FieldRates m_Fields; //m_Rates => checked and filled 


        public int Score { get; set; }

        public List<Throw> PossibleThrows { get; set; } = new List<Throw>();

        public Checkout(FieldRates ranks)
        {
            m_Rates = ranks;
            m_Fields = m_Rates.GetFieldList(FillOptions.LowestRate);
        }

        public Throw FindWay(int score, Segments checkoutMethode = Segments.Single)
        {
            if (score < 0)
                throw new ArgumentOutOfRangeException($"Checkoutscore ({score}) must be larger then 0.");

            switch (checkoutMethode)
            {
                case Segments.Single:
                    if (score > 145)
                        throw new ArgumentOutOfRangeException($"Score {score} to high for a checkout with {checkoutMethode}.");
                    break;
                case Segments.Double:
                    if (score > 170)
                        throw new ArgumentOutOfRangeException($"Score {score} to high for a checkout with {checkoutMethode}.");
                    break;
                default:
                    if (score > 180)
                        throw new ArgumentOutOfRangeException($"Score {score} to high for a checkout with {checkoutMethode}.");
                    break;
            }

            throw new NotImplementedException();
        }
    }
}
