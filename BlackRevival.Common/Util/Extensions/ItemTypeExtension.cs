using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB;
using BlackRevival.Common.GameDB.Item;
using BlackRevival.Common.Model;

public static class ItemTypeExtension
	{
		public static string GetItemTypeName(this ItemType itemType)
		{
			switch (itemType)
			{
			case ItemType.ARM_PROTECTOR:
				return LocalizationDB.Instance.Dynamic("팔");
			case ItemType.CHEST_PROTECTOR:
				return LocalizationDB.Instance.Dynamic("옷");
			case ItemType.HEAD_PROTECTOR:
				return LocalizationDB.Instance.Dynamic("머리");
			case ItemType.LEG_PROTECTOR:
				return LocalizationDB.Instance.Dynamic("다리");
			case ItemType.TRINKET:
				return LocalizationDB.Instance.Dynamic("장식");
			case ItemType.HEALTH_FOOD:
				return LocalizationDB.Instance.Dynamic("체력");
			case ItemType.STAMINA_FOOD:
				return LocalizationDB.Instance.Dynamic("스테미너");
			case ItemType.ENHANCEMENT:
				return LocalizationDB.Instance.Dynamic("강화");
			case ItemType.AMMO:
				return LocalizationDB.Instance.Dynamic("장전용");
			case ItemType.TRAP:
				return LocalizationDB.Instance.Dynamic("트랩");
			case ItemType.MATERIAL:
				return LocalizationDB.Instance.Dynamic("재료");
			case ItemType.SPECIAL:
				return LocalizationDB.Instance.Dynamic("특수");
			}
			return string.Empty;
		}

		public static string GetTypeIcon(this ItemType itemType)
		{
			switch (itemType)
			{
			case ItemType.ARM_PROTECTOR:
				return "Ingame_Status_Icon_arm_02";
			case ItemType.CHEST_PROTECTOR:
				return "Ingame_Status_Icon_armor_02";
			case ItemType.HEAD_PROTECTOR:
				return "Ingame_Status_Icon_head_02";
			case ItemType.LEG_PROTECTOR:
				return "Ingame_Status_Icon_leg_02";
			case ItemType.TRINKET:
				return "Ingame_Status_Icon_deco_02";
			case ItemType.WEAPON:
				return "Ingame_Status_Icon_weapon_02";
			}
			return string.Empty;
		}

		public static int GetEquipSlotNumber(this ItemType itemType)
		{
			switch (itemType)
			{
			case ItemType.ARM_PROTECTOR:
				return 3;
			case ItemType.CHEST_PROTECTOR:
				return 2;
			case ItemType.HEAD_PROTECTOR:
				return 1;
			case ItemType.LEG_PROTECTOR:
				return 4;
			case ItemType.TRINKET:
				return 5;
			case ItemType.WEAPON:
				return 0;
			}
			return -1;
		}

		public static string GetNavigatorObejctName(this ItemType itemType, AcE_WEAPON_TYPE weaponType)
		{
			switch (itemType)
			{
			case ItemType.ARM_PROTECTOR:
			case ItemType.CHEST_PROTECTOR:
			case ItemType.HEAD_PROTECTOR:
			case ItemType.LEG_PROTECTOR:
			case ItemType.TRINKET:
				return string.Format("Check_Armor_{0}", (int)itemType);
			case ItemType.HEALTH_FOOD:
			case ItemType.STAMINA_FOOD:
				return string.Format("Check_Food_{0}", (int)itemType);
			case ItemType.WEAPON:
				return string.Format("Check_Weapon_{0}", (int)weaponType);
			case ItemType.ENHANCEMENT:
			case ItemType.MATERIAL:
			case ItemType.SPECIAL:
				return string.Format("Check_Miscellany_{0}", (int)itemType);
			case ItemType.TRAP:
				return string.Format("Check_Weapon_{0}", 12);
			}
			return "";
		}

		public static int GetNavigatorCategoryIndex(this ItemType itemType)
		{
			switch (itemType)
			{
			case ItemType.ARM_PROTECTOR:
			case ItemType.CHEST_PROTECTOR:
			case ItemType.HEAD_PROTECTOR:
			case ItemType.LEG_PROTECTOR:
			case ItemType.TRINKET:
				return 1;
			case ItemType.HEALTH_FOOD:
			case ItemType.STAMINA_FOOD:
				return 2;
			case ItemType.WEAPON:
			case ItemType.TRAP:
				return 0;
			}
			return 3;
		}

		public static bool IsEquipable(this ItemType itemType)
		{
			return itemType - ItemType.ARM_PROTECTOR <= 4 || itemType == ItemType.WEAPON;
		}

		public static List<int> GetRecoveryDebuff(this ItemType type, ItemData itemData)
		{
			List<int> list = new List<int>();
			if (type == ItemType.HEALTH_FOOD)
			{
				list.Add(10008);
				return list;
			}
			if (type != ItemType.STAMINA_FOOD)
			{
				return null;
			}
			if (itemData.IsAlcoholItem())
			{
				list.Add(10010);
			}
			list.Add(10009);
			return list;
		}

		public static bool IsMatchingStartingSetType(this ItemType itemType, AcE_StartingSetType setType)
		{
			if (itemType - ItemType.ARM_PROTECTOR > 4)
			{
				return itemType == ItemType.WEAPON && setType == AcE_StartingSetType.WEAPON;
			}
			return setType == AcE_StartingSetType.ARMOR;
		}

		public static bool IsCheckItemPopupButton(this ItemType itemType)
		{
			return itemType == ItemType.SPECIAL || itemType == ItemType.MATERIAL;
		}
	}