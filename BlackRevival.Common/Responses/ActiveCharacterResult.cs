using BlackRevival.Common.Model;

namespace BlackRevival.Common.Responses;

public class ActiveCharacterResult: CommunityRequsetResult
{
    public Character activeCharacter{ get; set; }
    
    public long tournamentStartDtm{ get; set; }
}