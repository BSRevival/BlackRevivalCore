using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class LatencyHttpModel : LatencyModel
{
    [JsonPropertyName("hlamx")]
    public int httpLatencyMax { get;set; }

    [JsonPropertyName("hlamn")]
    public int httpLatencyMin { get;set; }

    [JsonPropertyName("hlaav")]
    public int httpLatencyAvg { get;set; }

    [JsonPropertyName("hlacn")]
    public int httpLatencyCount { get;set; }
}