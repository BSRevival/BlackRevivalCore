using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlackRevival.APIServer.Database;

public class InventoryGoods
{
    [JsonPropertyName("c")]
    public string Text { get; set; }

    [JsonPropertyName("a")]
    public int Type { get; set; }

    [JsonPropertyName("n")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Num { get; set; }
    
    [ForeignKey("User")]
    [JsonPropertyName("un")]
    public long UserNum { get; set; }

    [JsonPropertyName("ia")]
    public bool IsActivated { get; set; }

    public bool Activated { get; set; }

    [JsonPropertyName("ed")]
    [JsonIgnore]
    public long ExpireDtm { get; set; }

    // Navigational properties
    public virtual User User { get; set; }
}
