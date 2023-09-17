using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.EnemyGroup;

public class EnemyGroupData
{
    [JsonPropertyName("cod")]
    public int code { get; set; }

    [JsonPropertyName("egl")]
    public List<EnemyGroupParam> enemyGroupList { get; set; }
}