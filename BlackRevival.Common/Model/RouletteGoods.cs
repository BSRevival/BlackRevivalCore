using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class RouletteGoods : Goods
{
    [JsonPropertyName("rgg")]
    public RouletteGoodsGradeData rouletteGoodsGrade { get; set; }

    [JsonPropertyName("slm")]
    public bool seasonLimit { get; set; }

    [JsonPropertyName("rfb")]
    public int refundBp { get; set; }
}