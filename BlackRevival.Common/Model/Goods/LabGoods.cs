using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class LabGoods
{       
    [JsonPropertyName("unm")]
    public long userNum{ get; set; }

    [JsonPropertyName("lnm")]
    public long labNum{ get; set; }

    [JsonPropertyName("ltp")]
    public LabType labType{ get; set; }

    [JsonPropertyName("sbt")]
    public string bgSubType{ get; set; }

    [JsonPropertyName("acti")]
    public bool isActivated{ get; set; }

    [JsonPropertyName("cps")]
    public string components{ get; set; }

    [JsonPropertyName("igl")]
    public List<long> invenGoodsList{ get; set; }
}