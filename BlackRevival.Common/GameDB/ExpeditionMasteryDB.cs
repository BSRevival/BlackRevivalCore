using BlackRevival.Common.Model;
using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Expedition;
using Serilog;
using BlackRevival.Common.PVE.Enums;
using BlackRevival.Common.Util;
using System.ComponentModel;

namespace BlackRevival.Common.GameDB;

public class ExpeditionMasteryDB
{

    public List<ExpeditionMasteryData> p_expeditionMastery
    {
        get
        {
            return this.expeditionMastery;
        }
    }

    public ExpeditionMasteryDB()
    {
        this.expeditionMastery = new List<ExpeditionMasteryData>();
        Instance = this;
    }

    public ExpeditionMasteryDB(ExpeditionMasteryDB.Model model)
    {
        this.expeditionMastery = model.expeditionMastery;
        Instance = this;
    }

    public ExpeditionMasteryData Find(int code)
    {
        if (this.expeditionMastery == null)
        {
            return null;
        }
        return this.expeditionMastery.Find((ExpeditionMasteryData x) => x.code == code);
    }

    public ExpeditionMasteryData Find(AcE_WEAPON_TYPE weaponType, float exp)
    {
        if (this.expeditionMastery == null)
        {
            return null;
        }
        List<ExpeditionMasteryData> list = this.expeditionMastery.FindAll((ExpeditionMasteryData x) => x.weaponType == weaponType && x.familiarityExp <= exp);
        if (list != null && list.Count > 0)
        {
            return list[list.Count - 1];
        }
        return this.expeditionMastery.Find((ExpeditionMasteryData x) => x.weaponType == weaponType && x.masteryGrade == AcE_MASTERY_RANK_TYPE.F);
    }

    public ExpeditionMasteryData Find(AcE_MASTERY_TYPE masteryType, float exp)
    {
        return this.Find(AcEnum.Convert<AcE_WEAPON_TYPE>(masteryType.ToString()), exp);
    }

    public AcE_MASTERY_RANK_TYPE FindRankType(AcE_WEAPON_TYPE weaponType, float exp)
    {
        return this.Find(weaponType, exp).masteryGrade;
    }

    public AcE_MASTERY_RANK_TYPE FindRankType(AcE_MASTERY_TYPE masteryType, float exp)
    {
        return this.Find(masteryType, exp).masteryGrade;
    }

    public ExpeditionMasteryData Find(AcE_WEAPON_TYPE weaponType, AcE_MASTERY_RANK_TYPE rankType)
    {
        if (this.expeditionMastery == null)
        {
            return null;
        }
        return this.expeditionMastery.Find((ExpeditionMasteryData x) => x.weaponType == weaponType && x.masteryGrade == rankType);
    }

    public ExpeditionMasteryData Find(AcE_MASTERY_TYPE masteryType, AcE_MASTERY_RANK_TYPE rankType)
    {
        return this.Find(AcEnum.Convert<AcE_WEAPON_TYPE>(masteryType.ToString()), rankType);
    }

    public ExpeditionMasteryData FindNextRankData(AcE_WEAPON_TYPE weaponType, AcE_MASTERY_RANK_TYPE rankType)
    {
        if (this.expeditionMastery == null)
        {
            return null;
        }
        if (rankType == AcE_MASTERY_RANK_TYPE.VF)
        {
            return this.expeditionMastery.Find((ExpeditionMasteryData x) => x.masteryGrade == AcE_MASTERY_RANK_TYPE.NONE);
        }
        AcE_MASTERY_RANK_TYPE rankType2 = AcEnum.NextValue<AcE_MASTERY_RANK_TYPE>(rankType);
        return this.Find(weaponType, rankType2);
    }

    public ExpeditionMasteryData FindNextRankData(AcE_MASTERY_TYPE masteryType, AcE_MASTERY_RANK_TYPE rankType)
    {
        return this.FindNextRankData(AcEnum.Convert<AcE_WEAPON_TYPE>(masteryType.ToString()), rankType);
    }

    public float GetMaxExp(AcE_WEAPON_TYPE weaponType, float exp)
    {
        return this.GetMaxExp(AcEnum.Convert<AcE_MASTERY_TYPE>(weaponType.ToString()), exp);
    }

    public float GetMaxExp(AcE_MASTERY_TYPE masteryType, float exp)
    {
        AcE_MASTERY_RANK_TYPE acE_MASTERY_RANK_TYPE = this.FindRankType(masteryType, exp);
        if (acE_MASTERY_RANK_TYPE == AcE_MASTERY_RANK_TYPE.VF)
        {
            return this.Find(masteryType, acE_MASTERY_RANK_TYPE).familiarityExp;
        }
        ExpeditionMasteryData expeditionMasteryData = this.FindNextRankData(masteryType, acE_MASTERY_RANK_TYPE);
        if (expeditionMasteryData != null)
        {
            return expeditionMasteryData.familiarityExp;
        }
        return this.Find(masteryType, acE_MASTERY_RANK_TYPE).familiarityExp;
    }

    public float GetMasteryRankExp(AcE_MASTERY_TYPE type, AcE_MASTERY_RANK_TYPE rankType)
    {
        ExpeditionMasteryData expeditionMasteryData = this.Find(type, rankType);
        if (expeditionMasteryData == null)
        {
            return 0f;
        }
        return expeditionMasteryData.familiarityExp;
    }

    public int GetMonstMaxActionCost()
    {
        return this.expeditionMastery.Find((ExpeditionMasteryData data) => data.code == 1).cost;
    }

    public static ExpeditionMasteryDB Instance { get; private set; }
    private readonly List<ExpeditionMasteryData> expeditionMastery;

    public class Model
    {
        public List<ExpeditionMasteryData> expeditionMastery { get; private set; }
    }
}
