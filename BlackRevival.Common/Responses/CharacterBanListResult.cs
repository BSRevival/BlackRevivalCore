using BlackRevival.Common.Model;

namespace BlackRevival.Common.Responses;

public class CharacterBanListResult
{
    public List<CharacterBan> characterBanList { get; set; }

    public List<GameModeStatus> gameStatusBanList { get; set; }

}