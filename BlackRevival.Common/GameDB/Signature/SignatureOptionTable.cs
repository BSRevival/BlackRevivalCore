using System.Text.Json.Serialization;
using BlackRevival.Common.Model.AcE;

namespace BlackRevival.Common.GameDB.Signature;

public class SignatureOptionTable
{
    public int GetRequiredLevelValue()
    {
        return (int)(this.endValue - this.startValue);
    }

    [JsonPropertyName("cod")]
    public int code { get; set; }

    [JsonPropertyName("stt")]
    public AcE_SignatureType signatureType { get; set; }

    [JsonPropertyName("lv")]
    public int level { get; set; }

    [JsonPropertyName("sv")]
    public float startValue { get; set; }

    [JsonPropertyName("ev")]
    public float endValue { get; set; }

    [JsonPropertyName("hn")]
    public bool hasNext { get; set; }
}