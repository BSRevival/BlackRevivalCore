using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.MiniLeague;

public class MiniLeagueTierData
{
    [JsonPropertyName("c")] 
    public int code { get; set; }

    [JsonPropertyName("p")] 
    public int promotionRank { get; set; }

    [JsonPropertyName("r")] 
    public int relegationRank { get; set; }
}