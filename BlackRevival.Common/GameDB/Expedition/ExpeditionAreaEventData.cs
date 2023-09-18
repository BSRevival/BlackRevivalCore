using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Expedition;


public class ExpeditionAreaEventData
{
    [JsonPropertyName("eid")]
    public int id { get; set; }

    [JsonPropertyName("eet")]
    public int eventType { get; set; }

    [JsonPropertyName("esp1")]
    public string subParam1 { get; set; }

    [JsonPropertyName("esp2")]
    public string subParam2 { get; set; }

    [JsonPropertyName("erpc")]
    public int repeatCount { get; set; }

    [JsonPropertyName("emnd")]
    public int minDistance { get; set; }

    [JsonPropertyName("emxd")]
    public int maxDistance { get; set; }
}