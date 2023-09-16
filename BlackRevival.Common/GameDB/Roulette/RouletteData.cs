using System.Text.Json.Serialization;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.GameDB.Roulette;

public class RouletteData
{
    [JsonPropertyName("t")]
    public string type { get; set; }

    [JsonPropertyName("ad")]
    public bool isSeasonGotcha { get; set; }

    [JsonPropertyName("sd")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime startDtm { get; set; }

    [JsonPropertyName("ed")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime endDtm { get; set; }

    [JsonPropertyName("pmf")]
    public List<RoulettePmf> pmf { get; set; }
}