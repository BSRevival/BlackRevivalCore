using BlackRevival.Common.GameDB.LevelTable;

namespace BlackRevival.Common.GameDB;

public class LevelExpTableDB
{
    public List<LevelExpTableData> p_tableList
    {
        get
        {
            return this.tableList;
        }
    }
    public static LevelExpTableDB Instance { get; set; }
    public LevelExpTableDB()
    {
        this.tableList = new List<LevelExpTableData>();
        Instance = this;
    }

    public LevelExpTableDB(LevelExpTableDB.Model model)
    {
        this.tableList = model.tableList;
        Instance = this;
    }

    public LevelExpTableData Find(MapType mapType, int level)
    {
        if (this.tableList == null)
        {
            return null;
        }
        LevelExpTableData levelExpTableData = this.tableList.Find((LevelExpTableData x) => x.mapType == mapType && x.lv == level);
        if (levelExpTableData == null)
        {
            return this.tableList.FindLast((LevelExpTableData x) => x.mapType == mapType);
        }
        return levelExpTableData;
    }

    public int GetLevel(MapType mapType, float exp)
    {
        if (this.tableList == null)
        {
            return 1;
        }
        int result = 1;
        foreach (LevelExpTableData levelExpTableData in this.tableList)
        {
            if (levelExpTableData.mapType == mapType && levelExpTableData.startExp <= exp)
            {
                result = levelExpTableData.lv;
                if (!levelExpTableData.hasNext || exp <= levelExpTableData.untilSameLv)
                {
                    return result;
                }
            }
        }
        return result;
    }

    private readonly List<LevelExpTableData> tableList;

    public class Model
    {
        public List<LevelExpTableData> tableList { get; set; }
    }
}