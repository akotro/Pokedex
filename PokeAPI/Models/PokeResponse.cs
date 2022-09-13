using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokeAPI.Models
{
    public class PokeResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("next")]
        public string? Next { get; set; }
        [JsonProperty("previous")]
        public string? Previous { get; set; }
        [JsonProperty("results")]
        public List<object>? Results { get; set; }
    }
}
