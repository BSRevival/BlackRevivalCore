using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.ResearcherLevel;

public class ResearcherLevelData
{
    [JsonPropertyName("l")] public int level { get; set; }

    [JsonPropertyName("e")] public int minExp { get; set; }

    [JsonPropertyName("r")] public Goods rewardGoods { get; set; }
}