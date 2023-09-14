using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class InstalledRobot
{
    [JsonPropertyName("isn")]
    public string installerNickname { get;set; }
}