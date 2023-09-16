using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Skills;

public class PotentialSkillData
{
    [JsonPropertyName("t")]
    public string type { get; set; }

    [JsonPropertyName("cs")]
    public int characterSpecialty { get; set; }

    [JsonPropertyName("ml")]
    public League minimumLeague { get; set; }

    [JsonPropertyName("bmd")]
    public PlayMode playMode { get; set; }
}