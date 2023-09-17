using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.Sns;

public class SnsLink
{
    [JsonPropertyName("plf")]
    public string platform { get; set; }

    [JsonPropertyName("lan")]
    public string language { get; set; }

    [JsonPropertyName("lnk")]
    public string link { get; set; }
    
}