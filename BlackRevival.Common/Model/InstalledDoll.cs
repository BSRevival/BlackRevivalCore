using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class InstalledDoll
{
    [JsonPropertyName("isn")]
    public string installerNickname { get; set; }
}