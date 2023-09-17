using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Field;

public class FieldTypeData
{
    
	[JsonIgnore]
	public string Name
	{
		get
		{
			if (this.code != 0)
			{
				return LocalizationDB.Instance.FieldName(this.code);
			}
			return "";
		}
	}

	[JsonIgnore]
	public string NaviName
	{
		get
		{
			if (this.code != 0)
			{
				return LocalizationDB.Instance.NaviFieldName(this.code);
			}
			return "";
		}
	}
	

	[JsonIgnore]
	public string MapCode
	{
		get
		{
			FieldType fieldType = (FieldType)this.code;
			switch (fieldType)
			{
			case FieldType.HARBOR:
				goto IL_14D;
			case FieldType.FACTORY:
				goto IL_13B;
			case FieldType.SLUM:
				goto IL_17D;
			case FieldType.VILLAGE_HALL:
				goto IL_19B;
			case FieldType.FIRE_STATION:
				goto IL_141;
			case FieldType.POND:
				goto IL_16B;
			case FieldType.CHURCH:
				goto IL_12F;
			case FieldType.HOTEL:
				goto IL_159;
			case FieldType.ALLEY:
				break;
			case FieldType.SCHOOL:
				goto IL_177;
			case FieldType.LABORATORY:
				goto IL_15F;
			case FieldType.TUNNEL:
				goto IL_18F;
			case FieldType.UPTOWN:
				goto IL_195;
			case FieldType.ARCHER_CENTER:
				goto IL_123;
			case FieldType.TRAIL:
				goto IL_189;
			case FieldType.CEMETERY:
				goto IL_129;
			case FieldType.HOSPITAL:
				goto IL_153;
			case FieldType.FOREST:
				goto IL_147;
			case FieldType.CLEAN_WELL:
				goto IL_135;
			case FieldType.TEMPLE:
				goto IL_183;
			case FieldType.SANDY_BEACH:
				goto IL_171;
			case FieldType.LIGHTHOUSE:
				goto IL_165;
			case FieldType.POWCAMP:
				goto IL_1A1;
			case FieldType.RANDOM_LUMIA:
				return "SR2";
			default:
				switch (fieldType)
				{
				case FieldType.STATION:
					return "SS4";
				case FieldType.MILITARY_BASE:
					return "SM1";
				case FieldType.MOUNTAIN:
					return "SM2";
				case FieldType.ISLAND:
					return "SL1";
				case FieldType.BRIDGE:
					return "SB7";
				case FieldType.SEOUL_FOREST:
					return "SF1";
				case FieldType.LAKE:
					return "SL2";
				case FieldType.BOULEVARD:
					return "SA5";
				case FieldType.SPORTS_COMPLEX:
					return "SS3";
				case FieldType.AVENUE:
					return "SB9";
				case FieldType.CONVENTION_CENTER:
					return "SC8";
				case FieldType.POST_OFFICE:
					return "SP1";
				case (FieldType)113:
					break;
				case FieldType.RANDOM_SEOUL:
					return "SR3";
				default:
					switch (fieldType)
					{
					case FieldType.HARBOR_EXPEDITION:
						goto IL_14D;
					case FieldType.FACTORY_EXPEDITION:
						goto IL_13B;
					case FieldType.SLUM_EXPEDITION:
						goto IL_17D;
					case FieldType.VILLAGE_HALL_EXPEDITION:
						goto IL_19B;
					case FieldType.FIRE_STATION_EXPEDITION:
						goto IL_141;
					case FieldType.POND_EXPEDITION:
						goto IL_16B;
					case FieldType.CHURCH_EXPEDITION:
						goto IL_12F;
					case FieldType.HOTEL_EXPEDITION:
						goto IL_159;
					case FieldType.ALLEY_EXPEDITION:
						goto IL_11D;
					case FieldType.SCHOOL_EXPEDITION:
						goto IL_177;
					case FieldType.LABORATORY_EXPEDITION:
						goto IL_15F;
					case FieldType.TUNNEL_EXPEDITION:
						goto IL_18F;
					case FieldType.UPTOWN_EXPEDITION:
						goto IL_195;
					case FieldType.ARCHER_CENTER_EXPEDITION:
						goto IL_123;
					case FieldType.TRAIL_EXPEDITION:
						goto IL_189;
					case FieldType.CEMETERY_EXPEDITION:
						goto IL_129;
					case FieldType.HOSPITAL_EXPEDITION:
						goto IL_153;
					case FieldType.FOREST_EXPEDITION:
						goto IL_147;
					case FieldType.CLEAN_WELL_EXPEDITION:
						goto IL_135;
					case FieldType.TEMPLE_EXPEDITION:
						goto IL_183;
					case FieldType.SANDY_BEACH_EXPEDITION:
						goto IL_171;
					case FieldType.LIGHTHOUSE_EXPEDITION:
						goto IL_165;
					case FieldType.POWCAMP_EXPEDITION:
						goto IL_1A1;
					}
					break;
				}
				return "";
			}
			IL_11D:
			return "C1";
			IL_123:
			return "D1";
			IL_129:
			return "D5";
			IL_12F:
			return "B6";
			IL_135:
			return "E5";
			IL_13B:
			return "A3";
			IL_141:
			return "B3";
			IL_147:
			return "E3";
			IL_14D:
			return "A1";
			IL_153:
			return "E2";
			IL_159:
			return "B8";
			IL_15F:
			return "C4";
			IL_165:
			return "F8";
			IL_16B:
			return "B5";
			IL_171:
			return "F4";
			IL_177:
			return "C2";
			IL_17D:
			return "A4";
			IL_183:
			return "E7";
			IL_189:
			return "D3";
			IL_18F:
			return "C6";
			IL_195:
			return "C7";
			IL_19B:
			return "B2";
			IL_1A1:
			return "S1";
		}
	}

	public bool IsPowCamp
	{
		get
		{
			return this.code == 23;
		}
	}

	public bool IsHavingNight
	{
		get
		{
			return this.code != 23 && this.code != 11;
		}
	}

	public bool HaveMinimap
	{
		get
		{
			return this.code != 0 && this.code != 23;
		}
	}

	public bool EnableSwim
	{
		get
		{
			return this.fieldProperties != null && this.fieldProperties.Count > 0 && this.fieldProperties.Contains(FieldProperty.SWIM_ABLE);
		}
	}

	public bool EnableFishing
	{
		get
		{
			return this.fieldProperties != null && this.fieldProperties.Count > 0 && this.fieldProperties.Contains(FieldProperty.FISH_ABLE);
		}
	}

	/*public Dictionary<ItemData, int> getCanFoundItemList(int fieldType, Dictionary<ItemData, int> needItems)
	{
		Dictionary<ItemData, int> dictionary = new Dictionary<ItemData, int>();
		foreach (ItemData itemData in needItems.Keys)
		{
			if (this.fixedItems.ContainsKey(itemData.code))
			{
				int num = this.fixedItems[itemData.code];
				int num2 = needItems[itemData];
				if (num >= num2)
				{
					dictionary.Add(itemData, num2);
				}
				else
				{
					dictionary.Add(itemData, num);
				}
			}
		}
		return dictionary;
	}

	public Dictionary<ItemData, int> getValueFoundItemList(int fieldType, Dictionary<ItemData, int> needItems, Dictionary<ItemData, int> itemValues)
	{
		Dictionary<ItemData, int> dictionary = new Dictionary<ItemData, int>();
		foreach (ItemData itemData in needItems.Keys)
		{
			bool flag = true;
			if (Ingame.inst.game.GetMapType.Equals(MapType.SEOUL) && Ingame.inst.game.GetRestrictionFieldStep < 3 && (itemData.itemGrade == ItemGrade.EPIC || itemData.itemGrade == ItemGrade.LEGEND))
			{
				flag = false;
			}
			if (flag && this.fixedItems.ContainsKey(itemData.code))
			{
				int num = this.fixedItems[itemData.code];
				int num2 = itemValues[itemData];
				int num3 = needItems[itemData];
				int num4 = 0;
				if (num >= num3)
				{
					num4 += num3 * num2;
					num4 += (num - num3) * num2 / 3;
				}
				else
				{
					num4 += num * num2;
				}
				dictionary.Add(itemData, num4);
			}
		}
		return dictionary;
	}*/

	[JsonPropertyName("cod")]
	public int code { get; set; }

	[JsonPropertyName("mtp")]
	public MapType mapType { get; set; }

	[JsonPropertyName("fit")]
	public Dictionary<int, int> fixedItems { get; set; }

	[JsonPropertyName("nfd")]
	public List<int> nearField { get; set; }

	[JsonPropertyName("fpr")]
	public List<FieldProperty> fieldProperties { get; set; }

	[JsonPropertyName("cntx")]
	public float SkillPanelPositionX { get; set; }

	[JsonPropertyName("cnty")]
	public float SkillPanelPositionY { get; set; }
}