using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class MiniLeague
{
    [JsonPropertyName("u")]
    public MiniLeagueUser leagueUser;

    [JsonPropertyName("g")]
    public MiniLeagueGroup group;

    [JsonPropertyName("m")]
    public MiniLeagueEntry myEntry;

    [JsonPropertyName("e")]
    public List<MiniLeagueEntry> entries;
}