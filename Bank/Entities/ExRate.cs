using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bank.Entities
{
    public class ExRate
    {
        [JsonProperty("name_rus")]
        public string Name { get; set; }
        [JsonProperty("kod")]
        public string Code { get; set; }
        [JsonProperty("sootnowenie")]
        public int Ratio { get; set; }
        [JsonProperty("kurs")]
        public decimal Exchange { get; set; }
    }
}
