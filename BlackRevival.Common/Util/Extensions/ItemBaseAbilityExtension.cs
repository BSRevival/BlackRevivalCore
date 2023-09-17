using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB;

public static class ItemBaseAbilityExtension
{
	public static string GetPropertyName(this ItemBaseAbility itemBaseAbility)
	{
		return LocalizationDB.Instance.Dynamic(string.Format("item_option_{0}", (int)itemBaseAbility));
	}

	public static string StringFormat(this ItemBaseAbility itemBaseAbility, float param)
	{
		if (itemBaseAbility <= ItemBaseAbility.CRIT_RATE_ONHIT_GUN)
		{
			if (itemBaseAbility <= ItemBaseAbility.TRUE_DMG_RATE_ONHIT_GUN)
			{
				switch (itemBaseAbility)
				{
				case ItemBaseAbility.ITEM_AP_RATE:
				case ItemBaseAbility.ITEM_DP_RATE:
				case ItemBaseAbility.CHR_AP_RATE:
				case ItemBaseAbility.CHR_DP_RATE:
				case ItemBaseAbility.CHR_MAX_HP_RATE:
				case ItemBaseAbility.CHR_MAX_SP_RATE:
				case ItemBaseAbility.TOTAL_AP_RATE:
				case ItemBaseAbility.TOTAL_DP_RATE:
					break;
				case ItemBaseAbility.ITEM_DP:
				case ItemBaseAbility.CHR_AP:
				case ItemBaseAbility.CHR_DP:
				case ItemBaseAbility.CHR_MAX_HP:
				case ItemBaseAbility.CHR_MAX_SP:
					goto IL_128;
				default:
					if (itemBaseAbility - ItemBaseAbility.TRUE_DMG_TRAP_RATE > 10)
					{
						goto IL_128;
					}
					break;
				}
			}
			else if (itemBaseAbility - ItemBaseAbility.DMGED_RATE_BY_TRAP > 12 && itemBaseAbility - ItemBaseAbility.CRIT_DMG_RATE_ONHIT > 9 && itemBaseAbility - ItemBaseAbility.CRIT_RATE > 9)
			{
				goto IL_128;
			}
		}
		else if (itemBaseAbility <= ItemBaseAbility.ITEM_SPRCVRY_ON_MAX_SP)
		{
			if (itemBaseAbility - ItemBaseAbility.HITRATE > 9 && itemBaseAbility - ItemBaseAbility.ITEM_HPRCVRY_ON_MAX_HP > 1)
			{
				goto IL_128;
			}
		}
		else if (itemBaseAbility - ItemBaseAbility.CHANCE_TO_STEP_ON_TRAP > 7 && itemBaseAbility != ItemBaseAbility.MOVE_DELAY)
		{
			switch (itemBaseAbility)
			{
			case ItemBaseAbility.LIFE_STEAL_RATE_ONHIT:
			case ItemBaseAbility.WEAPON_FAILURE_RATE:
			case ItemBaseAbility.CHANCE_OF_INJURY:
			case ItemBaseAbility.NOISE_OCCURRENCE_RATE:
			case ItemBaseAbility.CHANCE_TO_HACK:
			case ItemBaseAbility.BONUS_MASTERY_RATE_MADE_WEAPON:
			case ItemBaseAbility.RELOAD_SPEED_RATE_ARROW:
			case ItemBaseAbility.RELOAD_SPEED_RATE_BULLET:
			case ItemBaseAbility.WEAPON_DAMAGED_RATE:
				break;
			case ItemBaseAbility.RECOVER_STAMINA_ONHIT:
			case ItemBaseAbility.BONUS_EXP_FOUND_ITEM:
			case ItemBaseAbility.BONUS_EXP_ONHIT:
			case ItemBaseAbility.BONUS_EXP_MADE_ITEM:
			case ItemBaseAbility.BONUS_EXP_MADE_WEAPON:
			case ItemBaseAbility.BONUS_EXP_FOUND_EXP:
			case ItemBaseAbility.BONUS_MASTERY_MADE_WEAPON:
				goto IL_128;
			default:
				goto IL_128;
			}
		}
		return string.Format("{0}%", param * 100f);
		IL_128:
		return param.ToString();
	}
}