using System.Text.Json.Serialization;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class UserDailyProduct
{
    [JsonPropertyName("idx")]
    public long idx{ get; set; }

    [JsonPropertyName("un")]
    public long userNum{ get; set; }

    [JsonPropertyName("pid")]
    public string productId{ get; set; }

    [JsonPropertyName("bgt")]
    public GoodsType buyGoodsType{ get; set; }

    [JsonPropertyName("bst")]
    public string buySubType{ get; set; }

    [JsonPropertyName("bam")]
    public int buyAmount{ get; set; }

    [JsonPropertyName("pgt")]
    public GoodsType payGoodsType{ get; set; }

    [JsonPropertyName("pst")]
    public PurchaseMethod paySubType{ get; set; }

    [JsonPropertyName("pam")]
    public int payAmount{ get; set; }

    [JsonPropertyName("rrc")]
    public int rerollCount{ get; set; }

    [JsonPropertyName("rmc")]
    public int reRollMaxCount{ get; set; }

    [JsonPropertyName("pcs")]
    public bool purchased{ get; set; }

    [JsonPropertyName("rdtm")]
    public long  registDtm{ get; set; }

    [JsonPropertyName("edtm")]
    public long expireDtm{ get; set; }
}