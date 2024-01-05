using CheckoutCalc.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CheckoutCalc.Board
{
    /// <summary>
    /// Specifies a single field on the board, including its hit rate.
    /// </summary>
    [DebuggerDisplay("{Name, nq}: {HitRate})")]
    public class Field
    {
        #region Members
        int m_HitRate;

        #endregion Members

        #region Properties
        /// <summary>
        /// Calculated score
        /// </summary>
        [JsonIgnore]
        public int Score => Bed * (int)Segment;

        /// <summary>
        /// Bed, 1 - 20 or 25
        /// </summary>
        [JsonIgnore]
        public int Bed { get; set; }

        /// <summary>
        /// Segment, S, D or T
        /// </summary>
        [JsonIgnore]
        public Segments Segment { get; set; }

        /// <summary>
        /// Short name
        /// (e.g. D20, T18, etc.)
        /// </summary>
        public string Name
        {
            get
            {
                return Segment.GetPrefix() + Bed.ToString();
            }
            set
            {
                var data = Field.Parse(value);
                Bed = data.Bed;
                Segment = data.Segment;
            }
        }

        /// <summary>
        /// The hit rate of this field.
        /// 1:   Field is hit once in 100 attempts.
        /// 100: Field is hit 100 times in 100 attempts.
        /// </summary>
        public int HitRate
        {
            get => m_HitRate;
            set
            {
                m_HitRate = value.Clamp(1, 100);
            }
        }

        #endregion Properties

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Field()
        {

        }

        public Field(Segments segment, int bed, int hitRate = 0)
        {
            Segment = segment;
            Bed = bed;
            HitRate = hitRate;
        }

        public Field(string name, int hitRate)
        {
            Name = name;
            HitRate = hitRate;
        }

        #endregion Constructors

        #region Public services
        public static Field Parse(string name)
        {
            var result = new Field();

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

        #endregion Public services
    }
}
