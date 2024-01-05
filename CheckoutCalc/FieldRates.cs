using CheckoutCalc.Board;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutCalc
{
    /// <summary>
    /// List of all fields with there hit rates
    /// </summary>
    public class FieldRates : List<Field>
    {
        #region Properties
        /// <summary>
        /// Contains only one entrie for each field.
        /// </summary>
        public bool IsConsistent => this.Select(x => x.Name).Distinct().Count() == this.Count;

        #endregion Properties

        #region Constructors
        public FieldRates()
        {

        }

        public FieldRates(ICollection<Field> rates)
        {
            this.Clear();
            this.AddRange(rates);
        }
        
        #endregion Constructors

        #region Public services
        public FieldRates GetFieldList(FillOptions mode)
        {
            if (!IsConsistent)
                throw new ArgumentException("Field rate list is not consistent (more than one entrie for one or more fields found).");
        
            if (this.Count == 62)
                return this;

            double defaultRate = 0;
            switch (mode)
            {
                case FillOptions.Disable:
                    return this;
                case FillOptions.LowestRate:
                    defaultRate = 1;
                    break;
                case FillOptions.HighestRate:
                    defaultRate = 100;
                    break;
                case FillOptions.AvarageRate:
                    defaultRate = this.Average(x => x.HitRate);
                    break;
            }

            var fields = new List<Field>();
            for (int i = 1; i <= 20; i++)
            {
                fields.Add(new Field(Segments.Single, i, defaultRate));
                fields.Add(new Field(Segments.Double, i, defaultRate));
                fields.Add(new Field(Segments.Triple, i, defaultRate));
            }
            fields.Add(new Field(Segments.Single, 25, defaultRate));
            fields.Add(new Field(Segments.Double, 25, defaultRate));

            foreach (var rate in this)
            {
                var i = fields.FindIndex(x => x.Name == rate.Name);

                if (i != -1)
                    fields[i] = rate;
            }

            return new FieldRates(fields);
        }

        /// <summary>
        /// Serialize the list to a json file.
        /// </summary>
        /// <param name="path">Path to json file</param>
        public void ToJson(string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (var sw = new StreamWriter(path))
            using (var writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, this);
            }
        }

        /// <summary>
        /// Deserialize the list from a json file.
        /// </summary>
        /// <param name="path">Path to json file</param>
        /// <returns>Deserialized object</returns>
        public static FieldRates FromJson(string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (var sr = new StreamReader(path))
            using (var reader = new JsonTextReader(sr))
            {
                return serializer.Deserialize<FieldRates>(reader);
            }
        }

        #endregion Public services

    }
}
