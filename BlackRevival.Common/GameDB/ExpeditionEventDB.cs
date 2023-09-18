using BlackRevival.Common.Model;
using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Expedition;
using Serilog;

namespace BlackRevival.Common.GameDB;

public class ExpeditionEventDB
{

    public ExpeditionEventDB()
    {
        this.expeditionEvent = new List<ExpeditionEventData>();
    }

    public ExpeditionEventDB(ExpeditionEventDB.Model model)
    {
        this.expeditionEvent = model.expeditionEvent;
    }

    public ExpeditionEventData Find(Predicate<ExpeditionEventData> match)
    {
        return this.expeditionEvent.Find(match);
    }

    private readonly List<ExpeditionEventData> expeditionEvent;

    public class Model
    {
        public List<ExpeditionEventData> expeditionEvent { get; set; }
    }
}
