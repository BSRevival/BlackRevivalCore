using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;

namespace BlackRevival.Common.GameDB.Signature;

public class SignatureOptionData
{
    [JsonPropertyName("caot")]
    public AcE_SignatureOptionType type { get; set; }

    [JsonPropertyName("val")]
    public decimal value { get; set; }
}