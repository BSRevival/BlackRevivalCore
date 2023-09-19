using BlackRevival.Common.GameDB.Battle;
using BlackRevival.Common.Model;
using Serilog;

namespace BlackRevival.Common.GameDB;

public class BattleDB
{
	public static BattleDB Instance { get; set; }
    public BattleDB()
	{
		this.battleData = new BattleData();
		Instance = this;
	}

	public BattleDB(BattleDB.Model model)
	{
		this.battleData = model.battleData;
		Instance = this;
	}

	public CharacterStanceData GetStanceData(int stanceType)
	{
		CharacterStanceData characterStanceData = this.battleData.stances.Find((CharacterStanceData x) => x.stanceType == stanceType);
		if (characterStanceData == null)
		{
			Log.Error($"[BattleDB.GetStanceData] Failed to find CharacterStanceData: {stanceType}");
			return new CharacterStanceData();
		}
		return characterStanceData;
	}

	public CharacterMasteryRankData GetMasteryRankData(int masteryId)
	{
		CharacterMasteryRankData characterMasteryRankData = this.battleData.masteryRanks.Find((CharacterMasteryRankData x) => x.masteryId == masteryId);
		if (characterMasteryRankData == null)
		{
			Log.Error($"[BattleDB.GetMasteryRankData] Fail to find CharactertMasteryRankData: {masteryId}");
			return new CharacterMasteryRankData();
		}
		return characterMasteryRankData;
	}

	public CharacterMasteryRankData GetMasteryRankDataByWeaponType(AcE_WEAPON_TYPE weaponType, VeteranGrade grade)
	{
		CharacterMasteryRankData characterMasteryRankData = this.battleData.masteryRanks.Find((CharacterMasteryRankData x) => x.weaponType == weaponType && x.grade == grade);
		if (characterMasteryRankData == null)
		{
			Log.Error($"[BattleDB.GetMasteryRankDataByWeaponType] Fail to find VeteranGrade: {(int)grade}");
			return new CharacterMasteryRankData();
		}
		return characterMasteryRankData;
	}

	public CharacterMasteryRankData GetMasteryRankDataByWeaponType(AcE_WEAPON_TYPE weaponType, float familiarity)
	{
		CharacterMasteryRankData characterMasteryRankData = null;
		foreach (CharacterMasteryRankData characterMasteryRankData2 in this.battleData.masteryRanks)
		{
			if (characterMasteryRankData2.weaponType == weaponType && characterMasteryRankData2.GetFamiliarityExp() <= familiarity)
			{
				characterMasteryRankData = characterMasteryRankData2;
			}
		}
		if (characterMasteryRankData == null)
		{
			Log.Error($"[BattleDB.GetMasteryRankDataByWeaponType] Fail to find familiarity: {weaponType}, {familiarity}");
			return new CharacterMasteryRankData();
		}
		return characterMasteryRankData;
	}

	public bool TryGetMasteryRankDataByWeaponType(AcE_WEAPON_TYPE weaponType, float familiarity, bool isTeam, out CharacterMasteryRankData rankData)
	{
		rankData = this.GetMasteryRankDataByWeaponType(weaponType, familiarity, isTeam);
		return rankData != null;
	}

	public CharacterMasteryRankData GetMasteryRankDataByWeaponType(AcE_WEAPON_TYPE weaponType, float familiarity, bool isTeam)
	{
		CharacterMasteryRankData characterMasteryRankData = null;
		foreach (CharacterMasteryRankData characterMasteryRankData2 in this.battleData.masteryRanks)
		{
			if (characterMasteryRankData2.weaponType == weaponType && characterMasteryRankData2.GetFamiliarityExp(isTeam) <= familiarity)
			{
				characterMasteryRankData = characterMasteryRankData2;
			}
		}
		if (characterMasteryRankData == null)
		{
			Log.Error($"[BattleDB.GetMasteryRankDataByWeaponType] Fail to find familiarity: {weaponType}, {familiarity}");
			return new CharacterMasteryRankData();
		}
		return characterMasteryRankData;
	}

	private BattleData battleData { get; set; } 

	public class Model
	{
		public BattleData battleData { get; set; }
	}
}