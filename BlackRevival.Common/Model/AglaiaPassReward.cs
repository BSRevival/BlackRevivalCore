using System.Text.Json.Serialization;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class AglaiaPassReward
{
    [JsonPropertyName("un")]
    public long userNum { get; set; }

    [JsonPropertyName("ep")]
    public int episode { get; set; }

    [JsonPropertyName("st")]
    public int step { get; set; }

    [JsonPropertyName("pa")]
    public bool paid { get; set; }

    [JsonPropertyName("re")]
    public bool rewarded { get; set; }

    [JsonPropertyName("cd")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime createDtm { get; set; }

    [JsonPropertyName("rs")]
    public CharacterSkin rewardSkin { get; set; }
}