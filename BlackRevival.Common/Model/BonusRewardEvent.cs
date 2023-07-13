using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class BonusRewardEvent
{
    [JsonPropertyName("ty")]
    public BonusRewardEventType type{ get; set; }

    [JsonPropertyName("tg")]
    public BonusRewardEventTarget target{ get; set; }

    [JsonPropertyName("r")]
    public int bonusRate{ get; set; }

    [JsonPropertyName("bd")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime beginDtm{ get; set; }

    [JsonPropertyName("ed")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime endDtm{ get; set; }
}