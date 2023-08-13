using System.Text.Json.Serialization;
using BlackRevival.Common.Model.AcE;

namespace BlackRevival.Common.GameDB.Signature;

public class SignatureData
{
    [JsonPropertyName("cod")]
    public int code{ get; set; }

    [JsonPropertyName("cc")]
    public int characterClass{ get; set; }

    [JsonPropertyName("ats")]
    public AcE_SignatureStateType signatureStateType{ get; set; }

    [JsonPropertyName("att")]
    public AcE_SignatureType signatureType{ get; set; }

    [JsonPropertyName("atol")]
    public List<SignatureOptionData> signatureOptionList{ get; set; }

    [JsonPropertyName("rst")]
    public List<string> rewardSubType{ get; set; }

    [JsonPropertyName("ml")]
    public float maxLevel{ get; set; }

    [JsonPropertyName("gs")]
    public string goodsSubType{ get; set; }
}