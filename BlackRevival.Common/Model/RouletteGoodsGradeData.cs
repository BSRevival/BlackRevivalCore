using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class RouletteGoodsGradeData
{
    [JsonPropertyName("grd")]
    public string grade{ get; set; }

    [JsonPropertyName("crd")]
    public int credit{ get; set; }
}