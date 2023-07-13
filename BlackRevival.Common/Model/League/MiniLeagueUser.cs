using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;

namespace BlackRevival.Common.Model;

public class MiniLeagueUser
{
    [JsonPropertyName("t")]
    public MiniLeagueTier tier { get; set; }

    [JsonPropertyName("gi")]
    public long? groupId { get; set; }
}