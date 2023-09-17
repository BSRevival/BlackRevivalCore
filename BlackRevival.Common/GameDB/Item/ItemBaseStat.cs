using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;

namespace BlackRevival.Common.GameDB.Item;

public class ItemBaseStat
{
    [JsonIgnore]
	public ItemOptionData optionData
	{
		get
		{
			return GameDB.ItemDB.Instance.FindOption(this.baseAbility);
		}
	}

	public ItemBaseStat(ItemBaseAbility baseAbility, float value)
	{
		this.baseAbility = baseAbility;
		this.value = value;
	}

	public ValueTuple<string, string> GetItemOptionLable()
	{
		string arg = string.Empty;
		if (this.value != 0f)
		{
			string text = this.optionData.itemBaseAbility.StringFormat(this.value);
			arg = ((this.value > 0f) ? string.Format("+{0}", text) : text);
		}
		ItemBaseAbility itemBaseAbility = this.baseAbility;
		if (itemBaseAbility == ItemBaseAbility.ITEM_AP_GROWING_BY_CHR_LV)
		{
			return new ValueTuple<string, string>(ItemBaseAbility.ITEM_AP.GetPropertyName(), string.Format("[{0}]{1} {2}[-]", this.optionData.GetColor(this.value), LocalizationDB.Instance.Dynamic("item_option_121_sub"), this.value));
		}
		return new ValueTuple<string, string>(this.optionData.GetPropertyName(), string.Format("[{0}]{1}[-]", this.optionData.GetColor(this.value), arg));
	}

	/*public int GetIngameTotalValue()
	{
		if (Ingame.inst == null || AcSingleton<AcGameManager>.Instance.p_modeStatus != AcE_GAME_MODE.PLAYING)
		{
			AcLogger.Debug("[ItemData.GetIngameTotalValue] Ingame is null or Not Playing Inagme");
			return 0;
		}
		ItemBaseAbility itemBaseAbility = this.baseAbility;
		if (itemBaseAbility == ItemBaseAbility.ITEM_AP_GROWING_BY_CHR_LV)
		{
			return (int)this.value * Ingame.inst.player.ability.level;
		}
		return (int)this.value;
	}*/

	public static bool CheckUseAbillity(ItemBaseAbility type)
	{
		if (type <= ItemBaseAbility.DMGED_RATE_BY_TRAP)
		{
			if (type <= ItemBaseAbility.TRUE_DMG_TRAP)
			{
				if (type == ItemBaseAbility.ITEM_AP || type == ItemBaseAbility.ITEM_DP)
				{
					return false;
				}
				if (type != ItemBaseAbility.TRUE_DMG_TRAP)
				{
					return true;
				}
			}
			else if (type != ItemBaseAbility.TRUE_DMG_TRAP_RATE && type != ItemBaseAbility.DMGED_BY_TRAP && type != ItemBaseAbility.DMGED_RATE_BY_TRAP)
			{
				return true;
			}
		}
		else if (type <= ItemBaseAbility.CHANCE_TO_FIND_KEYSLOT)
		{
			if (type - ItemBaseAbility.ITEM_HPRCVRY <= 1 || type - ItemBaseAbility.ITEM_HPRCVRY_ON_MAX_HP <= 1)
			{
				return false;
			}
			if (type - ItemBaseAbility.CHANCE_TO_STEP_ON_TRAP > 7)
			{
				return true;
			}
		}
		else if (type - ItemBaseAbility.SEARCH_COST > 6 && type - ItemBaseAbility.RECOVER_STAMINA_ONHIT > 13)
		{
			if (type - ItemBaseAbility.MATERIAL_COMMON > 4)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	[JsonPropertyName("bst")]
	public ItemBaseAbility baseAbility { get; set; }

	[JsonPropertyName("val")]
	public float value { get; set; }

	[JsonIgnore]
	private const string DEFAULT_LABLE_FORMAT = "[{0}]{1}[-]";
}