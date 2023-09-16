using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Roulette;

public class RoulettePmf
{
    [JsonPropertyName("key")]
    public RouletteGoods goods { get; set; }

    [JsonPropertyName("value")]
    public double ratio { get; set; }
}