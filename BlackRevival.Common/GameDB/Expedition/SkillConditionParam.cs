using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Expedition;


public class SkillConditionParam
{
    [JsonPropertyName("esc")]
    public int stepCondition { get; set; }

    [JsonPropertyName("sct")]
    public int conditionTargetType { get; set; }

    [JsonPropertyName("cpr")]
    public float conditionParam { get; set; }
}