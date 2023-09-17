using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Quest;
using BlackRevival.Common.Model;
using Serilog;

namespace BlackRevival.Common.GameDB;

public class QuestDB
{
    public QuestDB()
    {
        this.questData = new List<QuestData>();
    }

    public QuestDB(QuestDB.Model data)
    {
        this.questData = data.questData;
    }

    public QuestData Find(int questId)
    {
        return this.questData.Find((QuestData data) => data.questId == questId);
    }

    public QuestRenewalType GetQuestRenewalType(int questId)
    {
        if (this.Find(questId) == null)
        {
            return QuestRenewalType.NONE;
        }
        return this.Find(questId).questRenewalType;
    }

    private List<QuestData> questData { get; set; }

    public class Model
    {
        public List<QuestData> questData { get; set; }
    }
}