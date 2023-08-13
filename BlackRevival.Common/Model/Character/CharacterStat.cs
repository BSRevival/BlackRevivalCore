using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class CharacterStat
{
    [JsonPropertyName("hea")]
    public float health{ get; set; }

    [JsonPropertyName("sta")]
    public float stamina{ get; set; }

    [JsonPropertyName("mht")]
    public float maxHealth{ get; set; }

    [JsonPropertyName("msm")]
    public float maxStamina{ get; set; }

    [JsonPropertyName("off")]
    public float offence{ get; set; }

    [JsonPropertyName("def")]
    public float defence{ get; set; }

    [JsonPropertyName("lvl")]
    public int level{ get; set; }

    [JsonPropertyName("exp")]
    public float exp{ get; set; }

    [JsonPropertyName("gfa")]
    public float gunFamiliarity{ get; set; }

    [JsonPropertyName("bfa")]
    public float bladeFamiliarity{ get; set; }

    [JsonPropertyName("tfa")]
    public float throwFamiliarity{ get; set; }

    [JsonPropertyName("pfa")]
    public float punchFamiliarity{ get; set; }

    [JsonPropertyName("wfa")]
    public float bowFamiliarity{ get; set; }

    [JsonPropertyName("lfa")]
    public float bluntFamiliarity{ get; set; }

    [JsonPropertyName("sfa")]
    public float stabFamiliarity{ get; set; }

    [JsonPropertyName("afy")]
    public float additionalFamiliarity{ get; set; }

    [JsonPropertyName("inch")]
    public float levelUpMaxHealthIncr{ get; set; }

    [JsonPropertyName("incs")]
    public float levelUpMaxStaminaIncr{ get; set; }

    [JsonPropertyName("inca")]
    public float levelUpOffenceIncr{ get; set; }

    [JsonPropertyName("incd")]
    public float levelUpDefenceIncr{ get; set; }
}