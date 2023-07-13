using System.Text.Json.Serialization;

namespace BlackRevival.Common.Apis;

public class PerkApi
{
    public class PerkPreset
    {
        [JsonPropertyName("default")]
        public bool isDefault { get; set; }
        
        [JsonPropertyName("pnm")]
        public long num{ get; set; }

        [JsonPropertyName("unm")]
        public long userNum{ get; set; }

        [JsonPropertyName("pnn")]
        public string name{ get; set; }

        [JsonPropertyName("cat")]
        public int category{ get; set; }

        [JsonPropertyName("fst")]
        public int baseFirst{ get; set; }

        [JsonPropertyName("snd")]
        public int baseSecond{ get; set; }

        [JsonPropertyName("act")]
        public bool activated{ get; set; }
    }
}