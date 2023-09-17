using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Collection;

public class SkinCollectionData
{
    [JsonPropertyName("cod")]
    public int code { get; set; }

    [JsonPropertyName("csts")]
    public List<int> characterSkinTypes { get; set; }

    [JsonPropertyName("gds")]
    public Goods goods { get; set; }
}