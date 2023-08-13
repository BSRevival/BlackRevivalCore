using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Character;

public class CharacterDiaryData
{
    [JsonPropertyName("cod")]
    public int code { get; set; }

    [JsonPropertyName("spc")]
    public List<CharacterDairy> characterDiaries { get; set; }

    [JsonPropertyName("siz")]
    public int size { get; set; }
}