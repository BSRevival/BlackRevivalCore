using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.ProductRelated;

public class TicketType
{
    [JsonPropertyName("ep")]
    public int episode { get; set; }

    [JsonPropertyName("t")]
    public string type { get; set; }

    [JsonPropertyName("tex")]
    public string texture { get; set; }
}