using BlackRevival.Common.Model;
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

    public int GetAssetValue(AssetType assetType)
    {
        switch (assetType)
        {
            case AssetType.GOLD:
                return Gold;
            case AssetType.GEM:
                return Gem;
            case AssetType.BEARPOINT:
                return BearPoint;
            case AssetType.CREDIT:
                return Credit;
            case AssetType.MILEAGE:
                return Mileage;
            case AssetType.EXPERIMENT_MEMORY:
                return ExperimentMemory;
            case AssetType.TOURNAMENT_POINT:
                return TournamentPoint;
            case AssetType.TOURNAMENT_TICKET:
                return TournamentTicket;
            case AssetType.VOTE_TICKET:
                return VoteTicket;
            case AssetType.VOTE_STAMP:
                return VoteStamp;
            case AssetType.LABYRINTH_POINT:
                return LabyrinthPoint;
            default:
                return 0;
        }
    }

    public void SetAssetValue(AssetType assetType, int value)
    {
        switch (assetType)
        {
            case AssetType.GOLD:
                Gold = value;
                break;
            case AssetType.GEM:
                Gem = value;
                break;
            case AssetType.BEARPOINT:
                BearPoint = value;
                break;
            case AssetType.CREDIT:
                Credit = value;
                break;
            case AssetType.MILEAGE:
                Mileage = value;
                break;
            case AssetType.EXPERIMENT_MEMORY:
                ExperimentMemory = value;
                break;
            case AssetType.TOURNAMENT_POINT:
                TournamentPoint = value;
                break;
            case AssetType.TOURNAMENT_TICKET:
                TournamentTicket = value;
                break;
            case AssetType.VOTE_TICKET:
                VoteTicket = value;
                break;
            case AssetType.VOTE_STAMP:
                VoteStamp = value;
                break;
            case AssetType.LABYRINTH_POINT:
                LabyrinthPoint = value;
                break;
            case AssetType.NONE:
            default:
                break;
        }
    }
}
