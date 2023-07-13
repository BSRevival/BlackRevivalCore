using System.Text.Json.Serialization;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class UpgradeLeagueInfo
{
    [JsonPropertyName("unm")]
    public long userNum{ get; set; }

    [JsonPropertyName("lea")]
    public League league{ get; set; }

    [JsonPropertyName("wn")]
    public bool win{ get; set; }

    [JsonPropertyName("gpf")]
    public int gainPointFirst{ get; set; }

    [JsonPropertyName("gps")]
    public int gainPointSecond{ get; set; }

    [JsonPropertyName("gpt")]
    public int gainPointThird{ get; set; }

    [JsonPropertyName("pc")]
    public int playCount{ get; set; }

    [JsonPropertyName("apc")]
    public int afterPlayCount{ get; set; }

    [JsonPropertyName("sdtm")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime startDtm{ get; set; }

    [JsonPropertyName("edtm")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime endDtm{ get; set; }

    [JsonPropertyName("tgp")]
    public int getTotalGainPoint{ get; set; }

    [JsonPropertyName("eupg")]
    public bool isEndUpgradeLeague{ get; set; }

    [JsonPropertyName("supg")]
    public bool isSuccessUpgrade{ get; set; }
}