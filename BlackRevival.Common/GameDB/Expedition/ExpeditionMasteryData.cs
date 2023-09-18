using System;
using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;
using BlackRevival.Common.GameDB;

namespace BlackRevival.Common.GameDB.Expedition;


public class ExpeditionMasteryData
{
    public float GetRealStartExp(float exp)
    {
        return Math.Max(0f, exp - this.familiarityExp);
    }

    public float GetExpPercent(float exp)
    {
        float num = ExpeditionMasteryDB.Instance.GetMaxExp(this.weaponType, exp) - this.familiarityExp;
        return Math.Clamp(this.GetRealStartExp(exp) / num, 0f, 1f);
    }

    [JsonPropertyName("cod")]
    public int code { get; set; }

    [JsonPropertyName("wtp")]
    public AcE_WEAPON_TYPE weaponType { get; set; }

    [JsonPropertyName("mgd")]
    public AcE_MASTERY_RANK_TYPE masteryGrade { get; set; }

    [JsonPropertyName("fex")]
    public float familiarityExp { get; set; }

    [JsonPropertyName("cst")]
    public int cost { get; set; }

    [JsonPropertyName("atr")]
    public float attackRatio { get; set; }

    [JsonPropertyName("htr")]
    public float hitRatio { get; set; }
}