using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class NavPresetGroup
{
    [JsonPropertyName("gid")]
    public int groupId{ get; set; }

    [JsonPropertyName("un")]
    public long userNum{ get; set; }

    [JsonPropertyName("gn")]
    public int groupNum{ get; set; }

    [JsonPropertyName("gnm")]
    public string groupName{ get; set; }

    [JsonPropertyName("ps")]
    public List<NavPreset> presets{ get; set; }
}