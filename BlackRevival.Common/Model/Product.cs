using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;

namespace BlackRevival.Common.Model;

public class Product
{
    [JsonPropertyName("pid")]
    public string productId{ get; set; }

    [JsonPropertyName("iap")]
    public string iapProductId{ get; set; }

    [JsonPropertyName("pm")]
    public PurchaseMethod purchaseMethod{ get; set; }

    [JsonPropertyName("pri")]
    public float price{ get; set; }

    [JsonPropertyName("scp")]
    public float steamchinaPrice{ get; set; }

    [JsonPropertyName("pc")]
    public AcE_PurchaseConditionType purchaseConditionType{ get; set; }

    [JsonPropertyName("pcn")]
    public int purchaseCount{ get; set; }

    [JsonPropertyName("gs")]
    public Goods goods{ get; set; }
}