using BlackRevival.Common.GameDB.Expedition;
using Serilog;
using BlackRevival.Common.Util;
using BlackRevival.Common.Enums;

namespace BlackRevival.Common.GameDB;

public class ExpeditionUnitDB
{
    public List<ExpeditionUnitData> p_expeditionUnit
    {
        get
        {
            return this.expeditionUnit;
        }
    }

    public List<ExpeditionUnitClass> p_expeditionUnitClass
    {
        get
        {
            return this.expeditionUnitClass;
        }
    }

    public List<int> p_playableCharacterList
    {
        get
        {
            return this.playableCharacterList;
        }
    }

    public ExpeditionUnitDB()
    {
        this.expeditionUnit = new List<ExpeditionUnitData>();
        this.playableCharacterList = new List<int>();
    }

    // Token: 0x060072BE RID: 29374 RVA: 0x001F1F3C File Offset: 0x001F013C
    public ExpeditionUnitDB(ExpeditionUnitDB.Model model)
    {
        this.expeditionUnit = model.expeditionUnit;
        this.expeditionUnitClass = model.unitClass;
        List<ExpeditionUnitData> list = this.expeditionUnit;
        List<int> list2;
        if (list == null)
        {
            list2 = null;
        }
        else
        {
            list2 = (from x in list
                     group x by x.unitClass into x
                     where x.First<ExpeditionUnitData>().playable
                     select x.First<ExpeditionUnitData>().unitClass).ToList<int>();
        }
        this.playableCharacterList = list2;
    }

    public ExpeditionUnitData Find(Predicate<ExpeditionUnitData> match)
    {
        return this.expeditionUnit.Find(match);
    }

    public ExpeditionUnitData Find(AcE_UNIT_CLASS unitClass, AcE_UNIT_GRADE unitGrade = AcE_UNIT_GRADE.GRADE_COMMON)
    {
        return this.Find((int)unitClass, (int)unitGrade);
    }

    public ExpeditionUnitData Find(AcE_UNIT_CLASS unitClass, int unitGrade = 201)
    {
        return this.Find((int)unitClass, unitGrade);
    }

    public ExpeditionUnitData Find(int unitClass, int unitGrade = 201)
    {
        return this.Find((ExpeditionUnitData x) => x.unitClass == unitClass && x.unitGrade == unitGrade);
    }

    public ExpeditionUnitClass FindClass(int unitClass)
    {
        if (this.p_expeditionUnitClass == null || this.p_expeditionUnitClass.Count == 0)
        {
            return null;
        }
        return this.p_expeditionUnitClass.Find((ExpeditionUnitClass i) => i.code == unitClass);
    }

    public AcE_WEAPON_TYPE GetUnitWeaponType(int groupCode, int unitClass)
    {
        switch (groupCode)
        {
            case 11:
                return AcE_WEAPON_TYPE.PUNCH;
            case 12:
                return AcE_WEAPON_TYPE.BLUNT;
            case 13:
                return AcE_WEAPON_TYPE.BLADE;
            case 14:
                return AcE_WEAPON_TYPE.STAB;
            case 15:
                return AcE_WEAPON_TYPE.THROW;
            case 16:
                return AcE_WEAPON_TYPE.GUN;
            case 17:
                return AcE_WEAPON_TYPE.BOW;
            default:
                {
                    ExpeditionUnitClass expeditionUnitClass = this.FindClass(unitClass);
                    if (expeditionUnitClass == null)
                    {
                        Log.Error($"ExpeditionUnitClass[{unitClass}] is null.");
                        return AcE_WEAPON_TYPE.PUNCH;
                    }
                    return (AcE_WEAPON_TYPE)expeditionUnitClass.weaponTypes[0];
                }
        }
    }

    public AcE_WEAPON_TYPE GetBossWeaponType(int unitClass)
    {
        if (unitClass <= 30000)
        {
            return AcE_WEAPON_TYPE.NONE;
        }
        ExpeditionUnitClass expeditionUnitClass = this.FindClass(unitClass);
        if (expeditionUnitClass == null)
        {
            Log.Error($"ExpeditionUnitClass[{unitClass}] is null.");
            return AcE_WEAPON_TYPE.PUNCH;
        }
        return (AcE_WEAPON_TYPE)expeditionUnitClass.weaponTypes[0];
    }

    private readonly List<ExpeditionUnitData> expeditionUnit;

    private readonly List<ExpeditionUnitClass> expeditionUnitClass;

    private readonly List<int> playableCharacterList;

    public class Model
    {
        public List<ExpeditionUnitData> expeditionUnit { get; set; }

        public List<ExpeditionUnitClass> unitClass { get; set; }
    }

}
