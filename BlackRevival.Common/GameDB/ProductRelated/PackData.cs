using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.ProductRelated;

public class PackData
{
    [JsonPropertyName("t")]
    public string type { get; set; }

    [JsonPropertyName("pc")]
    public PackCondition packCondition { get; set; }

    [JsonPropertyName("pt")]
    public PackDetailType packDetailType { get; set; }

    [JsonPropertyName("gl")]
    public List<Goods> goodsList { get; set; }
}