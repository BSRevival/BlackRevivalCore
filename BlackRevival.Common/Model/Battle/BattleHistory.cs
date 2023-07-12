using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model
{
	public class BattleHistory
	{
		[JsonPropertyName("knn")]
		public string killerNickname;

		[JsonPropertyName("rcn")]
		public long retainedCharacterNum;

		[JsonPropertyName("skn")]
		public int characterSkinType;

		[JsonPropertyName("pkc")]
		public int playerKill;

		[JsonPropertyName("tdtc")]
		public float playerHitDamage;

		[JsonPropertyName("rak")]
		public int rank;

		[JsonPropertyName("pts")]
		public long playTimeSeconds;

		[JsonPropertyName("bdt")]
		[Newtonsoft.Json.JsonConverter(typeof(MicrosecondEpochConverter))]
		public DateTime battleDtm;

		[JsonPropertyName("cht")]
		public int chest;

		[JsonPropertyName("leg")]
		public int leg;

		[JsonPropertyName("hed")]
		public int head;

		[JsonPropertyName("wep")]
		public int weapon;

		[JsonPropertyName("trk")]
		public int trinket;

		[JsonPropertyName("arm")]
		public int arm;

		[JsonPropertyName("pla")]
		public int players;

		[JsonPropertyName("mkc")]
		public int monsterKill;

		[JsonPropertyName("tdtm")]
		public float monsterHitDamage;

		[JsonPropertyName("hea")]
		public float health;

		[JsonPropertyName("sta")]
		public float stamina;

		[JsonPropertyName("off")]
		public float offence;

		[JsonPropertyName("def")]
		public float defence;

		[JsonPropertyName("gfa")]
		public float gunFamiliarity;

		[JsonPropertyName("bfa")]
		public float bladeFamiliarity;

		[JsonPropertyName("tfa")]
		public float throwFamiliarity;

		[JsonPropertyName("pfa")]
		public float punchFamiliarity;

		[JsonPropertyName("wfa")]
		public float bowFamiliarity;

		[JsonPropertyName("lfa")]
		public float bluntFamiliarity;

		[JsonPropertyName("sfa")]
		public float stabFamiliarity;

		[JsonPropertyName("clv")]
		public int characterLevel;

		public int[] inventoryItems;

		[JsonPropertyName("gmd")]
		public int gameMode;

		[JsonPropertyName("psid")]
		public int potentialSkill;

		[JsonPropertyName("kut")]
		public UnitType killerUnitType;

		[JsonPropertyName("asc")]
		public int assistCount;

		[JsonPropertyName("ddc")]
		public int deadCount;

		[JsonPropertyName("rts")]
		public int redTeamScore;

		[JsonPropertyName("bts")]
		public int blueTeamScore;

		[JsonPropertyName("tnm")]
		public int teamNumber;

		[JsonPropertyName("mpk")]
		public int mainPerk;

		[JsonPropertyName("fpk")]
		public int firstPerk;

		[JsonPropertyName("spk")]
		public int secondPerk;

		[JsonPropertyName("upg")]
		public bool upgrade;

		[JsonPropertyName("ts")]
		public int tournamentStage;

		[Newtonsoft.Json.JsonIgnore]
		public bool isWin
		{
			get
			{
				return rank == 1;
			}
		}

		public bool IsTeamMode()
		{
			if (gameMode != 40)
			{
				return gameMode == 41;
			}
			return true;
		}

		public List<int> GetEquipmentList()
		{
			return new List<int> { weapon, head, arm, chest, leg, trinket };
		}

		//public PerkData GetPerkData()
		//{
		//	return GameDB.perk.GetPerkData(mainPerk);
		//}

		//public PerkData GetFirstAchievementPerkData()
		//{
		//	return GameDB.perk.GetPerkData(firstPerk);
		//}

		//public PerkData GetSecondAchievementPerkData()
		//{
		//	return GameDB.perk.GetPerkData(secondPerk);
		//}

		public void GetTopFamiliarity(out AcE_WEAPON_TYPE _Type, out float _Familiarity)
		{
			_Familiarity = 0f;
			_Type = AcE_WEAPON_TYPE.NONE;
			if (_Familiarity < gunFamiliarity)
			{
				_Type = AcE_WEAPON_TYPE.GUN;
				_Familiarity = gunFamiliarity;
			}
			if (_Familiarity < bladeFamiliarity)
			{
				_Type = AcE_WEAPON_TYPE.BLADE;
				_Familiarity = bladeFamiliarity;
			}
			if (_Familiarity < throwFamiliarity)
			{
				_Type = AcE_WEAPON_TYPE.THROW;
				_Familiarity = throwFamiliarity;
			}
			if (_Familiarity < punchFamiliarity)
			{
				_Type = AcE_WEAPON_TYPE.PUNCH;
				_Familiarity = punchFamiliarity;
			}
			if (_Familiarity < bowFamiliarity)
			{
				_Type = AcE_WEAPON_TYPE.BOW;
				_Familiarity = bowFamiliarity;
			}
			if (_Familiarity < bluntFamiliarity)
			{
				_Type = AcE_WEAPON_TYPE.BLUNT;
				_Familiarity = bluntFamiliarity;
			}
			if (_Familiarity < stabFamiliarity)
			{
				_Type = AcE_WEAPON_TYPE.STAB;
				_Familiarity = stabFamiliarity;
			}
		}
	}
}
