using System.Text.Json.Serialization;
using BlackRevival.Common.Model.AcE;

namespace BlackRevival.Common.Model;

public class CharacterSignature
{
    [JsonPropertyName("cc")]
    public int characterClass { get; set; }

    [JsonPropertyName("ats")]
    public AcE_SignatureStateType state { get; set; }

    [JsonPropertyName("att")]
    public AcE_SignatureType type { get; set; }

    [JsonPropertyName("lv")]
    public int level { get; set; }
}