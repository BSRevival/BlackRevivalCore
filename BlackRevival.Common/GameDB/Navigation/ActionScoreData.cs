using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.Navigation;

public class ActionScoreData
{
    [JsonPropertyName("cod")]
    public int navigatorType { get; set; }

    [JsonPropertyName("asr")]
    public int actionScore { get; set; }
}