using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.APIServer.Database.MiniLeague;

public class MiniLeague
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonPropertyName("u")]
    public MiniLeagueUser leagueUser { get; set; }

    [JsonPropertyName("g")] 
    public MiniLeagueGroup group { get; set; }

    [JsonPropertyName("m")] 
    public MiniLeagueEntry myEntry { get; set; }

    [JsonPropertyName("e")] 
    public List<MiniLeagueEntry> entries { get; set; }
}