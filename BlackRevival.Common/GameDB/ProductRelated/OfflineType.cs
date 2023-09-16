using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.ProductRelated;

public class OfflineType
{
    [JsonPropertyName("c")]
    public int code { get; set; }

    [JsonPropertyName("t")]
    public string type { get; set; }

    [JsonPropertyName("tex")]
    public string texture { get; set; }
}