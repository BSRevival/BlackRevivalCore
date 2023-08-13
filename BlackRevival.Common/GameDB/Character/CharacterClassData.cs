using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Character;

public class CharacterClassData
{
    [JsonPropertyName("cod")]
    public int characterNum{ get; set; }

    [JsonPropertyName("cta")]
    public List<CharacterStat> ability{ get; set; }

    [JsonPropertyName("dcs")]
    public int defaultSkinCode{ get; set; }

    [JsonPropertyName("acs")]
    public List<int> skins{ get; set; }

    [JsonPropertyName("skil")]
    public List<int> skills{ get; set; }

    [JsonPropertyName("ist")]
    public int strategyType{ get; set; }

    [JsonPropertyName("rmt")]
    public List<AcE_WEAPON_TYPE> randomMasteryType{ get; set; }

}