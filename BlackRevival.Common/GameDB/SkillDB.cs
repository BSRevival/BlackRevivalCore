using BlackRevival.Common.GameDB.Skills;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB;

public class SkillDB
{
    public static SkillDB Instance { get; private set; }
    public class Model
    {
        public List<SkillData> skillData { get; set; }
    }

    public List<SkillData> skillData { get; set; }

    public SkillDB()
    {
        skillData = new List<SkillData>();
        Instance = this;
    }

    public SkillDB(Model model)
    {
        skillData = model.skillData;
        Instance = this;
    }

    public SkillData Find(int id)
    {
        return skillData.Find((SkillData data) => data.id == id);
    }

    public SkillData Find(Skill skill)
    {
        return skillData.Find((SkillData data) => data.id == (int)skill);
    }
    

    public string GetName(int id)
    {
        SkillData skillData = Find(id);
        if (skillData != null)
        {
            return skillData.GetName();
        }
        return string.Empty;
    }

    public string GetTooltipName(int id)
    {
        SkillData skillData = Find(id);
        if (skillData != null)
        {
            return skillData.GetCaseByCaseName();
        }
        return string.Empty;
    }

    public string GetDesc(int id)
    {
        SkillData skillData = Find(id);
        if (skillData != null)
        {
            return skillData.GetDesc();
        }
        return string.Empty;
    }

    public string GetIconSprite(int id)
    {
        SkillData skillData = Find(id);
        if (skillData == null)
        {
            return string.Empty;
        }
        return skillData.GetIconSprite();
    }

    public SkillHolder GetHolder(int id)
    {
        return Find(id)?.holder ?? SkillHolder.NONE;
    }

    public SkillData GetRandom()
    {
        Random random = new Random(DateTime.Now.Ticks.GetHashCode());
        return skillData[random.Next(0, skillData.Count)];
    }
}