using BlackRevival.Common.Apis;
using BlackRevival.Common.GameDB.Perks;

namespace BlackRevival.Common.GameDB;

public class PerkDB
{
    public PerkDB()
    {
        this.data_list = new List<PerkData>();
    }

    public PerkDB(PerkDB.Model data)
    {
        this.data_list = data.perkData;
    }

    public PerkData GetPerkData(int id)
    {
        return this.data_list.Find((PerkData x) => x.id == id);
    }

    public List<PerkData> GetPerkDatas()
    {
        return (from data in this.data_list
            where data.level == 1
            orderby data.category
            select data).ToList<PerkData>();
    }

    public List<PerkData> GetPerkNormalDatas(PerkApi.PerkPreset perk, PerkDB.AcE_PERK_TYPE type)
    {
        return (from data in this.data_list
            where data.category == perk.category && data.level == (int)type
            orderby data.skill_id
            select data).ToList<PerkData>();
    }

    public PerkDB.AcE_PERK_TYPE GetPerkType(int level)
    {
        for (PerkDB.AcE_PERK_TYPE acE_PERK_TYPE = PerkDB.AcE_PERK_TYPE.None; acE_PERK_TYPE <= PerkDB.AcE_PERK_TYPE.Normal_2; acE_PERK_TYPE++)
        {
            if (level == (int)acE_PERK_TYPE)
            {
                return acE_PERK_TYPE;
            }
        }
        return PerkDB.AcE_PERK_TYPE.None;
    }

    public bool isPerkSkill(int skillId)
    {
        return this.data_list.Exists((PerkData x) => x.skill_id == skillId);
    }
    

    public List<PerkData> data_list { get; set; }

    public class Model
    {
        public List<PerkData> perkData { get; set; }
    }

    public enum AcE_PERK_TYPE
    {
        None,
        Main,
        Normal_1 = 100,
        Normal_2 = 200
    }
}