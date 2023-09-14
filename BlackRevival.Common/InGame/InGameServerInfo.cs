using System.Text.Json.Serialization;

namespace BlackRevival.Common.InGame;

public class InGameServerInfo
{
    [JsonPropertyName("a")]
    public string address { get; set; }

    [JsonPropertyName("t")]
    public  string battleSeatKey { get; set; }

    [JsonPropertyName("rk")]
    public string roomKey { get; set; }
}