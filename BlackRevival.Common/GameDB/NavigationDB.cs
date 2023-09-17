using BlackRevival.Common.GameDB.Navigation;

namespace BlackRevival.Common.GameDB;

public class NavigationDB
{
    public static NavigationDB Instance { get; private set; }
    public NavigationDB()
    {
    }

    public NavigationDB(NavigationDB.Model data)
    {
        this.actionScores = data.navigation;
        this.actionScoreMap = new Dictionary<int, int>();
        foreach (ActionScoreData actionScoreData in this.actionScores)
        {
            this.actionScoreMap[actionScoreData.navigatorType] = actionScoreData.actionScore;
        }
        Instance = this;
    }

    public int GetActionScore(int navigatorType)
    {
        return this.actionScoreMap[navigatorType];
    }

    private readonly List<ActionScoreData> actionScores;

    private readonly Dictionary<int, int> actionScoreMap;

    public class Model
    {
        public List<ActionScoreData> navigation { get; set; }
    }
}