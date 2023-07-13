using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class MiniLeagueEntry
{
    [JsonPropertyName("n")]
    public string nickname { get; set; }

    [JsonPropertyName("p")]
    public int point { get; set; }

    [JsonPropertyName("r")]
    public int rank { get; set; }

    [JsonPropertyName("w")]
    public int winCount { get; set; }
}