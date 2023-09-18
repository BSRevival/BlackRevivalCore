using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Expedition;


public class ExpeditionEventData
{
    [JsonPropertyName("cod")]
    public int code { get; set; }

    [JsonPropertyName("eid")]
    public int id { get; set; }

    [JsonPropertyName("etp")]
    public int eventType { get; set; }

    [JsonPropertyName("esp1")]
    public string subParam1 { get; set; }

    [JsonPropertyName("esp2")]
    public string subParam2 { get; set; }
}