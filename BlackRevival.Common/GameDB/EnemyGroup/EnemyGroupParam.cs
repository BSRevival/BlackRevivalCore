using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.EnemyGroup;

public class EnemyGroupParam
{
    [JsonPropertyName("uc")]
    public int unitClass { get; set; }

    [JsonPropertyName("ug")]
    public int unitGrade { get; set; }

    [JsonPropertyName("ar")]
    public float appearRatio { get; set; }
}