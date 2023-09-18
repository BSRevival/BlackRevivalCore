using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Expedition;

public class ExpeditionSkillData
{
    [JsonPropertyName("sid")]
    public int expeditionSkillId { get; set; }

    [JsonPropertyName("sgid")]
    public int skillGroupId { get; set; }

    [JsonPropertyName("scpl")]
    public List<SkillConditionParam> skillConditionParamList { get; set; }

    [JsonPropertyName("ett")]
    public int expeditionTargetType { get; set; }

    [JsonPropertyName("est")]
    public int skillType { get; set; }

    [JsonPropertyName("sst")]
    public int skillSubType { get; set; }

    [JsonPropertyName("ess")]
    public int skillStep { get; set; }

    [JsonPropertyName("tpr")]
    public float targetParam { get; set; }

    [JsonPropertyName("lvl")]
    public int level { get; set; }

    [JsonPropertyName("evl")]
    public float effectValue { get; set; }

    [JsonPropertyName("efvl")]
    public float effectValue2 { get; set; }

    [JsonPropertyName("sp1")]
    public string subParam1 { get; set; }

    [JsonPropertyName("sp2")]
    public string subParam2 { get; set; }

    [JsonPropertyName("dur")]
    public int duration { get; set; }

    [JsonPropertyName("stt")]
    public int stackType { get; set; }

    [JsonPropertyName("mst")]
    public int maxStack { get; set; }

    [JsonPropertyName("ist")]
    public int initialStack { get; set; }

    [JsonPropertyName("ast")]
    public int additionStack { get; set; }
}