using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.Field;

public class RestrictFieldTime
{
    [JsonPropertyName("stp")]
    public int step { get; set; }

    [JsonPropertyName("ldu")]
    public int lumiaDuration { get; set; }

    [JsonPropertyName("sdu")]
    public int seoulDuration { get; set; }
    
}