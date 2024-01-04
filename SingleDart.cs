using CheckoutCalc.Extensions;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CheckoutCalc
{
    public class SingleDart
    {
        int m_Rank;

        [JsonIgnore]
        public int Score => Bed * (int)Segment;

        [JsonIgnore]
        public int Bed { get; set; }

        [JsonIgnore]
        public Segments Segment { get; set; }

        public string Name
        {
            get
            {
                return Segment.GetPrefix() + Bed.ToString();
            }
            set
            {
                var data = SingleDart.Parse(value);
                Bed = data.Bed;
                Segment = data.Segment;
            }
        }

        /// <summary>
        /// Beliebtheit des Feldes, höchster Wert 62
        /// </summary>
        public int Rank
        {
            get => m_Rank;
            set
            {
                m_Rank = value.Clamp(0, 62);
            }
        }

        public SingleDart()
        {

        }
        public SingleDart(Segments segment, int bed, int rank = 0)
        {
            Segment = segment;
            Bed = bed;
            Rank = rank;
        }

        public SingleDart(string name, int rank)
        {
            Name = name;
            Rank = rank;
        }

        public static SingleDart Parse(string name)
        {
            var result = new SingleDart();

            var segments = Enum.GetValues(typeof(Segments)).Cast<Segments>();
            var prefixes = new Dictionary<string, Segments>();
            foreach (var segment in segments)
            {
                foreach (var prefix in segment.GetPrefixes())
                {
                    prefixes.Add(prefix, segment);
                }
            }


            //string pattern = @"^(?<segment>|S|D|T)(?<bed>\d{1,2})$";
            var pattern = new StringBuilder(@"^(?<prefix>");

            foreach (var prefix in prefixes)
            {
                pattern.Append("|");
                pattern.Append(prefix.Key);
            }
            pattern.Append(@")(?<bed>\d{1,2})$");

            var regex = new Regex(pattern.ToString(), RegexOptions.IgnoreCase);
            var m = regex.Match(name);

            if (m.Success)
            {
                result.Bed = int.Parse(m.Groups["bed"].Value);
                result.Segment = prefixes[m.Groups["prefix"].Value];
            }

            return result;
        }
    }
}
