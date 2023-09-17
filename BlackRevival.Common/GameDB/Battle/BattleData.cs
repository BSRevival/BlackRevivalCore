using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.Battle;

public class BattleData
{
    [JsonPropertyName("sts")]
    public List<CharacterStanceData> stances { get; set; }

    [JsonPropertyName("mts")]
    public List<CharacterMasteryRankData> masteryRanks { get; set; }
}