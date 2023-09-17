using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;
using BlackRevival.Common.Util;

namespace BlackRevival.APIServer.Database.MiniLeague;

public class MiniLeagueGroup
{
    [JsonIgnore]
    [Key]
    [JsonPropertyName("gi")]
    public int groupid { get; set; }

    [JsonPropertyName("c")]
    public int memberCount { get; set; }

    [JsonPropertyName("t")] 
    public MiniLeagueTier tier { get; set; }

    [JsonPropertyName("e")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime expireDtm { get; set; }
}