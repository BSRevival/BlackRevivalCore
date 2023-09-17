using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;

namespace BlackRevival.APIServer.Database.MiniLeague;

public class MiniLeagueUser
{
    [JsonPropertyName("t")] 
    public MiniLeagueTier tier { get; set; }

    [JsonPropertyName("gi")] 
    [Key]
    public long? groupId { get; set; }
}