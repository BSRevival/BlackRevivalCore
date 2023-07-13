using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;

namespace BlackRevival.Common.Model;

public class MiniLeagueGroup
{
    [JsonPropertyName("c")]
    public int memberCount { get; set; }

    [JsonPropertyName("t")]
    public MiniLeagueTier tier { get; set; }

    [JsonPropertyName("e")]
    public long? expireDtm { get; set; }
}