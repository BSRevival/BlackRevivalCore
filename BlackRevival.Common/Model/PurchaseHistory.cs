using System.Text.Json.Serialization;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class PurchaseHistory
{
    [JsonPropertyName("usn")]
    public long userNum{ get; set; }

    [JsonPropertyName("pid")]
    public string productId{ get; set; }

    [JsonPropertyName("ldt")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime logDtm{ get; set; }
}