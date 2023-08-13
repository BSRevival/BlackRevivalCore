using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class CharacterDocument
{
    [JsonPropertyName("unm")]
    public long userNum { get; set; }

    [JsonPropertyName("cls")]
    public int characterClass { get; set; }

    [JsonPropertyName("ptt")]
    public int pattern { get; set; }

    [JsonPropertyName("ptn")]
    public bool patternReward { get; set; }

    [JsonPropertyName("wkn")]
    public int weakness { get; set; }

    [JsonPropertyName("wks")]
    public bool weaknessReward { get; set; }

    [JsonPropertyName("crl")]
    public int characterLike { get; set; }

    [JsonPropertyName("lik")]
    public bool characterLikeReward { get; set; }

    [JsonPropertyName("itv")]
    public int interview { get; set; }

    [JsonPropertyName("itr")]
    public bool interviewReward { get; set; }
}