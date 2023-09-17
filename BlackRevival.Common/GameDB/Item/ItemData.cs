using System.Drawing;
using System.Text;
using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Field;
using BlackRevival.Common.GameDB.Skills;
using BlackRevival.Common.Model;
using Serilog;

namespace BlackRevival.Common.GameDB.Item;

public class ItemData
{
    [JsonIgnore]
	public SkillData skillData
	{
		get
		{
			return GameDB.SkillDB.Instance.Find(this.skillId);
		}
		private set
		{
		}
	}

	public ItemType itemType
	{
		get
		{
			return (ItemType)this.itemTypeCode;
		}
	}

	public ItemSubType itemSubType
	{
		get
		{
			return (ItemSubType)this.itemSubTypeCode;
		}
	}

	public ItemData()
	{
		this.isHighRankItem.Clear();
		this.isHighRankItem.Add(MapType.LUMIA, false);
		this.isHighRankItem.Add(MapType.SEOUL, false);
		this.isHighRankItem.Add(MapType.EXPEDITION, false);
		this.augendItem.Clear();
		this.augendItem.Add(MapType.SEOUL, 0);
		this.augendItem.Add(MapType.LUMIA, 0);
		this.augendItem.Add(MapType.EXPEDITION, 0);
		this.addendItem.Clear();
		this.addendItem.Add(MapType.SEOUL, 0);
		this.addendItem.Add(MapType.LUMIA, 0);
		this.addendItem.Add(MapType.EXPEDITION, 0);
		this.childItemList = new List<int>();
		this.synthesizableItems = null;
	}

	public void Init(List<ItemData> items, List<ItemCombinationData> itemCombinations)
	{
		this.itemName = LocalizationDB.Instance.ItemName(this.code);
		this.itemDesc = LocalizationDB.Instance.ItemDesc(this.code);
		if (this.itemSubType == ItemSubType.EVOLUTION)
		{
			this.itemConditionDesc = LocalizationDB.Instance.ItemConditionDesc(this.code);
		}
		this.InitMaterialItems(items, itemCombinations);
		this.InitSynthesizableItems(items, itemCombinations);
	}

	public string GetItemName()
	{
		return this.itemName;
	}

	public string GetDicItemName()
	{
		return LocalizationDB.Instance.DicItemName(this.code);
	}

	public string GetItemColorName()
	{
		return string.Format("[{1}]{0}[-]", this.GetItemName(), this.GetGradeColor(false));
	}

	public string GetDicItemColorName()
	{
		return string.Format("[{1}]{0}[-]", this.GetDicItemName(), this.GetGradeColor(false));
	}

	public string GetItemDesc()
	{
		return this.itemDesc;
	}

	public string GetItemConditionDesc()
	{
		return this.itemConditionDesc;
	}

	public List<ItemData> GetSynthesizableItems()
	{
		return this.synthesizableItems;
	}

	private class localClass
	{
		internal ItemData theItem;

		internal List<ItemCombinationData> combinationDatas;

		internal List<ItemData> items;
	}
	private void InitSynthesizableItems(List<ItemData> items, List<ItemCombinationData> itemCombinations)
	{
		localClass locals = new localClass();
		locals.theItem = this;
		this.synthesizableItems = new List<ItemData>();
		locals.combinationDatas = itemCombinations.FindAll((ItemCombinationData combination) => combination.addend == locals.theItem.code || combination.augend == locals.theItem.code);
		int i;
		int j;
		for (i = 0; i < locals.combinationDatas.Count; i = j + 1)
		{
			ItemData item = items.Find((ItemData t) => t.code == locals.combinationDatas[i].result);
			if (!this.synthesizableItems.Contains(item))
			{
				this.synthesizableItems.Add(item);
			}
			j = i;
		}
	}

	private void InitMaterialItems(List<ItemData> items, List<ItemCombinationData> itemCombinations)
	{
		ItemCombinationData combinationData = itemCombinations.Find((ItemCombinationData combination) => combination.result == this.code);
		if (combinationData != null)
		{
			this.addendItemData.Clear();
			this.augendItemData.Clear();
			if (combinationData.mapType.Contains(MapType.LUMIA))
			{
				this.augendItem[MapType.LUMIA] = combinationData.augend;
				this.addendItem[MapType.LUMIA] = combinationData.addend;
				this.isHighRankItem[MapType.LUMIA] = true;
			}
			if (combinationData.mapType.Contains(MapType.SEOUL))
			{
				this.augendItem[MapType.SEOUL] = combinationData.augend;
				this.addendItem[MapType.SEOUL] = combinationData.addend;
				this.isHighRankItem[MapType.SEOUL] = true;
			}
			if (combinationData.mapType.Contains(MapType.EXPEDITION))
			{
				this.augendItem[MapType.EXPEDITION] = combinationData.augend;
				this.addendItem[MapType.EXPEDITION] = combinationData.addend;
				this.isHighRankItem[MapType.EXPEDITION] = true;
			}
			ItemData itemData = items.Find((ItemData t) => t.code == combinationData.augend);
			if (itemData != null)
			{
				if (combinationData.mapType.Contains(MapType.LUMIA))
				{
					this.augendItemData.Add(MapType.LUMIA, itemData);
				}
				if (combinationData.mapType.Contains(MapType.SEOUL))
				{
					this.augendItemData.Add(MapType.SEOUL, itemData);
				}
				if (combinationData.mapType.Contains(MapType.EXPEDITION))
				{
					this.augendItemData.Add(MapType.EXPEDITION, itemData);
				}
			}
			ItemData itemData2 = items.Find((ItemData t) => t.code == combinationData.addend);
			if (itemData2 != null)
			{
				if (combinationData.mapType.Contains(MapType.LUMIA))
				{
					this.addendItemData.Add(MapType.LUMIA, itemData2);
				}
				if (combinationData.mapType.Contains(MapType.SEOUL))
				{
					this.addendItemData.Add(MapType.SEOUL, itemData2);
				}
				if (combinationData.mapType.Contains(MapType.EXPEDITION))
				{
					this.addendItemData.Add(MapType.EXPEDITION, itemData2);
				}
			}
		}
	}

	public string GetItemCodeName()
	{
		string result;
		try
		{
			result = ((AcE_Item)this.code).ToString();
		}
		catch (Exception ex)
		{
			Log.Error(ex.Message);
			result = "";
		}
		return result;
	}

	public bool IsMagazineItem()
	{
		return !this.IsLoadableItem() && this.loadableType == LoadableType.BULLET;
	}

	public bool IsQuiverItem()
	{
		return !this.IsLoadableItem() && this.loadableType == LoadableType.ARROW;
	}

	public bool IsLoadableItem()
	{
		return this.itemType == ItemType.AMMO;
	}

	public bool IsProjectileWeapon()
	{
		return (this.weaponType == AcE_WEAPON_TYPE.GUN && this.loadableType == LoadableType.BULLET) || (this.weaponType == AcE_WEAPON_TYPE.BOW && this.loadableType == LoadableType.ARROW);
	}

	public bool IsPVEProjectileWeapon()
	{
		return (this.weaponType == AcE_WEAPON_TYPE.GUN && this.loadableType == LoadableType.BULLET) || (this.weaponType == AcE_WEAPON_TYPE.BOW && this.loadableType == LoadableType.ARROW) || this.weaponType == AcE_WEAPON_TYPE.THROW;
	}

	public TopItemType GetTopCategory()
	{
		switch (this.itemType)
		{
		case ItemType.ARM_PROTECTOR:
		case ItemType.CHEST_PROTECTOR:
		case ItemType.HEAD_PROTECTOR:
		case ItemType.LEG_PROTECTOR:
		case ItemType.TRINKET:
			return TopItemType.PROTECTOR;
		case ItemType.HEALTH_FOOD:
			return TopItemType.HEALTH_FOOD;
		case ItemType.STAMINA_FOOD:
			return TopItemType.STAMINA_FOOD;
		case ItemType.WEAPON:
			return TopItemType.WEAPON;
		case ItemType.TRAP:
			return TopItemType.TRAP;
		}
		return TopItemType.MISC;
	}

	public bool IsHighRankItem(MapType mapType)
	{
		return this.isHighRankItem[mapType];
	}

	public int GetMaterial1(MapType mapType)
	{
		if (!this.augendItem.ContainsKey(mapType))
		{
			return 0;
		}
		return this.augendItem[mapType];
	}

	public ItemData GetMaterialData1(MapType mapType)
	{
		if (!this.augendItemData.ContainsKey(mapType))
		{
			return null;
		}
		return this.augendItemData[mapType];
	}

	public int GetMaterial2(MapType mapType)
	{
		if (!this.addendItem.ContainsKey(mapType))
		{
			return 0;
		}
		return this.addendItem[mapType];
	}

	public ItemData GetMaterialData2(MapType mapType)
	{
		if (!this.addendItemData.ContainsKey(mapType))
		{
			return null;
		}
		return this.addendItemData[mapType];
	}

	public List<int> GetTotalMaterials(MapType mapType)
	{
		List<int> list = new List<int>
		{
			this.GetMaterial1(mapType),
			this.GetMaterial2(mapType)
		};
		if (this.IsExsitMaterial(this.GetMaterialData1(mapType), mapType))
		{
			list.AddRange(this.GetMaterialData1(mapType).GetTotalMaterials(mapType).ToArray());
		}
		if (this.IsExsitMaterial(this.GetMaterialData2(mapType), mapType))
		{
			list.AddRange(this.GetMaterialData2(mapType).GetTotalMaterials(mapType).ToArray());
		}
		list.RemoveAll((int x) => x == 0);
		return list;
	}

	public List<NavigatorMaterialData> GetTotalMaterials(int grade, MapType mapType)
	{
		grade++;
		List<NavigatorMaterialData> list = new List<NavigatorMaterialData>();
		if (this.GetMaterialData1(mapType) != null)
		{
			list.Add(new NavigatorMaterialData
			{
				item = this.GetMaterialData1(mapType),
				targetItem = this,
				isLeft = true,
				TreeGrade = grade
			});
			list.AddRange(this.GetMaterialData1(mapType).GetTotalMaterials(grade, mapType));
		}
		if (this.GetMaterialData2(mapType) != null)
		{
			list.Add(new NavigatorMaterialData
			{
				item = this.GetMaterialData2(mapType),
				targetItem = this,
				isLeft = false,
				TreeGrade = grade
			});
			list.AddRange(this.GetMaterialData2(mapType).GetTotalMaterials(grade, mapType));
		}
		return list;
	}

	private bool IsExsitMaterial(ItemData item, MapType mapType)
	{
		return item != null && (item.GetMaterial1(mapType) != 0 || item.GetMaterial2(mapType) != 0);
	}

	public bool IsExsitMaterial(MapType mapType)
	{
		return this.GetMaterial1(mapType) != 0 || this.GetMaterial2(mapType) != 0;
	}

	public ItemData FindNonExistMaterial(List<FieldItem> fieldItems, MapType mapType)
	{
		if (fieldItems.Find((FieldItem target) => target.item == this.augendItem[mapType]) == null)
		{
			return this.GetMaterialData1(mapType);
		}
		if (fieldItems.Find((FieldItem target) => target.item == this.addendItem[mapType]) == null)
		{
			return this.GetMaterialData2(mapType);
		}
		return null;
	}

	public bool CheckMaterialInFieldItems(List<FieldItem> fieldItems)
	{
		Log.Error("getin 2");
		bool result = false;
		using (List<MapType>.Enumerator enumerator = this.mapTypeList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				MapType map = enumerator.Current;
				result = fieldItems.Find((FieldItem target) => target.item == this.augendItem[map]) != null && fieldItems.Find((FieldItem target) => target.item == this.addendItem[map]) != null;
			}
		}
		return result;
	}

	public bool IsMyMaterial(ItemData itemData, MapType mapType)
	{
		return itemData != null && (itemData.code == this.addendItem[mapType] || itemData.code == this.augendItem[mapType]);
	}

	public bool HasDurability()
	{
		return this.durability > 0;
	}

	public bool IsBrokenItem()
	{
		return this.baseOffence > 20f || this.weaponType == AcE_WEAPON_TYPE.GUN || this.weaponType == AcE_WEAPON_TYPE.BOW;
	}

	public bool GetUseableSkill(bool isPvEModeItem = false)
	{
		return this.skillData != null && this.skillData.UseableSkill(isPvEModeItem);
	}

	public string GetItemSkillName(bool isPvEModeItem = false)
	{
		if (this.skillData != null && this.GetUseableSkill(isPvEModeItem))
		{
			return this.skillData.GetName(isPvEModeItem);
		}
		return "";
	}

	public string GetItemSpecialtyCooltime(bool isPvEModeItem = false)
	{
		if (this.skillData != null && this.skillData.coolTime > 0 && this.GetUseableSkill(isPvEModeItem))
		{
			return string.Format("({0} {1})", LocalizationDB.Instance.Dynamic("쿨타임"), this.skillData.coolTime);
		}
		return string.Empty;
	}

	public string GetItemSpecialtyDesc(bool isPvEModeItem = false)
	{
		if (this.skillData != null && this.GetUseableSkill(isPvEModeItem))
		{
			return this.skillData.GetDesc(isPvEModeItem);
		}
		return "";
	}

	public string GetItemSkillDescAdd(bool isPvEModeItem = false)
	{
		if (this.skillData != null && this.GetUseableSkill(isPvEModeItem))
		{
			return this.skillData.GetDescAdd(isPvEModeItem);
		}
		return "";
	}


	public bool IsStackableItem()
	{
		if (this.weaponType == AcE_WEAPON_TYPE.THROW)
		{
			return true;
		}
		switch (this.itemType)
		{
		case ItemType.HEALTH_FOOD:
		case ItemType.STAMINA_FOOD:
		case ItemType.AMMO:
		case ItemType.TRAP:
		case ItemType.MATERIAL:
			return true;
		}
		return false;
	}

	public int IsMoreValueableThan(ItemData target)
	{
		int num = this.itemGrade - target.itemGrade;
		if (num != 0)
		{
			return num;
		}
		return this.CalculateActivePointGap(target);
	}

	public int CalculateActivePointGap(ItemData target)
	{
		return this.GetActivePoint() - target.GetActivePoint();
	}

	public bool IsEquipable()
	{
		ItemType itemType = this.itemType;
		return itemType - ItemType.ARM_PROTECTOR <= 4 || itemType == ItemType.WEAPON;
	}

	public bool IsFoodItem()
	{
		return this.itemType == ItemType.HEALTH_FOOD || this.itemType == ItemType.STAMINA_FOOD;
	}

	public bool IsAlcoholItem()
	{
		return this.staminaFoodCategory == 1;
	}

	public int GetActivePoint()
	{
		switch (this.itemType)
		{
		case ItemType.ARM_PROTECTOR:
		case ItemType.CHEST_PROTECTOR:
		case ItemType.HEAD_PROTECTOR:
		case ItemType.LEG_PROTECTOR:
		case ItemType.TRINKET:
		case ItemType.HEALTH_FOOD:
		case ItemType.STAMINA_FOOD:
		case ItemType.WEAPON:
		case ItemType.TRAP:
			if (this.properties != null && this.properties.Count > 0)
			{
				return (int)MathF.Floor(this.properties[0].value);
			}
			return 0;
		}
		return 0;
	}

	public int GetNavigationPoint()
	{
		int activePoint = this.GetActivePoint();
		if (this.itemType == ItemType.HEALTH_FOOD || this.itemType == ItemType.STAMINA_FOOD)
		{
			return (int)((float)(activePoint * this.initialBundleQty) * 0.1f);
		}
		return activePoint;
	}

	public string GetCompletePoint()
	{
		if (this.GetActivePoint() > 0)
		{
			return string.Format("{0} {1}", this.GetItemTypeName(), this.GetActivePoint());
		}
		return this.GetItemTypeName();
	}
	
	public string GetWeaponTypeName()
	{
		return this.weaponType.GetName();
	}

	public string GetItemTypeName()
	{
		if (this.itemType == ItemType.WEAPON)
		{
			return this.GetWeaponTypeName();
		}
		return this.itemType.GetItemTypeName();
	}

	public string GetGradeColor(bool grayed = false)
	{
		if (grayed)
		{
			switch (this.itemGrade)
			{
			case ItemGrade.COMMON:
				return "C9C9C9";
			case ItemGrade.UNCOMMON:
				return "519d75";
			case ItemGrade.RARE:
				return "317e9e";
			case ItemGrade.EPIC:
				return "8b51a3";
			case ItemGrade.LEGEND:
				return "98853b";
			default:
				return "FFFFFF";
			}
		}
		else
		{
			switch (this.itemGrade)
			{
			case ItemGrade.COMMON:
				return "C4C4C4";
			case ItemGrade.UNCOMMON:
				return "35ff94";
			case ItemGrade.RARE:
				return "2ac0ff";
			case ItemGrade.EPIC:
				return "d05eff";
			case ItemGrade.LEGEND:
				return "ffd738";
			default:
				return "FFFFFF";
			}
		}
	}



	public string GetStrategyIconName()
	{
		switch (this.itemType)
		{
		case ItemType.HEALTH_FOOD:
			return "Ingame_Navi_Recently_Icon_Hit";
		case ItemType.STAMINA_FOOD:
			return "Ingame_Navi_Recently_Icon_Stamina";
		case ItemType.WEAPON:
			return "Ingame_Navi_Recently_Icon_Attack";
		case ItemType.TRAP:
			return "Ingame_Navi_Recently_Icon_Trap";
		}
		return "Ingame_Navi_Recently_Icon_Defense";
	}

	public float GetItemMakeMasteryPoint()
	{
		float num = 0f;
		switch (this.itemGrade)
		{
		case ItemGrade.COMMON:
			num = 0f;
			break;
		case ItemGrade.UNCOMMON:
			num = 1f;
			break;
		case ItemGrade.RARE:
			num = 2f;
			break;
		case ItemGrade.EPIC:
			num = 3f;
			break;
		case ItemGrade.LEGEND:
			num = 4f;
			break;
		}
		if (this.weaponType == AcE_WEAPON_TYPE.BLADE_STAB)
		{
			return num * 0.5f;
		}
		return num;
	}

	public bool CheckStrategyMatching(List<StrategyType> strategyTypes)
	{
		using (List<StrategyType>.Enumerator enumerator = strategyTypes.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.CompareWithWeaponType(this.weaponType))
				{
					return true;
				}
			}
		}
		return false;
	}

	public ItemBaseStat GetItemOption(ItemBaseAbility baseAbility)
	{
		if (this.properties == null)
		{
			return null;
		}
		return this.properties.Find((ItemBaseStat x) => x.baseAbility == baseAbility);
	}

	public string StatDescBrief(int addPoint)
	{
		string text = string.Empty;
		if (addPoint > 0)
		{
			text = string.Format("{0}([54CA58]+{1}[-])", this.GetActivePoint(), addPoint);
		}
		else if (addPoint < 0)
		{
			text = string.Format("{0}([F22613]{1}[-])", this.GetActivePoint(), addPoint);
		}
		else
		{
			text = string.Format("{0}", this.GetActivePoint());
		}
		switch (this.itemType)
		{
		case ItemType.ARM_PROTECTOR:
		case ItemType.CHEST_PROTECTOR:
		case ItemType.HEAD_PROTECTOR:
		case ItemType.LEG_PROTECTOR:
		case ItemType.TRINKET:
		case ItemType.AMMO:
			return LocalizationDB.Instance.StringFormat("방어력 +{0}", new object[] { text });
		case ItemType.WEAPON:
			return LocalizationDB.Instance.StringFormat("공격력 +{0}", new object[] { text });
		}
		return "???";
	}



	public bool IsWeaponOrArmor()
	{
		return this.itemType == ItemType.ARM_PROTECTOR || this.itemType == ItemType.CHEST_PROTECTOR || this.itemType == ItemType.HEAD_PROTECTOR || this.itemType == ItemType.LEG_PROTECTOR || this.itemType == ItemType.TRINKET || this.itemType == ItemType.WEAPON || this.itemType == ItemType.TRAP;
	}

	public List<ItemData> GetFindItemsByTypes()
	{
		ItemType itemType = ItemType.NONE;
		AcE_WEAPON_TYPE acE_WEAPON_TYPE = AcE_WEAPON_TYPE.NONE;
		if (this.weaponType != AcE_WEAPON_TYPE.NONE)
		{
			acE_WEAPON_TYPE = this.weaponType;
		}
		else
		{
			itemType = this.itemType;
		}
		return GameDB.ItemDB.Instance.FindItemsByTypes(MapType.LUMIA, itemType, acE_WEAPON_TYPE);
	}

	public bool isContainWeaponType(AcE_WEAPON_TYPE weaponType)
	{
		AcE_WEAPON_TYPE acE_WEAPON_TYPE = this.weaponType;
		if (acE_WEAPON_TYPE != AcE_WEAPON_TYPE.BLADE)
		{
			if (acE_WEAPON_TYPE != AcE_WEAPON_TYPE.BLADE_STAB)
			{
				if (acE_WEAPON_TYPE != AcE_WEAPON_TYPE.STAB)
				{
					return this.weaponType.Equals(weaponType);
				}
				if (weaponType.Equals(AcE_WEAPON_TYPE.BLADE_STAB))
				{
					return true;
				}
				if (weaponType.Equals(AcE_WEAPON_TYPE.STAB))
				{
					return true;
				}
			}
			else
			{
				if (weaponType.Equals(AcE_WEAPON_TYPE.BLADE_STAB))
				{
					return true;
				}
				if (weaponType.Equals(AcE_WEAPON_TYPE.BLADE))
				{
					return true;
				}
				if (weaponType.Equals(AcE_WEAPON_TYPE.STAB))
				{
					return true;
				}
			}
		}
		else
		{
			if (weaponType.Equals(AcE_WEAPON_TYPE.BLADE_STAB))
			{
				return true;
			}
			if (weaponType.Equals(AcE_WEAPON_TYPE.BLADE))
			{
				return true;
			}
		}
		return false;
	}

	public bool IsRandomMaterialMakeItem(MapType mapType)
	{
		return (from x in this.GetTotalMaterials(mapType)
			select GameDB.ItemDB.Instance.FindFast(x)).Any(delegate(ItemData material)
		{
			if (material.IsExsitMaterial(mapType))
			{
				return false;
			}
			PlacedItemData placedItemData = GameDB.FieldTypeDB.Instance.FindPlacedItemData(mapType, material.code);
			if (placedItemData == null)
			{
				return false;
			}
			List<PlacedItemData.Entry> entries = placedItemData.entries;
			int? num = ((entries != null) ? new int?(entries.Count) : null);
			int num2 = 0;
			return (num.GetValueOrDefault() <= num2) & (num != null);
		});
	}

	[JsonIgnore]
	public const int Item_None = 0;

	[JsonPropertyName("cod")]
	public readonly int code;

	[JsonPropertyName("mtl")]
	public readonly List<MapType> mapTypeList;

	[JsonPropertyName("itp")]
	public readonly int itemTypeCode;

	[JsonPropertyName("isu")]
	public readonly int itemSubTypeCode;

	[JsonPropertyName("nam")]
	public readonly string name;

	public readonly float cooldown;

	public readonly float globalCooldown;

	[JsonPropertyName("rqt")]
	public readonly int randomQuantity;

	[JsonPropertyName("wpt")]
	public readonly AcE_WEAPON_TYPE weaponType;

	[JsonPropertyName("lcc")]
	public readonly int loadingCapacity;

	[JsonPropertyName("igd")]
	public readonly ItemGrade itemGrade;

	[JsonPropertyName("bof")]
	public readonly float baseOffence;

	[JsonPropertyName("def")]
	public readonly int defence;

	[JsonPropertyName("hcb")]
	public readonly int healthContribution;

	[JsonPropertyName("scb")]
	public readonly int staminaContribution;

	[JsonPropertyName("ski")]
	public readonly int skillId;

	[JsonPropertyName("mio")]
	public readonly int maxInventorOverlapQty;

	[JsonPropertyName("ibq")]
	public readonly int initialBundleQty;

	[JsonPropertyName("lat")]
	public readonly LoadableType loadableType;

	[JsonPropertyName("sfc")]
	private readonly int staminaFoodCategory;

	[JsonPropertyName("dbl")]
	public readonly int durability;

	[JsonPropertyName("itv")]
	public readonly int valueScore;

	[JsonPropertyName("prop")]
	public readonly List<ItemBaseStat> properties;

	[JsonPropertyName("cil")]
	public readonly List<int> childItemList;

	[JsonPropertyName("ag")]
	public readonly float apGrowing;

	[JsonIgnore]
	public const float BROKEN_WEAPON = 20f;

	[JsonIgnore]
	private Dictionary<MapType, bool> isHighRankItem = new Dictionary<MapType, bool>();

	[JsonIgnore]
	private Dictionary<MapType, int> augendItem = new Dictionary<MapType, int>();

	[JsonIgnore]
	private Dictionary<MapType, int> addendItem = new Dictionary<MapType, int>();

	[JsonIgnore]
	private Dictionary<MapType, ItemData> augendItemData = new Dictionary<MapType, ItemData>();

	[JsonIgnore]
	private Dictionary<MapType, ItemData> addendItemData = new Dictionary<MapType, ItemData>();

	[JsonIgnore]
	private List<ItemData> synthesizableItems;

	private string itemName;

	private string itemDesc;

	private string itemConditionDesc;
}