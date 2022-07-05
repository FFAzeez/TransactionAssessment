using CalculatorAssessment.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAssessment.BusinessLogic
{
    public class ReadFromJson
    {
        private readonly static string json = "..\\..\\..\\DB\\fees.config.json";
        public static async Task<ListOfFees> FetchFees()
        {
            var readText = await File.ReadAllTextAsync(json);
            var serializer = new JsonSerializer();
            using var stringReader = new StringReader(readText);
            using (var jsonReader = new JsonTextReader(stringReader))
            {
                jsonReader.SupportMultipleContent = true;
                ListOfFees result = serializer.Deserialize<ListOfFees>(jsonReader);
               
                return result;
            }
        }
    }
}
