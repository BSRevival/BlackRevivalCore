using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Item;
using BlackRevival.Common.Model;
using Serilog;

namespace BlackRevival.Common.GameDB;

public class ItemDB
{
	public static ItemDB Instance { get; private set; }
    public ItemDB()
	{
		this.items = new List<ItemData>();
		this.itemCombinations = new List<ItemCombinationData>();
		this.itemOptionDatas = new List<ItemOptionData>();
		this.startingItems = new List<StartingItemData>();
		this._itemDic = new Dictionary<int, ItemData>();
		
		Instance = this;
	}

	public ItemDB(ItemDB.Model data)
	{
		this.items = data.items;
		this.itemCombinations = data.itemCombination;
		this.itemOptionDatas = data.itemOptionColor;
		this.startingItems = data.startingItems;
		foreach (ItemData itemData in this.items)
		{
			itemData.Init(this.items, this.itemCombinations);
		}
		this._itemDic = this.items.ToDictionary((ItemData x) => x.code);
		Instance = this;
	}

	public ItemData Find(int itemCode)
	{
		ItemData itemData = this.items.Find((ItemData data) => data.code == itemCode);
		if (itemData == null)
		{
			return new ItemData();
		}
		return itemData;
	}

	public bool TryFindFast(int itemCode, out ItemData itemData)
	{
		itemData = this.FindFast(itemCode);
		return itemData.code > 0;
	}

	public ItemData FindFast(int itemCode)
	{
		ItemData result;
		if (this._itemDic.TryGetValue(itemCode, out result))
		{
			return result;
		}
		return new ItemData();
	}

	public bool TryFind(int itemCode, out ItemData itemData)
	{
		itemData = this.Find(itemCode);
		return itemData.code > 0;
	}

	public ItemOptionData FindOption(ItemBaseAbility property)
	{
		ItemOptionData itemOptionData = this.itemOptionDatas.Find((ItemOptionData data) => data.itemBaseAbility == property);
		if (itemOptionData == null)
		{
			Log.Error($"[ItemDB.FindOption] Failed to find ItemBaseAbility: {property}");
			return null;
		}
		return itemOptionData;
	}

	public List<ItemData> FindItemsByItemType(MapType mapType, ItemType itemType)
	{
		return this.items.FindAll((ItemData data) => data.itemType == itemType && data.mapTypeList.Contains(mapType));
	}

	public List<ItemData> FindLoadableItem(LoadableType loadableType)
	{
		return this.items.FindAll((ItemData data) => data.itemType == ItemType.AMMO && data.loadableType == loadableType);
	}

	public List<ItemData> FindItemsByWeaponType(AcE_WEAPON_TYPE weaponType)
	{
		return this.items.FindAll((ItemData data) => data.weaponType == weaponType);
	}

	public List<ItemData> FindItemsByWeaponType(AcE_WEAPON_TYPE weaponType, MapType mapType)
	{
		return this.items.FindAll((ItemData data) => data.weaponType == weaponType && data.mapTypeList.Contains(mapType));
	}

	public string GetItemName(int item)
	{
		ItemData itemData = this.Find(item);
		if (itemData == null)
		{
			return "";
		}
		return itemData.GetItemName();
	}

	public string GetColorItemName(int item)
	{
		ItemData itemData = this.Find(item);
		if (itemData == null)
		{
			return "";
		}
		return itemData.GetItemColorName();
	}

	public string GetDicItemName(int item)
	{
		ItemData itemData = this.Find(item);
		if (itemData == null)
		{
			return "";
		}
		return itemData.GetDicItemName();
	}

	public string GetItemDesc(int item)
	{
		ItemData itemData = this.Find(item);
		if (itemData == null)
		{
			return "";
		}
		return itemData.GetItemDesc();
	}

	public string GetItemConditionDesc(int item)
	{
		ItemData itemData = this.Find(item);
		if (itemData == null)
		{
			return string.Empty;
		}
		return itemData.GetItemConditionDesc();
	}
	
	public List<ItemData> FindItemsByTypes(MapType mapType, ItemType itemType, AcE_WEAPON_TYPE weaponType)
	{
		List<ItemData> list = new List<ItemData>();
		if (itemType != ItemType.NONE)
		{
			list = this.FindItemsByItemType(mapType, itemType);
			if (itemType == ItemType.MATERIAL)
			{
				list.AddRange(this.FindItemsByItemType(mapType, ItemType.AMMO));
			}
			list.Sort(new Comparison<ItemData>(this.CalcuratingItem));
			return list;
		}
		if (weaponType != AcE_WEAPON_TYPE.NONE)
		{
			list.AddRange(this.FindItemsByWeaponType(weaponType));
			if (weaponType == AcE_WEAPON_TYPE.BLADE || weaponType == AcE_WEAPON_TYPE.STAB)
			{
				list.AddRange(this.FindItemsByWeaponType(AcE_WEAPON_TYPE.BLADE_STAB));
			}
			list.Sort(new Comparison<ItemData>(this.CalcuratingItem));
			return list;
		}
		return list;
	}

	public int CalcuratingItem(ItemData x, ItemData y)
	{
		if (x.itemGrade != y.itemGrade)
		{
			return y.itemGrade.CompareTo(x.itemGrade);
		}
		if (x.GetActivePoint() == y.GetActivePoint())
		{
			return y.code.CompareTo(x.code);
		}
		return y.GetActivePoint().CompareTo(x.GetActivePoint());
	}

	public ItemData GetRandom()
	{
		Random random = new Random();
		return this.items[random.Next(0, this.items.Count)];
	}

	public ItemData Combine(int materialItemA, int materialItemB)
	{
		ItemCombinationData itemCombinationData = this.itemCombinations.Find((ItemCombinationData combination) => (combination.addend == materialItemA && combination.augend == materialItemB) || (combination.addend == materialItemB && combination.augend == materialItemA));
		return this.Find((itemCombinationData == null) ? 0 : itemCombinationData.result);
	}

	public bool TryGetStartingItem(MapType mapType, out List<StartingItemData> startingItemData)
	{
		startingItemData = this.GetStartingItemList(mapType);
		return startingItemData != null;
	}

	public List<StartingItemData> GetStartingItemList(MapType mapType)
	{
		List<StartingItemData> list = this.startingItems.FindAll((StartingItemData x) => x.mapType == mapType);
		if (list.Count <= 0)
		{
			Log.Error(string.Format("{0} is Null or Empty || {1} == {2}", "outData", "MapType", mapType));
		}
		return list;
	}

	public bool TryGetStartingItemList(ItemType itemType, out List<StartingItemData> startingItemData)
	{
		startingItemData = this.GetStartingItemList(itemType);
		return startingItemData != null;
	}

	public List<StartingItemData> GetStartingItemList(ItemType itemType)
	{
		return this.startingItems.FindAll((StartingItemData x) => x.itemType == itemType);
	}

	public bool TryGetStartingItemList(MapType mapType, ItemData itemData, out List<StartingItemData> dataList)
	{
		dataList = this.GetStartingItemList(mapType, itemData);
		return dataList != null && dataList.Count > 0;
	}

	public List<StartingItemData> GetStartingItemList(MapType mapType, ItemData itemData)
	{
		if (itemData.itemType != ItemType.WEAPON)
		{
			return this.GetStartingItemList(mapType, itemData.itemType);
		}
		return this.GetStartingItemList(mapType, itemData.itemType, itemData.weaponType);
	}

	public bool TryGetStartingItem(MapType mapType, ItemType itemType, out StartingItemData data)
	{
		data = this.GetStartingItem(mapType, itemType);
		return data != null;
	}

	public bool TryGetStartingItemList(MapType mapType, ItemType itemType, out List<StartingItemData> dataList)
	{
		dataList = this.GetStartingItemList(mapType, itemType);
		return dataList != null && dataList.Count > 0;
	}

	public StartingItemData GetStartingItem(MapType mapType, ItemType itemType)
	{
		return this.GetStartingItemList(mapType, itemType).First<StartingItemData>();
	}

	public List<StartingItemData> GetStartingItemList(MapType mapType, ItemType itemType)
	{
		return this.startingItems.FindAll((StartingItemData x) => x.mapType == mapType && x.itemType == itemType);
	}

	public bool TryGetStartingItem(MapType mapType, ItemType itemType, AcE_WEAPON_TYPE weaponType, out StartingItemData data)
	{
		data = this.GetStartingItem(mapType, itemType, weaponType);
		return data != null;
	}

	public bool TryGetStartingItemList(MapType mapType, ItemType itemType, AcE_WEAPON_TYPE weaponType, out List<StartingItemData> dataList)
	{
		dataList = this.GetStartingItemList(mapType, itemType, weaponType);
		return dataList != null && dataList.Count > 0;
	}

	public StartingItemData GetStartingItem(MapType mapType, ItemType itemType, AcE_WEAPON_TYPE weaponType)
	{
		return this.GetStartingItemList(mapType, itemType, weaponType).FirstOrDefault<StartingItemData>();
	}

	public List<StartingItemData> GetStartingItemList(MapType mapType, ItemType itemType, AcE_WEAPON_TYPE weaponType)
	{
		if (weaponType != AcE_WEAPON_TYPE.BLADE_STAB)
		{
			return this.startingItems.FindAll((StartingItemData x) => x.mapType == mapType && x.itemType == itemType && x.weaponType == weaponType);
		}
		return this.startingItems.FindAll((StartingItemData x) => x.mapType == mapType && x.itemType == itemType && (x.weaponType == AcE_WEAPON_TYPE.BLADE || x.weaponType == AcE_WEAPON_TYPE.STAB));
	}

	public List<ItemCombinationData> GetCombinationsData()
	{
		return this.itemCombinations;
	}

	public bool TryGetUltimateItemList(int itemCode, out List<ItemData> itemCodeList)
	{
		itemCodeList = GetUltimateItemList(itemCode);
		List<ItemData> obj = itemCodeList;
		if (obj == null)
		{
			return false;
		}
		return obj.Count > 0;
	}

	public bool TryGetUltimateItemList(int itemCode, out List<ItemData> itemCodeList, params AcE_WEAPON_TYPE[] weaponTypes)
	{
		itemCodeList = GetUltimateItemList(itemCode, weaponTypes);
		List<ItemData> obj = itemCodeList;
		if (obj == null)
		{
			return false;
		}
		return obj.Count > 0;
	}

	public List<ItemData> GetUltimateItemList(int itemCode, params AcE_WEAPON_TYPE[] weaponTypes)
	{
		return GetUltimateItemList(itemCode).FindAll((ItemData x) => weaponTypes.Any((AcE_WEAPON_TYPE weaponType) => x.weaponType.IsContainsWeapon(weaponType)));
	}

	public List<ItemData> GetUltimateItemList(int itemCode)
	{
		Queue<int> materialQueue = new Queue<int>();
		List<int> list = new List<int>();
		itemCombinations.FindAll((ItemCombinationData x) => x.addend == itemCode || x.augend == itemCode).ForEach(delegate(ItemCombinationData x)
		{
			materialQueue.Enqueue(x.code);
		});
		while (materialQueue.Count > 0)
		{
			int count = materialQueue.Count;
			for (int i = 0; i < count; i++)
			{
				int materialCode = materialQueue.Dequeue();
				itemCombinations.FindAll((ItemCombinationData x) => x.addend == materialCode || x.augend == materialCode).ForEach(delegate(ItemCombinationData x)
				{
					materialQueue.Enqueue(x.code);
				});
				list.Add(materialCode);
			}
		}
		return (from x in list.Distinct().Select(FindFast)
			where x.itemGrade == ItemGrade.EPIC || x.itemGrade == ItemGrade.LEGEND
			select x).ToList();
	}

	public bool IsMaterial(int itemID, int materialItemID)
	{
		return itemID != 0 && materialItemID != 0 && (itemID == materialItemID || this.IsMaterial(this.Find(itemID).GetMaterial1(MapType.LUMIA), materialItemID) || this.IsMaterial(this.Find(itemID).GetMaterial2(MapType.LUMIA), materialItemID));
	}

	private List<ItemData> items { get; set; }

	private List<ItemCombinationData> itemCombinations { get; set; }

	private List<ItemOptionData> itemOptionDatas { get; set; }

	private List<StartingItemData> startingItems { get; set; }

	private Dictionary<int, ItemData> _itemDic = new Dictionary<int, ItemData>();

	public class Model
	{
		public List<ItemData> items { get; set; }

		public List<ItemCombinationData> itemCombination { get; set; }

		public List<ItemOptionData> itemOptionColor { get; set; }

		public List<StartingItemData> startingItems { get; set; }
	}
}