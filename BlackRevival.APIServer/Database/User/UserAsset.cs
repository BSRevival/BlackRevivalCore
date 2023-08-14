using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackRevival.APIServer.Database;

public class UserAsset
{
    [Key]
    [ForeignKey("User")]
    public long UserNum { get; set; }
    public int Gold { get; set; } = 10000000;
    public int Gem { get; set; } = 10000000;
    public int BearPoint { get; set; } = 1000000;
    public int Credit { get; set; } = 0;
    public int Mileage { get; set; } = 1000000;
    public int ExperimentMemory { get; set; } = 0;
    public int TournamentPoint { get; set; } = 0;
    public int TournamentTicket { get; set; } = 0;
    public int VoteTicket { get; set; } = 0;
    public int VoteStamp { get; set; } = 0;
    public int LabyrinthPoint { get; set; } = 0;
    public int AgliaScore { get; set; } = 0;

    public virtual User User { get; set; }
}
