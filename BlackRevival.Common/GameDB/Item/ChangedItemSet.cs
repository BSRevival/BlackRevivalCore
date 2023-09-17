using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.Item;

public class ChangedItemSet
{
    [JsonPropertyName("iid")]
    public int itemId { get; set; }

    [JsonPropertyName("cnt")]
    public int count { get; set; }
}