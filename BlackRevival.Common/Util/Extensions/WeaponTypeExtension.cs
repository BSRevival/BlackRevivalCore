using BlackRevival.Common.GameDB;
using BlackRevival.Common.Model;


public static class WeaponTypeExtension
	{
		public static string GetName(this AcE_WEAPON_TYPE weaponType)
		{
			switch (weaponType)
			{
			case AcE_WEAPON_TYPE.BLADE:
				return LocalizationDB.Instance.Dynamic("베기");
			case AcE_WEAPON_TYPE.BOW:
				return LocalizationDB.Instance.Dynamic("활");
			case AcE_WEAPON_TYPE.BLADE_STAB:
				return LocalizationDB.Instance.Dynamic("베기/찌르기");
			case AcE_WEAPON_TYPE.BLUNT:
				return LocalizationDB.Instance.Dynamic("둔기");
			case AcE_WEAPON_TYPE.GUN:
				return LocalizationDB.Instance.Dynamic("총");
			case AcE_WEAPON_TYPE.STAB:
				return LocalizationDB.Instance.Dynamic("찌르기");
			case AcE_WEAPON_TYPE.PUNCH:
				return LocalizationDB.Instance.Dynamic("권법");
			case AcE_WEAPON_TYPE.THROW:
				return LocalizationDB.Instance.Dynamic("던지기");
			default:
				return "";
			}
		}

		public static StrategyType GetStrategyType(this AcE_WEAPON_TYPE weaponType)
		{
			switch (weaponType)
			{
			case AcE_WEAPON_TYPE.BLADE:
				return StrategyType.BLADE;
			case AcE_WEAPON_TYPE.BOW:
				return StrategyType.BOW;
			case AcE_WEAPON_TYPE.BLADE_STAB:
				return StrategyType.BLADE_STAB;
			case AcE_WEAPON_TYPE.BLUNT:
				return StrategyType.BLUNT;
			case AcE_WEAPON_TYPE.GUN:
				return StrategyType.GUN;
			case AcE_WEAPON_TYPE.STAB:
				return StrategyType.STAB;
			case AcE_WEAPON_TYPE.PUNCH:
				return StrategyType.PUNCH;
			case AcE_WEAPON_TYPE.THROW:
				return StrategyType.THROW;
			default:
				return StrategyType.NONE;
			}
		}

		
		public static bool IsProjectileWeapon(this AcE_WEAPON_TYPE weaponType)
		{
			return weaponType == AcE_WEAPON_TYPE.BOW || weaponType == AcE_WEAPON_TYPE.GUN || weaponType == AcE_WEAPON_TYPE.THROW;
		}

		public static bool IsMeleeWeapon(this AcE_WEAPON_TYPE weaponType)
		{
			switch (weaponType)
			{
			case AcE_WEAPON_TYPE.BLADE:
			case AcE_WEAPON_TYPE.BLADE_STAB:
			case AcE_WEAPON_TYPE.BLUNT:
			case AcE_WEAPON_TYPE.STAB:
			case AcE_WEAPON_TYPE.PUNCH:
				return true;
			}
			return false;
		}

		public static bool IsRangedWeapon(this AcE_WEAPON_TYPE weaponType)
		{
			return weaponType == AcE_WEAPON_TYPE.BOW || weaponType == AcE_WEAPON_TYPE.GUN || weaponType == AcE_WEAPON_TYPE.THROW;
		}

		public static bool IsSameWeapon(this AcE_WEAPON_TYPE weaponType, AcE_WEAPON_TYPE type)
		{
			return weaponType == type;
		}

		public static bool IsContainsWeapon(this AcE_WEAPON_TYPE itemWeaponType, AcE_WEAPON_TYPE type)
		{
			if (itemWeaponType == AcE_WEAPON_TYPE.BLADE_STAB)
			{
				return type == AcE_WEAPON_TYPE.BLADE || type == AcE_WEAPON_TYPE.STAB;
			}
			return itemWeaponType == type;
		}

		public static AcE_WEAPON_TYPE GetSortingMastery(int index)
		{
			switch (index)
			{
			case 1:
				return AcE_WEAPON_TYPE.PUNCH;
			case 2:
				return AcE_WEAPON_TYPE.BLUNT;
			case 3:
				return AcE_WEAPON_TYPE.BLADE;
			case 4:
				return AcE_WEAPON_TYPE.STAB;
			case 5:
				return AcE_WEAPON_TYPE.THROW;
			case 6:
				return AcE_WEAPON_TYPE.GUN;
			case 7:
				return AcE_WEAPON_TYPE.BOW;
			default:
				return AcE_WEAPON_TYPE.NONE;
			}
		}

		public static int EquipmentOrder(this ItemType type)
		{
			switch (type)
			{
			case ItemType.ARM_PROTECTOR:
				return 4;
			case ItemType.CHEST_PROTECTOR:
				return 3;
			case ItemType.HEAD_PROTECTOR:
				return 2;
			case ItemType.LEG_PROTECTOR:
				return 5;
			case ItemType.TRINKET:
				return 6;
			case ItemType.WEAPON:
				return 1;
			}
			return 0;
		}

		public static int ItemTypeOrder(this ItemType type)
		{
			switch (type)
			{
			case ItemType.ARM_PROTECTOR:
				return 4;
			case ItemType.CHEST_PROTECTOR:
				return 3;
			case ItemType.HEAD_PROTECTOR:
				return 2;
			case ItemType.LEG_PROTECTOR:
				return 5;
			case ItemType.TRINKET:
				return 6;
			case ItemType.HEALTH_FOOD:
				return 7;
			case ItemType.STAMINA_FOOD:
				return 8;
			case ItemType.WEAPON:
				return 1;
			case ItemType.ENHANCEMENT:
				return 11;
			case ItemType.AMMO:
				return 9;
			case ItemType.TRAP:
				return 12;
			case ItemType.MATERIAL:
				return 10;
			}
			return 13;
		}

		public static int StartingSetCompareTo(this AcE_WEAPON_TYPE x, AcE_WEAPON_TYPE y)
		{
			return StartingSet.WEAPON_TYPE_SORT_ORDER.FindIndex((AcE_WEAPON_TYPE t) => t == x).CompareTo(StartingSet.WEAPON_TYPE_SORT_ORDER.FindIndex((AcE_WEAPON_TYPE t) => t == y));
		}
		
		public static class StartingSet
		{
			public static readonly List<AcE_WEAPON_TYPE> WEAPON_TYPE_SORT_ORDER = new List<AcE_WEAPON_TYPE>
			{
				AcE_WEAPON_TYPE.PUNCH,
				AcE_WEAPON_TYPE.BLUNT,
				AcE_WEAPON_TYPE.BLADE,
				AcE_WEAPON_TYPE.STAB,
				AcE_WEAPON_TYPE.GUN,
				AcE_WEAPON_TYPE.BOW,
				AcE_WEAPON_TYPE.THROW,
				AcE_WEAPON_TYPE.NONE
			};
		}
	}