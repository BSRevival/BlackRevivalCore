using BlackRevival.Common.GameDB.ResearcherLevel;

namespace BlackRevival.Common.GameDB;

public class ResearcherLevelDB
{
    public ResearcherLevelDB()
    {
        this.researcherLevels = new List<ResearcherLevelData>();
    }

    public ResearcherLevelDB(ResearcherLevelDB.Model model)
    {
        this.researcherLevels = model.researcherLevels;
        this.maxLevel = this.researcherLevels[this.researcherLevels.Count - 1].level;
    }

    public ResearcherLevelData GetLevelData(int level)
    {
        return this.researcherLevels.Find((ResearcherLevelData o) => o.level == level);
    }

    public ResearcherLevelData GetNextLevelData(int level)
    {
        int nextLevel = Math.Min(level + 1, this.maxLevel);
        return this.researcherLevels.Find((ResearcherLevelData o) => o.level == nextLevel);
    }

    public int GetLevel(int exp)
    {
        ResearcherLevelData researcherLevelData = this.researcherLevels.Find((ResearcherLevelData r) => r.minExp >= exp);
        if (researcherLevelData == null)
        {
            return 0;
        }

        return Math.Max(1, researcherLevelData.level - 1);
    }

    public string GetLevelIconName(int level)
    {
        if (level < 11)
        {
            return "Icon_Userlevel_01";
        }

        if (10 < level && level < 31)
        {
            return "Icon_Userlevel_02;";
        }
        if (30 < level && level < 61)
        {
            return "Icon_Userlevel_03";
        }
        if (60 < level && level < 91)
        {
            return "Icon_Userlevel_04";
        }
        return "Icon_Userlevel_05";
    }

    public List<ResearcherLevelData> researcherLevels;

    public int maxLevel;

    public class Model
    {
        public List<ResearcherLevelData> researcherLevels { get; set; }
    }
}