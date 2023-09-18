using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Expedition;


public class ExpeditionUnitData
{
    [JsonPropertyName("uc")]
    public int unitClass { get; set; }

    [JsonPropertyName("ug")]
    public int unitGrade { get; set; }

    [JsonPropertyName("ext")]
    public int expeditionType { get; set; }

    [JsonPropertyName("cdl")]
    public List<int> cardIdList { get; set; }

    [JsonPropertyName("ht")]
    public float health { get; set; }

    [JsonPropertyName("st")]
    public float stamina { get; set; }

    [JsonPropertyName("of")]
    public float offence { get; set; }

    [JsonPropertyName("df")]
    public float defence { get; set; }

    [JsonPropertyName("iht")]
    public float incrHealth { get; set; }

    [JsonPropertyName("ist")]
    public float incrStamina { get; set; }

    [JsonPropertyName("iof")]
    public float incrOffence { get; set; }

    [JsonPropertyName("idf")]
    public float incrDefence { get; set; }

    [JsonPropertyName("mr")]
    public List<int> mastery { get; set; }

    [JsonPropertyName("kxp")]
    public int killExp { get; set; }

    [JsonPropertyName("stn")]
    public float searchTimeNormal { get; set; }

    [JsonPropertyName("stf")]
    public float searchTimeFast { get; set; }

    [JsonPropertyName("nl")]
    public int noiseLevel { get; set; }

    [JsonPropertyName("pab")]
    public bool playable { get; set; }

    [JsonPropertyName("bst")]
    public int bossSkinType { get; set; }
}