using BlackRevival.Common.GameDB;
using BlackRevival.Common.Model;

public static class StrategyTypeExtension
	{
		public static string GetSpriteName(this StrategyType strategyType)
		{
			switch (strategyType)
			{
			case StrategyType.NONE:
				return "Ingame_Navi_Recently_Icon_Defense";
			case StrategyType.BLADE:
			case StrategyType.BOW:
			case StrategyType.BLADE_STAB:
			case StrategyType.BLUNT:
			case StrategyType.GUN:
			case StrategyType.STAB:
			case StrategyType.PUNCH:
			case StrategyType.THROW:
				return "Ingame_Navi_Recently_Icon_Attack";
			case StrategyType.HACK:
				return "Ingame_Navi_Recently_Icon_Hacking";
			case StrategyType.TRAP:
				return "Ingame_Navi_Recently_Icon_Trap";
			case StrategyType.RANDOM:
				return "";
			default:
				return "";
			}
		}

		public static string GetName(this StrategyType strategyType)
		{
			switch (strategyType)
			{
			case StrategyType.NONE:
				return LocalizationDB.Instance.Dynamic("방어구");
			case StrategyType.BLADE:
				return LocalizationDB.Instance.Dynamic("베기");
			case StrategyType.BOW:
				return LocalizationDB.Instance.Dynamic("활");
			case StrategyType.BLADE_STAB:
				return LocalizationDB.Instance.Dynamic("베기/찌르기");
			case StrategyType.BLUNT:
				return LocalizationDB.Instance.Dynamic("둔기");
			case StrategyType.GUN:
				return LocalizationDB.Instance.Dynamic("총");
			case StrategyType.STAB:
				return LocalizationDB.Instance.Dynamic("찌르기");
			case StrategyType.PUNCH:
				return LocalizationDB.Instance.Dynamic("권법");
			case StrategyType.THROW:
				return LocalizationDB.Instance.Dynamic("던지기");
			case StrategyType.HACK:
				return LocalizationDB.Instance.Dynamic("해킹");
			case StrategyType.TRAP:
				return LocalizationDB.Instance.Dynamic("트랩");
			case StrategyType.RANDOM:
				return LocalizationDB.Instance.Dynamic("랜덤");
			default:
				return "";
			}
		}

		public static bool IsWeaponStrategy(this StrategyType strategyType)
		{
			return strategyType - StrategyType.BLADE <= 7;
		}

		public static bool CompareWithWeaponType(this StrategyType strategyType, AcE_WEAPON_TYPE weaponType)
		{
			switch (strategyType)
			{
			case StrategyType.BLADE:
				if (weaponType == AcE_WEAPON_TYPE.BLADE || weaponType == AcE_WEAPON_TYPE.BLADE_STAB)
				{
					return true;
				}
				return false;
			case StrategyType.BOW:
				if (weaponType == AcE_WEAPON_TYPE.BOW)
				{
					return true;
				}
				return false;
			case StrategyType.BLADE_STAB:
				if (weaponType == AcE_WEAPON_TYPE.BLADE || weaponType == AcE_WEAPON_TYPE.STAB)
				{
					return true;
				}
				return false;
			case StrategyType.BLUNT:
				if (weaponType == AcE_WEAPON_TYPE.BLUNT)
				{
					return true;
				}
				return false;
			case StrategyType.GUN:
				if (weaponType == AcE_WEAPON_TYPE.GUN)
				{
					return true;
				}
				return false;
			case StrategyType.STAB:
				if (weaponType == AcE_WEAPON_TYPE.STAB || weaponType == AcE_WEAPON_TYPE.BLADE_STAB)
				{
					return true;
				}
				return false;
			case StrategyType.PUNCH:
				if (weaponType == AcE_WEAPON_TYPE.PUNCH)
				{
					return true;
				}
				return false;
			case StrategyType.THROW:
				if (weaponType == AcE_WEAPON_TYPE.THROW)
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}