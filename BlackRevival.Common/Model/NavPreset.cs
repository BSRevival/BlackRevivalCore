using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class NavPreset
{
    [JsonPropertyName("pid")]
    public long presetId{ get; set; }

    [JsonPropertyName("gid")]
    public int groupId{ get; set; }

    [JsonPropertyName("sn")]
    public int slotNum{ get; set; }

    [JsonPropertyName("itm")]
    public int item{ get; set; }
}