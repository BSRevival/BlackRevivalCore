using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Field;

namespace BlackRevival.Common.GameDB;

public class FieldTypeDB
{
	public static FieldTypeDB Instance { get; private set; }
	public FieldTypeDB()
	{
		this.fields = new List<FieldTypeData>();
		this.restrictFieldTimes = new List<RestrictFieldTime>();
		Instance = this;
	}

	public FieldTypeDB(FieldTypeDB.Model model)
	{
		this.fields = model.fields;
		this.restrictFieldTimes = model.restrictFieldTimes;
		this.placedItemDataCache = new Dictionary<int, PlacedItemData>();
		this.cachedItemMapType = new Dictionary<int, MapType>();
		Instance = this;
	}

	public FieldTypeData Find(int code)
	{
		return this.fields.Find((FieldTypeData data) => data.code == code);
	}

	public List<FieldTypeData> FindAllByMapType(MapType mapType, bool isExceptPowCamp)
	{
		List<FieldTypeData> list = this.fields.FindAll((FieldTypeData data) => data.mapType == mapType);
		if (!isExceptPowCamp)
		{
			if (this.fields.Exists((FieldTypeData x) => x.IsPowCamp))
			{
				list.Add(this.fields.Find((FieldTypeData x) => x.IsPowCamp));
			}
		}
		return list;
	}

	public List<FieldTypeData> FindAll(MapType mapType, bool isExceptPowCamp)
	{
		List<FieldTypeData> list = this.fields.FindAll((FieldTypeData x) => x.mapType == mapType);
		if (!isExceptPowCamp)
		{
			list.Add(this.fields.Find((FieldTypeData x) => x.IsPowCamp));
		}
		return list;
	}

	/*public int GetNextReducedTime(PlayMode playMode, int currentStep)
	{
		RestrictFieldTime restrictFieldTime = this.restrictFieldTimes.Find((RestrictFieldTime x) => x.step == currentStep);
		if (restrictFieldTime == null)
		{
			return 0;
		}
		RestrictFieldTime restrictFieldTime2 = this.restrictFieldTimes.Find((RestrictFieldTime x) => x.step == currentStep + 1);
		if (restrictFieldTime2 == null)
		{
			return 0;
		}
		if (playMode.IsTeamMode())
		{
			return restrictFieldTime.seoulDuration - restrictFieldTime2.seoulDuration;
		}
		return restrictFieldTime.lumiaDuration - restrictFieldTime2.lumiaDuration;
	}

	public int GetRestrcitFieldDuration(PlayMode playMode, int step)
	{
		RestrictFieldTime restrictFieldTime = this.restrictFieldTimes.Find((RestrictFieldTime x) => x.step == step);
		if (restrictFieldTime == null)
		{
			AcLogger.LogError("[FieldTypeDB.GetRestrcitFieldDuration] not found step");
			return 120;
		}
		if (playMode.IsTeamMode())
		{
			return restrictFieldTime.seoulDuration;
		}
		return restrictFieldTime.lumiaDuration;
	}

	public bool TryFindPlacedItemData(MapType mapType, int itemCode, out PlacedItemData placedItemData)
	{
		placedItemData = this.FindPlacedItemData(mapType, itemCode);
		return placedItemData != null;
	}*/

	public PlacedItemData FindPlacedItemData(MapType mapType, int itemCode)
	{
		if (this.placedItemDataCache.ContainsKey(itemCode) && this.cachedItemMapType[itemCode] == mapType)
		{
			return this.placedItemDataCache[itemCode];
		}
		PlacedItemData placedItemData = new PlacedItemData();
		List<FieldTypeData> list = this.fields;
		/*Predicate<FieldTypeData> <>9__0;
		Predicate<FieldTypeData> match;
		if ((match = <>9__0) == null)
		{
			match = (<>9__0 = (FieldTypeData x) => x.mapType == mapType);
		}
		foreach (FieldTypeData fieldTypeData in list.FindAll(match))
		{
			if (fieldTypeData.fixedItems.ContainsKey(itemCode))
			{
				placedItemData.Add(fieldTypeData, fieldTypeData.fixedItems[itemCode]);
			}
		}*/
		this.placedItemDataCache[itemCode] = placedItemData;
		this.cachedItemMapType[itemCode] = mapType;
		return placedItemData;
	}

	public PlacedItemData FindPlacedItemDataExceptList(int itemCode, List<int> restrictedFields)
	{
		PlacedItemData placedItemData = new PlacedItemData();
		foreach (FieldTypeData fieldTypeData in this.fields)
		{
			if ((restrictedFields == null || !restrictedFields.Contains(fieldTypeData.code)) && fieldTypeData.fixedItems.ContainsKey(itemCode))
			{
				placedItemData.Add(fieldTypeData, fieldTypeData.fixedItems[itemCode]);
			}
		}
		return placedItemData;
	}

	public string GetFieldName(int fieldTypeCode)
	{
		FieldTypeData fieldTypeData = this.Find(fieldTypeCode);
		if (fieldTypeData != null)
		{
			return fieldTypeData.Name;
		}
		return "";
	}

	public string GetMapCode(int fieldTypeCode)
	{
		FieldTypeData fieldTypeData = this.Find(fieldTypeCode);
		if (fieldTypeData != null)
		{
			return fieldTypeData.MapCode;
		}
		return "";
	}

	public FieldTypeData GetMostAcquiarableFieldData(MapType mapType, int itemCode, List<int> restrictedField = null)
	{
		PlacedItemData placedItemData;
		if (restrictedField == null)
		{
			placedItemData = this.FindPlacedItemData(mapType, itemCode);
		}
		else
		{
			placedItemData = this.FindPlacedItemDataExceptList(itemCode, restrictedField);
		}
		if (placedItemData == null)
		{
			return null;
		}
		if (placedItemData.Count == 0)
		{
			return null;
		}
		return placedItemData.AtIndex(0).fieldTypeData;
	}

	public bool HaveMinimap(int code)
	{
		FieldTypeData fieldTypeData = this.Find(code);
		return fieldTypeData != null && fieldTypeData.HaveMinimap;
	}

	/*public Dictionary<ItemData, int> getCanFoundItemList(int fieldType, Dictionary<ItemData, int> needItems)
	{
		foreach (FieldTypeData fieldTypeData in this.fields)
		{
			if (fieldTypeData.code == fieldType)
			{
				return fieldTypeData.getCanFoundItemList(fieldType, needItems);
			}
		}
		return null;
	}

	public Dictionary<int, int> getRecommandFieldDic(MapType mapType, int exceptfieldType, Dictionary<ItemData, int> needItems, Dictionary<ItemData, int> itemValues)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (FieldTypeData fieldTypeData in this.fields)
		{
			if (fieldTypeData.mapType.Equals(mapType) && fieldTypeData.code != exceptfieldType)
			{
				int num = fieldTypeData.getValueFoundItemList(fieldTypeData.code, needItems, itemValues).Sum((KeyValuePair<ItemData, int> x) => x.Value);
				if (num > 0)
				{
					dictionary.Add(fieldTypeData.code, num);
				}
			}
		}
		dictionary = (from s in dictionary
			orderby s.Value descending
			select s).ToDictionary((KeyValuePair<int, int> pair) => pair.Key, (KeyValuePair<int, int> pair) => pair.Value);
		return dictionary;
	}

	public bool isDropItem(MapType mapType, ItemData itemData)
	{
		bool flag = false;
		foreach (FieldTypeData fieldTypeData in this.fields)
		{
			if (!flag && fieldTypeData.mapType.Equals(mapType) && fieldTypeData.fixedItems.ContainsKey(itemData.code))
			{
				flag = true;
			}
		}
		return flag;
	}

	public List<int> getDropFields(MapType mapType, ItemData itemData)
	{
		List<int> list = new List<int>();
		foreach (FieldTypeData fieldTypeData in this.fields)
		{
			if (fieldTypeData.mapType.Equals(mapType) && fieldTypeData.fixedItems.ContainsKey(itemData.code))
			{
				list.Add(fieldTypeData.code);
			}
		}
		return list;
	}*/

	private List<FieldTypeData> fields { get; set; } 

	private Dictionary<int, PlacedItemData> placedItemDataCache { get; set; }

	private List<RestrictFieldTime> restrictFieldTimes { get; set; } 

	private Dictionary<int, MapType> cachedItemMapType { get; set; }

	public class Model
	{
		public List<FieldTypeData> fields { get; set; }

		public List<RestrictFieldTime> restrictFieldTimes { get; set; }
	}
}