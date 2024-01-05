using CheckoutCalc.Board;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutCalc
{
    /// <summary>
    /// List of all fields with there hit rates
    /// </summary>
    public class FieldRates : List<Field>
    {
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
    }
}
