using System.Text.Json.Serialization;

namespace BlackRevival.Common.Apis;

public class AcCodexApi
{
    
    public class AcCodexInfo
    {
        [JsonPropertyName("acy")]
        public int accountCreateYear { get; set; }

        [JsonPropertyName("apd")]
        public long accountPeriodDays { get; set; }

        [JsonPropertyName("wkey")]
        public string weatherKey { get; set; }
    }

    public class AcCodexInfoResult
    {
        public AcCodexApi.AcCodexInfo codexInfo { get; set; }
    }
}