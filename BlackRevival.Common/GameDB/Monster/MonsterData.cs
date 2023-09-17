using System.Text;
using System.Text.Json.Serialization;
using BlackRevival.Common.GameDB.Field;
using BlackRevival.Common.Model;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.GameDB.Monster;

public class MonsterData
{
	[JsonIgnore]
	public string monsterPlaceDesc
	{
		get
		{
			int count = this.appearFieldTypes.Count;
			if (count == 0)
			{
				return LocalizationDB.Instance.Dynamic("등장후 일정 시간마다 랜덤한 위치로 이동");
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				int num = this.appearFieldTypes[i];
				FieldTypeData fieldTypeData = GameDB.FieldTypeDB.Instance.Find(num);
				stringBuilder.Append(fieldTypeData.Name);
				if (i < count - 1)
				{
					stringBuilder.Append(", ");
				}
			}
			return stringBuilder.ToString();
		}
	}

	public string GetName()
	{
		return LocalizationDB.Instance.MonsterName(this.monsterClass);
	}

	public string GetDesc()
	{
		return LocalizationDB.Instance.Monster("Monster_Desc", this.monsterClass);
	}

	public string GetWatchword()
	{
		return LocalizationDB.Instance.MonsterWatchEvent(this.monsterClass);
	}

	public string GetWeaponName()
	{
		return LocalizationDB.Instance.MonsterWeaponName(this.monsterWeaponType);
	}
	

	public string GetRandomItemDesc()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (this.supplyBoxTypes == null || this.supplyBoxTypes.Count == 0)
		{
			return string.Empty;
		}
		foreach (SupplyBoxType supplyBoxType in this.supplyBoxTypes)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append(LocalizationDB.Instance.Dynamic("MonsterView/Item/" + supplyBoxType.ToString()));
		}
		return stringBuilder.ToString();
	}
	

	[JsonPropertyName("cod")]
	public int code { get; set; }

	[JsonPropertyName("mtp")]
	public MapType mapType { get; set; }

	[JsonPropertyName("msc")]
	public int monsterClass { get; set; }

	[JsonPropertyName("aft")]
	public List<int> appearFieldTypes { get; set; }

	[JsonPropertyName("fdi")]
	public List<int> fixedDropItem { get; set; }

	[JsonPropertyName("hlt")]
	public int health { get; set; }

	[JsonPropertyName("atk")]
	public int attack { get; set; }

	[JsonPropertyName("def")]
	public int defence { get; set; }

	[JsonPropertyName("exp")]
	public int expContribution { get; set; }

	[JsonPropertyName("iis")]
	public int initialIntervalSeconds { get; set; }

	[JsonPropertyName("ris")]
	public int regenIntervalSeconds { get; set; }

	[JsonPropertyName("mwt")]
	public MonsterWeaponType monsterWeaponType { get; set; }

	[JsonPropertyName("mmd")]
	public int defaultDamage { get; set; }

	[JsonPropertyName("sbt")]
	public List<SupplyBoxType> supplyBoxTypes { get; set; }
}