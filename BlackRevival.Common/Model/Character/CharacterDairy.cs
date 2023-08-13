using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class CharacterDairy
{
    [JsonPropertyName("csc")]
    public int characterClass { get; set; }

    [JsonPropertyName("d")]
    public int diary { get; set; }

    [JsonPropertyName("dt")]
    public int researcherDairyType { get; set; }

    [JsonPropertyName("ot")]
    public int objectType { get; set; }

    [JsonPropertyName("od")]
    public int objectData { get; set; }

    [JsonPropertyName("f")]
    public int factor { get; set; }

    public enum DiaryActionType
    {
        NONE,
        WOUND,
        MAKE,
        DAMAGE,
        HUNT,
        WEAPON_BROKEN,
        FIND,
        USE,
        GET,
        USE_SKILL,
        WEAPON_HALF_BROKEN,
        ACTIVE_EFFECT
    }

    public enum DiaryTargetType
    {
        NONE,
        CHARACTER,
        MONSTER,
        ITEM,
        USER,
        RECOVER,
        SKILL
    }
}