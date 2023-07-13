using System.Text.Json.Serialization;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class UserCollection
{
    [JsonPropertyName("unm")]
    public long userNum{ get; set; }

    [JsonPropertyName("scd")]
    public int collection{ get; set; }

    [JsonPropertyName("vl")]
    public int value{ get; set; }

    [JsonPropertyName("rwd")]
    public bool rewarded{ get; set; }

    [JsonPropertyName("cdtm")]
    public long createDtm{ get; set; }

    [JsonPropertyName("udtm")]
    public long updateDtm{ get; set; }

    [JsonPropertyName("rdtm")]
    public long rewardDtm{ get; set; }
}