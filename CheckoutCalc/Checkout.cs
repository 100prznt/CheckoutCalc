﻿using CheckoutCalc.Board;
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
        Dictionary<int, Throw> m_Throws;
        List<Throw> m_AllThrows;


        public int Score { get; set; }

        public List<Throw> PossibleThrows { get; set; } = new List<Throw>();

        public Checkout(FieldRates ranks)
        {
            m_Rates = ranks;
            m_Fields = m_Rates.GetFieldList(FillOptions.LowestRate);

            CalculateAllThrows();
        }

        public Throw FindWay(int score, Segments checkoutMethode = Segments.Single)
        {
            if (score < 0)
                throw new ArgumentOutOfRangeException($"Checkoutscore ({score}) must be larger then 0.");

            var fittedThrows = new List<Throw>();

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

            if (checkoutMethode == Segments.Undefined)
                fittedThrows = m_AllThrows;
            else
                fittedThrows = m_AllThrows.Where(x => x.Hits.Any(y => y.Segment == checkoutMethode)).ToList();

            var possibleThrows = fittedThrows.Where(x => x.Score == score).ToList();



            throw new NotImplementedException();
        }

        public void CalculateAllThrows()
        {
            var fieldCount = m_Fields.Count;
            m_AllThrows = new List<Throw>();

            for (int x = -1; x < fieldCount; x++)
            {
                var dart1 = new Field();
                if (x >= 0)
                    dart1 = m_Fields[x];
                for (int y = -1; y < fieldCount; y++)
                {
                    var dart2 = new Field();
                    if (y >= 0)
                        dart2 = m_Fields[y];
                    for (int z = -1; z < fieldCount; z++)
                    {
                        var dart3 = new Field();
                        if (z >= 0)
                            dart3 = m_Fields[z];

                        var combination = new Throw();
                        combination.Hits.Add(dart1);
                        combination.Hits.Add(dart2);
                        combination.Hits.Add(dart3);

                        m_AllThrows.Add(combination);
                    }
                }
            }

            m_AllThrows.Sort();

            var fu = m_AllThrows.Max(x => x.Score);
        }
    }
}
