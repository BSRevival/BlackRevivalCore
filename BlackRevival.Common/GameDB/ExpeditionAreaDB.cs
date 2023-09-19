using BlackRevival.Common.Model;
using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Expedition;
using Serilog;
using BlackRevival.Common.GameDB.Field;
using Serilog.Core;

namespace BlackRevival.Common.GameDB;

public class ExpeditionAreaDB
{

    public ExpeditionAreaDB()
    {
        this.dicExpeditionArea = new Dictionary<int, List<ExpeditionAreaData>>();
    }

    public ExpeditionAreaDB(ExpeditionAreaDB.Model model)
    {
        this.dicExpeditionArea = new Dictionary<int, List<ExpeditionAreaData>>();
        foreach (ExpeditionAreaData expeditionAreaData in model.expeditionArea)
        {
            if (this.dicExpeditionArea.ContainsKey(expeditionAreaData.fieldType))
            {
                this.dicExpeditionArea[expeditionAreaData.fieldType].Add(expeditionAreaData);
            }
            else
            {
                this.dicExpeditionArea.Add(expeditionAreaData.fieldType, new List<ExpeditionAreaData>
                {
                    expeditionAreaData
                });
            }
        }
        this.expeditionAreaMaxClear = model.expeditionAreaMaxClear;
        this.expeditionGlobalInfo = model.expeditionGlobalInfo;
    }

    public ExpeditionAreaData FindAreaData(int code, int district)
    {
        List<ExpeditionAreaData> lst = this.FindArea(code);
        return this.FindAreaData(lst, district);
    }

    public List<ExpeditionAreaData> FindArea(int code)
    {
        List<ExpeditionAreaData> result = null;
        if (!this.dicExpeditionArea.TryGetValue(code, out result))
        {
            Log.Error($"ArgumentException. fieldType[{code}]");
        }
        return result;
    }

    private ExpeditionAreaData FindAreaData(List<ExpeditionAreaData> lst, int district)
    {
        return lst.Find((ExpeditionAreaData item) => item.district.Equals(district));
    }

    public ExpeditionAreaData FindSpecialArea(int district)
    {
        Predicate<ExpeditionAreaData> p9_0;
        foreach (List<ExpeditionAreaData> list in this.dicExpeditionArea.Values)
        {
            Predicate<ExpeditionAreaData> match;
            match = (p9_0 = ((ExpeditionAreaData i) => i.district == district));
            ExpeditionAreaData expeditionAreaData = list.Find(match);
            if (expeditionAreaData != null)
            {
                return expeditionAreaData;
            }
        }
        return null;
    }

    public ExpeditionGlobalnfo FindGlobalInfo(int difficult)
    {
        if (this.expeditionGlobalInfo == null)
        {
            return null;
        }
        return this.expeditionGlobalInfo.Find((ExpeditionGlobalnfo info) => info.code == difficult);
    }

    public int GetOpenLabDay(int difficult)
    {
        ExpeditionGlobalnfo expeditionGlobalInfo = this.FindGlobalInfo(difficult);
        if (expeditionGlobalInfo == null)
        {
            return 0;
        }
        return expeditionGlobalInfo.openLaboCount;
    }

    public int GetLabDefeatDay(int difficult)
    {
        ExpeditionGlobalnfo expeditionGlobalInfo = this.FindGlobalInfo(difficult);
        if (expeditionGlobalInfo == null)
        {
            return 0;
        }
        return expeditionGlobalInfo.afterLaboCount;
    }

    public Dictionary<int, int> GetDropItems(int fieldType, int code, int district, out Dictionary<AcE_PROBABILITY_CATEGORY, float> additionalRate)
    {
        additionalRate = null;
        ExpeditionAreaData expeditionAreaData = this.FindAreaData(code, district);
        if (expeditionAreaData == null)
        {
            Log.Error($"Failed to find ExpeditionAreaData[{code} - {district}].");
            return null;
        }
        if (expeditionAreaData.districtType == 1)
        {
            return null;
        }
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        if (!expeditionAreaData.sameFieldInfo)
        {
            dictionary = new Dictionary<int, int>();
            foreach (KeyValuePair<int, int> keyValuePair in expeditionAreaData.fixedItems)
            {
                dictionary.Add(keyValuePair.Key, keyValuePair.Value);
            }
            return dictionary;
        }
        FieldTypeData fieldTypeData = FieldTypeDB.Instance.Find(fieldType);
        if (fieldTypeData == null || fieldTypeData.IsPowCamp)
        {
            Log.Error($"Invalid FieldType Code. [{fieldType}]");
            return null;
        }
        additionalRate = new Dictionary<AcE_PROBABILITY_CATEGORY, float>();
        foreach (ExpeditionAreaEventData expeditionAreaEventData in expeditionAreaData.eventList)
        {
            AcE_EXPEDITION_EVENT_ID id = (AcE_EXPEDITION_EVENT_ID)expeditionAreaEventData.id;
            if (id <= AcE_EXPEDITION_EVENT_ID.FOUND_ITEM_PROTECTOR)
            {
                if (id != AcE_EXPEDITION_EVENT_ID.FOUND_ITEM_WEAPON)
                {
                    if (id == AcE_EXPEDITION_EVENT_ID.FOUND_ITEM_PROTECTOR)
                    {
                        additionalRate.Add(AcE_PROBABILITY_CATEGORY.PROTECTOR, AcTryParse.AsFloat(expeditionAreaEventData.subParam2));
                    }
                }
                else
                {
                    additionalRate.Add(AcE_PROBABILITY_CATEGORY.WEAPON, AcTryParse.AsFloat(expeditionAreaEventData.subParam2));
                }
            }
            else if (id != AcE_EXPEDITION_EVENT_ID.FOUND_ITEM_FOOD)
            {
                if (id == AcE_EXPEDITION_EVENT_ID.FOUND_ITEM_MATERIAL)
                {
                    additionalRate.Add(AcE_PROBABILITY_CATEGORY.MATERIAL, AcTryParse.AsFloat(expeditionAreaEventData.subParam2));
                }
            }
            else
            {
                additionalRate.Add(AcE_PROBABILITY_CATEGORY.FOOD, AcTryParse.AsFloat(expeditionAreaEventData.subParam2));
            }
        }
        foreach (KeyValuePair<int, int> keyValuePair2 in fieldTypeData.fixedItems)
        {
            dictionary.Add(keyValuePair2.Key, keyValuePair2.Value);
        }
        return dictionary;
    }

    public List<ExpeditionAreaData> ChoosDistricts(int code, int count = 2, bool duplicate = false)
    {
        List<ExpeditionAreaData> list = this.FindArea(code);
        List<AcChoose.AcChoosObject> list2 = new List<AcChoose.AcChoosObject>();
        float prob = 1f;
        foreach (ExpeditionAreaData data in list)
        {
            list2.Add(new AcChoose.AcChoosObject(prob, data));
        }
        list2.Add(new AcChoose.AcChoosObject(prob, this.FindAreaData(250, 1)));
        list2.Add(new AcChoose.AcChoosObject(prob, this.FindAreaData(250, 2)));
        list2.Add(new AcChoose.AcChoosObject(prob, this.FindAreaData(261, 1)));
        List<AcChoose.AcChoosObject> list3 = AcChoose.ChooseMultiple(list2, count, duplicate);
        List<ExpeditionAreaData> list4 = new List<ExpeditionAreaData>();
        foreach (AcChoose.AcChoosObject acChoosObject in list3)
        {
            list4.Add(acChoosObject.data as ExpeditionAreaData);
        }
        return list4;
    }

    private readonly Dictionary<int, List<ExpeditionAreaData>> dicExpeditionArea;

    public readonly int expeditionAreaMaxClear;

    private readonly List<ExpeditionGlobalnfo> expeditionGlobalInfo;

    public class Model
    {
        public List<ExpeditionAreaData> expeditionArea { get; set; }

        public int expeditionAreaMaxClear { get; set; }

        public List<ExpeditionGlobalnfo> expeditionGlobalInfo { get; set; }
    }
}
