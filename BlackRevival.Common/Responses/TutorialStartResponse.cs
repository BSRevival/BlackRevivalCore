using BlackRevival.Common.Model;

namespace BlackRevival.Common.Responses;

public class TutorialStartResponse
{
    public UserTutorial userTutorial { get; set; }
    public IngameServerInfo ingameServerInfo { get; set; }
}