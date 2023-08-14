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
		public long characterNum{ get; set; }

		[JsonPropertyName("unm")]
		public long userNum{ get; set; }

		[JsonPropertyName("cls")]
		public int characterClass{ get; set; }

		[JsonPropertyName("crd")]
		public CharacterGrade characterGrade{ get; set; }

		[JsonPropertyName("ast")]
		public int activeCharacterSkinType{ get; set; }

		[JsonPropertyName("ehx")]
		public int enhanceExp{ get; set; }

		[JsonPropertyName("cpt")]
		public CharacterPurchaseType characterPurchaseType{ get; set; }

		[JsonPropertyName("unn")]
		public string userNickname{ get; set; }

		[JsonPropertyName("lwd")]
		[JsonIgnore]
		public string userLastword{ get; set; }

		[JsonPropertyName("wwd")]
		[JsonIgnore]
		public string userWatchword{ get; set; }

		[JsonPropertyName("ddm")]
		[JsonIgnore]
		public long deadTime{ get; set; }

		[JsonPropertyName("ctt")]
		public CharacterStatus characterStatus{ get; set; }

		[JsonPropertyName("leg")]
		public League league{ get; set; }

		[JsonPropertyName("nrs")]
		public long toNormalRemainSeconds{ get; set; }

		[JsonPropertyName("rpc")]
		public int rankPlayCount{ get; set; }

		[JsonPropertyName("rwc")]
		public int rankWinCount{ get; set; }

		[JsonPropertyName("npc")]
		public int normalPlayCount{ get; set; }

		[JsonPropertyName("nwc")]
		public int normalWinCount{ get; set; }

		[JsonPropertyName("gbd")]
		public int leagueBorder{ get; set; }

		[JsonPropertyName("psi")]
		public int potentialSkillId{ get; set; }

		[JsonPropertyName("tnm")]
		public int teamNumber{ get; set; }

		[JsonPropertyName("l2d")]
		public bool activeLive2D{ get; set; }

		[JsonPropertyName("hst")]
		public bool host{ get; set; }

		[JsonPropertyName("rtc")]
		public int researcherTitleCode{ get; set; }

		[JsonPropertyName("mcc")]
		public int matchingCardCode{ get; set; }
		
		public int pmn { get; set; }
		public int pfr { get; set; }
		public int psd { get; set; }


		[JsonIgnore]
		private Dictionary<AcE_WEAPON_TYPE, float> _defaultMasteryDic = new Dictionary<AcE_WEAPON_TYPE, float>();

		[JsonIgnore]
		private float _defaultTopMastery;
	}
}
