using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.EnemyGroup;

public class EquipTemplate
{
    [JsonPropertyName("cod")]
    public int code { get; set; }

    [JsonPropertyName("wtp")]
    public int weaponType { get; set; }

    [JsonPropertyName("idx")]
    public int index { get; set; }

    [JsonPropertyName("its")]
    public List<int> itemIds { get; set; }
}