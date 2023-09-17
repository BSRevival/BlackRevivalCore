using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BlackRevival.Common.Model;
using BlackRevival.Common.Util;

namespace BlackRevival.APIServer.Database.MiniLeague;

public class MiniLeagueStatus
{
    [ForeignKey("User")]
    [JsonPropertyName("n")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string nickname { get; set; }

    [JsonPropertyName("p")] 
    public int point { get; set; }

    [JsonPropertyName("r")] 
    public int rank { get; set; }
    
    [JsonPropertyName("w")]
    public int winCount { get; set; }
}