using BlackRevival.Common.Model;
using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Expedition;
using Serilog;

namespace BlackRevival.Common.GameDB;

public class ExpeditionSkillDB
{
    public ExpeditionSkillDB()
    {
        expeditionSkill = new List<ExpeditionSkillData>();
        Instance = this;
    }

    public ExpeditionSkillDB(ExpeditionSkillDB.Model model)
    {
        expeditionSkill = model.expeditionSkill;
        Instance = this;
    }

    public ExpeditionSkillData Find(ExpeditionSkillId type)
    {
        return this.Find((int)type);
    }

    public ExpeditionSkillData Find(int skillId)
    {
        return this.expeditionSkill.Find((ExpeditionSkillData skill) => skill.expeditionSkillId == skillId);
    }

    public List<ExpeditionSkillData> expeditionSkill { get; set; }
    public static ExpeditionSkillDB Instance { get; private set; }

    public class Model
    {
        public List<ExpeditionSkillData> expeditionSkill { get; set; }
    }

}
