using System.Text.Json.Serialization;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class Promotion
{

    [JsonPropertyName("pt")]
    public int promotionType{ get; set; }

    [JsonPropertyName("pmd")]
    public int promotionId{ get; set; }

    [JsonPropertyName("pid")]
    public string productId{ get; set; }

    [JsonPropertyName("dpc")]
    public int discountPercent{ get; set; }

    [JsonPropertyName("bgd")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime? beginDtm{ get; set; }

    [JsonPropertyName("edt")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime? endDtm{ get; set; }
}