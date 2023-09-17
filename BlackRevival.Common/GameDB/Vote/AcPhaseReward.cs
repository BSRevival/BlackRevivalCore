using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.GameDB.Vote;

public class AcPhaseReward
{
    public AcE_VOTE_PHASE_TYPE GetPhaseType()
    {
        return AcEnum.ConvertInt<AcE_VOTE_PHASE_TYPE>(this.phase);
    }

    [JsonPropertyName("ssn")]
    public int season { get; set; }

    [JsonPropertyName("phs")]
    public int phase { get; set; }

    [JsonPropertyName("rnk")]
    public int rank { get; set; }

    [JsonPropertyName("gst")]
    public GoodsType goodsType { get; set; }

    [JsonPropertyName("stp")]
    public string subType { get; set; }

    [JsonPropertyName("amt")]
    public int amount { get; set; }

    [JsonPropertyName("tky")]
    public string textKey { get; set; }
}