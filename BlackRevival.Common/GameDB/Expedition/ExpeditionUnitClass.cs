using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Expedition;


public class ExpeditionUnitClass
{
    [JsonPropertyName("cod")]
    public int code { get; set; }

    [JsonPropertyName("ccs")]
    public int characterClass { get; set; }

    [JsonPropertyName("mcs")]
    public int monsterClass { get; set; }

    [JsonPropertyName("wtpl")]
    public List<int> weaponTypes { get; set; }
}