using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Expedition;


public class ExpeditionGlobalnfo
{
    [JsonPropertyName("cod")]
    public int code { get; set; }

    [JsonPropertyName("iarc")]
    public int initialAreaCount { get; set; }

    [JsonPropertyName("ialc")]
    public int initialAllyCount { get; set; }

    [JsonPropertyName("olc")]
    public int openLaboCount { get; set; }

    [JsonPropertyName("alc")]
    public int afterLaboCount { get; set; }
}