using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Aglaia;

public class AglaiaPassData
{
    [JsonPropertyName("ep")]
    public  int episode { get; set; }

    [JsonPropertyName("st")]
    public  int step { get; set; }

    [JsonPropertyName("pt")]
    public  int point { get; set; }

    [JsonPropertyName("pa")]
    public  bool paid { get; set; }

    [JsonPropertyName("gs")]
    public  Goods goods { get; set; }

    [JsonPropertyName("epn")]
    public  string date { get; set; }
}