using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutCalc
{
    /// <summary>
    /// Aufnahme
    /// Beschreibt das Werfen von drei Pfeilen nacheinander auf das Dartboard.
    /// Alternativ ist auch die Bezeichnung „Wurf“ möglich.
    /// Einfacher erklärt: Ein Spieler wirft in einer Aufnahme drei Darts hintereinander auf die Dartscheibe.
    /// Anschließend ist der nächste Spieler mit seinen drei Darts (seiner Aufnahme) an der Reihe.
    /// </summary>
    public class Throw
    {
        public int Score => Darts.Sum(x => x.Score);

        public double Average => Darts.Count() > 0 ? Score / Darts.Count() : 0;

        public List<SingleDart> Darts = new List<SingleDart>();
    }
}
