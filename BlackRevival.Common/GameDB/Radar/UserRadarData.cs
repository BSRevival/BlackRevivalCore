using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Radar;

public class UserRadarData
{
    public int GetMax()
    {
        if (this.name.Equals("Mastery"))
        {
            return this.max - 55;
        }
        return this.max;
    }

    [JsonPropertyName("nm")]
    public string name { get; set; }

    [JsonPropertyName("leg")]
    public League league { get; set; }

    [JsonPropertyName("mn")]
    public int min { get; set; }

    [JsonPropertyName("mx")]
    public int max { get; set; }
}