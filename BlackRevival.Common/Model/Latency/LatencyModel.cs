using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class LatencyModel
{
    [JsonPropertyName("unn")]
    public long userNum  { get;set; }

    [JsonPropertyName("clip")] 
    public string clientIp { get; set; } = "Unknown";

    [JsonPropertyName("osna")]
    public string osName  { get;set; }

    [JsonPropertyName("osve")]
    public string osVersion  { get;set; }

    [JsonPropertyName("devn")]
    public string deviceName { get;set; }

    [JsonPropertyName("isp")]
    public string isp  { get;set; } = "Unknown";

    [JsonPropertyName("seip")]
    public string serverIp { get;set; }

    [JsonPropertyName("ntyp")]
    public string netType { get;set; }

    [JsonPropertyName("isgm")]
    public bool ingame { get;set; }

    [JsonPropertyName("lcod")]
    public string locationCode { get;set; }

    [JsonPropertyName("pimx")]
    public int pingMax { get;set; }

    [JsonPropertyName("pimn")]
    public int pingMin { get;set; }

    [JsonPropertyName("piav")]
    public int pingAvg { get;set; }

    [JsonPropertyName("picn")]
    public int pingCount { get;set; }

    [JsonPropertyName("dicn")]
    public int disconnectCount { get;set; }
}