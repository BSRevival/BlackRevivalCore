using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.Battle;

public class CharacterStanceData
{
    [JsonPropertyName("sst")]
    public int stanceType { get; set; }

    [JsonPropertyName("ofr")]
    public float offenceRate { get; set; }

    [JsonPropertyName("dfr")]
    public float deffenceRate { get; set; }

    [JsonPropertyName("fer")]
    public float findEnemyRate { get; set; }

    [JsonPropertyName("bfr")]
    public float befindEnemyRate { get; set; }

    [JsonPropertyName("ifr")]
    public float itemFindRate { get; set; }
}