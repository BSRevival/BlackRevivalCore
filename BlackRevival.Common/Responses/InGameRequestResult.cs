using BlackRevival.Common.InGame;

namespace BlackRevival.Common.Responses;

public class InGameRequestResult
{
        public bool isChatRestricted { get; set; }
        public InGameServerInfo ingameServerInfo { get; set; }
}