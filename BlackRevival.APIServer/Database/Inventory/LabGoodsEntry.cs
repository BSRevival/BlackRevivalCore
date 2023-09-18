using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.APIServer.Database;

public class LabGoodsEntry
{
    [ForeignKey("User")]
    [JsonPropertyName("unm")]
    public long userNum{ get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

    [ForeignKey("InventoryGoods")]
    [JsonPropertyName("igl")]
    public ICollection<InventoryGoods> invenGoodsList{ get; set; }
}