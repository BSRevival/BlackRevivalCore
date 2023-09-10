using System.Text.Json.Serialization;

namespace BlackRevival.APIServer.Database;

public class InventoryGoods
{
    [JsonPropertyName("c")]
    public string Text { get; set; }

    [JsonPropertyName("a")]
    public int Type { get; set; }

    [JsonPropertyName("n")]
    public long Num { get; set; }

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
