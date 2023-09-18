using BlackRevival.Common.Model;
using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Expedition;
using Serilog;
using Serilog.Core;

namespace BlackRevival.Common.GameDB;

public class ExpeditionCardDB
{
    public ExpeditionCardDB()
    {
        this.expeditionCard = new List<ExpeditionCardData>();
    }

    public ExpeditionCardDB(ExpeditionCardDB.Model model)
    {
        this.expeditionCard = model.expeditionCard;
    }

    public ExpeditionCardData FindCardData(int cardId)
    {
        return this.expeditionCard.Find((ExpeditionCardData item) => item.cardId.Equals(cardId));
    }

    public List<ExpeditionSkillData> GetSkillsByCardLevel(int cardId, int level)
    {
        ExpeditionCardData expeditionCardData = this.expeditionCard.Find((ExpeditionCardData item) => item.cardId.Equals(cardId));
        List<int> list = null;
        if (!expeditionCardData.skillForCardLevel.TryGetValue(level, out list))
        {
            Log.Warning("Could not found Skills. cardID[{0}], level[{1}]", new object[]
            {
                cardId,
                level
            });
        }
        if (list == null)
        {
            return null;
        }
        List<ExpeditionSkillData> outList = new List<ExpeditionSkillData>();
        list.ForEach(delegate (int skill)
        {
            ExpeditionSkillData expeditionSkillData = ExpeditionSkillDB.Instance.Find(skill);
            if (expeditionSkillData != null)
            {
                outList.Add(expeditionSkillData);
            }
        });
        return outList;
    }

    public ExpeditionCardData Find(Predicate<ExpeditionCardData> match)
    {
        return this.expeditionCard.Find(match);
    }

    private readonly List<ExpeditionCardData> expeditionCard;

    public class Model
    {
        public List<ExpeditionCardData> expeditionCard { get; set; }
    }
}
