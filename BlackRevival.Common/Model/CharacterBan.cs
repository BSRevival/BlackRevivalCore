using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class CharacterBan
{
    [JsonPropertyName("bml")]
    public List<int> battleModeList{ get; set; }

    [JsonPropertyName("cls")]
    public int characterClass{ get; set; }

    [JsonPropertyName("bdtm")]
    public long beginDtm{ get; set; }

    [JsonPropertyName("edtm")]
    public long endDtm { get; set; }
}