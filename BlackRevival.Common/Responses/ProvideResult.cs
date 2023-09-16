using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.Responses;

public class ProvideResult
{
    [JsonPropertyName("gs")]
    public Goods goods { get; set; }

    [JsonPropertyName("rgs")]
    public RouletteGoods rouletteGoods { get; set; }

    [JsonPropertyName("cha")]
    public Character character { get; set; }

    [JsonPropertyName("cs")]
    public CharacterSkin characterSkin { get; set; }

    [JsonPropertyName("igs")]
    public InvenGoods invenGoods { get; set; }

    [JsonPropertyName("prt")]
    public List<ProvideResult> results { get; set; }

    [JsonPropertyName("rrt")]
    public List<ProvideResult> rewardResults { get; set; }

    [JsonPropertyName("rdp")]
    public bool isDuplication { get; set; }

    [JsonPropertyName("cbr")]
    public float creditBonusRate { get; set; }
}