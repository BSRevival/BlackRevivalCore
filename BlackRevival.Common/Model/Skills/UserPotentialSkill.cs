using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class UserPotentialSkill
{
    [JsonPropertyName("si")]
    public int skillId { get; set; }

    [JsonPropertyName("rt")]
    public long remainTime  { get; set; }

    [JsonPropertyName("fi")]
    public bool freeItem { get; set; }

    [JsonPropertyName("bmd")]
    public int getBattleMode { get; set; }

    [JsonIgnore]
    private long _expiredTime { get; set; }
}