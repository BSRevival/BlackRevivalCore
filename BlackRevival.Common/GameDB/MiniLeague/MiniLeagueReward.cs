using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.MiniLeague;

public class MiniLeagueReward
{
    public bool IsInnerRank(int rank)
    {
        return this.startRank <= rank && this.endRank >= rank;
    }
    
    [JsonPropertyName("t")]
    public MiniLeagueTier tier { get; set; }
    
    [JsonPropertyName("sr")]
    public int startRank { get; set; }
    
    [JsonPropertyName("er")]
    public int endRank { get; set; }

    [JsonPropertyName("r")] 
    public Goods rewardGoods { get; set; }
}
