using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model
{
    public class Character
    {
		[JsonPropertyName("cnm")]
		public long characterNum;

		[JsonPropertyName("unm")]
		public long userNum;

		[JsonPropertyName("cls")]
		public int characterClass;

		[JsonPropertyName("crd")]
		public CharacterGrade characterGrade;

		[JsonPropertyName("ast")]
		public int activeCharacterSkinType;

		[JsonPropertyName("ehx")]
		public int enhanceExp;

		[JsonPropertyName("cpt")]
		public CharacterPurchaseType characterPurchaseType;

		[JsonPropertyName("unn")]
		public string userNickname;

		[JsonPropertyName("lwd")]
		public string userLastword;

		[JsonPropertyName("wwd")]
		public string userWatchword;

		[JsonPropertyName("ddm")]
		[Newtonsoft.Json.JsonConverter(typeof(MicrosecondEpochConverter))]
		public DateTime deadTime;

		[JsonPropertyName("ctt")]
		public CharacterStatus characterStatus;

		[JsonPropertyName("leg")]
		public League league;

		[JsonPropertyName("nrs")]
		public long toNormalRemainSeconds;

		[JsonPropertyName("rpc")]
		public int rankPlayCount;

		[JsonPropertyName("rwc")]
		public int rankWinCount;

		[JsonPropertyName("npc")]
		public int normalPlayCount;

		[JsonPropertyName("nwc")]
		public int normalWinCount;

		[JsonPropertyName("gbd")]
		public int leagueBorder;

		[JsonPropertyName("psi")]
		public int potentialSkillId;

		[JsonPropertyName("tnm")]
		public int teamNumber;

		[JsonPropertyName("l2d")]
		public bool activeLive2D;

		[JsonPropertyName("hst")]
		public bool host;

		[JsonPropertyName("rtc")]
		public int researcherTitleCode;

		[JsonPropertyName("mcc")]
		public int matchingCardCode;

		[Newtonsoft.Json.JsonIgnore]
		private Dictionary<AcE_WEAPON_TYPE, float> _defaultMasteryDic = new Dictionary<AcE_WEAPON_TYPE, float>();

		[Newtonsoft.Json.JsonIgnore]
		private float _defaultTopMastery;
	}
}
